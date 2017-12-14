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
    public partial class ChemicalManagement : Form
    {
        public int requestid;
        public String date;
        public String chemname;
        public int qty;
        public String tfname;
        public String tlname;
        public String subj;
        public String sfname;
        public String slname;
        public String yearcourse;
        public String measuretype;
        public Form main { get; set; }
        public string Getfname { get; set; }
        public string Getlname { get; set; }
        public int Adminid { get; set; }
        MySqlConnection conn;
        public ChemicalManagement()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void ChemicalManagement_Load(object sender, EventArgs e)
        {
            
            Loadall();
        }

        public void Loadall()
        {

            string query = "SELECT chemRequestId,b.itemName,a.cqty,a.measurementType,studentFName,studentLName,subject,c.yearCourse,teacherFName,teacherLName,a.dateRequested FROM chem_lab.chemrequest a, " +
                "chem_lab.item b, chem_lab.student c,teacher d WHERE b.itemID = a.itemID " +
                "AND c.studentID = a.studentId AND a.teacherId = d.teacherID";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["chemRequestId"].Visible = false;

            dataGridView1.Columns["itemName"].HeaderText = "Item Name";
            dataGridView1.Columns["cqty"].HeaderText = "Quantity Requested";
            dataGridView1.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView1.Columns["studentFName"].HeaderText = "Student First Name";
            dataGridView1.Columns["studentLName"].HeaderText = "Student Last Name";
            dataGridView1.Columns["teacherFName"].Visible = false;
            dataGridView1.Columns["teacherLName"].Visible = false;
            dataGridView1.Columns["subject"].Visible = false;
            dataGridView1.Columns["chemRequestId"].Visible = false;
            dataGridView1.Columns["dateRequested"].HeaderText = "Date Requested";

            dataGridView1.ClearSelection();
            button3.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChemicalManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChemMgtCreate chemcreate = new ChemMgtCreate();
            chemcreate.Getfname = this.Getfname;
            chemcreate.Getlname = this.Getlname;
            chemcreate.Adminid = this.Adminid;
            chemcreate.main = this;
            chemcreate.Show();
            //this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChemMgtUpdate chemupd = new ChemMgtUpdate();
            chemupd.main = this;
            chemupd.Requestid = requestid;
            chemupd.uchemname = chemname;
            chemupd.uqty = qty;
            chemupd.utfname = tfname;
            chemupd.utlname = tlname;
            chemupd.usubj = subj;
            chemupd.usfname = sfname;
            chemupd.uslname = slname;
            chemupd.uyearcourse = yearcourse;
            chemupd.umeasuretype = measuretype;
            //chemupd.date = date;
            chemupd.Show();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ChemicalManagement_Leave(object sender, EventArgs e)
        {
           
        }

        private void ChemicalManagement_Shown(object sender, EventArgs e)
        {
          
        }

        private void ChemicalManagement_Activated(object sender, EventArgs e)
        {
            Loadall();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                requestid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["chemRequestId"].Value.ToString());
                chemname = dataGridView1.Rows[e.RowIndex].Cells["itemName"].Value.ToString();
                qty = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["cqty"].Value.ToString());
                tfname = dataGridView1.Rows[e.RowIndex].Cells["teacherFName"].Value.ToString();
                tlname = dataGridView1.Rows[e.RowIndex].Cells["teacherLName"].Value.ToString();
                subj = dataGridView1.Rows[e.RowIndex].Cells["subject"].Value.ToString();
                sfname = dataGridView1.Rows[e.RowIndex].Cells["studentFName"].Value.ToString();
                slname = dataGridView1.Rows[e.RowIndex].Cells["studentLName"].Value.ToString();
                yearcourse = dataGridView1.Rows[e.RowIndex].Cells["yearCourse"].Value.ToString();
                measuretype = dataGridView1.Rows[e.RowIndex].Cells["measurementType"].Value.ToString();
                
                button3.Enabled = true;
            }
        }
    }
}
