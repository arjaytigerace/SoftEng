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
        public string status;
        public int studentPK;
        public int teacherPK;
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

            string query = "SELECT chemRequestId,b.itemName,CONCAT(a.cqty,' ',a.measurementType) AS cqty,studentFName,studentLName,c.studentId,d.teacherId,subject,c.yearCourse,teacherFName,teacherLName," +
                "a.dateRequested,a.dateUpdated,CONCAT(e.firstname,' ',e.lastname) AS PreparedBy, CONCAT(f.firstname, ' ', f.lastname) AS LastUpdatedBy, a.status" +
                " FROM chem_lab.chemrequest a INNER JOIN administrativeassociate e ON a.userID = e.admin_ID " +
                "INNER JOIN administrativeassociate f ON a.lastUpdatedUser = f.admin_ID," +
                "chem_lab.item b, chem_lab.student c, teacher d WHERE b.itemID = a.itemID" +
                " AND c.studentID = a.studentId AND a.teacherId = d.teacherID";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["chemRequestId"].Visible = false;
            dataGridView1.Columns["studentId"].Visible = false;
            dataGridView1.Columns["teacherId"].Visible = false;
            dataGridView1.Columns["itemName"].HeaderText = "Item Name";
            dataGridView1.Columns["itemName"].Width = 150;
            dataGridView1.Columns["cqty"].HeaderText = "QTY Requested";
            dataGridView1.Columns["cqty"].Width = 90;
            dataGridView1.Columns["studentFName"].HeaderText = "Student First Name";
            dataGridView1.Columns["studentLName"].HeaderText = "Student Last Name";
            dataGridView1.Columns["yearCourse"].HeaderText = "Course";
            dataGridView1.Columns["teacherFName"].HeaderText = "Teacher First Name";
            dataGridView1.Columns["teacherLName"].HeaderText = "Teacher Last Name";
            dataGridView1.Columns["subject"].HeaderText = "Subject";
            dataGridView1.Columns["chemRequestId"].Visible = false;
            dataGridView1.Columns["dateRequested"].HeaderText = "Date Requested";
            dataGridView1.Columns["dateUpdated"].HeaderText = "Date Updated";
            dataGridView1.Columns["PreparedBy"].HeaderText = "Prepared By";
            dataGridView1.Columns["LastUpdatedBy"].HeaderText = "Last Updated By";
            dataGridView1.Columns["status"].HeaderText = "Status";

            dataGridView1.ClearSelection();
            specificsearch.SelectedIndex = 0;
            button3.Enabled = false;

            string query1 = "SELECT COUNT(*) from chemrequest";

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            rnum.Text= dt1.Rows[0]["COUNT(*)"].ToString();


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
            chemupd.Adminid = this.Adminid;
            chemupd.uchemname = chemname;
            chemupd.uqty = qty;
            chemupd.utfname = tfname;
            chemupd.utlname = tlname;
            chemupd.usubj = subj;
            chemupd.usfname = sfname;
            chemupd.uslname = slname;
            chemupd.uyearcourse = yearcourse;
            chemupd.umeasuretype = measuretype;
            chemupd.status = status;
            chemupd.Getfname = this.Getfname;
            chemupd.Getlname = this.Getlname;
            chemupd.FacultyID = this.teacherPK;
            chemupd.studID = this.studentPK;
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

                string query = "select cqty, measurementType from chemrequest where chemRequestId=" + requestid;
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                teacherPK = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["teacherId"].Value.ToString());
                studentPK = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["studentId"].Value.ToString());
                chemname = dataGridView1.Rows[e.RowIndex].Cells["itemName"].Value.ToString();
                qty = Convert.ToInt32(dt.Rows[0]["cqty"].ToString());
                measuretype = dt.Rows[0]["measurementType"].ToString();
                tfname = dataGridView1.Rows[e.RowIndex].Cells["teacherFName"].Value.ToString();
                tlname = dataGridView1.Rows[e.RowIndex].Cells["teacherLName"].Value.ToString();
                subj = dataGridView1.Rows[e.RowIndex].Cells["subject"].Value.ToString();
                sfname = dataGridView1.Rows[e.RowIndex].Cells["studentFName"].Value.ToString();
                slname = dataGridView1.Rows[e.RowIndex].Cells["studentLName"].Value.ToString();
                yearcourse = dataGridView1.Rows[e.RowIndex].Cells["yearCourse"].Value.ToString();
                status= dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString();


                if (status == "Released")
                {
                    button3.Enabled = false;
                }
                else
                {
                    button3.Enabled = true;
                }
            }
        }

        private void searchchem_Click(object sender, EventArgs e)
        {
            ChemMgtSearch chemsearch = new ChemMgtSearch();

            chemsearch.main = this;
            chemsearch.index = specificsearch.SelectedIndex;
            chemsearch.search = searchc.Text;
            chemsearch.Show();
        }

        private void searchc_TextChanged(object sender, EventArgs e)
        {

        }

        private void specificsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
