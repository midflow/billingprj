﻿namespace DataCollect
{
    partial class DataCopy2010
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
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ofdDidong = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.pbRun = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.chkRunAll = new System.Windows.Forms.CheckBox();
            this.btnMobileDataCopy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(229, 145);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 52);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Sao chép dữ liệu";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(391, 214);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(163, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(222, 20);
            this.dtpFrom.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(163, 53);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(222, 20);
            this.dtpTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến ngày";
            // 
            // ofdDidong
            // 
            this.ofdDidong.Filter = "Foxpro file|*.DBF";
            this.ofdDidong.Title = "Chọn tệp dữ liệu di động";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(66, 146);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 52);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.Text = "Chọn tệp dữ liệu di động";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(148, 145);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 52);
            this.btndelete.TabIndex = 3;
            this.btndelete.Text = "Xóa dữ liệu cũ";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(389, 145);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 52);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Chạy tổng hợp";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pbRun
            // 
            this.pbRun.Location = new System.Drawing.Point(66, 111);
            this.pbRun.MarqueeAnimationSpeed = 1000;
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(400, 23);
            this.pbRun.Step = 1;
            this.pbRun.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbRun.TabIndex = 6;
            this.pbRun.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(24, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(463, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Đang chạy xin hãy chờ ...";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // chkRunAll
            // 
            this.chkRunAll.AutoSize = true;
            this.chkRunAll.Checked = true;
            this.chkRunAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunAll.Location = new System.Drawing.Point(66, 219);
            this.chkRunAll.Name = "chkRunAll";
            this.chkRunAll.Size = new System.Drawing.Size(89, 17);
            this.chkRunAll.TabIndex = 7;
            this.chkRunAll.Text = "Chạy toàn bộ";
            this.chkRunAll.UseVisualStyleBackColor = true;
            // 
            // btnMobileDataCopy
            // 
            this.btnMobileDataCopy.Enabled = false;
            this.btnMobileDataCopy.Location = new System.Drawing.Point(310, 145);
            this.btnMobileDataCopy.Name = "btnMobileDataCopy";
            this.btnMobileDataCopy.Size = new System.Drawing.Size(75, 52);
            this.btnMobileDataCopy.TabIndex = 8;
            this.btnMobileDataCopy.Text = "Sao chép dữ liệu di động";
            this.btnMobileDataCopy.UseVisualStyleBackColor = true;
            this.btnMobileDataCopy.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(195, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 9;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataCopy2010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 252);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnMobileDataCopy);
            this.Controls.Add(this.chkRunAll);
            this.Controls.Add(this.pbRun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataCopy2010";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp dữ liệu năm 2010";
            this.Load += new System.EventHandler(this.DataCopy2010_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataCopy2010_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdDidong;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ProgressBar pbRun;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkRunAll;
        private System.Windows.Forms.Button btnMobileDataCopy;
        private System.Windows.Forms.Label label4;
    }
}