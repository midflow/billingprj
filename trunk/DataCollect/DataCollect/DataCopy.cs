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
    public partial class DataCopy : Form
    {
        SqlConnection TargetConn = new SqlConnection(global::DataCollect.Properties.Settings.Default.TargetConn);
        SqlConnection SourceConn = new SqlConnection(global::DataCollect.Properties.Settings.Default.SourceConn);
        string filename;
        SqlCommand cmd;

        public DataCopy()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //if (dtpFrom.Value.Day == 0)
            //{                
            //    SaoChepSTT();
            //    SaoChepSTTDD();
            //    SaoChepThueBao();
            //    SaoChepThueBao_CN();
            //}
            SaoChepDiDong();
            //SaoChepCTHT();           
            //SaoChepCTCTHT();
            
            MessageBox.Show("Hoàn thành");
        }

        private void SaoChepDiDong()
        {
            try
            {
                //Connection string to a dbase file
                string dbfConnectionString = string.Format("Dsn=tradidong;sourcedb=C:\\data;sourcetype=DBF;exclusive=No;backgroundfetch=Yes;collate=Machine;null=Yes;deleted=Yes");

                //create connection to the DBF file
                using (OdbcConnection connection = new OdbcConnection(dbfConnectionString))
                {
                    OdbcCommand command = new OdbcCommand("Select * from " + filename, connection);
                    connection.Open();

                    //Create a dbDatareader to the dbf file
                    using (OdbcDataReader dr = command.ExecuteReader())
                    {
                        //cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.TargetConn);
                        //cmd.CommandType = CommandType.StoredProcedure
                        //cmd = new SqlCommand("Delete from tradd_092009"));
                        ////if (cnn.State != ConnectionState.Open) 
                        //cmd.Connection = TargetConn;
                        //cnn.Open();
                        //cmd.CommandTimeout = 0;
                        //cmd.ExecuteNonQuery();

                        //bulk copy of sql server
                        //DataTable dt = new DataTable();
                        //dt.Load(dr);
                        using (SqlBulkCopy BulkCopy = new SqlBulkCopy(TargetConn.ConnectionString, SqlBulkCopyOptions.UseInternalTransaction))
                        {
                            BulkCopy.BulkCopyTimeout = 0;
                            BulkCopy.BatchSize = 5000;
                            BulkCopy.DestinationTableName = "tradd_092009";
                            BulkCopy.WriteToServer(dr);
                        }
                    }
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void SaoChepCTCT()
        {
            SqlConnection cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.DB_4ConnectionString);


            // Getting source data
            SqlCommand cmd = new SqlCommand("select * from CTCT where CTid in (select ID from tblCT where NgayCT between '" + dtpFrom.Value.ToString("dd MMM yyy") + "' and '" + dtpTo.Value.ToString("dd MMM yyy") + "')", cnn);
            cmd.CommandTimeout = 0;
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            // Initializing an SqlBulkCopy object
            SqlBulkCopy sbc = new SqlBulkCopy(global::DataCollect.Properties.Settings.Default.TargetConn);
            sbc.BulkCopyTimeout = 6000;
            sbc.BatchSize = 50000;

            // Copying data to destination
            sbc.DestinationTableName = "dbo.tblCCTT";
            //DataTable dt = new DataTable();
            //dt.Load(rdr);
            sbc.WriteToServer(rdr);

            // Closing connection and the others
            sbc.Close();
            rdr.Close();
            cnn.Close();
        }

        private void SaoChepCT()
        {
            // Establishing connection
            //SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();
            //cb.DataSource = "SQLProduction";
            //cb.InitialCatalog = "Sales";
            //cb.IntegratedSecurity = true;
            SqlConnection cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.SourceConn);


            // Getting source data
            SqlCommand cmd = new SqlCommand("select * from tblCT where NgayCT between '" + dtpFrom.Value.ToString("dd MMM yyy") + "' and '" + dtpTo.Value.ToString("dd MMM yyy")  + "'", cnn);
            cmd.CommandTimeout = 0;
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            // Initializing an SqlBulkCopy object
            SqlBulkCopy sbc = new SqlBulkCopy(global::DataCollect.Properties.Settings.Default.TargetConn);
            sbc.BulkCopyTimeout = 6000;
            sbc.BatchSize = 50000;

            // Copying data to destination
            sbc.DestinationTableName = "dbo.tblCT";
            //DataTable dt = new DataTable();
            //dt.Load(rdr);
            sbc.WriteToServer(rdr);

            // Closing connection and the others
            sbc.Close();
            rdr.Close();
            cnn.Close();
        }

        private void SaoChepCTCTHT()
        {
            SqlConnection cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.DB_4ConnectionString);


            // Getting source data
            SqlCommand cmd = new SqlCommand("select * from CTCT where CTid in (select ID from tblCT where NgayCT between '" + dtpFrom.Value.ToString("dd MMM yyy") + "' and '" + dtpTo.Value.ToString("dd MMM yyy") + "')", cnn);
            cmd.CommandTimeout = 0;
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            // Initializing an SqlBulkCopy object
            SqlBulkCopy sbc = new SqlBulkCopy(global::DataCollect.Properties.Settings.Default.TargetConn);
            sbc.BulkCopyTimeout = 6000;
            sbc.BatchSize = 50000;

            // Copying data to destination
            sbc.DestinationTableName = "dbo.tblCCTT";
            //DataTable dt = new DataTable();
            //dt.Load(rdr);
            sbc.WriteToServer(rdr);

            // Closing connection and the others
            sbc.Close();
            rdr.Close();
            cnn.Close();
        }

        private void SaoChepCTHT()
        {            
            SqlConnection cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.SourceConn);


            // Getting source data
            SqlCommand cmd = new SqlCommand("select * from tblCT where NgayCT between '" + dtpFrom.Value.ToString("dd MMM yyy") + "' and '" + dtpTo.Value.ToString("dd MMM yyy") + "'", cnn);
            cmd.CommandTimeout = 0;
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            // Initializing an SqlBulkCopy object
            SqlBulkCopy sbc = new SqlBulkCopy(global::DataCollect.Properties.Settings.Default.TargetConn);
            sbc.BulkCopyTimeout = 6000;
            sbc.BatchSize = 50000;

            // Copying data to destination
            sbc.DestinationTableName = "dbo.tblCT";
            //DataTable dt = new DataTable();
            //dt.Load(rdr);
            sbc.WriteToServer(rdr);

            // Closing connection and the others
            sbc.Close();
            rdr.Close();
            cnn.Close();
        }

        private void SaoChepThueBao()
        {
            // Establishing connection
            //SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();
            //cb.DataSource = "SQLProduction";
            //cb.InitialCatalog = "Sales";
            //cb.IntegratedSecurity = true;
            SqlConnection cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.SourceConn);


            // Getting source data
            SqlCommand cmd = new SqlCommand("select * from tblThueBao where thangnam='" + dtpTo.Value.ToString("MMyyyy") + "'", cnn);
            cmd.CommandTimeout = 0;
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();           

            // Initializing an SqlBulkCopy object
            SqlBulkCopy sbc = new SqlBulkCopy(global::DataCollect.Properties.Settings.Default.TargetConn);
            sbc.BulkCopyTimeout = 6000;
            sbc.BatchSize = 50000;

            // Copying data to destination
            sbc.DestinationTableName = "dbo.tblThueBao";
            //DataTable dt = new DataTable();
            //dt.Load(rdr);
            sbc.WriteToServer(rdr);

            // Closing connection and the others
            sbc.Close();
            rdr.Close();
            cnn.Close(); 
        }

        private void SaoChepSTT()
        {                        
            // Getting source data
            cmd = new SqlCommand("select * from tblstt where thangnam='" + dtpTo.Value.ToString("MMyyyy") + "'", SourceConn);
            cmd.CommandTimeout = 0;
            SourceConn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();           

            // Initializing an SqlBulkCopy object
           
            SqlBulkCopy sbc = new SqlBulkCopy(TargetConn.ConnectionString);
            sbc.BulkCopyTimeout = 6000;
            sbc.BatchSize = 50000;

            // Copying data to destination
            sbc.DestinationTableName = "dbo.tblstt";
            //DataTable dt = new DataTable();
            //dt.Load(rdr);
            sbc.WriteToServer(rdr);

            // Closing connection and the others
            sbc.Close();
            rdr.Close();
            SourceConn.Close(); 
        }

        private void SaoChepSTTDD()
        {
            //SqlConnection cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.SourceConn);

            // Getting source data
            cmd = new SqlCommand("select * from tblsttdidong where thangnam='" + dtpTo.Value.ToString("MMyyyy") + "'", SourceConn);
            cmd.CommandTimeout = 0;
            SourceConn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            // Initializing an SqlBulkCopy object
            SqlBulkCopy sbc = new SqlBulkCopy(TargetConn.ConnectionString);
            sbc.BulkCopyTimeout = 6000;
            sbc.BatchSize = 50000;

            // Copying data to destination
            sbc.DestinationTableName = "dbo.tblsttdidong";
            //DataTable dt = new DataTable();
            //dt.Load(rdr);
            sbc.WriteToServer(rdr);

            // Closing connection and the others
            sbc.Close();
            rdr.Close();
            SourceConn.Close();
        }

        private void SaoChepThueBao_CN()
        {           
            SqlConnection cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.SourceConn);


            // Getting source data
            SqlCommand cmd = new SqlCommand("select distinct id, tenthuebao, diachi, '', '', '', khid, line from tblstt where thangnam='" + dtpTo.Value.ToString("MMyyyy") + "'", cnn);
            cmd.CommandTimeout = 0;
            cnn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();


            cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.TargetConn);
            //cmd.CommandType = CommandType.StoredProcedure
            cmd = new SqlCommand("Delete from tblThuebao_cn");
            //if (cnn.State != ConnectionState.Open) 
            cmd.Connection = cnn;
            cnn.Open();
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();

            // Initializing an SqlBulkCopy object
            SqlBulkCopy sbc = new SqlBulkCopy(global::DataCollect.Properties.Settings.Default.TargetConn);
            sbc.BulkCopyTimeout = 6000;
            sbc.BatchSize = 50000;

            // Copying data to destination
            sbc.DestinationTableName = "dbo.tblThueBao_cn";
            //DataTable dt = new DataTable();
            //dt.Load(rdr);
            sbc.WriteToServer(rdr);

            // Closing connection and the others
            sbc.Close();
            rdr.Close();
            cnn.Close(); 
        }

        private void DataCopy_Load(object sender, EventArgs e)
        {
            //LayThongTinDuLieuHienTai();
        }       

        private void XoaDuLieu()
        {            
            SqlTransaction tran = TargetConn.BeginTransaction();
            try
            {
                cmd = new SqlCommand("DeleteData");
                cmd.Parameters.Add("@thangnam", SqlDbType.NVarChar, 6).Value = dtpFrom.Value.ToString("MMyyyy");
                cmd.Connection = TargetConn;
                TargetConn.Open();
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                TargetConn.Close();
            }
        }
        
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            ofdDidong.ShowDialog();
            filename = ofdDidong.SafeFileName.Split('.')[0];
            //SaoChepDiDong();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                //timer1.Start();                
                pbRun.Value = 0;
                //timer1.Enabled=true;
                //pbRun.Visible = true;
                pbRun.Show();
                //cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.TargetConn);
                cmd = new SqlCommand("DeleteData");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ngaydauthang", SqlDbType.DateTime).Value = "01 " + dtpFrom.Value.ToString("MMM yyyy");
                if (dtpFrom.Value.ToString("dd MMM yyyy") == "01 " + dtpFrom.Value.ToString("MMM yyyy"))
                    cmd.Parameters.Add("@thangmoi", SqlDbType.Bit).Value = 1;
                else
                    cmd.Parameters.Add("@thangmoi", SqlDbType.Bit).Value = 0;


                //if (cnn.State != ConnectionState.Open) 
                cmd.Connection = TargetConn;
                TargetConn.Open();
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
                //pbRun.Visible = false;
            }
            catch
            {
                MessageBox.Show("lỗi");
            }
            finally
            {
                TargetConn.Close();
                //pbRun.Visible = false;
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbRun.Value == pbRun.Maximum)
                pbRun.Value = 0;

            pbRun.Value += 10;
        }

       
    }
}