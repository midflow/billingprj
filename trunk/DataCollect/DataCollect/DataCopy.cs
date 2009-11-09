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
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtpFrom.Value.Day == 1)
                {
                    SaoChepSTT();
                    SaoChepSTTDD();
                    SaoChepThueBao();
                    //SaoChepThueBao_CN();
                }
                SaoChepDiDong();
                SaoChepCTHT();
                SaoChepCTCTHT();
                SaoChepDuLieuMoi();
                this.Cursor = Cursors.Default;
                MessageBox.Show("Hoàn thành việc sao chép dữ liệu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Lỗi phần sao chép dữ liệu");
               
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SaoChepDuLieuMoi()
        {
            if (TargetConn.State == ConnectionState.Closed)
                TargetConn.Open();
            SqlTransaction tran = TargetConn.BeginTransaction();
            try
            {
                cmd = new SqlCommand("CopyData", TargetConn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@thangnam", SqlDbType.NVarChar, 6).Value = dtpFrom.Value.ToString("MMyyyy");
                cmd.Parameters.Add("@ngaydauthang", SqlDbType.DateTime).Value = "01 " + dtpFrom.Value.ToString("MMM yyyy");
                if (dtpFrom.Value.ToString("dd MMM yyyy") == "01 " + dtpFrom.Value.ToString("MMM yyyy"))
                    cmd.Parameters.Add("@thangmoi", SqlDbType.Bit).Value = 1;
                else
                    cmd.Parameters.Add("@thangmoi", SqlDbType.Bit).Value = 0;

                //cmd.Connection = TargetConn;
                //TargetConn.Open();
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
                tran.Commit();
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
            }
        }

        private void SaoChepDiDong()
        {

            //Connection string to a dbase file
            string dbfConnectionString = string.Format("Dsn=tradidong;sourcedb=C:\\data;sourcetype=DBF;exclusive=No;backgroundfetch=Yes;collate=Machine;null=Yes;deleted=Yes");

            //create connection to the DBF file
            using (OdbcConnection connection = new OdbcConnection(dbfConnectionString))
            {
                OdbcCommand command = new OdbcCommand("Select * from " + filename, connection);
                connection.Open();

                //Create a dbDatareader to the dbf file
                if (TargetConn.State == ConnectionState.Closed)
                TargetConn.Open();
                SqlTransaction trans = TargetConn.BeginTransaction();
                using (OdbcDataReader dr = command.ExecuteReader())
                {
                    try
                    {
                        using (SqlBulkCopy BulkCopy = new SqlBulkCopy(TargetConn, SqlBulkCopyOptions.Default, trans))
                        {
                            BulkCopy.BulkCopyTimeout = 60000;
                            BulkCopy.BatchSize = 5000;
                            BulkCopy.DestinationTableName = "tradd_092009";
                            BulkCopy.WriteToServer(dr);
                        }
                        trans.Commit();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        MessageBox.Show("Lỗi phần sao chép dữ liệu di động");
                        trans.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                        trans.Dispose();
                    }
                }                
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

        private void SaoChepCTCTHT()
        {
            if (TargetConn.State == ConnectionState.Closed)
                TargetConn.Open();
            SqlTransaction trans = TargetConn.BeginTransaction();
            try
            {
                // Getting source data
                cmd = new SqlCommand("select * from tblCTCTHT", SourceConn);
                cmd.CommandTimeout = 0;
                SourceConn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                // Initializing an SqlBulkCopy object
                SqlBulkCopy sbc = new SqlBulkCopy(TargetConn, SqlBulkCopyOptions.KeepIdentity, trans);
                sbc.BulkCopyTimeout = 6000;
                sbc.BatchSize = 50000;

                // Copying data to destination
                sbc.DestinationTableName = "dbo.tblCTCTHT";
                //DataTable dt = new DataTable();
                //dt.Load(rdr);
                sbc.WriteToServer(rdr);
                sbc.Close();
                rdr.Close();
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                MessageBox.Show("Lỗi ở phần sao chép dữ liệu bảng tblctctht");
            }
            finally
            {
                // Closing connection and the others
                trans.Dispose();
                TargetConn.Close();
                SourceConn.Close();
            }
        }

        private void SaoChepCTHT()
        {
            if (TargetConn.State==ConnectionState.Closed)
            TargetConn.Open();
            SqlTransaction trans = TargetConn.BeginTransaction();
            try
            {
                // Getting source data
                cmd = new SqlCommand("select * from tblCTHT", SourceConn);
                cmd.CommandTimeout = 0;
                SourceConn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                // Initializing an SqlBulkCopy object

                SqlBulkCopy sbc = new SqlBulkCopy(TargetConn, SqlBulkCopyOptions.KeepIdentity, trans);
                sbc.BulkCopyTimeout = 6000;
                sbc.BatchSize = 50000;

                // Copying data to destination
                sbc.DestinationTableName = "dbo.tblCTHT";
                //DataTable dt = new DataTable();
                //dt.Load(rdr);
                sbc.WriteToServer(rdr);
                sbc.Close();
                rdr.Close();
                trans.Commit();
            }
            catch
            {
                MessageBox.Show("Lỗi ở phần sao chép dữ liệu bảng tblctht");
                trans.Rollback();
            }
            finally
            {
                // Closing connection and the others
                trans.Dispose();
                TargetConn.Close();
                SourceConn.Close();
            }
        }

        private void SaoChepThueBao()
        {
            if (TargetConn.State == ConnectionState.Closed)
            TargetConn.Open();
            //SqlTransaction transaction = TargetConn.BeginTransaction();
            try
            {
                cmd = new SqlCommand("select * from tblThueBao where thangnam='" + dtpTo.Value.AddMonths(-1).ToString("MMyyyy") + "'", SourceConn);
                cmd.CommandTimeout = 0;
                //cmd.Transaction = transaction;
                if (SourceConn.State == ConnectionState.Closed)
                    SourceConn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                // Initializing an SqlBulkCopy object

                SqlBulkCopy sbc = new SqlBulkCopy(TargetConn.ConnectionString, SqlBulkCopyOptions.KeepIdentity);

                sbc.BulkCopyTimeout = 6000;
                sbc.BatchSize = 50000;

                // Copying data to destination
                sbc.DestinationTableName = "dbo.tblThueBao";
                //DataTable dt = new DataTable();
                //dt.Load(rdr);
                
                sbc.WriteToServer(rdr);
                sbc.Close();
                rdr.Close();
                //transaction.Commit();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Lỗi ở phần sao chép tblthuebao");
                //transaction.Rollback();
                throw ex;
            }
            finally
            {
                // Closing connection and the others
                //transaction.Dispose();
                SourceConn.Close();
            }
        }

        private void SaoChepSTT()
        {
            try
            {
                // Getting source data
                cmd = new SqlCommand("select * from tblstt where thangnam='" + dtpTo.Value.AddMonths(-1).ToString("MMyyyy") + "'", SourceConn);
                cmd.CommandTimeout = 0;
                if (SourceConn.State == ConnectionState.Closed)
                    SourceConn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                // Initializing an SqlBulkCopy object

                SqlBulkCopy sbc = new SqlBulkCopy(TargetConn.ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
                sbc.BulkCopyTimeout = 6000;
                sbc.BatchSize = 50000;

                // Copying data to destination
                sbc.DestinationTableName = "dbo.tblstt";
                //DataTable dt = new DataTable();
                //dt.Load(rdr);
                sbc.WriteToServer(rdr);
                sbc.Close();
                rdr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ở phần sao chép tblstt");
                throw ex;
            }
            finally
            {
                // Closing connection and the others

                SourceConn.Close();
            }
        }

        private void SaoChepSTTDD()
        {
            try
            {
                // Getting source data
                cmd = new SqlCommand("select * from tblsttdidong where thangnam='" + dtpTo.Value.AddMonths(-1).ToString("MMyyyy") + "'", SourceConn);
                cmd.CommandTimeout = 0;
                if (SourceConn.State == ConnectionState.Closed)
                    SourceConn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                // Initializing an SqlBulkCopy object
                SqlBulkCopy sbc = new SqlBulkCopy(TargetConn.ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
                sbc.BulkCopyTimeout = 6000;
                sbc.BatchSize = 50000;

                // Copying data to destination
                sbc.DestinationTableName = "dbo.tblsttdidong";
                //DataTable dt = new DataTable();
                //dt.Load(rdr);
                sbc.WriteToServer(rdr);
                sbc.Close();
                rdr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ở phần sao chép tblsttdidong");
                throw ex;
            }
            finally
            {
                // Closing connection and the others

                SourceConn.Close();
            }
        }

        //private void SaoChepThueBao_CN()
        //{
        //    //SqlConnection cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.SourceConn);


        //    // Getting source data
        //    SqlCommand cmd = new SqlCommand("select distinct id, tenthuebao, diachi, '', '', '', khid, line from tblstt where thangnam='" + dtpTo.Value.ToString("MMyyyy") + "'", cnn);
        //    cmd.CommandTimeout = 0;
        //    cnn.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();


        //    cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.TargetConn);
        //    //cmd.CommandType = CommandType.StoredProcedure
        //    cmd = new SqlCommand("Delete from tblThuebao_cn");
        //    //if (cnn.State != ConnectionState.Open) 
        //    cmd.Connection = cnn;
        //    cnn.Open();
        //    cmd.CommandTimeout = 0;
        //    cmd.ExecuteNonQuery();

        //    // Initializing an SqlBulkCopy object
        //    SqlBulkCopy sbc = new SqlBulkCopy(global::DataCollect.Properties.Settings.Default.TargetConn);
        //    sbc.BulkCopyTimeout = 6000;
        //    sbc.BatchSize = 50000;

        //    // Copying data to destination
        //    sbc.DestinationTableName = "dbo.tblThueBao_cn";
        //    //DataTable dt = new DataTable();
        //    //dt.Load(rdr);
        //    sbc.WriteToServer(rdr);

        //    // Closing connection and the others
        //    sbc.Close();
        //    rdr.Close();
        //    cnn.Close();
        //}

        private void DataCopy_Load(object sender, EventArgs e)
        {
            //LayThongTinDuLieuHienTai();
        }

        private void XoaDuLieu()
        {
            if (TargetConn.State == ConnectionState.Closed)
                TargetConn.Open();
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
            btnCopy.Enabled = true;
            //SaoChepDiDong();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            try
            {
                //timer1.Start();                
                this.Cursor = Cursors.WaitCursor;
                //cnn = new SqlConnection(global::DataCollect.Properties.Settings.Default.TargetConn);
                cmd = new SqlCommand("DeleteData");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@thangnam", SqlDbType.NVarChar).Value = dtpFrom.Value.AddMonths(-1).ToString("MMyyyy");
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
                MessageBox.Show("Xoá dữ liệu hoàn thành!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("lỗi khi xoá dữ liệu");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                TargetConn.Close();                
                //pbRun.Visible = false;
                //timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbRun.Value == pbRun.Maximum)
                pbRun.Value = 0;

            pbRun.Value += 10;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (TargetConn.State == ConnectionState.Closed)
                TargetConn.Open();
            SqlTransaction tran = TargetConn.BeginTransaction();
            try
            {
                cmd = new SqlCommand("Tonghopbaocao", TargetConn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tungay", SqlDbType.NVarChar).Value = dtpFrom.Value.ToString("dd MMM yyyy");
                cmd.Parameters.Add("@denngay", SqlDbType.NVarChar).Value = dtpTo.Value.ToString("dd MMM yyyy");
                
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
                this.Cursor = Cursors.Default;
            }            
        }

    }
}