
namespace FileDupeChecker.UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRemoveDupes = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.checkBoxSubDirectories = new System.Windows.Forms.CheckBox();
            this.textBoxWildCard = new System.Windows.Forms.TextBox();
            this.labelWildcard = new System.Windows.Forms.Label();
            this.buttonPath = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewDuplicates = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanelPreview = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerPathHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRemoveDupes);
            this.panel1.Controls.Add(this.buttonCheck);
            this.panel1.Controls.Add(this.checkBoxSubDirectories);
            this.panel1.Controls.Add(this.textBoxWildCard);
            this.panel1.Controls.Add(this.labelWildcard);
            this.panel1.Controls.Add(this.buttonPath);
            this.panel1.Controls.Add(this.textBoxPath);
            this.panel1.Controls.Add(this.labelPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 66);
            this.panel1.TabIndex = 0;
            // 
            // buttonRemoveDupes
            // 
            this.buttonRemoveDupes.Location = new System.Drawing.Point(508, 5);
            this.buttonRemoveDupes.Name = "buttonRemoveDupes";
            this.buttonRemoveDupes.Size = new System.Drawing.Size(75, 53);
            this.buttonRemoveDupes.TabIndex = 7;
            this.buttonRemoveDupes.Text = "Remove Dupes";
            this.toolTip1.SetToolTip(this.buttonRemoveDupes, "Remove the selected dupes");
            this.buttonRemoveDupes.UseVisualStyleBackColor = true;
            this.buttonRemoveDupes.Click += new System.EventHandler(this.ButtonRemoveDupesClick);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(427, 33);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 6;
            this.buttonCheck.Text = "&Check";
            this.toolTip1.SetToolTip(this.buttonCheck, "Check for dupes");
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.ButtonCheckClick);
            // 
            // checkBoxSubDirectories
            // 
            this.checkBoxSubDirectories.AutoSize = true;
            this.checkBoxSubDirectories.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSubDirectories.Checked = true;
            this.checkBoxSubDirectories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSubDirectories.Location = new System.Drawing.Point(290, 37);
            this.checkBoxSubDirectories.Name = "checkBoxSubDirectories";
            this.checkBoxSubDirectories.Size = new System.Drawing.Size(131, 17);
            this.checkBoxSubDirectories.TabIndex = 5;
            this.checkBoxSubDirectories.Text = "Search subdirectories:";
            this.checkBoxSubDirectories.UseVisualStyleBackColor = true;
            // 
            // textBoxWildCard
            // 
            this.textBoxWildCard.Location = new System.Drawing.Point(79, 35);
            this.textBoxWildCard.Name = "textBoxWildCard";
            this.textBoxWildCard.Size = new System.Drawing.Size(205, 20);
            this.textBoxWildCard.TabIndex = 4;
            this.textBoxWildCard.Text = "*.*";
            this.toolTip1.SetToolTip(this.textBoxWildCard, "Separate WildCards with ;");
            // 
            // labelWildcard
            // 
            this.labelWildcard.AutoSize = true;
            this.labelWildcard.Location = new System.Drawing.Point(3, 38);
            this.labelWildcard.Name = "labelWildcard";
            this.labelWildcard.Size = new System.Drawing.Size(63, 13);
            this.labelWildcard.TabIndex = 3;
            this.labelWildcard.Text = "Wildcard(s):";
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(427, 6);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(75, 23);
            this.buttonPath.TabIndex = 2;
            this.buttonPath.Text = "&Browse";
            this.toolTip1.SetToolTip(this.buttonPath, "Browse directory");
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.ButtonPathClick);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(79, 6);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(342, 20);
            this.textBoxPath.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxPath, "The directory to search for dupes");
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(3, 9);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 13);
            this.labelPath.TabIndex = 0;
            this.labelPath.Text = "Path:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 66);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(591, 309);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 1;
            // 
            // listViewFiles
            // 
            this.listViewFiles.CheckBoxes = true;
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.GridLines = true;
            this.listViewFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(232, 309);
            this.listViewFiles.TabIndex = 0;
            this.toolTip1.SetToolTip(this.listViewFiles, "List of files that contain duplicates");
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "FileName";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Directory";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Dupes";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewDuplicates);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanelPreview);
            this.splitContainer2.Size = new System.Drawing.Size(355, 309);
            this.splitContainer2.SplitterDistance = 153;
            this.splitContainer2.TabIndex = 1;
            // 
            // listViewDuplicates
            // 
            this.listViewDuplicates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewDuplicates.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewDuplicates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDuplicates.FullRowSelect = true;
            this.listViewDuplicates.GridLines = true;
            this.listViewDuplicates.HideSelection = false;
            this.listViewDuplicates.Location = new System.Drawing.Point(0, 0);
            this.listViewDuplicates.Name = "listViewDuplicates";
            this.listViewDuplicates.Size = new System.Drawing.Size(355, 153);
            this.listViewDuplicates.TabIndex = 0;
            this.toolTip1.SetToolTip(this.listViewDuplicates, "List of Duplicates");
            this.listViewDuplicates.UseCompatibleStateImageBehavior = false;
            this.listViewDuplicates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "FileName";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Directory";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Size";
            // 
            // tableLayoutPanelPreview
            // 
            this.tableLayoutPanelPreview.AutoScroll = true;
            this.tableLayoutPanelPreview.ColumnCount = 5;
            this.tableLayoutPanelPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPreview.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPreview.Name = "tableLayoutPanelPreview";
            this.tableLayoutPanelPreview.RowCount = 1;
            this.tableLayoutPanelPreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPreview.Size = new System.Drawing.Size(355, 152);
            this.tableLayoutPanelPreview.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tableLayoutPanelPreview, "Images");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelStatus);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 375);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 40);
            this.panel2.TabIndex = 1;
            // 
            // labelStatus
            // 
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatus.Location = new System.Drawing.Point(0, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(591, 21);
            this.labelStatus.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 21);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(591, 19);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.explorerPathHereToolStripMenuItem,
            this.openFileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 92);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItemClick);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            this.selectNoneToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.selectNoneToolStripMenuItem.Text = "Select &None";
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.SelectNoneToolStripMenuItemClick);
            // 
            // explorerPathHereToolStripMenuItem
            // 
            this.explorerPathHereToolStripMenuItem.Name = "explorerPathHereToolStripMenuItem";
            this.explorerPathHereToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.explorerPathHereToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.explorerPathHereToolStripMenuItem.Text = "&Explorer Path Here";
            this.explorerPathHereToolStripMenuItem.Click += new System.EventHandler(this.ExplorerPathHereToolStripMenuItemClick);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.openFileToolStripMenuItem.Text = "&Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 415);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(607, 454);
            this.Name = "MainForm";
            this.Text = "File Dupe Checker";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ListView listViewDuplicates;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.CheckBox checkBoxSubDirectories;
        private System.Windows.Forms.TextBox textBoxWildCard;
        private System.Windows.Forms.Label labelWildcard;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonRemoveDupes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPreview;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerPathHereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
    }
}

