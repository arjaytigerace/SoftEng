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
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string passw = textBox2.Text;
            string query = "SELECT * FROM administrativeassociate " + "WHERE user = '" + username + "' AND pass = '" + passw + "'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                string firstname = dt.Rows[0]["firstname"].ToString();
                string lastname = dt.Rows[0]["lastname"].ToString();
                int id = (int)dt.Rows[0]["admin_ID"];
                string type = dt.Rows[0]["type"].ToString();




                MessageBox.Show("Welcome " + firstname + " " + lastname);   
                MainMenu Main = new MainMenu();

                
                Main.adminid = id;
                Main.Getfname = firstname;
                Main.Getlname = lastname;
                Main.type = type;
                Main.Form1 = this;
                Main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Re-Enter Details", "Incorrect Log In Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
