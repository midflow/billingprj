using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace DataCollect
{
    public partial class KiemKe : Form
    {
        SqlConnection TargetConn = new SqlConnection(global::DataCollect.Properties.Settings.Default.TargetConn);
        SqlConnection SourceConn = new SqlConnection(global::DataCollect.Properties.Settings.Default.SourceConn);
        SqlCommand cmd;
        DateTime Batdau;
        DateTime Ketthuc;

        public KiemKe()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }       

        private void DataCopy2010_Load(object sender, EventArgs e)
        {
            //LayThongTinDuLieuHienTai();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbRun.Value == 100)
                pbRun.Value = 0;
            pbRun.Value += 1;

            backgroundWorker1.ReportProgress(pbRun.Value);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            this.Cursor = Cursors.WaitCursor;
            timer1.Enabled = true;
            timer1.Start();
            pbRun.Visible = true;            
            backgroundWorker1.RunWorkerAsync();
        }

        private void ChayTongHop()
        {
            //this.Cursor = Cursors.WaitCursor;
            if (TargetConn.State == ConnectionState.Closed)
                TargetConn.Open();
            SqlTransaction tran = TargetConn.BeginTransaction();
            try
            {
                cmd = new SqlCommand("baocaokk_run2010", TargetConn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ngaybaocao", SqlDbType.NVarChar).Value = dtpFrom.Value.ToString("dd MMM yyyy");
                cmd.Parameters.Add("@thangnam", SqlDbType.NVarChar,6).Value = dtpFrom.Value.ToString("MMyyyy");
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
                tran.Commit();
                MessageBox.Show("Tổng hợp xong báo cáo");
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                TargetConn.Close();
                label3.Text = "Kết thúc với thời gian " + (Ketthuc - Batdau);
                //this.Cursor = Cursors.Default;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ChayTatCa();            
        }

        private void ChayTatCa()
        {
            Batdau = DateTime.Now;
            try
            {                
                ChayTongHop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Chương trình dừng do lỗi");
                return;
            }
            Ketthuc = DateTime.Now;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbRun.Value = e.ProgressPercentage;
        }       

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Stop();
            pbRun.Visible = false;
            this.Cursor = Cursors.Default;         
        }
    }
}