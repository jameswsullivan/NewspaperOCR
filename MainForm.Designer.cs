﻿using NewspaperOCR.src;
using System.Runtime.CompilerServices;

namespace NewspaperOCR
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            folderBrowserButton = new Button();
            folderBrowserTextBox = new TextBox();
            exitButton = new Button();
            sourceFilesListView = new ListView();
            sourceFilesListView_filenameCol = new ColumnHeader();
            sourceFilesListView_ocrStatusCol = new ColumnHeader();
            optionsButton = new Button();
            beginOCRButton = new Button();
            viewLogsButton = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            loadImagesButton = new Button();
            startOverButton = new Button();
            statusBar = new StatusStrip();
            statusBarItem_numberOfImagesLoaded = new ToolStripStatusLabel();
            statusBarItem_divider = new ToolStripStatusLabel();
            statusBarItem_numberOfCompletedItems = new ToolStripStatusLabel();
            statusBarItem_numberOfCompletedItemsLabel = new ToolStripStatusLabel();
            cancelOCRButton = new Button();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // folderBrowserButton
            // 
            folderBrowserButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            folderBrowserButton.Location = new Point(944, 7);
            folderBrowserButton.Name = "folderBrowserButton";
            folderBrowserButton.Size = new Size(150, 31);
            folderBrowserButton.TabIndex = 0;
            folderBrowserButton.Text = "... Browse ...";
            folderBrowserButton.UseVisualStyleBackColor = true;
            folderBrowserButton.Click += folderBrowserButton_Click;
            // 
            // folderBrowserTextBox
            // 
            folderBrowserTextBox.AcceptsReturn = true;
            folderBrowserTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            folderBrowserTextBox.Location = new Point(12, 9);
            folderBrowserTextBox.Name = "folderBrowserTextBox";
            folderBrowserTextBox.ReadOnly = true;
            folderBrowserTextBox.Size = new Size(926, 27);
            folderBrowserTextBox.TabIndex = 1;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exitButton.Location = new Point(1130, 615);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(120, 29);
            exitButton.TabIndex = 2;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // sourceFilesListView
            // 
            sourceFilesListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sourceFilesListView.Columns.AddRange(new ColumnHeader[] { sourceFilesListView_filenameCol, sourceFilesListView_ocrStatusCol });
            sourceFilesListView.Location = new Point(12, 44);
            sourceFilesListView.Name = "sourceFilesListView";
            sourceFilesListView.Size = new Size(1238, 564);
            sourceFilesListView.TabIndex = 3;
            sourceFilesListView.UseCompatibleStateImageBehavior = false;
            sourceFilesListView.View = View.Details;
            // 
            // sourceFilesListView_filenameCol
            // 
            sourceFilesListView_filenameCol.Text = "Filename";
            sourceFilesListView_filenameCol.Width = 1088;
            // 
            // sourceFilesListView_ocrStatusCol
            // 
            sourceFilesListView_ocrStatusCol.Text = "OCR Status";
            sourceFilesListView_ocrStatusCol.Width = 120;
            // 
            // optionsButton
            // 
            optionsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            optionsButton.Location = new Point(878, 615);
            optionsButton.Name = "optionsButton";
            optionsButton.Size = new Size(120, 29);
            optionsButton.TabIndex = 4;
            optionsButton.Text = "Options";
            optionsButton.UseVisualStyleBackColor = true;
            optionsButton.Click += optionsButton_Click;
            // 
            // beginOCRButton
            // 
            beginOCRButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            beginOCRButton.Location = new Point(12, 614);
            beginOCRButton.Name = "beginOCRButton";
            beginOCRButton.Size = new Size(200, 29);
            beginOCRButton.TabIndex = 5;
            beginOCRButton.Text = "Begin OCR";
            beginOCRButton.UseVisualStyleBackColor = true;
            beginOCRButton.Click += beginOCRButton_Click;
            // 
            // viewLogsButton
            // 
            viewLogsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            viewLogsButton.Location = new Point(1004, 615);
            viewLogsButton.Name = "viewLogsButton";
            viewLogsButton.Size = new Size(120, 29);
            viewLogsButton.TabIndex = 6;
            viewLogsButton.Text = "View Logs";
            viewLogsButton.UseVisualStyleBackColor = true;
            viewLogsButton.Click += viewLogsButton_Click;
            // 
            // loadImagesButton
            // 
            loadImagesButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            loadImagesButton.Location = new Point(1100, 7);
            loadImagesButton.Name = "loadImagesButton";
            loadImagesButton.Size = new Size(150, 31);
            loadImagesButton.TabIndex = 7;
            loadImagesButton.Text = "Load Images";
            loadImagesButton.UseVisualStyleBackColor = true;
            loadImagesButton.Click += loadImagesButton_Click;
            // 
            // startOverButton
            // 
            startOverButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startOverButton.Location = new Point(752, 615);
            startOverButton.Name = "startOverButton";
            startOverButton.Size = new Size(120, 29);
            startOverButton.TabIndex = 10;
            startOverButton.Text = "Start Over";
            startOverButton.UseVisualStyleBackColor = true;
            startOverButton.Click += startOverButton_Click;
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize = new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { statusBarItem_numberOfImagesLoaded, statusBarItem_divider, statusBarItem_numberOfCompletedItems, statusBarItem_numberOfCompletedItemsLabel });
            statusBar.Location = new Point(0, 647);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(1262, 26);
            statusBar.TabIndex = 16;
            statusBar.Text = "statusBar";
            // 
            // statusBarItem_numberOfImagesLoaded
            // 
            statusBarItem_numberOfImagesLoaded.Name = "statusBarItem_numberOfImagesLoaded";
            statusBarItem_numberOfImagesLoaded.Size = new Size(162, 20);
            statusBarItem_numberOfImagesLoaded.Text = "No Image Files Loaded";
            // 
            // statusBarItem_divider
            // 
            statusBarItem_divider.Name = "statusBarItem_divider";
            statusBarItem_divider.Size = new Size(29, 20);
            statusBarItem_divider.Text = "  |  ";
            // 
            // statusBarItem_numberOfCompletedItems
            // 
            statusBarItem_numberOfCompletedItems.Name = "statusBarItem_numberOfCompletedItems";
            statusBarItem_numberOfCompletedItems.Size = new Size(15, 20);
            statusBarItem_numberOfCompletedItems.Text = "-";
            // 
            // statusBarItem_numberOfCompletedItemsLabel
            // 
            statusBarItem_numberOfCompletedItemsLabel.Name = "statusBarItem_numberOfCompletedItemsLabel";
            statusBarItem_numberOfCompletedItemsLabel.Size = new Size(206, 20);
            statusBarItem_numberOfCompletedItemsLabel.Text = "Images Have Completed OCR";
            // 
            // cancelOCRButton
            // 
            cancelOCRButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelOCRButton.Location = new Point(218, 614);
            cancelOCRButton.Name = "cancelOCRButton";
            cancelOCRButton.Size = new Size(200, 29);
            cancelOCRButton.TabIndex = 17;
            cancelOCRButton.Text = "Stop OCR";
            cancelOCRButton.UseVisualStyleBackColor = true;
            cancelOCRButton.Click += cancelOCRButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(cancelOCRButton);
            Controls.Add(statusBar);
            Controls.Add(startOverButton);
            Controls.Add(loadImagesButton);
            Controls.Add(viewLogsButton);
            Controls.Add(beginOCRButton);
            Controls.Add(optionsButton);
            Controls.Add(sourceFilesListView);
            Controls.Add(exitButton);
            Controls.Add(folderBrowserTextBox);
            Controls.Add(folderBrowserButton);
            MinimumSize = new Size(1280, 720);
            Name = "MainForm";
            Text = "Newspaper OCR";
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region My custom initializations

        private LogForm logForm;
        private OptionsForm optionsForm;
        public Button viewLogsButton;
        internal OCR ocr;
        internal OCRHelper ocrHelper;

        private void CustomInitializations()
        {
            // Set MainForm start location :
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2 - 50);

            // Initialize LogForm :
            logForm = new LogForm();
            logForm.mainForm = this;
            logForm.StartPosition = FormStartPosition.Manual;
            logForm.Location = new Point(this.Location.X + this.Width + 10, this.Location.Y);

            // Initialize OptionsForm :
            optionsForm = new OptionsForm(logForm);
            optionsForm.mainForm = this;
            optionsForm.StartPosition = FormStartPosition.Manual;
            optionsForm.Location = new Point(this.Location.X + this.Width + 20, this.Location.Y);

            // Initialize MainForm UI :
            folderBrowserTextBox.Text = String.Empty;
            folderBrowserDialog.SelectedPath = String.Empty;
            loadImagesButton.Enabled = false;

            sourceFilesListView_filenameCol.Width = sourceFilesListView.Width - 150;
            sourceFilesListView.SizeChanged += imageFilesListView_SizeChanged;

            beginOCRButton.Enabled = false;

            statusBarItem_numberOfImagesLoaded.Text = "No Image Files Loaded";
            statusBarItem_numberOfCompletedItems.Text = "-";

            //ocrHelper.resetStatusBar();
        }
        #endregion

        internal Button folderBrowserButton;
        internal TextBox folderBrowserTextBox;
        internal Button exitButton;
        internal ListView sourceFilesListView;
        internal ColumnHeader sourceFilesListView_filenameCol;
        internal Button optionsButton;
        internal Button beginOCRButton;
        internal ColumnHeader sourceFilesListView_ocrStatusCol;
        internal FolderBrowserDialog folderBrowserDialog;
        internal Button loadImagesButton;
        internal Button startOverButton;
        internal ToolStripStatusLabel statusStripItem_Status;
        internal StatusStrip statusBar;
        internal ToolStripStatusLabel statusBarItem_numberOfImagesLoaded;
        internal ToolStripStatusLabel statusBarItem_numberOfCompletedItems;
        internal ToolStripStatusLabel statusBarItem_divider;
        internal Button cancelOCRButton;
        internal ToolStripStatusLabel statusBarItem_numberOfCompletedItemsLabel;
    }
}
