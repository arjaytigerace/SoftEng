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
        public int brequestid;
        public int studentid;
        public String itemname;
        public decimal qty;
        public String measuretype;
        public String sfname;
        public String slname;
        public String yearcourse;
        public String status;
        public String borrowdate;
        public String ereturndate;
        public String[] expectedreturn;

        public BorrowingChem()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                brequestid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["borrowRequestId"].Value.ToString());

                string query = "select qty, measureType, studentFName, studentLName from borrowing,student where borrowRequestId=" + brequestid+" AND student.studentID=borrowing.studentId";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                 
                studentid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["schoolId"].Value.ToString());
                itemname = dataGridView1.Rows[e.RowIndex].Cells["itemName"].Value.ToString();
                qty = Convert.ToDecimal(dt.Rows[0]["qty"].ToString());
                measuretype = dt.Rows[0]["measureType"].ToString();

                
                sfname = dt.Rows[0]["studentFName"].ToString();
                slname = dt.Rows[0]["studentLName"].ToString();
                yearcourse = dataGridView1.Rows[e.RowIndex].Cells["yearCourse"].Value.ToString();
                status = dataGridView1.Rows[e.RowIndex].Cells["requestStatus"].Value.ToString();
                borrowdate= dataGridView1.Rows[e.RowIndex].Cells["borrowedDate"].Value.ToString();
                ereturndate= dataGridView1.Rows[e.RowIndex].Cells["returnDate"].Value.ToString();
                expectedreturn = ereturndate.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                

                if (status == "Released")
                {
                    button3.Enabled = false;
                    button4.Enabled = true;
                    
                }
                else if (status == "Cancelled" || status == "Returned")
                {

                    button3.Enabled = false;
                    button4.Enabled = false;

                }
                else if(status == "Unreleased")
                {
                    button3.Enabled = true;
                    button4.Enabled = false;
                }
            }
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

            returnform.returnitem = itemname;
            returnform.qty = qty;
            returnform.mtype = measuretype;
            returnform.borrowdate = borrowdate;
            returnform.borrowid = brequestid;
            returnform.Adminid = this.Adminid;
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
            string query = "SELECT borrowRequestId,b.itemName,CONCAT(a.qty,' ',a.measureType) AS qty,CONCAT(studentFName,' ',studentLName) AS student,c.schoolId,c.yearCourse," +
            "a.borrowedDate,a.returnDate,CONCAT(e.firstname,' ',e.lastname) AS releasedBy,c.studentId, a.requestStatus, a.remarks" +
             " FROM chem_lab.borrowing a INNER JOIN administrativeassociate e ON a.releasedBy = e.admin_ID, " +
             "chem_lab.item b, chem_lab.student c WHERE b.itemID = a.itemID" +
             " AND c.studentID = a.studentId AND a.requestStatus!='Returned'";

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
            dataGridView1.Columns["student"].HeaderText = "Borrowed By";
            dataGridView1.Columns["yearCourse"].HeaderText = "Course";
            dataGridView1.Columns["borrowedDate"].HeaderText = "Date Borrowed";
      
            dataGridView1.Columns["returnDate"].HeaderText = "Expected Return Date";
            dataGridView1.Columns["releasedBy"].HeaderText = "Released By";
            dataGridView1.Columns["requestStatus"].HeaderText = "Status";
            dataGridView1.Columns["remarks"].HeaderText = "Remarks";
            dataGridView1.ClearSelection();

           

            string query1 = "SELECT COUNT(*) from borrowing WHERE requestStatus!='Returned'";

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            label2.Text = dt1.Rows[0]["COUNT(*)"].ToString();

            button3.Enabled = false;
            button4.Enabled = false;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BRWupdate update = new BRWupdate();
            update.main = this;
            update.Adminid = this.Adminid;
            update.Getfname = this.Getfname;
            update.Getlname = this.Getlname;
            update.brequestid = this.brequestid;
            update.studentid = this.studentid;
            update.itemname = this.itemname;
            update.quantity = this.qty;
            update.measuretype = this.measuretype;
            update.sfname = this.sfname;
            update.slname = this.slname;
            update.yearcourse = this.yearcourse;
            update.status = this.status;
            update.borrowdate = this.borrowdate;
            update.expectedreturndate = expectedreturn[0];
            update.expectedreturntime = expectedreturn[1];
            update.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void refresh_Click(object sender, EventArgs e)
        {
            string query = "SELECT borrowRequestId,b.itemName,CONCAT(a.qty,' ',a.measureType) AS qty,CONCAT(studentFName,' ',studentLName) AS student,c.schoolId,c.yearCourse," +
            "a.borrowedDate,a.returnDate,CONCAT(e.firstname,' ',e.lastname) AS releasedBy,c.studentId, a.requestStatus, a.remarks" +
             " FROM chem_lab.borrowing a INNER JOIN administrativeassociate e ON a.releasedBy = e.admin_ID, " +
             "chem_lab.item b, chem_lab.student c WHERE b.itemID = a.itemID" +
             " AND c.studentID = a.studentId AND requestStatus!='Returned'";

            Loadall(query);
        }

        private void searchborrow_Click(object sender, EventArgs e)
        {
            string query = "SELECT borrowRequestId,b.itemName,CONCAT(a.qty,' ',a.measureType) AS qty,CONCAT(studentFName,' ',studentLName) AS student,c.schoolId,c.yearCourse," +
            "a.borrowedDate,a.returnDate,CONCAT(e.firstname,' ',e.lastname) AS releasedBy,c.studentId, a.requestStatus, a.remarks" +
            " FROM chem_lab.borrowing a INNER JOIN administrativeassociate e ON a.releasedBy = e.admin_ID " + "JOIN item ON a.itemID=item.itemID AND item.itemName LIKE '" + search.Text + "%'," +
            "chem_lab.item b, chem_lab.student c WHERE b.itemID = a.itemID"+
            " AND c.studentID = a.studentId AND requestStatus!='Returned'";

            Loadall(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnedItems ritems = new ReturnedItems();
            ritems.main = this;
            ritems.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            CRPBorrowingManagment genallrep = new CRPBorrowingManagment();
            genallrep.main = this;
            genallrep.Show();
        }
    }
}
