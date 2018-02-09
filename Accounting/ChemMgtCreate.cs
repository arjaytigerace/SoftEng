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
    public partial class ChemMgtCreate : Form
    {
        
        public Form main { get; set; }
        MySqlConnection conn;
        public string Getfname { get; set; }
        public string Getlname { get; set; }
        public int Adminid { get; set; }
        public ChemMgtCreate()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }



        private void ChemMgtCreate_Load(object sender, EventArgs e)
        {
            cqty.Minimum = 0;
            cqty.Maximum = 9999;
            user.Text = this.Getfname + " " + this.Getlname;
            label12.Text = "";

            chemname.AutoCompleteMode = AutoCompleteMode.Suggest;
            chemname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            chemname.AutoCompleteCustomSource = DataCollection;

            facID.AutoCompleteMode = AutoCompleteMode.Suggest;
            facID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection1 = new AutoCompleteStringCollection();
            getTeacherData(DataCollection1);
            facID.AutoCompleteCustomSource = DataCollection1;

            sID.AutoCompleteMode = AutoCompleteMode.Suggest;
            sID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection2 = new AutoCompleteStringCollection();
            getStudentData(DataCollection2);
            sID.AutoCompleteCustomSource = DataCollection2;

            tFName.ReadOnly = true;
            tLName.ReadOnly = true;
            sFName.ReadOnly = true;
            sLName.ReadOnly = true;
            yearcourse.ReadOnly = true;
        }

        private void getData(AutoCompleteStringCollection dataCollection)
        {
     
      
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();
           
            string sql = "SELECT itemName FROM item where itemTypeID=3";

 
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
        private void getTeacherData(AutoCompleteStringCollection dataCollection)
        {


            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "SELECT schoolID FROM teacher";


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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if(facID.Text=="" || sID.Text=="" || cqty.Value==0 || chemname.Text=="" || tFName.Text == "" || tLName.Text==""|| subj.Text=="" || sLName.Text=="" || sFName.Text==""||yearcourse.Text=="")
            {
                MessageBox.Show("Please do not leave a field empty");

            }
            else
            {
                string query = "SELECT itemID, quantity from item where itemName ='"+chemname.Text+"' AND itemTypeID=3";

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
                
                    if (cqty.Value<= Convert.ToInt32(dt.Rows[0]["quantity"].ToString()))
                    {
                        if (!checkTeacher() || !checkStudent())
                        {
                            MessageBox.Show("Teacher or Student Doesn't Exist!");

                        }

                        else
                        {
                            //get teacher id
                            string query2 = "SELECT teacherID from teacher WHERE schoolID="+facID.Text;
                            conn.Open();
                            MySqlCommand comm2 = new MySqlCommand(query2, conn);
                            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                            conn.Close();
                            DataTable dt2 = new DataTable();
                            adp2.Fill(dt2);

                            int teacherid = Convert.ToInt32(dt2.Rows[0]["teacherID"].ToString());

                            //get student id
                            string query3 = "SELECT studentID from student WHERE schoolID = " + sID.Text;
                            conn.Open();
                            MySqlCommand comm3 = new MySqlCommand(query3, conn);
                            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                            conn.Close();
                            DataTable dt3 = new DataTable();
                            adp3.Fill(dt3);

                            int studentid = Convert.ToInt32(dt3.Rows[0]["studentID"].ToString());

                            //inserting
                            DateTime dateValue = DateTime.Now;
                            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                            conn.Open();

                            string queryrequest = "INSERT INTO chemrequest(itemID,cqty,measurementType,teacherId,studentId,subject,dateRequested,userID,dateUpdated,lastUpdatedUser,status) " + "VALUES('" + itemid + "', '" + cqty.Value + "', '" +
                                label12.Text + "', '" + teacherid + "', '" + studentid + "', '" + subj.Text + "', '" + date + "', '" + this.Adminid + "', '" + date + "', '" + this.Adminid + "', 'Unreleased')";

                            MySqlCommand commrequest = new MySqlCommand(queryrequest, conn);
                            commrequest.ExecuteNonQuery();
                            conn.Close();
                            /*
                            conn.Open();

                            string updateqty = "UPDATE item SET quantity = quantity - " + cqty.Value + " WHERE itemID='" + itemid + "'";

                            MySqlCommand commupdate = new MySqlCommand(updateqty, conn);
                            commupdate.ExecuteNonQuery();
                            conn.Close();*/

                            MessageBox.Show("Success", "Request Made", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //main.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chemical does not have enough Quantity");
                    }

                }
                else
                {
                    MessageBox.Show("The item you entered isn't a chemical");
                }


            }
        }

        private Boolean checkTeacher()
        {

            string query2 = "SELECT teacherID from teacher WHERE schoolID=" + facID.Text;
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            bool hasRows2 = dt2.Rows.GetEnumerator().MoveNext();

            return hasRows2;

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

        private void tFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cqty_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ChemMgtCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chemname_Leave(object sender, EventArgs e)
        {
            string query3 = "SELECT measurementType from item WHERE itemName='" + chemname.Text + "'";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                label12.Text = dt3.Rows[0]["measurementType"].ToString();
            }
            else
            {
                MessageBox.Show("Item is not a chemical");
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
                yearcourse.Text = dt3.Rows[0]["yearCourse"].ToString();
            }



        }

        private void facID_Leave(object sender, EventArgs e)
        {
            string query3 = "SELECT teacherFName, teacherLName from teacher WHERE schoolID='" + facID.Text + "'";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                tFName.Text = dt3.Rows[0]["teacherFName"].ToString();
                tLName.Text = dt3.Rows[0]["teacherLName"].ToString();
               
            }

        }
    }
}
