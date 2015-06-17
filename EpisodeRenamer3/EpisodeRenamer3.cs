using EpisodeRenamer3.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVRageAPICommunicator;

namespace EpisodeRenamer3
{
    public partial class EpisodeRenamer3 : Form
    {
        private TVRageCommunicator _communicator;
        private SearchQueue _queue;
        private int _activeSearches = 0;
        private int _groupCount = 0;
        private int _sortColumn = -1;
        private int ActiveSearches
        {
            get
            {
                return _activeSearches;
            }

            set
            {
                _activeSearches = value < 0 ? 0 : value;
                LBL_Searches.Text = string.Format("Current Searches: {0}", _activeSearches);              
            }
        }
        private string GroupCount
        {
            get { return _groupCount.ToString(); }
        }
        private bool IsShowSelected
        {
            get
            {
                return LV_Content.SelectedItems != null && LV_Content.SelectedItems.Count > 0;
            }
        }

        public EpisodeRenamer3()
        {
            InitializeComponent();
            CB_IsSeries.Items.AddRange(Enum.GetNames(typeof(ShowInformation.MediaType)));
            _communicator = new TVRageCommunicator();
            _queue = new SearchQueue(8, this);

            TB_Formats.Text = Settings.Default.Formats;
        }

        #region Get Results Methods
        private void GetSearchResults(ShowInformation showInfo, SearchObject.delVoidObj callback)
        {
            var test =  _communicator.Searches;
            _queue.AddSearch(delegate() {
                ResultsShow temp;
                _communicator.GetSearchInformation(showInfo.ShowName, out temp);
                return temp;
            }, callback);
        }

        private void GetShowInformation(ShowInformation showInfo, SearchObject.delVoidObj callback)
        {
            _queue.AddSearch(delegate() {
                Show temp;
                _communicator.GetShowInformation(showInfo.ShowID, out temp);
                return temp;
            }, callback);
        }
        #endregion

        #region Panel Events Options
        #region Main View
        private void LV_Content_Resize(object sender, EventArgs e)
        {
            int totalWidth = LV_Content.Width - 185;
            columnHeader3.Width = 110;
            columnHeader4.Width = 70;

            columnHeader1.Width = (int)(totalWidth * 0.4);
            columnHeader2.Width = (int)(totalWidth * 0.6);
        }

        private void LV_Content_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _sortColumn)
                LV_Content.Sorting = LV_Content.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            _sortColumn = e.Column;

