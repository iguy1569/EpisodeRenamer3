using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpisodeRenamer3
{
    class EpisodeParser
    {
        public static ShowInformation GetEpisodeInfo(FileInfo file)
        {
            #region Patterns
            // s01e02, s1e2, s01.e02, s01_e02, 1x02
            string SeasonEpisode = string.Format("({0})", string.Join("|",
                @"s\d{1,2}[_.\s]?[xe]\d{1,3}",                          // s01e02, s1e2, s01.e02, s01_e02
                @"\d{1,2}[x]\d{1,3}",                                   // 01x02, 1x02, 1x2
                @"season[_.\s]?\d{1,2}[_.\s]?episode[_.\s]?\d{1,3}"     // season 1 episode 02,
            ));

            // ep02, ep_02, part.II, pt.II, pt_II
            string EpisodeOnly = string.Format("({0})", string.Join("|",
                @"[ex]\d{1,3}",
                @"ep\d{1,3}",
                @"episode[_.\s]?\d{1,3}",
                @"part[_.\s]?[\dvix]{1,2}",
                @"pt[_.\s]?[\dvix]{1,2}"  
            )); 
            #endregion

            Match mTemp = null;
            List<Match> lsTemp = null;
            ShowInformation sShowInfo = new ShowInformation(file);

            string showName = Regex.Replace(file.Name, @"(.[xh]264|720[ip]|1080[ip]|[(]\d{4,4}[)])", string.Empty, RegexOptions.IgnoreCase);

            #region Season / Episode
            if ((mTemp = Regex.Match(showName, SeasonEpisode, RegexOptions.IgnoreCase)).Success)
            {
                sShowInfo.ContentType = ShowInformation.MediaType.Series;
                sShowInfo.ShowName = Regex.Replace(showName.Substring(0, mTemp.Index), @"[^A-Z0-9,._'\s]", string.Empty, RegexOptions.IgnoreCase).Replace(@".", " ").Replace("_", " ").Trim();

                string sSeason = Regex.Replace(mTemp.Value, EpisodeOnly, string.Empty, RegexOptions.IgnoreCase);

                sShowInfo.SeasonNumber = int.Parse(Regex.Replace(sSeason, @"[^0-9]", string.Empty, RegexOptions.IgnoreCase));
                sShowInfo.ManualOverride = true;
                sShowInfo.SeasonNumber = int.Parse(Regex.Replace(sSeason, @"[^0-9]", string.Empty, RegexOptions.IgnoreCase));
                sShowInfo.ManualOverride = false;

                lsTemp = Regex.Matches(file.Name.Replace(mTemp.Value, string.Empty), EpisodeOnly, RegexOptions.IgnoreCase).Cast<Match>().ToList();
                lsTemp.Add(Regex.Match(mTemp.Value, EpisodeOnly, RegexOptions.IgnoreCase));

                sShowInfo.EpisodeNumber = GetEpisodeNumbers(lsTemp).Count > 0 ? GetEpisodeNumbers(lsTemp)[0] : -1;
                sShowInfo.ManualOverride = true;
                sShowInfo.EpisodeNumber = GetEpisodeNumbers(lsTemp).Count > 0 ? GetEpisodeNumbers(lsTemp)[0] : -1;
                sShowInfo.ManualOverride = false;
            }
            #endregion
            #region Episode Only
            else if ((lsTemp = Regex.Matches(showName, SeasonEpisode, RegexOptions.IgnoreCase).Cast<Match>().ToList()).Count > 0)
            {
                sShowInfo.ContentType = ShowInformation.MediaType.Series;
                sShowInfo.ShowName =
                    Regex.Replace(showName.Substring(0, mTemp.Index), @"[^A-Z0-9,._'\s]", string.Empty, RegexOptions.IgnoreCase).Replace(@".", " ").Replace("_", " ").Trim();

                sShowInfo.SeasonNumber = 0;
                sShowInfo.EpisodeNumber = GetEpisodeNumbers(lsTemp).Count > 0 ? GetEpisodeNumbers(lsTemp)[0] : -1;
                sShowInfo.ManualOverride = true;
                sShowInfo.SeasonNumber = 0;
                sShowInfo.EpisodeNumber = GetEpisodeNumbers(lsTemp).Count > 0 ? GetEpisodeNumbers(lsTemp)[0] : -1;
                sShowInfo.ManualOverride = false;
            }
            #endregion
            #region Indetermined
            else if ((mTemp = Regex.Match(showName, @"\d{2,4}", RegexOptions.IgnoreCase)).Success)
            {
                sShowInfo.ContentType = ShowInformation.MediaType.Indeterminate;
                int iSplit = mTemp.Value.Length > 3 ? 2 : 1;
                sShowInfo.ShowName =
                    Regex.Replace(showName.Substring(0, mTemp.Index), @"[^A-Z0-9,._'\s]", string.Empty, RegexOptions.IgnoreCase).Replace(@".", " ").Replace("_", " ").Trim();
                
                int iTemp;
                if (int.TryParse(mTemp.Value.Substring(0, iSplit), out iTemp))
                {
                    sShowInfo.SeasonNumber = iTemp;
                    sShowInfo.ManualOverride = true;
                    sShowInfo.SeasonNumber = iTemp;
                    sShowInfo.ManualOverride = false;
                }
                else
                {
                    sShowInfo.SeasonNumber = 0;
                    sShowInfo.ManualOverride = true;
                    sShowInfo.SeasonNumber = 0;
                    sShowInfo.ManualOverride = false;
                }

                sShowInfo.EpisodeNumber = (int.Parse(mTemp.Value.Substring(iSplit, mTemp.Value.Length - iSplit)));
                sShowInfo.ManualOverride = true;
                sShowInfo.EpisodeNumber = (int.Parse(mTemp.Value.Substring(iSplit, mTemp.Value.Length - iSplit)));
                sShowInfo.ManualOverride = false;
            }
            #endregion
            #region Not Season
            else
            {
                sShowInfo.ContentType = ShowInformation.MediaType.Standalone;
                sShowInfo.ShowName =
                    Regex.Replace(showName, @"[^A-Z0-9,._'\s]", string.Empty, RegexOptions.IgnoreCase).Replace(@".", " ").Replace("_", " ").Trim();

                sShowInfo.SeasonNumber = 0;
                sShowInfo.EpisodeNumber = 0;
                sShowInfo.ManualOverride = true;
                sShowInfo.SeasonNumber = 0;
                sShowInfo.EpisodeNumber = 0;
                sShowInfo.ManualOverride = false;
            }
            #endregion

            return sShowInfo;
        }

        private static List<int> GetEpisodeNumbers(List<Match> lsTemp)
        {
            List<int> EpisodeNumbers = new List<int>();
            foreach (Match m in lsTemp)
                EpisodeNumbers.Add(int.Parse(Regex.Replace(m.Value, "[^0-9]", "", RegexOptions.IgnoreCase)));
            EpisodeNumbers.Sort();

            return EpisodeNumbers; 
        }
    }
}
