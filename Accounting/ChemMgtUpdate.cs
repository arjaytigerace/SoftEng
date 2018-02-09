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
    public partial class ChemMgtUpdate : Form
    {
        public Form main { get; set; }
        public int Requestid { get; set; }
        public int uqty { get; set; }
        public int oldqty { get; set; }
        public string oldchem { get; set; }
        public String utfname { get; set; }
        public String utlname { get; set; }
        public String uchemname { get; set; }
        public String usubj { get; set; }
        public String date { get; set; }
        public String usfname { get; set; }
        public String uslname { get; set; }
        public String uyearcourse { get; set; }
        public String umeasuretype { get; set; }
        public string Getfname { get; set; }
        public string Getlname { get; set; }
        public int Adminid { get; set; }
        public String status {get;set;}
        public int FacultyID { get; set; }
        public int studID { get; set; }

        MySqlConnection conn;
        public ChemMgtUpdate()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void ChemMgtUpdate_Load(object sender, EventArgs e)
        {

            cqty.Minimum = 0;
            cqty.Maximum = 9999;
            chemname.Text = this.uchemname;
            cqty.Value = this.uqty;
            oldqty = this.uqty;
            oldchem = this.uchemname;
            tFName.Text = this.utfname;
            tLName.Text = this.utlname;
            subj.Text = this.usubj;
            sFName.Text = this.usfname;
            sLName.Text = this.uslname;
            yearcourse.Text = this.uyearcourse;
            mtype.Text = this.umeasuretype;
            user.Text = this.Getfname + " " + this.Getlname;
            sID.Text = getStudentID();
            facID.Text = getFacID();
            rstatus.SelectedIndex = 0;
            autocomplete();

            tFName.ReadOnly = true;
            tLName.ReadOnly = true;
            sFName.ReadOnly = true;
            sLName.ReadOnly = true;
            yearcourse.ReadOnly = true;

        }

        private String getStudentID()
        {
            string query2 = "SELECT schoolID from student WHERE studentId=" + studID;
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            return dt2.Rows[0]["schoolID"].ToString();


        }
        private String getFacID()
        {
            string query2 = "SELECT schoolID from teacher WHERE teacherId=" + FacultyID;
            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            return dt2.Rows[0]["schoolID"].ToString();


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
        private void autocomplete()
        {
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

        }



        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (cqty.Value == 0 || chemname.Text == "" || tFName.Text == "" || tLName.Text == "" || subj.Text == "" || sLName.Text == "" || sFName.Text == "" || yearcourse.Text == "" || rstatus.Text=="")
            {
                MessageBox.Show("Please do not leave a field empty");

            }
            else
            {
                string query = "SELECT itemID, quantity from item where itemName ='" + chemname.Text + "' AND itemTypeID=3";
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

                    if (cqty.Value <= Convert.ToInt32(dt.Rows[0]["quantity"].ToString()))
                    {
                        if (!checkTeacher() || !checkStudent())
                        {
                            MessageBox.Show("Teacher or Student Doesn't Exist!");

                        }
                        else
                        {

                            string query2 = "SELECT teacherID,teacherFName,teacherLName from teacher WHERE schoolID=" + facID.Text;
                            conn.Open();
                            MySqlCommand comm2 = new MySqlCommand(query2, conn);
                            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                            conn.Close();
                            DataTable dt2 = new DataTable();
                            adp2.Fill(dt2);

                            int teacherid = Convert.ToInt32(dt2.Rows[0]["teacherID"].ToString());
                            

                            string query3 = "SELECT studentID from student WHERE schoolID=" + sID.Text;
                            conn.Open();
                            MySqlCommand comm3 = new MySqlCommand(query3, conn);
                            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                            conn.Close();
                            DataTable dt3 = new DataTable();
                            adp3.Fill(dt3);

                            int studentid = Convert.ToInt32(dt3.Rows[0]["studentID"].ToString());

                            //updating
                            DateTime dateValue = DateTime.Now;
                            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                            conn.Open();

                            string queryrequest = "UPDATE chemrequest SET itemID = '" + itemid + "', cqty = '" + cqty.Value + "', measurementType='"+ mtype.Text+"', teacherId = '" + teacherid + "',studentId = '" + studentid +
                            "', subject='" + subj.Text + "', dateUpdated='" + date + "', lastUpdatedUser='" + this.Adminid + "',status='" + rstatus.Text + "' WHERE chemRequestId = '" + Requestid + "'";


                            MySqlCommand commrequest = new MySqlCommand(queryrequest, conn);
                            commrequest.ExecuteNonQuery();
                            conn.Close();

                            if (rstatus.SelectedIndex == 1) { 
                                conn.Open();

                                string updateqty = "UPDATE item SET quantity = quantity -" + cqty.Value + " WHERE itemID='" + itemid + "'";

                                MySqlCommand commupdate = new MySqlCommand(updateqty, conn);
                                commupdate.ExecuteNonQuery();
                                conn.Close();

                                MessageBox.Show("Success", "Request Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Success", "Request Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantity is not enough");
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
        
        private void chemname_TextChanged(object sender, EventArgs e)
        {
           


        }

        private void chemname_ControlRemoved(object sender, ControlEventArgs e)
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
                mtype.Text = dt3.Rows[0]["measurementType"].ToString();
            }
            else
            {
                MessageBox.Show("Item is not a chemical");
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
    }


}
