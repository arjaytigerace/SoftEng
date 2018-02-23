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
    public partial class BorrowingChem : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public int Adminid { get; set; }
        public string Getfname { get; set; }
        public string Getlname { get; set; }
        public BorrowingChem()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BorrowingChem_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BRWBorrow borrow = new BRWBorrow();
            borrow.main = this;
            borrow.Adminid = this.Adminid;
            borrow.Getfname = this.Getfname;
            borrow.Getlname = this.Getlname;
            borrow.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            returnbutton returnform = new returnbutton();
            returnform.main = this;
            returnform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BRWupdate borrowupd = new BRWupdate();
            borrowupd.main = this;
            borrowupd.Show();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void BorrowingChem_Load(object sender, EventArgs e)
        {

            Loadall();


        }

        public void Loadall()
        {

            string query = "SELECT borrowRequestId,b.itemName,CONCAT(a.qty,' ',a.measureType) AS qty,CONCAT(studentFName,' ',studentLName) AS student,c.studentId,c.yearCourse," +
                "a.borrowedDate,a.returnDate,CONCAT(e.firstname,' ',e.lastname) AS releasedBy, a.requestStatus" +
                " FROM chem_lab.borrowing a INNER JOIN administrativeassociate e ON a.releasedBy = e.admin_ID, " +         
                "chem_lab.item b, chem_lab.student c WHERE b.itemID = a.itemID" +
                " AND c.studentID = a.studentId";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["borrowRequestId"].Visible = false;
            dataGridView1.Columns["studentId"].Visible = false;
    
            dataGridView1.Columns["itemName"].HeaderText = "Item Name";
            dataGridView1.Columns["itemName"].Width = 150;
            dataGridView1.Columns["qty"].HeaderText = "QTY Requested";
            dataGridView1.Columns["qty"].Width = 90;
            dataGridView1.Columns["student"].HeaderText = "Borrowed By";
            dataGridView1.Columns["yearCourse"].HeaderText = "Course";
            dataGridView1.Columns["borrowedDate"].HeaderText = "Date Borrowed";
      
            dataGridView1.Columns["returnDate"].HeaderText = "Expected Return Date";
            dataGridView1.Columns["releasedBy"].HeaderText = "Released By";
            dataGridView1.Columns["requestStatus"].HeaderText = "Status";

            dataGridView1.ClearSelection();

           

            string query1 = "SELECT COUNT(*) from borrowing";

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            label2.Text = dt1.Rows[0]["COUNT(*)"].ToString();



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BRWupdate update = new BRWupdate();
            update.main = this;
            update.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Loadall();
        }
    }
}
