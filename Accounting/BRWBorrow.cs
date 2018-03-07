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
    public partial class BRWBorrow : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public int Adminid { get; set; }
        public string Getfname { get; set; }
        public string Getlname { get; set; }
        public String myDate;
        public BRWBorrow()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm:ss";
            dateTimePicker2.ShowUpDown = true;

            myDate = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker2.Value.ToString("HH:mm:ss");
            if (itemName.Text=="" || qty.Value==0 || sID.Text == "" || sFName.Text=="" || sLName.Text=="" || yc.Text=="")
            {
                MessageBox.Show("Please do not leave a field empty");
            }
            else
            {
                string query = "SELECT itemID, quantity from item where itemName ='" + itemName.Text+"' AND itemstatus='Active'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                bool hasRows = dt.Rows.GetEnumerator().MoveNext();
                if (hasRows)
                {
                    int itemid = Convert.ToInt32(dt.Rows[0]["itemID"].ToString());
                    if (qty.Value <= Convert.ToDecimal(dt.Rows[0]["quantity"].ToString()))
                    {

                        if (!checkStudent())
                        {
                            MessageBox.Show("Student Doesn't Exist!");

                        }
                        else
                        {

                            string query3 = "SELECT studentID from student WHERE schoolID = " + sID.Text;
                            conn.Open();
                            MySqlCommand comm3 = new MySqlCommand(query3, conn);
                            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                            conn.Close();
                            DataTable dt3 = new DataTable();
                            adp3.Fill(dt3);
                            int studentid = Convert.ToInt32(dt3.Rows[0]["studentID"].ToString());
                            DateTime dateValue = DateTime.Now;
                            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                            string queryrequest = "INSERT INTO borrowing(itemID,qty,measureType,borrowedDate,returnDate,studentId,requestStatus,releasedBy,isReturned) " + "VALUES('" + itemid + "', '" + qty.Value + "', '" + label6.Text+"','"+
                                date + "', '" + myDate + "', '" + studentid + "', 'Unreleased', '" + this.Adminid + "',0)";
                            conn.Open();
                            MySqlCommand commrequest = new MySqlCommand(queryrequest, conn);
                            commrequest.ExecuteNonQuery();
                            conn.Close();

                            string update = "UPDATE item SET quantity=quantity-" + qty.Value + " WHERE itemID=" + itemid;
                            conn.Open();
                            MySqlCommand commrequest1 = new MySqlCommand(update, conn);
                            commrequest1.ExecuteNonQuery();
                            conn.Close();

                            MessageBox.Show("Success", "Borrow Request Made", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not enough available quantity");
                    }
                }
                else
                {
                    MessageBox.Show("The item you entered does not exist or is inactive");
                }
            }

        }

        private Boolean checkStudent()
        {

            string query2 = "SELECT studentID from student WHERE schoolID=" + sID.Text;
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            bool hasRows2 = dt2.Rows.GetEnumerator().MoveNext();

            return hasRows2;

        }

        private void BRWBorrow_Load(object sender, EventArgs e)
        {
            qty.Maximum = 9999;
            qty.Minimum = 0;
            label1.Text = DateTime.Now.ToString();
            

            sFName.ReadOnly = true;
            sLName.ReadOnly = true;
            yc.ReadOnly = true;
            label9.Text = this.Getfname + " " + this.Getlname;
            autocomplete();

        }

        private void autocomplete()
        {
            itemName.AutoCompleteMode = AutoCompleteMode.Suggest;
            itemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            itemName.AutoCompleteCustomSource = DataCollection;


            sID.AutoCompleteMode = AutoCompleteMode.Suggest;
            sID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection2 = new AutoCompleteStringCollection();
            getStudentData(DataCollection2);
            sID.AutoCompleteCustomSource = DataCollection2;

        }

        private void getStudentData(AutoCompleteStringCollection dataCollection)
        {


            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "SELECT schoolID FROM student";


            conn.Open();
            command = new MySqlCommand(sql, conn);
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();
            conn.Close();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataCollection.Add(row[0].ToString());
            }


        }

        private void getData(AutoCompleteStringCollection dataCollection)
        {


            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "SELECT itemName FROM item where (itemTypeID=1 OR itemTypeID=2) AND itemstatus='Active'";


            conn.Open();
            command = new MySqlCommand(sql, conn);
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();
            conn.Close();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataCollection.Add(row[0].ToString());
            }


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void itemName_Leave(object sender, EventArgs e)
        {
            string query3 = "SELECT quantity,measurementType from item WHERE itemName='" + itemName.Text + "' AND itemstatus='Active'";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                label6.Text = dt3.Rows[0]["measurementType"].ToString();
                label14.Text= dt3.Rows[0]["quantity"].ToString();
            }

        }

        private void sID_Leave(object sender, EventArgs e)
        {
            string query3 = "SELECT studentFName, studentLName, yearCourse from student WHERE schoolID='" + sID.Text + "'";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                sFName.Text = dt3.Rows[0]["studentFName"].ToString();
                sLName.Text = dt3.Rows[0]["studentLName"].ToString();
                yc.Text = dt3.Rows[0]["yearCourse"].ToString();
            }
            else
            {
                sFName.Text = "";
                sLName.Text = "";
                yc.Text = "";
            }
        }
    }
}
