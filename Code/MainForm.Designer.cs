namespace ModDownloader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem downloadSteamCMDToolStripMenuItem;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer = new SplitContainer();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            downloadSteamCMDToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            lstGames = new ListBox();
            label6 = new Label();
            txtNewGameId = new TextBox();
            label5 = new Label();
            txtNewGameName = new TextBox();
            btnAddGame = new Button();
            label4 = new Label();
            txtModIds = new TextBox();
            label3 = new Label();
            txtWorkshop = new TextBox();
            btnDownloadSteamCMD = new Button();
            txtSteamCMD = new TextBox();
            label2 = new Label();
            progressBar = new ProgressBar();
            lblLoading = new Label();
            btnStop = new Button();
            btnDownload = new Button();
            btnBrowseSteamCMD = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(784, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { downloadSteamCMDToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(0, 0);
            fileToolStripMenuItem.Text = "&File";
            fileToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            editToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            //
            // downloadSteamCMDToolStripMenuItem
            //
            downloadSteamCMDToolStripMenuItem.Name = "downloadSteamCMDToolStripMenuItem";
            downloadSteamCMDToolStripMenuItem.Size = new Size(180, 22);
            downloadSteamCMDToolStripMenuItem.Text = "Download SteamCMD";
            downloadSteamCMDToolStripMenuItem.Click += btnDownloadSteamCMD_Click;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.Location = new Point(0, 24);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            //splitContainer.Panel1.Controls.Add(btnDownloadSteamCMD);
            //splitContainer.Panel2.Controls.Add(label2);
            //splitContainer.Panel2.Controls.Add(txtSteamCMD);
            splitContainer.Panel1.Controls.Add(label1);
            splitContainer.Panel1.Controls.Add(lstGames);
            splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(label6);
            splitContainer.Panel2.Controls.Add(txtNewGameId);
            splitContainer.Panel2.Controls.Add(label5);
            splitContainer.Panel2.Controls.Add(txtNewGameName);
            splitContainer.Panel2.Controls.Add(btnAddGame);
            splitContainer.Panel2.Controls.Add(label4);
            splitContainer.Panel2.Controls.Add(txtModIds);
            splitContainer.Panel2.Controls.Add(label3);
            splitContainer.Panel2.Controls.Add(txtWorkshop);
            splitContainer.Panel2.Controls.Add(txtSteamCMD);
            splitContainer.Panel2.Controls.Add(label2);
            splitContainer.Panel2.Controls.Add(progressBar);
            splitContainer.Panel2.Controls.Add(lblLoading);
            splitContainer.Panel2.Controls.Add(btnStop);
            splitContainer.Panel2.Controls.Add(btnDownload);
            splitContainer.Panel2.Controls.Add(btnBrowseSteamCMD);
            splitContainer.Size = new Size(784, 461);
            splitContainer.SplitterDistance = 200;
            splitContainer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(13, 7);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 1;
            label1.Text = "Game Names:";
            // 
            // lstGames
            // 
            lstGames.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstGames.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lstGames.FormattingEnabled = true;
            lstGames.ItemHeight = 17;
            lstGames.Location = new Point(12, 32);
            lstGames.Name = "lstGames";
            lstGames.Size = new Size(176, 376);
            lstGames.TabIndex = 0;
            lstGames.SelectedIndexChanged += lstGames_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(13, 249);
            label6.Name = "label6";
            label6.Size = new Size(119, 21);
            label6.TabIndex = 15;
            label6.Text = "Enter Game ID:";
            // 
            // txtNewGameId
            // 
            txtNewGameId.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNewGameId.Location = new Point(13, 273);
            txtNewGameId.Name = "txtNewGameId";
            txtNewGameId.Size = new Size(546, 25);
            txtNewGameId.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(13, 193);
            label5.Name = "label5";
            label5.Size = new Size(147, 21);
            label5.TabIndex = 13;
            label5.Text = "Enter Game Name:";
            // 
            // txtNewGameName
            // 
            txtNewGameName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNewGameName.Location = new Point(13, 217);
            txtNewGameName.Name = "txtNewGameName";
            txtNewGameName.Size = new Size(546, 25);
            txtNewGameName.TabIndex = 12;
            // 
            // btnAddGame
            // 
            btnAddGame.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddGame.Location = new Point(13, 304);
            btnAddGame.Name = "btnAddGame";
            btnAddGame.Size = new Size(546, 30);
            btnAddGame.TabIndex = 11;
            btnAddGame.Text = "Add Game";
            btnAddGame.UseVisualStyleBackColor = true;
            btnAddGame.Click += btnAddGame_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(13, 143);
            label4.Name = "label4";
            label4.Size = new Size(195, 21);
            label4.TabIndex = 10;
            label4.Text = "Mod IDs (comma separated):";
            // 
            // txtModIds
            // 
            txtModIds.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtModIds.Location = new Point(13, 167);
            txtModIds.Name = "txtModIds";
            txtModIds.Size = new Size(546, 25);
            txtModIds.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(13, 82);
            label3.Name = "label3";
            label3.Size = new Size(174, 21);
            label3.TabIndex = 8;
            label3.Text = "Workshop Content Folder:";
            // 
            // txtWorkshop
            // 
            txtWorkshop.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtWorkshop.Location = new Point(13, 109);
            txtWorkshop.Name = "txtWorkshop";
            txtWorkshop.ReadOnly = true;
            txtWorkshop.Size = new Size(546, 25);
            txtWorkshop.TabIndex = 7;
            // 
            // btnDownloadSteamCMD
            // 
            //btnDownloadSteamCMD.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            //btnDownloadSteamCMD.Location = new Point(0, 0);
            //btnDownloadSteamCMD.Name = "btnDownloadSteamCMD";
            //btnDownloadSteamCMD.Size = new Size(120, 25);
            //btnDownloadSteamCMD.TabIndex = 7;
            //btnDownloadSteamCMD.Text = "Download SteamCMD";
            //btnDownloadSteamCMD.UseVisualStyleBackColor = true;
            //btnDownloadSteamCMD.Click += btnDownloadSteamCMD_Click;
            // 
            // txtSteamCMD
            // 
            txtSteamCMD.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSteamCMD.Location = new Point(13, 32);
            txtSteamCMD.Name = "txtSteamCMD";
            txtSteamCMD.ReadOnly = true;
            txtSteamCMD.Size = new Size(516, 25);
            txtSteamCMD.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(13, 7);
            label2.Name = "label2";
            label2.Size = new Size(144, 21);
            label2.TabIndex = 4;
            label2.Text = "SteamCMD Directory:";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(13, 391);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(546, 23);
            progressBar.TabIndex = 3;
            // 
            // lblLoading
            // 
            lblLoading.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoading.Location = new Point(13, 424);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(126, 21);
            lblLoading.TabIndex = 2;
            lblLoading.Text = "⌛ Downloading...";
            lblLoading.Visible = false;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStop.Enabled = false;
            btnStop.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnStop.Location = new Point(459, 352);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 30);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnDownload
            // 
            btnDownload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDownload.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDownload.Location = new Point(353, 352);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(100, 30);
            btnDownload.TabIndex = 0;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // btnBrowseSteamCMD
            // 
            btnBrowseSteamCMD.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnBrowseSteamCMD.Location = new Point(529, 31);
            btnBrowseSteamCMD.Name = "btnBrowseSteamCMD";
            btnBrowseSteamCMD.Size = new Size(30, 27);
            btnBrowseSteamCMD.TabIndex = 6;
            btnBrowseSteamCMD.Text = "📁";
            btnBrowseSteamCMD.TextAlign = ContentAlignment.MiddleCenter;
            btnBrowseSteamCMD.UseVisualStyleBackColor = true;
            btnBrowseSteamCMD.Click += btnBrowseSteamCMD_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(splitContainer);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(800, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mod Downloader";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer;
        private Label label1;
        private ListBox lstGames;
        private Label label6;
        private TextBox txtNewGameId;
        private Label label5;
        private TextBox txtNewGameName;
        private Button btnAddGame;
        private Label label4;
        private TextBox txtModIds;
        private Label label3;
        private TextBox txtWorkshop;
        private Button btnDownloadSteamCMD;
        private TextBox txtSteamCMD;
        private Label label2;
        private ProgressBar progressBar;
        private Label lblLoading;
        private Button btnStop;
        private Button btnDownload;
        private Button btnBrowseSteamCMD;
    }
} 