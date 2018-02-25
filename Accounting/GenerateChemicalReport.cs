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
    public partial class GenerateChemicalReport : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public int Adminid { get; set; }
        public GenerateChemicalReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            CrystalReportChem rpt = new CrystalReportChem();
            crystalReportViewer1.ReportSource = rpt;
        }

        private void GenerateChemicalReport_Load(object sender, EventArgs e)
        {

        }
    }
}
