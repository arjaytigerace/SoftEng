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
    public partial class CRPBorrowingManagment : Form
    {
        public Form main { get; set; }
        public CRPBorrowingManagment()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            BorrowingManagementRPT rpt = new BorrowingManagementRPT();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
