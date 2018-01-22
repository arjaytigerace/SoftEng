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
    public partial class BorrowingChem : Form
    {
        public Form main { get; set; }
        public BorrowingChem()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BorrowingChem_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BRWBorrow borrow = new BRWBorrow();
            borrow.main = this;
            borrow.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BRWReturn returnform = new BRWReturn();
            returnform.main = this;
            returnform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BRWupdate borrowupd = new BRWupdate();
            borrowupd.main = this;
            borrowupd.Show();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void BorrowingChem_Load(object sender, EventArgs e)
        {

        }
    }
}
