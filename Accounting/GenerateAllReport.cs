﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Accounting
{
    public partial class GenerateAllReport : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public int Adminid { get; set; }
        public GenerateAllReport()
        {
            InitializeComponent();
        }

        private void GenerateAllReport_Load(object sender, EventArgs e)
        {
            CrystalReportAll rpt = new CrystalReportAll();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}