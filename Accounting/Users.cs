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
    public partial class Users : Form
     
    {
        public Form main { get; set; }
        

        MySqlConnection conn;
        public Users()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
            

        }

        private void Users_Load(object sender, EventArgs e)
        {
            loadall();
        }

        private void loadall()
        {
            
            string query = "SELECT * FROM administrativeassociate";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

           
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["admin_id"].Visible = false;
            dataGridView1.Columns["firstname"].HeaderText = "First name";
            dataGridView1.Columns["lastname"].HeaderText = "Last name";
            dataGridView1.Columns["user"].HeaderText = "User name";
            dataGridView1.Columns["pass"].HeaderText = "Password";
            dataGridView1.Columns["type"].HeaderText = "Type";

            deselect();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text=="")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }


            string query = "UPDATE administrativeassociate SET firstname='"+textBox3.Text+"',lastname='"+textBox1.Text+"',type='"+comboBox1.Text+"',user='"+textBox4.Text+"',pass='"+textBox5.Text+"' WHERE admin_ID =" + selected_admin_id;

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully updated the user", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadall();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox1.Text == "" ||  textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please input required fields");
            }
            else
            {
                String query1 = "SELECT * FROM administrativeassociate WHERE user='" + textBox4.Text + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query1, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Username Taken");

                }
                else
                {
                    string query2 = "INSERT INTO administrativeassociate(firstname,lastname,type,user,pass) " + "VALUES('" + textBox3.Text + "', '" + textBox1.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";

                    conn.Open();
                    MySqlCommand comm1 = new MySqlCommand(query2, conn);
                    comm1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Success", "Created New Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadall();
                }
            }
        
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Users_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }
        private int selected_admin_id;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selected_admin_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["admin_id"].Value.ToString());
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["user"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["pass"].Value.ToString();

                button2.Enabled = false;
                button3.Enabled = true;
                button1.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void deselect()
        {
            dataGridView1.ClearSelection();
            textBox3.Text = "";
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            textBox4.Text = "";
            textBox5.Text = "";
            button2.Enabled = true;
            button3.Enabled = false;
            button1.Enabled = false;
            button4.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            deselect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*DialogResult dialogResult = MessageBox.Show("Delete this user?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                string query = "DELETE FROM administrativeassociate WHERE admin_ID =" + selected_admin_id;

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query, conn);
                comm1.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully deleted the user", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deselect();
                loadall();

            }*/


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
