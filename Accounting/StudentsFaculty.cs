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
    public partial class StudentsFaculty : Form
    {
        public Form main { get; set; }
        public int selectedSID;
        public int selectedFID;
        MySqlConnection conn;

        public StudentsFaculty()
        {
            InitializeComponent();

            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }
        private void loadall()
        {

            string query = "SELECT * FROM student";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);


            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["studentID"].Visible = false;
            dataGridView1.Columns["schoolID"].HeaderText = "ID";
            dataGridView1.Columns["studentFName"].HeaderText = "First Name";
            dataGridView1.Columns["studentLName"].HeaderText = "Last Name";
            dataGridView1.Columns["yearCourse"].HeaderText = "Year & Course";
            dataGridView1.Columns["status"].HeaderText = "Status";

            string query1 = "SELECT * FROM teacher";

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);


            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["teacherID"].Visible = false;
            dataGridView2.Columns["schoolID"].HeaderText = "ID";
            dataGridView2.Columns["teacherFName"].HeaderText = "First Name";
            dataGridView2.Columns["teacherLName"].HeaderText = "Last Name";
            dataGridView2.Columns["status"].HeaderText = "Status";


            deselect();

        }


        private void deselect()
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            sID.Text = "";
            sfname.Text = "";
            comboBox1.SelectedIndex = -1;
            slname.Text = "";
            scourse.Text = "";
            screate.Enabled = true;
            sdeselect.Enabled = false;
            supdate.Enabled = false;

            facID.Text = "";
            facfname.Text = "";
            faclname.Text = "";
            facstatus.SelectedIndex = -1;
            fcreate.Enabled = true;
            fdeselect.Enabled = false;
            fupdate.Enabled = false;

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentsFaculty_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void sdeselect_Click(object sender, EventArgs e)
        {
            deselect();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                sID.Text = dataGridView1.Rows[e.RowIndex].Cells["schoolID"].Value.ToString();
                sfname.Text = dataGridView1.Rows[e.RowIndex].Cells["studentFName"].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();
                slname.Text = dataGridView1.Rows[e.RowIndex].Cells["studentLName"].Value.ToString();
                scourse.Text = dataGridView1.Rows[e.RowIndex].Cells["yearCourse"].Value.ToString();
                selectedSID= int.Parse(dataGridView1.Rows[e.RowIndex].Cells["studentID"].Value.ToString());

                screate.Enabled = false;
                sdeselect.Enabled = true;
                supdate.Enabled = true;
               
            }
        }

        private void screate_Click(object sender, EventArgs e)
        {
            if (sID.Text == "" || sfname.Text == "" || slname.Text == "" || scourse.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please input required fields");
            }
            else
            {
                String query1 = "SELECT * FROM student WHERE schoolID='" + sID.Text + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query1, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("This ID already exists");

                }
                else
                {
                    string query2 = "INSERT INTO student(schoolID,studentFname,studentLname,yearCourse,status) " + "VALUES('" + sID.Text + "', '" + sfname.Text + "', '" + slname.Text + "', '" + scourse.Text + "', '" + comboBox1.Text + "')";

                    conn.Open();
                    MySqlCommand comm1 = new MySqlCommand(query2, conn);
                    comm1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Success", "Added New Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadall();
                }
            }
        }

        private void fupdate_Click(object sender, EventArgs e)
        {
            if (facID.Text == "" || facfname.Text == "" || faclname.Text == "" || facstatus.Text == "")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }
            else
            {

                string query = "UPDATE teacher SET schoolID='" + facID.Text + "',teacherFName='" + facfname.Text + "',teacherLName='" + faclname.Text + "',status='" + facstatus.Text + "' WHERE teacherID =" + selectedFID;

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query, conn);
                comm1.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully updated the faculty member", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadall();
            }
        }

        private void StudentsFaculty_Load(object sender, EventArgs e)
        {
            loadall();
        }

        private void supdate_Click(object sender, EventArgs e)
        {
            if (sID.Text == "" || sfname.Text == "" || slname.Text == "" || scourse.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }
            else
            {

                string query = "UPDATE student SET schoolID='" + sID.Text + "',studentFName='" + sfname.Text + "',studentLName='" + slname.Text + "',yearCourse='" + scourse.Text + "',status='" + comboBox1.Text + "' WHERE studentID =" + selectedSID;

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query, conn);
                comm1.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully updated the student", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadall();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                facID.Text = dataGridView2.Rows[e.RowIndex].Cells["schoolID"].Value.ToString();
                facfname.Text = dataGridView2.Rows[e.RowIndex].Cells["teacherFName"].Value.ToString();
                facstatus.Text = dataGridView2.Rows[e.RowIndex].Cells["status"].Value.ToString();
                faclname.Text = dataGridView2.Rows[e.RowIndex].Cells["teacherLName"].Value.ToString();
              
                selectedFID = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["teacherID"].Value.ToString());

                fcreate.Enabled = false;
                fdeselect.Enabled = true;
                fupdate.Enabled = true;

            }
        }

        private void fcreate_Click(object sender, EventArgs e)
        {
            if (facID.Text == "" || facfname.Text == "" || faclname.Text == "" || facstatus.Text == "")
            {
                MessageBox.Show("Please input required fields");
            }
            else
            {
                String query1 = "SELECT * FROM teacher WHERE schoolID='" + facID.Text + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query1, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("This ID already exists");

                }
                else
                {
                    string query2 = "INSERT INTO teacher(schoolID,teacherFName,teacherLName,status) " + "VALUES('" + facID.Text + "', '" + facfname.Text + "', '" + faclname.Text + "', '" + facstatus.Text + "')";

                    conn.Open();
                    MySqlCommand comm1 = new MySqlCommand(query2, conn);
                    comm1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Success", "Added New Faculty Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadall();
                }
            }
        }

        private void fdeselect_Click(object sender, EventArgs e)
        {
            deselect();
        }
    }
}
