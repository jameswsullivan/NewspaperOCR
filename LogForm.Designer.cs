﻿namespace NewspaperOCR
{
    partial class LogForm
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
            logsTextBox = new TextBox();
            saveLogsButton = new Button();
            hideLogsButton = new Button();
            clearLogsButton = new Button();
            verboseLogCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // logsTextBox
            // 
            logsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logsTextBox.BackColor = Color.FromArgb(64, 64, 64);
            logsTextBox.ForeColor = Color.FromArgb(0, 192, 0);
            logsTextBox.Location = new Point(12, 12);
            logsTextBox.Multiline = true;
            logsTextBox.Name = "logsTextBox";
            logsTextBox.ScrollBars = ScrollBars.Vertical;
            logsTextBox.Size = new Size(758, 614);
            logsTextBox.TabIndex = 0;
            // 
            // saveLogsButton
            // 
            saveLogsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveLogsButton.Location = new Point(398, 632);
            saveLogsButton.Name = "saveLogsButton";
            saveLogsButton.Size = new Size(120, 29);
            saveLogsButton.TabIndex = 2;
            saveLogsButton.Text = "Save Logs";
            saveLogsButton.UseVisualStyleBackColor = true;
            saveLogsButton.Click += logFormSaveLogsButton_Click;
            // 
            // hideLogsButton
            // 
            hideLogsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            hideLogsButton.Location = new Point(650, 632);
            hideLogsButton.Name = "hideLogsButton";
            hideLogsButton.Size = new Size(120, 29);
            hideLogsButton.TabIndex = 3;
            hideLogsButton.Text = "Hide Logs";
            hideLogsButton.UseVisualStyleBackColor = true;
            hideLogsButton.Click += logFormHideLogsButton_Click;
            // 
            // clearLogsButton
            // 
            clearLogsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clearLogsButton.Location = new Point(524, 632);
            clearLogsButton.Name = "clearLogsButton";
            clearLogsButton.Size = new Size(120, 29);
            clearLogsButton.TabIndex = 4;
            clearLogsButton.Text = "Clear Logs";
            clearLogsButton.UseVisualStyleBackColor = true;
            clearLogsButton.Click += clearLogsButton_Click;
            // 
            // verboseLogCheckBox
            // 
            verboseLogCheckBox.AutoSize = true;
            verboseLogCheckBox.Checked = true;
            verboseLogCheckBox.CheckState = CheckState.Checked;
            verboseLogCheckBox.Location = new Point(12, 637);
            verboseLogCheckBox.Name = "verboseLogCheckBox";
            verboseLogCheckBox.Size = new Size(84, 24);
            verboseLogCheckBox.TabIndex = 5;
            verboseLogCheckBox.Text = "Verbose";
            verboseLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // LogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 673);
            Controls.Add(verboseLogCheckBox);
            Controls.Add(clearLogsButton);
            Controls.Add(hideLogsButton);
            Controls.Add(saveLogsButton);
            Controls.Add(logsTextBox);
            MaximumSize = new Size(800, 720);
            MinimumSize = new Size(800, 720);
            Name = "LogForm";
            Text = "View Logs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region Custom Initializations

        public MainForm mainForm;
        public string LOG_TYPE_INFO, LOG_TYPE_WARN, LOG_TYPE_ERROR;
        public CheckBox verboseLogCheckBox;
        private string LOG_TIMESTAMP;
        private void CustomInitializations()
        {
            verboseLogCheckBox.Checked = true;

            LOG_TYPE_INFO = " - [INFO] - ";
            LOG_TYPE_WARN = " - [WARN] - ";
            LOG_TYPE_ERROR = " - [ERROR] - ";

            LOG_TIMESTAMP = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        private Button saveLogsButton;
        private Button hideLogsButton;
        private TextBox logsTextBox;
        private Button clearLogsButton;
    }
}