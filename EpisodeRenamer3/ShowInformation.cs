using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpisodeRenamer3
{
    class ShowInformation
    {
        private ShowSpecifics _autoEpisodeInfo;
        private ShowSpecifics _manualEpisodeInfo;
        private string _showName;

        private ShowSpecifics AutoEpisodeInfo
        {
            get
            {
                if (_autoEpisodeInfo == null)
                    _autoEpisodeInfo = new ShowSpecifics();
                return _autoEpisodeInfo;
            }
            set { _autoEpisodeInfo = value; }
        }
        private ShowSpecifics ManualEpisodeInfo
        {
            get
            {
                if (_manualEpisodeInfo == null)
                    _manualEpisodeInfo = new ShowSpecifics();
                return _manualEpisodeInfo;
            }
            set { _autoEpisodeInfo = value; }
        }

        public class ShowSpecifics
        {
            public string EpisodeName { get; set; }
            public int EpisodeNumber { get; set; }
            public int SeasonNumber { get; set; }
        }
        public enum MediaType
        {
            Series,
            Standalone,
            Indeterminate
        }

        public bool ManualOverride { get; set; }
        public int ShowID { get; set; }
        public string GroupID { get; set; }
        public FileInfo OriginalFile { get; set; }
        public MediaType ContentType { get; set; }

        public string ShowName
        {
            get { return _showName; }
            set { _showName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        }
        public int SeasonNumber
        {
            get
            {
                if (ManualOverride)
                    return ManualEpisodeInfo.SeasonNumber;
                else
                    return AutoEpisodeInfo.SeasonNumber;
            }
            set
            {
                if (ManualOverride)
                    ManualEpisodeInfo.SeasonNumber = value;
                else
                    AutoEpisodeInfo.SeasonNumber = value;
            }
        }
        public int EpisodeNumber
        {
            get
            {
                if (ManualOverride)
                    return ManualEpisodeInfo.EpisodeNumber;
                else
                    return AutoEpisodeInfo.EpisodeNumber;
            }
            set
            {
                if (ManualOverride)
                    ManualEpisodeInfo.EpisodeNumber = value;
                else
                    AutoEpisodeInfo.EpisodeNumber = value;
            }
        }
        public string EpisodeName
        {
            get
            {
                if (ManualOverride)
                    return ManualEpisodeInfo.EpisodeName;
                else
                    return AutoEpisodeInfo.EpisodeName;
            }
            set
            {
                if (ManualOverride)
                    ManualEpisodeInfo.EpisodeName = value;
                else
                    AutoEpisodeInfo.EpisodeName = value;
            }
        }

        public string Output 
        {
           get 
           {
               StringBuilder sbTemp = new StringBuilder(ShowName);
               if (ContentType == MediaType.Series)
               {
                   if (ManualOverride)
                   {
                       ManualEpisodeInfo.EpisodeName = ManualEpisodeInfo.EpisodeName == null || ManualEpisodeInfo.EpisodeName.Equals("") ?
                           AutoEpisodeInfo.EpisodeName : ManualEpisodeInfo.EpisodeName;

                       sbTemp.AppendFormat(
                           " S{0}E{1} {2} {3}",
                           ManualEpisodeInfo.SeasonNumber.ToString().PadLeft(2, '0'),
                           ManualEpisodeInfo.EpisodeNumber.ToString().PadLeft(2, '0'),
                           ManualEpisodeInfo.EpisodeName == null || ManualEpisodeInfo.EpisodeName.Equals("") ? "" : "-",
                           ManualEpisodeInfo.EpisodeName.Equals("") ? AutoEpisodeInfo.EpisodeName : ManualEpisodeInfo.EpisodeName
                       );
                   }
                   else
                   {
                       sbTemp.AppendFormat(
                           " S{0}E{1} {2} {3}",
                           AutoEpisodeInfo.SeasonNumber.ToString().PadLeft(2, '0'),
                           AutoEpisodeInfo.EpisodeNumber.ToString().PadLeft(2, '0'),
                           AutoEpisodeInfo.EpisodeName == null || AutoEpisodeInfo.EpisodeName.Equals("") ? "" : "-",
                           AutoEpisodeInfo.EpisodeName
                       );
                   }
               }

               return sbTemp.ToString();
           }
        }

        public ShowInformation(FileInfo file)
        {
            OriginalFile = file;
        }

        public ListViewItem NewListViewItem()
        {
            ListViewItem lvi = new ListViewItem(OriginalFile.Name);
            lvi.SubItems.Add(Output);
            lvi.SubItems.Add(Enum.GetName(typeof(MediaType), ContentType));
            lvi.SubItems.Add(GroupID);
            lvi.Tag = this;
            return lvi;
        }

        public void UpdateListViewItem(ListViewItem lvi)
        {
            UpdateListViewItem(lvi, Output);
        }

        public void UpdateListViewItem(ListViewItem lvi, string manualShowName)
        {
            lvi.SubItems[1].Text = manualShowName;
            lvi.SubItems[2].Text = Enum.GetName(typeof(MediaType), ContentType);
            lvi.SubItems[3].Text = GroupID;
        }
    }
}
