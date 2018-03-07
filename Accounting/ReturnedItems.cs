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
    public partial class ReturnedItems : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public ReturnedItems()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void ReturnedItems_Load(object sender, EventArgs e)
        {

            string query = "SELECT returnrequests.borrowRequestId,b.itemName,CONCAT(a.qty,' ',a.measureType) AS qty,returnrequests.numdmg,CONCAT(studentFName,' ',studentLName) AS student,c.schoolId,c.yearCourse,"+
            "a.borrowedDate,returnrequests.returnDate, CONCAT(e.firstname, ' ', e.lastname) AS releasedBy, returnrequests.remarks,c.studentId"+
          " FROM chem_lab.borrowing a, returnrequests INNER JOIN administrativeassociate e ON returnrequests.userId = e.admin_ID,"+
            "chem_lab.item b, chem_lab.student c WHERE b.itemID = a.itemID"+
            " AND c.studentID = a.studentId AND a.requestStatus = 'Returned' AND a.borrowRequestId = returnrequests.borrowRequestId";

            Loadall(query);

        }

        public void Loadall(String query)
        {

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["borrowRequestId"].Visible = false;
            dataGridView1.Columns["schoolId"].Visible = false;
            dataGridView1.Columns["studentId"].Visible = false;
            dataGridView1.Columns["itemName"].HeaderText = "Item Name";
            dataGridView1.Columns["itemName"].Width = 150;
            dataGridView1.Columns["qty"].HeaderText = "QTY Requested";
            dataGridView1.Columns["qty"].Width = 90;
            dataGridView1.Columns["numdmg"].HeaderText = "# Damaged";
            dataGridView1.Columns["student"].HeaderText = "Borrowed By";
            dataGridView1.Columns["yearCourse"].HeaderText = "Course";
            dataGridView1.Columns["borrowedDate"].HeaderText = "Date Borrowed";
            dataGridView1.Columns["returnDate"].HeaderText = "Date Returned";
            
            dataGridView1.Columns["releasedBy"].HeaderText = "Released By";
            

            dataGridView1.ClearSelection();


            /*
            string query1 = "SELECT COUNT(*) from borrowing";

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            //label2.Text = dt1.Rows[0]["COUNT(*)"].ToString();

           // button3.Enabled = false;

    */
        }

    }
}