            LV_Content.ListViewItemSorter = new ListViewItemComparer(e.Column, LV_Content.Sorting);
        }

        private void LV_Content_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void LV_Content_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                AddMediaFiles(files);
            }
        }

        private void LV_Content_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                ShowInformation showInfo = LV_Content.SelectedItems[0].Tag as ShowInformation;
                LoadDefaults(showInfo);
                if (showInfo.ContentType == ShowInformation.MediaType.Series)
                {
                    ActiveSearches += 1;
                    GetSearchResults(showInfo, delegate(object obj) {
                        ActiveSearches -= 1;
                        if (obj is ResultsShow)
                        {
                            LoadSearches(showInfo);

                            ActiveSearches += 1;
                            GetShowInformation(showInfo, delegate(object obj2)
                            {
                                ActiveSearches -= 1;
                                if (obj2 is Show)
                                {
                                    Show show = obj2 as Show;
                                    LoadSeasons(show, showInfo);
                                    LoadEpisodes(show, showInfo);
                                }
                            });
                        }
                    });
                }
            }
        }
        #endregion

        #region Search Options
        private void CB_IsSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                ShowInformation showInfo = LV_Content.SelectedItems[0].Tag as ShowInformation;
                showInfo.ContentType = (ShowInformation.MediaType)Enum.Parse(typeof(ShowInformation.MediaType), CB_IsSeries.SelectedItem.ToString(), true);
                showInfo.UpdateListViewItem(LV_Content.SelectedItems[0]);
                LoadGroups(showInfo);
            }
        }   

        private void BTN_Search_Click(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                ShowInformation showInfo = LV_Content.SelectedItems[0].Tag as ShowInformation;
                showInfo.ShowName = TB_ShowName.Text;
                LoadGroups(showInfo);
                showInfo.UpdateListViewItem(LV_Content.SelectedItems[0]);
            }
        }

        private void CB_SearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                ShowInformation showInfo = LV_Content.SelectedItems[0].Tag as ShowInformation;
                ResultsShow search = (ResultsShow)CB_SearchOptions.SelectedItem;
                showInfo.ShowID = search.showid;
                LoadGroups(showInfo);

                ActiveSearches += 1;
                GetShowInformation(showInfo, delegate(object obj)
                {
                    ActiveSearches -= 1;
                    if (obj is Show)
                    {
                        Show show = (Show)obj;
                        LoadSeasons(show, showInfo);
                        LoadEpisodes(show, showInfo);
                        showInfo.UpdateListViewItem(LV_Content.SelectedItems[0]);
                    }
                });
            }
        }
        #endregion

        #region Automated Season / Episodes
        private void CB_Seasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                ShowInformation showInfo = LV_Content.SelectedItems[0].Tag as ShowInformation;

                if (!showInfo.ManualOverride)
                    showInfo.SeasonNumber = CB_Seasons.SelectedIndex;

                GetShowInformation(showInfo, delegate(object obj)
                {
                    ActiveSearches -= 1;
                    if (obj is Show)
                    {
                        Show show = (Show)obj;
                        LoadEpisodes(show, showInfo);
                        showInfo.UpdateListViewItem(LV_Content.SelectedItems[0]);
                    }
                });
            }
        }

        private void CB_Episodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                ShowInformation showInfo = LV_Content.SelectedItems[0].Tag as ShowInformation;
                if (!showInfo.ManualOverride)
                    showInfo.EpisodeNumber = CB_Episodes.SelectedIndex;

                ShowEpisodelistEpisode episode = (ShowEpisodelistEpisode) CB_Episodes.SelectedItem;
                showInfo.EpisodeName = episode.title;
                showInfo.UpdateListViewItem(LV_Content.SelectedItems[0]);
            }
        }
        #endregion

        #region Maunal Mode Options
        private void CB_ManualMode_CheckedChanged(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                ShowInformation showInfo = LV_Content.SelectedItems[0].Tag as ShowInformation;
                showInfo.ManualOverride = CB_ManualMode.Checked;
                LoadDefaults(showInfo);
                showInfo.UpdateListViewItem(LV_Content.SelectedItems[0]);
            }
        }

        private void NUD_ManualSeason_ValueChanged(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                ShowInformation showInfo = LV_Content.SelectedItems[0].Tag as ShowInformation;
                if (showInfo.ManualOverride)
                {
                    showInfo.SeasonNumber = (int)NUD_ManualSeason.Value;
                    showInfo.UpdateListViewItem(LV_Content.SelectedItems[0]);
                }
            }
        }

        private void NUD_ManualEpisode_ValueChanged(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                ShowInformation showInfo = LV_Content.SelectedItems[0].Tag as ShowInformation;
                if (showInfo.ManualOverride)
                {
                    showInfo.EpisodeNumber = (int)NUD_ManualEpisode.Value;
                    showInfo.UpdateListViewItem(LV_Content.SelectedItems[0]);
                }
            }
        }

        private void BTN_OutputOverride_Click(object sender, EventArgs e)
        {
            if (IsShowSelected)
            {
                LV_Content.SelectedItems[0].SubItems[1].Text = TB_OutputOverride.Text;
            }
        }
        #endregion

        #region Menu Events
        private void BTN_NewGroup_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LV_Content.CheckedItems)
            {
                ShowInformation showInfo = lvi.Tag as ShowInformation;
                showInfo.GroupID = GroupCount;
                showInfo.UpdateListViewItem(lvi);
            }
            _groupCount++;
        }

        private void BTN_RemoveGroup_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LV_Content.CheckedItems)
            {
                ShowInformation showInfo = lvi.Tag as ShowInformation;
                showInfo.GroupID = "";
                showInfo.UpdateListViewItem(lvi);
            }
        }

        private void BTN_AddMedia_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LV_Content.Items.Clear();
                AddMediaFiles(Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.AllDirectories));
            }
        }

        private void BTN_RemoveMedia_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LV_Content.CheckedItems)
                lvi.Remove();
        }

        private void BTN_RenameMedia_Click(object sender, EventArgs e)
        {
            for (int index = LV_Content.CheckedItems.Count - 1; index >= 0; index--)
            {
                ShowInformation showInfo = LV_Content.CheckedItems[index].Tag as ShowInformation;
                if (File.Exists(showInfo.OriginalFile.FullName))
                {
                    string newName = Path.Combine(showInfo.OriginalFile.DirectoryName,
                        Regex.Replace(showInfo.Output, "[<>:\"\\|?*]", "", RegexOptions.None).Replace("/", " to ") + showInfo.OriginalFile.Extension);
                    try
                    {
                        File.Move(showInfo.OriginalFile.FullName, newName);
                        LV_Content.CheckedItems[index].Remove();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void BTN_SetFormats_Click(object sender, EventArgs e)
        {
            string[] saFormats = TB_Formats.Text.Split('|');
            Settings.Default.Formats = string.Join("|",
                    saFormats.Where(extension => Regex.IsMatch(extension, "[*][.][a-z0-9]{2,4}$", RegexOptions.IgnoreCase))
                );
            Settings.Default.Save();

            TB_Formats.Text = Settings.Default.Formats;
        }
        #endregion
        #endregion

        #region Support Methods 
        private void LoadDefaults(ShowInformation showInfo)
        {
            CB_IsSeries.SelectedIndexChanged -= CB_IsSeries_SelectedIndexChanged;
            CB_ManualMode.CheckedChanged -= CB_ManualMode_CheckedChanged;
            NUD_ManualSeason.ValueChanged -= NUD_ManualSeason_ValueChanged;
            NUD_ManualEpisode.ValueChanged -= NUD_ManualEpisode_ValueChanged;

            CB_IsSeries.SelectedItem = Enum.GetName(typeof(ShowInformation.MediaType), showInfo.ContentType);
            TB_ShowName.Text = showInfo.ShowName;

            CB_ManualMode.Checked = showInfo.ManualOverride;
            NUD_ManualSeason.Value = showInfo.SeasonNumber;
            NUD_ManualEpisode.Value = showInfo.EpisodeNumber;

            TB_OutputOverride.Text = showInfo.Output;

            CB_IsSeries.SelectedIndexChanged += CB_IsSeries_SelectedIndexChanged;
            CB_ManualMode.CheckedChanged += CB_ManualMode_CheckedChanged;
            NUD_ManualSeason.ValueChanged += NUD_ManualSeason_ValueChanged;
            NUD_ManualEpisode.ValueChanged += NUD_ManualEpisode_ValueChanged;
        }

        private void LoadSearches(ShowInformation showInfo)
        {
            CB_SearchOptions.SelectedIndexChanged -= CB_SearchOptions_SelectedIndexChanged;

            CB_SearchOptions.Items.Clear();
            CB_SearchOptions.Items.AddRange(_communicator.Searches);

            if(_communicator.HasSearchResult(showInfo.ShowName))
            {
                ResultsShow temp;
                if(_communicator.GetSearchInformation(showInfo.ShowName, out temp))
                    CB_SearchOptions.SelectedItem = temp;
            }

            CB_SearchOptions.SelectedIndexChanged += CB_SearchOptions_SelectedIndexChanged;
        }

        private void LoadSeasons(Show show, ShowInformation showInfo)
        {
            CB_Seasons.SelectedIndexChanged -= CB_Seasons_SelectedIndexChanged;

            CB_Seasons.Items.Clear();
            CB_Seasons.Items.Add("No Season");

            for (int count = 1; count <= show.totalseasons; count++)
                CB_Seasons.Items.Add(string.Format("Season {0}", count.ToString().PadLeft(2, '0')));

            CB_Seasons.SelectedIndex = showInfo.SeasonNumber <= show.totalseasons ? showInfo.SeasonNumber : 0;

            CB_Seasons.SelectedIndexChanged += CB_Seasons_SelectedIndexChanged;
        }

        private void LoadEpisodes(Show show, ShowInformation showInfo)
        {
            CB_Episodes.SelectedIndexChanged -= CB_Episodes_SelectedIndexChanged;

            CB_Episodes.Items.Clear();
            CB_Episodes.Items.Add("No Episode");

            int season = showInfo.SeasonNumber - 1;
            if (season >-1 && season < show.Episodelist.Season.Length)
            {
                CB_Episodes.Items.AddRange(show.Episodelist.Season[season].episode);
                CB_Episodes.SelectedIndex = showInfo.EpisodeNumber <= show.Episodelist.Season[season].episode.Length ? showInfo.EpisodeNumber : 0;
            }
            else
                CB_Episodes.SelectedIndex = 0;

            CB_Episodes.SelectedIndexChanged += CB_Episodes_SelectedIndexChanged;
        }

        private void SetEpisodeName(ShowInformation showInfo, Show episode, ListViewItem lvi)
        {
            if (episode.Episodelist.Season.Length >= showInfo.SeasonNumber &&
                episode.Episodelist.Season[showInfo.SeasonNumber - 1].episode.Length >= showInfo.EpisodeNumber)
            {
                showInfo.EpisodeName = episode.Episodelist.Season[showInfo.SeasonNumber - 1].episode[showInfo.EpisodeNumber - 1].title;
            }
            showInfo.UpdateListViewItem(lvi);
        }

        private void LoadGroups(ShowInformation showInfo)
        {
            if (showInfo.GroupID != null && !showInfo.GroupID.Equals(""))
            {
                foreach (ListViewItem lvi in LV_Content.Items.Cast<ListViewItem>().Where(x => ((ShowInformation)x.Tag).GroupID.Equals(showInfo.GroupID)))
                {
                    ShowInformation showSibling = lvi.Tag as ShowInformation;

                    showSibling.ContentType = showInfo.ContentType;
                    showSibling.ShowName = showInfo.ShowName;
                    showSibling.ShowID = showInfo.ShowID;
                    showSibling.UpdateListViewItem(lvi);
                }
            }
        }

        private void AddMediaFiles(string[] files)
        {
            string pattern = "(" + Settings.Default.Formats.Replace("*", "") + ")";

            IEnumerable<ShowInformation> showInfo = files
                .Select<string, FileInfo>(x => new FileInfo(x))
                .Where(x => Regex.IsMatch(x.Extension, pattern, RegexOptions.IgnoreCase))
                .Select<FileInfo, ShowInformation>(x => EpisodeParser.GetEpisodeInfo(x));

            ShowInformation[] allSeries = showInfo.Where(x => x.ContentType == ShowInformation.MediaType.Series).ToArray();
            string[] distinctSeriesNames = allSeries.Select<ShowInformation, string>(x => x.ShowName).Distinct().ToArray();
            foreach (string showName in distinctSeriesNames)
            {
                foreach (ShowInformation selectShow in allSeries.Where(x => x.ShowName.Equals(showName)))
                {
                    ListViewItem lvi = selectShow.NewListViewItem();
                    LV_Content.Items.Add(lvi);
                    BuildSeriesListViewItem(selectShow, lvi);
                }
            }

            foreach (ShowInformation show in showInfo.Where(x =>
                x.ContentType == ShowInformation.MediaType.Indeterminate || x.ContentType == ShowInformation.MediaType.Standalone))
            {
                LV_Content.Items.AddRange(showInfo
                    .Select<ShowInformation, ListViewItem>(x => x.NewListViewItem())
                    .ToArray());
            }
        }

        private void BuildSeriesListViewItem(ShowInformation showInfo, ListViewItem lvi)
        {
            ActiveSearches += 1;
            GetSearchResults(showInfo, delegate(object searches)
            {
                ActiveSearches -= 1;
                if (searches is ResultsShow)
                {
                    showInfo.ShowID = ((ResultsShow)searches).showid;
                    #region Get Show Info
                    ActiveSearches += 1;
                    GetShowInformation(showInfo, delegate(object episodesInfo)
                    {
                        ActiveSearches -= 1;
                        if (episodesInfo is Show)
                        {
                            Show episode = (Show)episodesInfo;
                            SetEpisodeName(showInfo, episode, lvi);
                        }
                    });
                    #endregion
                }
                else
                    Console.WriteLine("Fucking " + showInfo.ShowName + " died.");
            });
        }
        #endregion
    }

    class ListViewItemComparer : IComparer
    {
        private int col;
        private int order;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            switch (order)
            {
                case SortOrder.Ascending:
                    this.order = 1;
                    break;
                case SortOrder.Descending:
                    this.order = -1;
                    break;
                default:
                    this.order = 0;
                    break;
            }
        }
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text) * order;
        }
    }
}
