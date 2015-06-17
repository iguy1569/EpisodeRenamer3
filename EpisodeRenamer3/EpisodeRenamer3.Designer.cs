namespace EpisodeRenamer3
{
    partial class EpisodeRenamer3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EpisodeRenamer3));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LV_Content = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BTN_OutputOverride = new System.Windows.Forms.Button();
            this.TB_OutputOverride = new System.Windows.Forms.TextBox();
            this.NUD_ManualEpisode = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.NUD_ManualSeason = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_ManualMode = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_SearchOptions = new System.Windows.Forms.ComboBox();
            this.BTN_Search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_ShowName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Episodes = new System.Windows.Forms.ComboBox();
            this.CB_Seasons = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_IsSeries = new System.Windows.Forms.ComboBox();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.BTN_NewGroup = new System.Windows.Forms.ToolStripButton();
            this.BTN_RemoveGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTN_AddMedia = new System.Windows.Forms.ToolStripButton();
            this.BTN_RemoveMedia = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTN_RenameMedia = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.LBL_Searches = new System.Windows.Forms.ToolStripLabel();
            this.TB_Formats = new System.Windows.Forms.ToolStripTextBox();
            this.BTN_SetFromats = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ManualEpisode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ManualSeason)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.LV_Content);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(834, 437);
            this.splitContainer1.SplitterDistance = 573;
            this.splitContainer1.TabIndex = 0;
            // 
            // LV_Content
            // 
            this.LV_Content.AllowDrop = true;
            this.LV_Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LV_Content.CheckBoxes = true;
            this.LV_Content.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.LV_Content.GridLines = true;
            this.LV_Content.Location = new System.Drawing.Point(3, 28);
            this.LV_Content.Name = "LV_Content";
            this.LV_Content.Size = new System.Drawing.Size(567, 406);
            this.LV_Content.TabIndex = 1;
            this.LV_Content.UseCompatibleStateImageBehavior = false;
            this.LV_Content.View = System.Windows.Forms.View.Details;
            this.LV_Content.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LV_Content_ColumnClick);
            this.LV_Content.SelectedIndexChanged += new System.EventHandler(this.LV_Content_SelectedIndexChanged);
            this.LV_Content.DragDrop += new System.Windows.Forms.DragEventHandler(this.LV_Content_DragDrop);
            this.LV_Content.DragEnter += new System.Windows.Forms.DragEventHandler(this.LV_Content_DragEnter);
            this.LV_Content.Resize += new System.EventHandler(this.LV_Content_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Original File Name";
            this.columnHeader1.Width = 215;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "New File Name";
            this.columnHeader2.Width = 228;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Is Series";
            this.columnHeader3.Width = 67;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Groups";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(3, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 406);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show Properties";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.BTN_OutputOverride);
            this.groupBox5.Controls.Add(this.TB_OutputOverride);
            this.groupBox5.Controls.Add(this.NUD_ManualEpisode);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.NUD_ManualSeason);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.CB_ManualMode);
            this.groupBox5.Location = new System.Drawing.Point(6, 274);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 124);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Manual Settings";
            // 
            // BTN_OutputOverride
            // 
            this.BTN_OutputOverride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_OutputOverride.Location = new System.Drawing.Point(6, 95);
            this.BTN_OutputOverride.Name = "BTN_OutputOverride";
            this.BTN_OutputOverride.Size = new System.Drawing.Size(224, 23);
            this.BTN_OutputOverride.TabIndex = 8;
            this.BTN_OutputOverride.Text = "Name Override";
            this.BTN_OutputOverride.UseVisualStyleBackColor = true;
            this.BTN_OutputOverride.Click += new System.EventHandler(this.BTN_OutputOverride_Click);
            // 
            // TB_OutputOverride
            // 
            this.TB_OutputOverride.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_OutputOverride.Location = new System.Drawing.Point(6, 69);
            this.TB_OutputOverride.Name = "TB_OutputOverride";
            this.TB_OutputOverride.Size = new System.Drawing.Size(224, 20);
            this.TB_OutputOverride.TabIndex = 7;
            // 
            // NUD_ManualEpisode
            // 
            this.NUD_ManualEpisode.Location = new System.Drawing.Point(182, 43);
            this.NUD_ManualEpisode.Name = "NUD_ManualEpisode";
            this.NUD_ManualEpisode.Size = new System.Drawing.Size(54, 20);
            this.NUD_ManualEpisode.TabIndex = 6;
            this.NUD_ManualEpisode.ValueChanged += new System.EventHandler(this.NUD_ManualEpisode_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Episode";
            // 
            // NUD_ManualSeason
            // 
            this.NUD_ManualSeason.Location = new System.Drawing.Point(57, 43);
            this.NUD_ManualSeason.Name = "NUD_ManualSeason";
            this.NUD_ManualSeason.Size = new System.Drawing.Size(54, 20);
            this.NUD_ManualSeason.TabIndex = 1;
            this.NUD_ManualSeason.ValueChanged += new System.EventHandler(this.NUD_ManualSeason_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Season";
            // 
            // CB_ManualMode
            // 
            this.CB_ManualMode.AutoSize = true;
            this.CB_ManualMode.Location = new System.Drawing.Point(9, 20);
            this.CB_ManualMode.Name = "CB_ManualMode";
            this.CB_ManualMode.Size = new System.Drawing.Size(140, 17);
            this.CB_ManualMode.TabIndex = 0;
            this.CB_ManualMode.Text = "Enable Manual Override";
            this.CB_ManualMode.UseVisualStyleBackColor = true;
            this.CB_ManualMode.CheckedChanged += new System.EventHandler(this.CB_ManualMode_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.CB_SearchOptions);
            this.groupBox4.Controls.Add(this.BTN_Search);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.TB_ShowName);
            this.groupBox4.Location = new System.Drawing.Point(6, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(239, 106);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Use Search";
            // 
            // CB_SearchOptions
            // 
            this.CB_SearchOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_SearchOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SearchOptions.FormattingEnabled = true;
            this.CB_SearchOptions.Location = new System.Drawing.Point(77, 75);
            this.CB_SearchOptions.Name = "CB_SearchOptions";
            this.CB_SearchOptions.Size = new System.Drawing.Size(153, 21);
            this.CB_SearchOptions.TabIndex = 3;
            this.CB_SearchOptions.SelectedIndexChanged += new System.EventHandler(this.CB_SearchOptions_SelectedIndexChanged);
            // 
            // BTN_Search
            // 
            this.BTN_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Search.Location = new System.Drawing.Point(9, 45);
            this.BTN_Search.Name = "BTN_Search";
            this.BTN_Search.Size = new System.Drawing.Size(221, 23);
            this.BTN_Search.TabIndex = 2;
            this.BTN_Search.Text = "Set Show Name";
            this.BTN_Search.UseVisualStyleBackColor = true;
            this.BTN_Search.Click += new System.EventHandler(this.BTN_Search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Show Name";
            // 
            // TB_ShowName
            // 
            this.TB_ShowName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_ShowName.Location = new System.Drawing.Point(77, 19);
            this.TB_ShowName.Name = "TB_ShowName";
            this.TB_ShowName.Size = new System.Drawing.Size(153, 20);
            this.TB_ShowName.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.CB_Episodes);
            this.groupBox3.Controls.Add(this.CB_Seasons);
            this.groupBox3.Location = new System.Drawing.Point(6, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 75);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Automated Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Episode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Season";
            // 
            // CB_Episodes
            // 
            this.CB_Episodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Episodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Episodes.FormattingEnabled = true;
            this.CB_Episodes.Location = new System.Drawing.Point(55, 46);
            this.CB_Episodes.Name = "CB_Episodes";
            this.CB_Episodes.Size = new System.Drawing.Size(175, 21);
            this.CB_Episodes.TabIndex = 1;
            this.CB_Episodes.SelectedIndexChanged += new System.EventHandler(this.CB_Episodes_SelectedIndexChanged);
            // 
            // CB_Seasons
            // 
            this.CB_Seasons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Seasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Seasons.FormattingEnabled = true;
            this.CB_Seasons.Location = new System.Drawing.Point(55, 19);
            this.CB_Seasons.Name = "CB_Seasons";
            this.CB_Seasons.Size = new System.Drawing.Size(175, 21);
            this.CB_Seasons.TabIndex = 0;
            this.CB_Seasons.SelectedIndexChanged += new System.EventHandler(this.CB_Seasons_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CB_IsSeries);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Is Series";
            // 
            // CB_IsSeries
            // 
            this.CB_IsSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_IsSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_IsSeries.FormattingEnabled = true;
            this.CB_IsSeries.Location = new System.Drawing.Point(6, 17);
            this.CB_IsSeries.Name = "CB_IsSeries";
            this.CB_IsSeries.Size = new System.Drawing.Size(224, 21);
            this.CB_IsSeries.TabIndex = 0;
            this.CB_IsSeries.SelectedIndexChanged += new System.EventHandler(this.CB_IsSeries_SelectedIndexChanged);
            // 
            // ToolStrip
            // 
            this.ToolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTN_NewGroup,
            this.BTN_RemoveGroup,
            this.toolStripSeparator1,
            this.BTN_AddMedia,
            this.BTN_RemoveMedia,
            this.toolStripSeparator2,
            this.BTN_RenameMedia,
            this.toolStripSeparator3,
            this.LBL_Searches,
            this.TB_Formats,
            this.BTN_SetFromats,
            this.toolStripSeparator4});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(834, 25);
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // BTN_NewGroup
            // 
            this.BTN_NewGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTN_NewGroup.Image = ((System.Drawing.Image)(resources.GetObject("BTN_NewGroup.Image")));
            this.BTN_NewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_NewGroup.Name = "BTN_NewGroup";
            this.BTN_NewGroup.Size = new System.Drawing.Size(71, 22);
            this.BTN_NewGroup.Text = "New Group";
            this.BTN_NewGroup.Click += new System.EventHandler(this.BTN_NewGroup_Click);
            // 
            // BTN_RemoveGroup
            // 
            this.BTN_RemoveGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTN_RemoveGroup.Image = ((System.Drawing.Image)(resources.GetObject("BTN_RemoveGroup.Image")));
            this.BTN_RemoveGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_RemoveGroup.Name = "BTN_RemoveGroup";
            this.BTN_RemoveGroup.Size = new System.Drawing.Size(90, 22);
            this.BTN_RemoveGroup.Text = "Remove Group";
            this.BTN_RemoveGroup.Click += new System.EventHandler(this.BTN_RemoveGroup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BTN_AddMedia
            // 
            this.BTN_AddMedia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTN_AddMedia.Image = ((System.Drawing.Image)(resources.GetObject("BTN_AddMedia.Image")));
            this.BTN_AddMedia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_AddMedia.Name = "BTN_AddMedia";
            this.BTN_AddMedia.Size = new System.Drawing.Size(69, 22);
            this.BTN_AddMedia.Text = "Add Media";
            this.BTN_AddMedia.Click += new System.EventHandler(this.BTN_AddMedia_Click);
            // 
            // BTN_RemoveMedia
            // 
            this.BTN_RemoveMedia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTN_RemoveMedia.Image = ((System.Drawing.Image)(resources.GetObject("BTN_RemoveMedia.Image")));
            this.BTN_RemoveMedia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_RemoveMedia.Name = "BTN_RemoveMedia";
            this.BTN_RemoveMedia.Size = new System.Drawing.Size(90, 22);
            this.BTN_RemoveMedia.Text = "Remove Media";
            this.BTN_RemoveMedia.Click += new System.EventHandler(this.BTN_RemoveMedia_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BTN_RenameMedia
            // 
            this.BTN_RenameMedia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTN_RenameMedia.Image = ((System.Drawing.Image)(resources.GetObject("BTN_RenameMedia.Image")));
            this.BTN_RenameMedia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_RenameMedia.Name = "BTN_RenameMedia";
            this.BTN_RenameMedia.Size = new System.Drawing.Size(90, 22);
            this.BTN_RenameMedia.Text = "Rename Media";
            this.BTN_RenameMedia.Click += new System.EventHandler(this.BTN_RenameMedia_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // LBL_Searches
            // 
            this.LBL_Searches.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LBL_Searches.Name = "LBL_Searches";
            this.LBL_Searches.Size = new System.Drawing.Size(108, 22);
            this.LBL_Searches.Text = "Current Searches: 0";
            // 
            // TB_Formats
            // 
            this.TB_Formats.Name = "TB_Formats";
            this.TB_Formats.Size = new System.Drawing.Size(200, 25);
            // 
            // BTN_SetFromats
            // 
            this.BTN_SetFromats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTN_SetFromats.Image = ((System.Drawing.Image)(resources.GetObject("BTN_SetFromats.Image")));
            this.BTN_SetFromats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_SetFromats.Name = "BTN_SetFromats";
            this.BTN_SetFromats.Size = new System.Drawing.Size(27, 22);
            this.BTN_SetFromats.Text = "Set";
            this.BTN_SetFromats.Click += new System.EventHandler(this.BTN_SetFormats_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // EpisodeRenamer3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 437);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 475);
            this.Name = "EpisodeRenamer3";
            this.Text = "Episode Renamer ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ManualEpisode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ManualSeason)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton BTN_NewGroup;
        private System.Windows.Forms.ToolStripButton BTN_RemoveGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTN_AddMedia;
        private System.Windows.Forms.ToolStripButton BTN_RemoveMedia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTN_RenameMedia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel LBL_Searches;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripTextBox TB_Formats;
        private System.Windows.Forms.ToolStripButton BTN_SetFromats;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ListView LV_Content;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_IsSeries;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Episodes;
        private System.Windows.Forms.ComboBox CB_Seasons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_SearchOptions;
        private System.Windows.Forms.Button BTN_Search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_ShowName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BTN_OutputOverride;
        private System.Windows.Forms.TextBox TB_OutputOverride;
        private System.Windows.Forms.NumericUpDown NUD_ManualEpisode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NUD_ManualSeason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CB_ManualMode;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

