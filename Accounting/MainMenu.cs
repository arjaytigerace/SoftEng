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
    public partial class MainMenu : Form
    {
        MySqlConnection conn;
        public MainMenu()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }
        public string Getfname { get; set; }
        public string Getlname { get; set; }

        public int adminid { get; set; }

        public string type { get; set; }

        public Form Form1 { get; set; }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            label1.Text = this.Getfname + " " + this.Getlname;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            if (this.type == "Admin")
            {
                Users User = new Users();

                User.main = this;
                User.Show();
                this.Hide();

            }
            else
            {
                /*
                pictureBox1.Enabled = false;
                pictureBox1.Cursor = DefaultCursor;*/
                MessageBox.Show("Please contact the admin", "You have no admin rights", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }


        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Show() ;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Inventory Inv = new Inventory();
            Inv.main = this;
            Inv.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


               UserPass UP = new UserPass();
               UP.Adminid = this.adminid;
               UP.main = this;
               UP.Show();
               this.Hide();

           

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            BorrowingChem B1 = new BorrowingChem();
            B1.main = this;
            B1.Show();
            this.Hide();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            ChemicalManagement C1 = new ChemicalManagement();
            C1.Getfname = this.Getfname;
            C1.Getlname = this.Getlname;
            C1.Adminid = this.adminid;
            C1.main = this;
            C1.Show();
            this.Hide();
        }
    }
}
