namespace DataCollect
{
    partial class DataCopy
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
            this.SuspendLayout();
            // 
            // btnCopy
            // 
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
            this.btnClose.Location = new System.Drawing.Point(391, 145);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 52);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(163, 46);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(222, 20);
            this.dtpFrom.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(163, 87);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(222, 20);
            this.dtpTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 90);
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
            this.btnSelectFile.Location = new System.Drawing.Point(148, 145);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 52);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.Text = "Chọn tệp dữ liệu di động";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(66, 145);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 52);
            this.btndelete.TabIndex = 3;
            this.btndelete.Text = "Xóa dữ liệu cũ";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(310, 145);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 52);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Chạy tổng hợp";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // pbRun
            // 
            this.pbRun.Location = new System.Drawing.Point(66, 111);
            this.pbRun.Maximum = 1000;
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(400, 23);
            this.pbRun.TabIndex = 6;
            this.pbRun.UseWaitCursor = true;
            this.pbRun.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DataCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 235);
            this.Controls.Add(this.pbRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClose);
            this.Name = "DataCopy";
            this.Text = "DataCopy";
            this.Load += new System.EventHandler(this.DataCopy_Load);
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
    }
}