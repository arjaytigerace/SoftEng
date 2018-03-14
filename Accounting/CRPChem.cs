using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting
{
    public partial class CRPChem : Form
    {
        public int Adminid { get; set; }
        public Form main { get; set; }

        public CRPChem()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            CrystalReport3 rpt = new CrystalReport3();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
