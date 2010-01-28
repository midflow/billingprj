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

        private void choNãm2009ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataCopy frm = new DataCopy();
            frm.ShowDialog(this);
        }

        private void choNãm2010ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataCopy2010 frm = new DataCopy2010();
            frm.ShowDialog(this);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
   }
}