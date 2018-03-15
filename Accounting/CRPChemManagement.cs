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
    public partial class CRPChemManagement : Form
    {
        public Form main { get; set; }
        public CRPChemManagement()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ChemicalManagementRPT rpt = new ChemicalManagementRPT();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
