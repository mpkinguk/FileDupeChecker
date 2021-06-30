using FileDupeChecker.Model;
using System;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDupeChecker.UI
{
    public partial class MainForm : Form
    {
        private FileDupeChecker _fileDupeChecker;

        private int _fileCount;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            listViewFiles.SelectedIndexChanged += ListViewFilesSelectedIndexChanged;
        }



        #region Form events

        /// <summary>
        /// ListViewFiles Selected index changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewFilesSelectedIndexChanged(object sender, EventArgs e)
        {
            GetDupes();
        }

        /// <summary>
        /// Path button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPathClick(object sender, EventArgs e)
        {
            textBoxPath.Text = Browse();
        }

        /// <summary>
        /// Check button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonCheckClick(object sender, EventArgs e)
        {
            var cancel = buttonCheck.Text == "&Cancel";

            EnableControls(false);

            await Check(cancel).ConfigureAwait(false);

            EnableControls(true);
        }

        /// <summary>
        /// RemoveDupes button clickwed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonRemoveDupesClick(object sender, EventArgs e)
        {
            await RemoveDupes().ConfigureAwait(false);
        }

        /// <summary>
        /// Files have been retrieved
        /// </summary>
        private void FileDupeCheckerFilesRetrieved(int value)
        {
            _fileCount = value;
            UpdateProgressBarValue(0);
            UpdateProgressBarMax(_fileCount);
            UpdateStatus($"{_fileCount} files found");
        }

        /// <summary>
        /// The number of files processed has changed
        /// </summary>
        /// <param name="value"></param>
        private void FileDupeCheckerProcessChanged(int value)
        {
            UpdateProgressBarValue(value);
            UpdateStatus($"Processing {value} of {_fileCount}");
        }

        /// <summary>
        /// Select all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllToolStripMenuItemClick(object sender, EventArgs e)
        {
            SelectAll(true);
        }

        /// <summary>
        /// Select none of the items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectNoneToolStripMenuItemClick(object sender, EventArgs e)
        {
            SelectAll(false);
        }

        /// <summary>
        /// Open the selected path in explorer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExplorerPathHereToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenPath(sender);
        }

        /// <summary>
        /// Open the selected file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenFile(sender);
        }



        #endregion Form events



        /// <summary>
        /// Check for duplicates
        /// </summary>
        /// <param name="cancel">Cancel the search?</param>
        /// <returns>Task</returns>
        private async Task Check(bool cancel = false)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxPath.Text))
                {
                    return;
                }

                if (!Directory.Exists(textBoxPath.Text))
                {
                    UpdateStatus("Invalid Path");
                    return;
                }

                if (!cancel)
                {
                    _fileDupeChecker = new FileDupeChecker(textBoxPath.Text, textBoxWildCard.Text, checkBoxSubDirectories.Checked);

                    UpdateStatus("Retrieving files");

                    _fileDupeChecker.ProcessChanged += FileDupeCheckerProcessChanged;
                    _fileDupeChecker.FilesRetrieved += FileDupeCheckerFilesRetrieved;

                    await _fileDupeChecker.GetDupes().ConfigureAwait(false);

                    if (_fileDupeChecker.DupeFiles.Count == 0)
                    {
                        UpdateStatus("No dupes found");
                        return;
                    }

                    ClearListViewFiles();

                    foreach (var dupeFile in _fileDupeChecker.DupeFiles)
                    {
                        var listViewItem = new ListViewItem(dupeFile.FileName) { Tag = dupeFile };

                        listViewItem.SubItems.Add(dupeFile.FilePath);
                        listViewItem.SubItems.Add(GetRightFileSize(dupeFile));
                        listViewItem.SubItems.Add(dupeFile.DupeMatches.Count.ToString());

                        AddFileItem(listViewItem);
                    }

                    var tDupe = new DupeFile() { FileSize = _fileDupeChecker.DupeFiles.Sum(x => x.DupeMatches.Sum(y => y.FileSize)) };

                    var totalSize = GetRightFileSize(tDupe);

                    UpdateStatus($"Complete - Total Dupes File size {totalSize}");

                    return;
                }

                UpdateStatus("Cancelling...");

                await _fileDupeChecker.GetDupes(cancel).ConfigureAwait(false);

                UpdateStatus("Check cancelled");
            }
            catch (Exception exc)
            {
                UpdateStatus(exc.Message);
            }
        }

        /// <summary>
        /// Return correct file size string
        /// </summary>
        /// <param name="dupeFile">The dupe file object</param>
        /// <returns>string</returns>
        private string GetRightFileSize(DupeFile dupeFile)
        {
            string result;

            if (dupeFile.FileSizeGB < 1)
            {
                if (dupeFile.FileSizeMB < 1)
                {
                    if (dupeFile.FileSizeKB < 1)
                    {
                        result = $"{dupeFile.FileSize} B";
                    }
                    else
                    {
                        result = $"{dupeFile.FileSizeKB} KB";
                    }
                }
                else
                {
                    result = $"{dupeFile.FileSizeMB} MB";
                }
            }
            else
            {
                result = $"{dupeFile.FileSizeGB} GB";
            }

            return result;
        }

        /// <summary>
        /// Retrieve the dupes for a given file
        /// </summary>
        private void GetDupes()
        {
            try
            {
                if (listViewFiles.SelectedItems.Count == 0)
                {
                    return;
                }

                listViewDuplicates.Items.Clear();

                foreach (var control in tableLayoutPanelPreview.Controls)
                {
                    if (control.GetType() == typeof(PictureBox))
                    {
                        var pictureBox = (PictureBox)control;

                        pictureBox.Image.Dispose();
                    }
                }

                tableLayoutPanelPreview.Controls.Clear();

                var item = (DupeFile)listViewFiles.SelectedItems[0].Tag;

                foreach (var dupeFile in item.DupeMatches)
                {
                    var listViewItem = new ListViewItem(dupeFile.FileName) { Tag = dupeFile };

                    listViewItem.SubItems.Add(dupeFile.FilePath);
                    listViewItem.SubItems.Add(GetRightFileSize(dupeFile));

                    AddDupeItem(listViewItem);
                }

                UpdateStatus($"Dupes retrieved for {item.FileName}");
            }
            catch (Exception exc)
            {
                UpdateStatus(exc.Message);
            }
        }

        /// <summary>
        /// Remove dupes based on what is checked in the list
        /// </summary>
        private async Task RemoveDupes()
        {
            try
            {
                if (listViewFiles.CheckedItems.Count == 0)
                {
                    return;
                }

                var message = $"You are about to delete duplicates for {listViewFiles.CheckedItems.Count} file{(listViewFiles.CheckedItems.Count != 1 ? "s" : "")}. Proceed?";

                if (MessageBox.Show(this, message, "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                bool partial = false;

                await Task.Run(() =>
                {
                    foreach (ListViewItem item in listViewFiles.CheckedItems)
                    {
                        var dupeFile = (DupeFile)item.Tag;

                        var counter = 0;

                        foreach (var file in dupeFile.DupeMatches)
                        {
                            try
                            {
                                UpdateStatus($"Deleting {file.FileName} - ({counter + 1} of {dupeFile.DupeMatches.Count})");
                                System.IO.File.Delete(file.FullFilePath);
                                UpdateStatus($"File {file.FileName} deleted");
                                counter++;
                            }
                            catch
                            {
                                UpdateStatus($"Could not delete duplicate file {file.FileName}");
                            }

                            if (counter == dupeFile.DupeMatches.Count)
                            {
                                UpdateStatus($"All Duplicate files deleted successfully for {file.FileName}");
                            }
                            else
                            {
                                UpdateStatus($"Could not delete all Duplicate files for {file.FileName}");
                                partial = true;
                            }
                        }
                    }
                }).ConfigureAwait(false);

                UpdateStatus($"Removal of dupes complete. {(partial ? "Some files could not be removed" : "")}");
            }
            catch (Exception exc)
            {
                UpdateStatus(exc.Message);
            }
        }

        /// <summary>
        /// Browse for the initial path
        /// </summary>
        private string Browse()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
                else
                {
                    return string.Empty;
                }
            }
        }



        #region Threadsafe calls

        /// <summary>
        /// Threadsafe method for clearing listViewFiles
        /// </summary>
        private void ClearListViewFiles()
        {
            if (listViewFiles.InvokeRequired || listViewDuplicates.InvokeRequired)
            {
                var d = new Action(ClearListViewFiles);
                Invoke(d);
            }
            else
            {
                listViewFiles.Items.Clear();
            }
        }

        /// <summary>
        /// Threadsafe method for adding items to listViewFiles
        /// </summary>
        /// <param name="listViewItem"></param>
        private void AddFileItem(ListViewItem listViewItem)
        {
            if (listViewFiles.InvokeRequired || listViewDuplicates.InvokeRequired)
            {
                var d = new Action<ListViewItem>(AddFileItem);
                Invoke(d, new object[] { listViewItem });
            }
            else
            {
                listViewFiles.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// Threadsafe method for adding items to listViewFiles
        /// </summary>
        /// <param name="listViewItem"></param>
        private void UpdateStatus(string value)
        {
            if (labelStatus.InvokeRequired)
            {
                var d = new Action<string>(UpdateStatus);
                Invoke(d, new object[] { value });
            }
            else
            {
                labelStatus.Text = value;
            }
        }

        /// <summary>
        /// Threadsafe method for adding items to listViewDuplicates
        /// </summary>
        /// <param name="listViewItem"></param>
        private void AddDupeItem(ListViewItem listViewItem)
        {
            if (listViewFiles.InvokeRequired || tableLayoutPanelPreview.InvokeRequired)
            {
                var d = new Action<ListViewItem>(AddFileItem);
                Invoke(d, new object[] { listViewItem });
            }
            else
            {
                listViewDuplicates.Items.Add(listViewItem);

                var dupeFile = (DupeFile)listViewItem.Tag;

                var controlCount = tableLayoutPanelPreview.Controls.Count;

                if (MimeTypeHelper.getMimeFromFile(dupeFile.FullFilePath).StartsWith("image"))
                {
                    var pictureBox = new PictureBox() { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom };

                    pictureBox.Load(dupeFile.FullFilePath);

                    pictureBox.Name = $"Dupe{controlCount + 1}";

                    toolTip1.SetToolTip(pictureBox, dupeFile.FullFilePath);

                    tableLayoutPanelPreview.Controls.Add(pictureBox);
                }
            }
        }

        /// <summary>
        /// Threadsafe method for updating the progressbar
        /// </summary>
        /// <param name="listViewItem"></param>
        private void UpdateProgressBarValue(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                var d = new Action<int>(UpdateProgressBarValue);
                Invoke(d, new object[] { value });
            }
            else
            {
                if (value <= progressBar1.Maximum)
                {
                    progressBar1.Value = value;
                }
                else
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
            }
        }

        /// <summary>
        /// Threadsafe method for updating the progressbar
        /// </summary>
        /// <param name="listViewItem"></param>
        private void UpdateProgressBarMax(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                var d = new Action<int>(UpdateProgressBarMax);
                Invoke(d, new object[] { value });
            }
            else
            {
                if (value >= progressBar1.Value)
                {
                    progressBar1.Maximum = value;
                }
                else
                {
                    progressBar1.Value = 0;
                    progressBar1.Maximum = value;
                    progressBar1.Value = value;
                }
            }
        }

        /// <summary>
        /// Enable or disable controls
        /// </summary>
        /// <param name="enabled">Enable?</param>
        private void EnableControls(bool enabled)
        {
            if (textBoxPath.InvokeRequired
                || textBoxWildCard.InvokeRequired
                || checkBoxSubDirectories.InvokeRequired
                || buttonPath.InvokeRequired
                || buttonRemoveDupes.InvokeRequired
                || buttonCheck.InvokeRequired)
            {
                var d = new Action<bool>(EnableControls);
                Invoke(d, new object[] { enabled });
            }
            else
            {
                //UpdateCheckButtonText();
                buttonCheck.Text = buttonCheck.Text == "&Check" ? "&Cancel" : "&Check";
                textBoxPath.Enabled = enabled;
                textBoxWildCard.Enabled = enabled;
                checkBoxSubDirectories.Enabled = enabled;
                buttonPath.Enabled = enabled;
                buttonRemoveDupes.Enabled = enabled;
            }
        }

        private void SelectAll(bool selected)
        {
            if (listViewFiles.InvokeRequired)
            {
                var d = new Action<bool>(SelectAll);
                Invoke(d, new object[] { selected });
            }
            else
            {
                foreach (ListViewItem item in listViewFiles.Items)
                {
                    item.Selected = selected;
                }
            }
        }

        /// <summary>
        /// Open the select path in Explorer
        /// </summary>
        private void OpenPath(object sender)
        {
            if (listViewFiles.InvokeRequired || listViewDuplicates.InvokeRequired)
            {
                var d = new Action<object>(OpenPath);
                Invoke(d, new object[] {sender});
            }
            else
            {
                ListView listView = (ListView)sender;

                ListViewItem item = listView.SelectedItems[0];

                var dupeItem = (DupeFile)item.Tag;

                Process.Start(dupeItem.FilePath);
            }
        }

        /// <summary>
        /// Open the selected file
        /// </summary>
        private void OpenFile(object sender)
        {
            if (listViewFiles.InvokeRequired || listViewDuplicates.InvokeRequired)
            {
                var d = new Action<object>(OpenPath);
                Invoke(d, new object[] {sender});
            }
            else
            {
                ListView listView = (ListView)sender;

                ListViewItem item = listView.SelectedItems[0];

                var dupeItem = (DupeFile)item.Tag;

                Process.Start(dupeItem.FullFilePath);
            }
        }


        #endregion Threadsafe calls
    }
}