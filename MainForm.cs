using ImageMagick;
using ImageMagick.Formats;
using NewspaperOCR.src;
using System.Windows.Forms;
using TesseractOCR;
using TesseractOCR.Enums;
using TesseractOCR.Renderers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NewspaperOCR
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CustomInitializations();
        }

        #region My Custom Functions

        private void imageFilesListView_SizeChanged(object sender, EventArgs e)
        {
            filenameCol.Width = imageFilesListView.Width - 150;
        }

        public void setDefaultOptions()
        {
            Properties.Settings.Default.TessdataLocation = Path.GetFullPath(".") + "\\tessdata";

            if (optionsForm.getOcrOutputLocation() != String.Empty)
            {
                Properties.Settings.Default.OCROutputLocation = optionsForm.getOcrOutputLocation();
            }
            else
            {
                Properties.Settings.Default.OCROutputLocation = Path.GetFullPath(".") + "\\output";
            }
            Properties.Settings.Default.ConcurrentOCRJobs = 1;
            Properties.Settings.Default.OCRLang = "eng";
            Properties.Settings.Default.TileSize = "[1024x1024]";
            Properties.Settings.Default.Save();

            logForm.appendTextsToLog("\"Tessdata Location\": " + Properties.Settings.Default.TessdataLocation, logForm.LOG_TYPE_INFO);
            logForm.appendTextsToLog("\"OCR Output Location\": " + Properties.Settings.Default.OCROutputLocation, logForm.LOG_TYPE_INFO);
            logForm.appendTextsToLog("\"Concurrent OCR Jobs\": " + Properties.Settings.Default.ConcurrentOCRJobs.ToString(), logForm.LOG_TYPE_INFO);
            logForm.appendTextsToLog("\"OCR Language\": " + Properties.Settings.Default.OCRLang, logForm.LOG_TYPE_INFO);
            logForm.appendTextsToLog("\"Tile Size\": " + Properties.Settings.Default.TileSize, logForm.LOG_TYPE_INFO);
        }
        private void startOver()
        {
            setDefaultOptions();

            imageFilesListView.Items.Clear();
            directoryStructure.Clear();

            numberOfImages.Text = "-";
            numberOfCompletedOcr.Text = "-";

            browse_folderBrowserDialog.SelectedPath = String.Empty;
            browse_TextBox.Text = String.Empty;

            loadImagesButton.Enabled = false;
            beginOCRButton.Enabled = false;

            clearStatusBar();
        }

        public void constructOutputDirectoryStructure()
        {
            string batchNameFolder = Path.GetFileName(browse_TextBox.Text);

            foreach (ListViewItem imageFileListViewItem in imageFilesListView.Items)
            {
                //Get the item index:
                int index = imageFileListViewItem.Index;

                //Construct issueDateFolder:
                string issueDateFolder = imageFileListViewItem.SubItems[0].Text;
                issueDateFolder = issueDateFolder.Replace(browse_TextBox.Text, "");
                var segments = issueDateFolder.Split(Path.DirectorySeparatorChar);
                if (segments.Length > 0)
                {
                    issueDateFolder = segments[1];
                }

                //Extract imageFileName:
                string imageFileName = Path.GetFileName(imageFileListViewItem.SubItems[0].Text);

                DirectoryStructure directoryStructureItem = new DirectoryStructure(index, batchNameFolder, issueDateFolder, imageFileName, imageFileListViewItem.SubItems[0].Text, Properties.Settings.Default.OCROutputLocation);
                directoryStructure.Add(directoryStructureItem);
            }
        }

        private void ocr(string sourceImageFileFullpath, string sourceImageFileName, string outputPdfFileFullPath, string outputAltoFileFullPath, string outputJp2FileFullPath)
        {
            string tessdataLoc = Properties.Settings.Default.TessdataLocation;

            using (var engine = new TesseractOCR.Engine(tessdataLoc, Language.English, EngineMode.LstmOnly))
            {
                using (var img = TesseractOCR.Pix.Image.LoadFromFile(sourceImageFileFullpath))
                {
                    using (var page = engine.Process(img))
                    {
                        using (var pdfRenderer = new PdfResult(outputPdfFileFullPath, tessdataLoc, false))
                        {
                            pdfRenderer.BeginDocument(sourceImageFileName);
                            pdfRenderer.AddPage(page);
                        }

                        using (var altoRenderer = new AltoResult(outputAltoFileFullPath))
                        {
                            altoRenderer.BeginDocument(sourceImageFileName);
                            altoRenderer.AddPage(page);
                        }
                    }
                }
            }

            using (var sourceImage = new MagickImage(sourceImageFileFullpath))
            {
                sourceImage.Format = MagickFormat.Jp2;
                sourceImage.Settings.Compression = CompressionMethod.JPEG2000;

                //sourceImage.ColorSpace = ColorSpace.Gray;
                //sourceImage.Settings.SetDefine(MagickFormat.Jp2, "number-resolutions", 5);
                //sourceImage.Settings.SetDefine(MagickFormat.Jp2, "Quality", "20,40,60,80");
                //sourceImage.Settings.SetDefine(MagickFormat.Jp2, "rate", "20,10,5,2,1");
                sourceImage.Settings.SetDefine(MagickFormat.Jp2, "progression-order", "RLCP");
                sourceImage.Quality = 40;

                string tiledJp2FileFullPath = outputJp2FileFullPath + Properties.Settings.Default.TileSize;

                sourceImage.Write(tiledJp2FileFullPath);

                if (File.Exists(outputJp2FileFullPath))
                {
                    File.Delete(outputJp2FileFullPath);
                }

                File.Move(tiledJp2FileFullPath, outputJp2FileFullPath);
            }
        }

        public void updateStatusBar(string status, string message)
        {
            statusBarItem_Status.Text = status;
            statusBarItem_Message.Text = message;
        }

        public void clearStatusBar()
        {
            statusBarItem_Status.Text = "No Image Files Loaded";
            statusBarItem_Message.Text = String.Empty;
        }

        #endregion

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            if (browse_folderBrowserDialog.SelectedPath != null)
            {
                List<string> imageFiles = new List<string>();

                imageFiles.AddRange(Directory.GetFiles(browse_folderBrowserDialog.SelectedPath, "*.tif", SearchOption.AllDirectories));

                foreach (string imageFile in imageFiles)
                {
                    ListViewItem item = new ListViewItem(imageFile);
                    item.SubItems.Add("...");

                    imageFilesListView.Items.Add(item);
                }

                numberOfImages.Text = imageFiles.Count.ToString();

                beginOCRButton.Enabled = true;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browse_Button_Click(object sender, EventArgs e)
        {
            browse_TextBox.Text = String.Empty;

            if (browse_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                browse_TextBox.Text = browse_folderBrowserDialog.SelectedPath;
                loadImagesButton.Enabled = true;
            }
            else
            {
                browse_TextBox.Text = String.Empty;
                loadImagesButton.Enabled = false;
            }
        }

        private void viewLogsButton_Click(object sender, EventArgs e)
        {
            if (logForm.Visible)
            {
                logForm.Hide();
                viewLogsButton.Text = "View Logs";
            }
            else
            {
                logForm.Location = new Point(this.Location.X + this.Width + 10, this.Location.Y);
                logForm.Show();
                viewLogsButton.Text = "Hide Logs";
            }
        }

        private async void beginOCRButton_Click(object sender, EventArgs e)
        {
            constructOutputDirectoryStructure();

            int completedOcr = 0;
            numberOfCompletedOcr.Text = completedOcr.ToString();
            DateTime batchStartTime = DateTime.Now;
            DateTime batchCompletionTime;
            TimeSpan batchProcessingTime;

            logForm.appendTextsToLog($"OCR of this batch started at: {batchStartTime.ToString(@"hh\:mm\:ss")}.", logForm.LOG_TYPE_INFO);

            foreach (DirectoryStructure item in directoryStructure)
            {
                ListViewItem imageFileListViewItem = imageFilesListView.Items[item.Index];

                if (File.Exists(item.OutputAltoFileFullPath + ".xml") || File.Exists(item.OutputPdfFileFullPath + ".pdf"))
                {
                    imageFileListViewItem.SubItems[1].Text = "Skipped";
                    logForm.appendTextsToLog($"{item.SourceImageFileFullPath} skipped. Destinationa file exists.", logForm.LOG_TYPE_INFO);
                    completedOcr++;
                    numberOfCompletedOcr.Text = completedOcr.ToString();
                    continue;
                }
                else
                {
                    imageFileListViewItem.EnsureVisible();

                    Task ocrTask = Task.Run(() => ocr(item.SourceImageFileFullPath, item.SourceImageFileNameWithoutExtension, item.OutputPdfFileFullPath, item.OutputAltoFileFullPath, item.OutputJp2ImageFileFullPath));

                    while (!ocrTask.IsCompleted)
                    {
                        if (imageFileListViewItem.SubItems[1].Text.Length < 8)
                        {
                            imageFileListViewItem.SubItems[1].Text += "..";
                        }
                        else
                        {
                            imageFileListViewItem.SubItems[1].Text = "...";
                        }

                        logForm.appendTextsToLog(item.SourceImageFileFullPath + " is being OCR'd " + imageFileListViewItem.SubItems[1].Text, logForm.LOG_TYPE_INFO);
                        updateStatusBar("File being processed: ", item.SourceImageFileFullPath);
                        imageFileListViewItem.SubItems[1].Text = imageFileListViewItem.SubItems[1].Text;
                        await Task.Delay(2000);
                    }

                    if (ocrTask.Status == TaskStatus.RanToCompletion)
                    {
                        logForm.appendTextsToLog(item.SourceImageFileFullPath + " ocr has completed ... ", logForm.LOG_TYPE_INFO);
                        imageFileListViewItem.SubItems[1].Text = "Finished";
                        completedOcr++;
                        numberOfCompletedOcr.Text = completedOcr.ToString();
                    }
                    else if (ocrTask.Status == TaskStatus.Canceled)
                    {
                        logForm.appendTextsToLog(item.SourceImageFileFullPath + " task cancelled ... ", logForm.LOG_TYPE_WARN);
                        imageFileListViewItem.SubItems[1].Text = "Cancelled";
                    }
                    else if (ocrTask.Status == TaskStatus.Faulted)
                    {
                        logForm.appendTextsToLog(ocrTask.Exception.ToString(), logForm.LOG_TYPE_ERROR);
                        imageFileListViewItem.SubItems[1].Text = "Faulted";
                    }
                }
            }

            batchCompletionTime = DateTime.Now;
            batchProcessingTime = batchCompletionTime - batchStartTime;

            string ocrCompleteMessage = $"OCR of this batch has completed at {batchCompletionTime.ToString(@"hh\:mm\:ss")}. Time spent: {batchProcessingTime.ToString(@"hh\:mm\:ss")}. Files from this batch will be cleared from the list.";

            logForm.appendTextsToLog(ocrCompleteMessage, logForm.LOG_TYPE_INFO);

            MessageBox.Show(ocrCompleteMessage, "OCR Complete!");

            startOver();
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            optionsForm.Show();
        }

        private void startOverButton_Click(object sender, EventArgs e)
        {
            startOver();
        }

    }
}
