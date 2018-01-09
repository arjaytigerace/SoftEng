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
    public partial class ChemMgtSearch : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public int index { get; set; }
        public string search { get; set; }
        public ChemMgtSearch()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void ChemMgtSearch_Load(object sender, EventArgs e)
        {
           
            if (index == 0)
            {
                string query = "SELECT chemRequestId,b.itemName,CONCAT(a.cqty,' ',a.measurementType) AS cqty,studentFName,studentLName,subject,c.yearCourse,teacherFName,teacherLName," +
                 "a.dateRequested,a.dateUpdated,CONCAT(e.firstname,' ',e.lastname) AS PreparedBy, CONCAT(f.firstname, ' ', f.lastname) AS LastUpdatedBy" +
                 " FROM chem_lab.chemrequest a INNER JOIN administrativeassociate e ON a.userID = e.admin_ID " +
                 "INNER JOIN administrativeassociate f ON a.lastUpdatedUser = f.admin_ID " + "JOIN item ON a.itemID=item.itemID AND item.itemName LIKE '"+search+"%',"+
                 " chem_lab.item b, chem_lab.student c, teacher d WHERE b.itemID = a.itemID" +
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
            }

            if (index == 1)
            {
                string query = "SELECT chemRequestId,b.itemName,CONCAT(a.cqty,' ',a.measurementType) AS cqty,studentFName,studentLName,subject,c.yearCourse,teacherFName,teacherLName," +
                 "a.dateRequested,a.dateUpdated,CONCAT(e.firstname,' ',e.lastname) AS PreparedBy, CONCAT(f.firstname, ' ', f.lastname) AS LastUpdatedBy" +
                 " FROM chem_lab.chemrequest a INNER JOIN administrativeassociate e ON a.userID = e.admin_ID " +
                 "INNER JOIN administrativeassociate f ON a.lastUpdatedUser = f.admin_ID, "+
                 "chem_lab.item b, chem_lab.student c, teacher d WHERE b.itemID =a.itemID"+
                 " AND c.studentID = a.studentId AND a.teacherId = d.teacherID AND a.subject LIKE '%"+search+"%'";

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

            }
            if (index == 2)
            {
                string query = "SELECT chemRequestId,b.itemName,CONCAT(a.cqty,' ',a.measurementType) AS cqty,c.studentFName,c.studentLName,subject,c.yearCourse,teacherFName,teacherLName," +
                 "a.dateRequested,a.dateUpdated,CONCAT(e.firstname,' ',e.lastname) AS PreparedBy, CONCAT(f.firstname, ' ', f.lastname) AS LastUpdatedBy" +
                 " FROM chem_lab.chemrequest a INNER JOIN administrativeassociate e ON a.userID = e.admin_ID " +
                 "INNER JOIN administrativeassociate f ON a.lastUpdatedUser = f.admin_ID " + "JOIN student ON a.studentId = student.studentID AND student.studentFName LIKE '"+search+"%',"+
                 "chem_lab.item b, chem_lab.student c, teacher d WHERE b.itemID = a.itemID" +
                 " AND c.studentID = a.studentID AND a.teacherId = d.teacherID";

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
            }

            if (index == 3)
            {
                string query = "SELECT chemRequestId,b.itemName,CONCAT(a.cqty,' ',a.measurementType) AS cqty,c.studentFName,c.studentLName,subject,c.yearCourse,teacherFName,teacherLName," +
                  "a.dateRequested,a.dateUpdated,CONCAT(e.firstname,' ',e.lastname) AS PreparedBy, CONCAT(f.firstname, ' ', f.lastname) AS LastUpdatedBy" +
                  " FROM chem_lab.chemrequest a INNER JOIN administrativeassociate e ON a.userID = e.admin_ID " +
                  "INNER JOIN administrativeassociate f ON a.lastUpdatedUser = f.admin_ID " + "JOIN student ON a.studentId = student.studentID AND student.studentLName LIKE '" + search + "%'," +
                  "chem_lab.item b, chem_lab.student c, teacher d WHERE b.itemID = a.itemID" +
                  " AND c.studentID = a.studentID AND a.teacherId = d.teacherID";

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
            }

        }
    }
}
