using System;
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
    public partial class GenerateApparatusReport : Form
    {

        public Form main { get; set; }
        MySqlConnection conn;
        public int Adminid { get; set; }
        public GenerateApparatusReport()
        {
            InitializeComponent();
        }

        private void GenerateApparatusReport_Load(object sender, EventArgs e)
        {
            CrystalReportAppa rpt = new CrystalReportAppa();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
