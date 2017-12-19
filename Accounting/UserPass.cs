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
    public partial class UserPass : Form
    {
        public UserPass()
        {
            InitializeComponent();
        }

        public int Adminid { get; set; }
 

        public Form main { get; set; }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UserPass_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            if(txtpswdold.Text == ""|| txtpswdnew.Text=="" || txtpswdnew2.Text == "")
            {

                MessageBox.Show("Missing fields");


            }
            else
            {

                MySqlConnection conn;
                conn = new MySqlConnection("Server=localhost;Database=chem_lab;Uid=root;Pwd=root");
                
  
                string passquery = "SELECT * FROM administrativeassociate " + " WHERE admin_ID=" + this.Adminid;

                conn.Open();

                MySqlCommand comm = new MySqlCommand(passquery, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

              
                  

                string pass = dt.Rows[0]["pass"].ToString();

                if(txtpswdold.Text!= pass)
                {

                    MessageBox.Show("Old password entered does not match");

                }
                else if(txtpswdnew.Text != txtpswdnew2.Text)
                {

                    MessageBox.Show("The two passwords do not match");

                }
                else
                {
                    string update = "UPDATE administrativeassociate SET pass ='" + txtpswdnew.Text + "' WHERE admin_ID=" + this.Adminid;
                    MySqlCommand upd = new MySqlCommand(update,conn);
                    upd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Success!");
                }

            }


        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
         
        }

        private void buttonupd_Click(object sender, EventArgs e)
        {



            if (txtusr.Text == "")
            {

                MessageBox.Show("You did not enter a username");

            }
            else
            {
                MySqlConnection conn;
                conn = new MySqlConnection("Server=localhost;Database=chem_lab;Uid=root;Pwd=root");
                string user = txtusr.Text;
                string query2 = "SELECT * FROM administrativeassociate " + "WHERE user= '" + user + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query2, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Username already taken");

                }
                else
                {
                    string uptquery = "UPDATE administrativeassociate SET user ='" + txtusr.Text + "' WHERE admin_ID =" + this.Adminid;

                    MySqlCommand update = new MySqlCommand(uptquery, conn);

                    update.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully updated username");
                }
            }

        }

        private void UserPass_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void txtpswdnew_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtpswdold_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
