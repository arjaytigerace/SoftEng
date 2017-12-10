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
            loadall();
        }

        public void loadall()
        {

            string query = "SELECT b.itemName,a.cqty,a.measurementType,studentFName,studentLName,a.dateRequested FROM chem_lab.chemrequest a, " +
                "chem_lab.item b, chem_lab.student c WHERE b.itemID = a.itemID " +
                "AND c.studentID = a.studentId";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["itemName"].HeaderText = "Item Name";
            dataGridView1.Columns["cqty"].HeaderText = "Quantity Requested";
            dataGridView1.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView1.Columns["studentFName"].HeaderText = "Student First Name";
            dataGridView1.Columns["studentLName"].HeaderText = "Student Last Name";
            dataGridView1.Columns["dateRequested"].HeaderText = "Date Requested";

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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChemMgtUpdate chemupd = new ChemMgtUpdate();
            chemupd.main = this;
            chemupd.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
