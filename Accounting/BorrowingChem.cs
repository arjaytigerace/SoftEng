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
    public partial class BorrowingChem : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public int Adminid { get; set; }
        public string Getfname { get; set; }
        public string Getlname { get; set; }
        public BorrowingChem()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
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
            borrow.Adminid = this.Adminid;
            borrow.Getfname = this.Getfname;
            borrow.Getlname = this.Getlname;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            BRWupdate update = new BRWupdate();
            update.main = this;
            update.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
