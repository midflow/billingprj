﻿using System;
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

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void choNam2009ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataCopy frm = new DataCopy();
            frm.ShowDialog(this);
        }

        private void choNam2010ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataCopy2010 frm = new DataCopy2010();
            frm.ShowDialog(this);
        }

        private void choBaoCaoKiemKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KiemKe frm = new KiemKe();
            frm.ShowDialog(this);
        }

       
   }
}