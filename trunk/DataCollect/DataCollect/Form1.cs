using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Odbc;
namespace DataCollect
{
    public partial class frmTongHop : Form
    {
        public frmTongHop()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //pgbCongNo.Visible = true;
            //pgbCongNo.be
            //if (rbtBctuan.Checked)
                TongHopDuLieuBaoCaoTuan();
            //else
                //TongHopDuLieuBaoCaoKiemKe();

            //pgbCongNo.Visible = false;
        }

        private void TongHopDuLieuBaoCaoKiemKe()
        {

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString(); 
            //string cmdQuery = "BaoCaoTuan";
            //SqlCommand cmd = new SqlCommand(cmdQuery);
            //cmd.Parameters.Add("@ThangNam", SqlDbType.DateTime).Value = dtpTuNgay.Value.ToString("MMyyyy");
            //cmd.Parameters.Add("@Hanbc", SqlDbType.DateTime).Value = "31 Jul 2009";
            //cmd.Parameters.Add("@Tungay", SqlDbType.DateTime).Value = dtpTuNgay.Value.ToString("MMyyyy");
            //cmd.Parameters.Add("@Denngay", SqlDbType.DateTime).Value = dtpDenNgay.Value.ToString("MMyyyy");
            ////cmd.Parameters.Add("@nam", SqlDbType.Int).Value = iNam;
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandTimeout = 0;
            //con.Open();
            //cmd.ExecuteNonQuery();

        //    @thangnam = N'082009',
        //@hanbc = N'31 jul 2009',
        //@tungay = N'03 aug 2009',
        //@denngay = N'09 aug 2009'

        }

        private void TongHopDuLieuBaoCaoTuan()
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            //string cmdQuery = "BaoCaoTuan";
            //SqlCommand cmd = new SqlCommand(cmdQuery);
            //cmd.Parameters.Add("@ThangNam", SqlDbType.DateTime).Value = dtpTuNgay.Value.ToString("MMyyyy");
            //cmd.Parameters.Add("@Hanbc", SqlDbType.DateTime).Value = "31 Jul 2009";
            //cmd.Parameters.Add("@Tungay", SqlDbType.DateTime).Value = dtpTuNgay.Value.ToString("MMyyyy");
            //cmd.Parameters.Add("@Denngay", SqlDbType.DateTime).Value = dtpDenNgay.Value.ToString("MMyyyy");
            ////cmd.Parameters.Add("@nam", SqlDbType.Int).Value = iNam;
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandTimeout = 0;
            //con.Open();
            //cmd.ExecuteNonQuery();

            //    @thangnam = N'082009',
            //@hanbc = N'31 jul 2009',
            //@tungay = N'03 aug 2009',
            //@denngay = N'09 aug 2009'
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (pgbCongNo.Value >= 2000 )
            //{
            //    pgbCongNo.Value = 0;
            //}
            ////return;
            ////}
            //pgbCongNo.Value += 10;
            //}
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
           // //fbdDidong.ShowDialog();
           // //string strpath = fbdDidong.SelectedPath;
           //// string targetConn = global::DataCollect.Properties.Settings.Default.TargetConn;
           // //if ((ofpDataCopy.PostedFile.FileName.ToLower.EndsWith(".dbf")))
           // //{
           //     //ofpDataCopy.PostedFile.SaveAs(location);
           //     try
           //     {
           //         //Connection string to a dbase file
           //         string dbfConnectionString = string.Format("Dsn=tradidong;sourcedb=d:\\data;sourcetype=DBF;exclusive=No;backgroundfetch=Yes;collate=Machine;null=Yes;deleted=Yes");

           //         //create connection to the DBF file
           //         using (OdbcConnection connection = new OdbcConnection(dbfConnectionString))
           //         {
           //             OdbcCommand command = new OdbcCommand("Select * from tra_082009.DBF", connection);
           //             connection.Open();

           //             //Create a dbDatareader to the dbf file
           //             using (OdbcDataReader dr = command.ExecuteReader())
           //             {
           //                 string sqlConnectionString = TargetConn.ConnectionString;
           //                 SqlConnection myConnection = new SqlConnection(TargetConn.ConnectionString);
           //                 string query = "Truncate table ASDBF";
           //                 myConnection.Open();
           //                 SqlCommand cmd = new SqlCommand(query, myConnection);
           //                 cmd.CommandType = CommandType.Text;
           //                 cmd.ExecuteScalar();
           //                 myConnection.Close();

           //                 //bulk copy of sql server
           //                 using (SqlBulkCopy BulkCopy = new SqlBulkCopy(TargetConn.ConnectionString))
           //                 {
           //                     BulkCopy.DestinationTableName = "ASDBF";
           //                     BulkCopy.WriteToServer(dr);
           //                 }
           //             }
           //             connection.Close();

           //         }
           //     }
           //     catch (Exception ex)
           //     {
           //         throw ex;

           //     }
           // }
       }
    }
}