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

            chemname.AutoCompleteMode = AutoCompleteMode.Suggest;
            chemname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            chemname.AutoCompleteCustomSource = DataCollection;
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
            if(cqty.Value==0 || chemname.Text=="" || tFName.Text == "" || tLName.Text==""|| subj.Text=="" || sLName.Text=="" || sFName.Text==""||yearcourse.Text=="")
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
                        if (!checkTeacher())
                        {
                            string queryteacher = "INSERT INTO teacher(teacherFName,teacherLName) " + "VALUES('" + tFName.Text + "', '" + tLName.Text + "')";

                            conn.Open();
                            MySqlCommand commteacher = new MySqlCommand(queryteacher, conn);
                            commteacher.ExecuteNonQuery();
                            conn.Close();

                        }

                        string query2 = "SELECT teacherID from teacher WHERE teacherFName='" + tFName.Text + "' AND teacherLName='" + tLName.Text + "'";
                        conn.Open();
                        MySqlCommand comm2 = new MySqlCommand(query2, conn);
                        MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                        conn.Close();
                        DataTable dt2 = new DataTable();
                        adp2.Fill(dt2);

                        int teacherid = Convert.ToInt32(dt2.Rows[0]["teacherID"].ToString());
                        if (!checkStudent())
                        {
                            string querystudent = "INSERT INTO student(studentFName,studentLName,yearCourse) " + "VALUES('" + sFName.Text + "', '" + sLName.Text + "', '" + yearcourse.Text + "')";

                            conn.Open();
                            MySqlCommand commstudent = new MySqlCommand(querystudent, conn);
                            commstudent.ExecuteNonQuery();
                            conn.Close();


                        }

                        string query3 = "SELECT studentID from student WHERE studentFName='" + sFName.Text + "' AND studentLName='" + sLName.Text + "' AND yearCourse='" + yearcourse.Text + "'";
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

                        string queryrequest = "INSERT INTO chemrequest(itemID,cqty,measurementType,teacherId,studentId,subject,dateRequested,userID,dateUpdated,lastUpdatedUser) " + "VALUES('" + itemid + "', '" + cqty.Value + "', '" +
                            mtype.Text + "', '" + teacherid + "', '" + studentid + "', '" + subj.Text + "', '" + date + "', '" + this.Adminid + "', '"+date+"', '"+this.Adminid+"')";

                        MySqlCommand commrequest = new MySqlCommand(queryrequest, conn);
                        commrequest.ExecuteNonQuery();
                        conn.Close();

                        conn.Open();

                        string updateqty = "UPDATE item SET quantity = quantity - " + cqty.Value + " WHERE itemID='" + itemid + "'";

                        MySqlCommand commupdate = new MySqlCommand(updateqty, conn);
                        commupdate.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Success", "Request Made", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //main.Show();
                        this.Close();
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

            string query2 = "SELECT teacherID from teacher WHERE teacherFName='" + tFName.Text + "' AND teacherLName='" + tLName.Text + "'";
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

            string query2 = "SELECT studentID from student WHERE studentFName='" + sFName.Text + "' AND studentLName='" + sLName.Text + "' AND yearCourse='"+yearcourse.Text+"'";
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
    }
}
