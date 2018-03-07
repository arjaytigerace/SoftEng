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
    public partial class Notification : Form
    {
        MySqlConnection conn;
        public Form main { get; set; }
        public Notification()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");

        }

        private void Notification_Load(object sender, EventArgs e)
        {
            string query = "SELECT itemName,quantity,measurementType,criticalLevel from item where quantity<=criticalLevel";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["itemName"].HeaderText = "Item Name";
            dataGridView1.Columns["quantity"].HeaderText = "Quantity";
            dataGridView1.Columns["quantity"].Width = 70;
            dataGridView1.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView1.Columns["criticalLevel"].HeaderText = "Critical Level";



            string query1 = "SELECT borrowRequestId,b.itemName,CONCAT(a.qty,' ',a.measureType) AS qty,CONCAT(studentFName,' ',studentLName) AS student,c.schoolId,c.yearCourse," +
            "a.borrowedDate,a.returnDate,CONCAT(e.firstname,' ',e.lastname) AS releasedBy,c.studentId, a.requestStatus" +
             " FROM chem_lab.borrowing a INNER JOIN administrativeassociate e ON a.releasedBy = e.admin_ID, " +
             "chem_lab.item b, chem_lab.student c WHERE b.itemID = a.itemID" +
            " AND c.studentID = a.studentId AND a.isReturned=0 AND requestStatus='Released' AND a.returnDate < NOW()";


            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = dt1;

            dataGridView2.Columns["borrowRequestId"].Visible = false;
            dataGridView2.Columns["schoolId"].Visible = false;
            dataGridView2.Columns["studentId"].Visible = false;
            dataGridView2.Columns["itemName"].HeaderText = "Item Name";
            dataGridView2.Columns["itemName"].Width = 150;
            dataGridView2.Columns["qty"].HeaderText = "QTY Requested";
            dataGridView2.Columns["qty"].Width = 90;
            dataGridView2.Columns["student"].HeaderText = "Borrowed By";
            dataGridView2.Columns["yearCourse"].HeaderText = "Course";
            dataGridView2.Columns["borrowedDate"].HeaderText = "Date Borrowed";
            dataGridView2.Columns["returnDate"].HeaderText = "Expected Return Date";
            dataGridView2.Columns["releasedBy"].HeaderText = "Released By";
            dataGridView2.Columns["requestStatus"].HeaderText = "Status";

        }
    }
}
