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
        public string Getfname { get; set; }
        public string Getlname { get; set; }

        public int adminid { get; set; }

        public string type { get; set; }
        public string notif { get; set; }

        public Form Form1 { get; set; }
        public MainMenu()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");


        }

 

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
            Inv.Adminid = this.adminid;
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
            B1.Adminid = this.adminid;
            B1.Getfname = this.Getfname;
            B1.Getlname = this.Getlname;
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            StudentsFaculty SF = new StudentsFaculty();
            SF.main = this;
            SF.Show();
            this.Hide();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Notification N = new Notification();
            N.main = this;
            N.Show();
            
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {

        }

        private void MainMenu_Enter(object sender, EventArgs e)
        {
  
        }

        private void MainMenu_Activated(object sender, EventArgs e)
        {
            string query2 = "SELECT itemName from item WHERE quantity=0";
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            bool hasRows = dt2.Rows.GetEnumerator().MoveNext();
            if (hasRows)
            {
                notif = "You have items \n that need to be \n restocked";
            }
            else
            {
                notif = "No items \n need to be \n restocked";
            }
            label3.Text = notif;
        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
