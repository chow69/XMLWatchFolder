namespace XMLWatchFolder
{
    partial class frmXmlWatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXmlWatch));
            this.label1 = new System.Windows.Forms.Label();
            this.txtWatchFolder = new System.Windows.Forms.TextBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.txtNotification = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.fldDialogWatch = new System.Windows.Forms.FolderBrowserDialog();
            this.tipWatch = new System.Windows.Forms.ToolTip(this.components);
            this.fswWatch = new System.IO.FileSystemWatcher();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPDFFolder = new System.Windows.Forms.Button();
            this.txtOutPDFFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fldDialogPDF = new System.Windows.Forms.FolderBrowserDialog();
            this.tipPDF = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fswWatch)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Watch Folder :";
            // 
            // txtWatchFolder
            // 
            this.txtWatchFolder.Location = new System.Drawing.Point(93, 19);
            this.txtWatchFolder.Name = "txtWatchFolder";
            this.txtWatchFolder.Size = new System.Drawing.Size(309, 20);
            this.txtWatchFolder.TabIndex = 1;
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(408, 16);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(25, 25);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(93, 89);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(55, 29);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "&Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // txtNotification
            // 
            this.txtNotification.Location = new System.Drawing.Point(93, 124);
            this.txtNotification.Multiline = true;
            this.txtNotification.Name = "txtNotification";
            this.txtNotification.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotification.Size = new System.Drawing.Size(309, 302);
            this.txtNotification.TabIndex = 4;
            this.txtNotification.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Notification :";
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Location = new System.Drawing.Point(93, 432);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(77, 27);
            this.btnSaveLog.TabIndex = 6;
            this.btnSaveLog.Text = "Save &Log";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // fswWatch
            // 
            this.fswWatch.EnableRaisingEvents = true;
            this.fswWatch.SynchronizingObject = this;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(378, 461);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 29);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPDFFolder
            // 
            this.btnPDFFolder.Location = new System.Drawing.Point(408, 51);
            this.btnPDFFolder.Name = "btnPDFFolder";
            this.btnPDFFolder.Size = new System.Drawing.Size(25, 25);
            this.btnPDFFolder.TabIndex = 10;
            this.btnPDFFolder.Text = "...";
            this.btnPDFFolder.UseVisualStyleBackColor = true;
            this.btnPDFFolder.Click += new System.EventHandler(this.btnPDFFolder_Click);
            // 
            // txtOutPDFFolder
            // 
            this.txtOutPDFFolder.Location = new System.Drawing.Point(93, 54);
            this.txtOutPDFFolder.Name = "txtOutPDFFolder";
            this.txtOutPDFFolder.Size = new System.Drawing.Size(309, 20);
            this.txtOutPDFFolder.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output Folder :";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(449, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(160, 17);
            this.lblStatus.Text = "Click [Start] to watch folder...";
            // 
            // frmXmlWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 539);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPDFFolder);
            this.Controls.Add(this.txtOutPDFFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNotification);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.txtWatchFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXmlWatch";
            this.Text = "XML Watch Folder";
            ((System.ComponentModel.ISupportInitialize)(this.fswWatch)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWatchFolder;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.TextBox txtNotification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.FolderBrowserDialog fldDialogWatch;
        private System.Windows.Forms.ToolTip tipWatch;
        private System.IO.FileSystemWatcher fswWatch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPDFFolder;
        private System.Windows.Forms.TextBox txtOutPDFFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog fldDialogPDF;
        private System.Windows.Forms.ToolTip tipPDF;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

