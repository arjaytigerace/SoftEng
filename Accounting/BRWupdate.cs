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
    public partial class BRWupdate : Form
    {
        public Form main { get; set; }
        public int Adminid { get; set; }
        
        public string Getfname { get; set; }
        public string Getlname { get; set; }
        public int brequestid { get; set; }
        public int studentid { get; set; }
        public String itemname { get; set; }
        public int quantity { get; set; }
        public String measuretype { get; set; }
        public String sfname { get; set; }
        public String slname { get; set; }
        public String yearcourse { get; set; }
        public String status { get; set; }
        public String borrowdate { get; set; }

        public decimal oldqty;
        public String olditem;

        public String expectedreturndate { get; set; }
        public String expectedreturntime { get; set; }

        MySqlConnection conn;
        public BRWupdate()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void BRWupdate_Load(object sender, EventArgs e)
        {
            itemName.Text = itemname;
            qty.Value = quantity;
            label6.Text = measuretype;
            label1.Text = borrowdate;
            sID.Text = studentid.ToString();
            sFName.Text = sfname;
            sLName.Text = slname;
            yc.Text = yearcourse;
            dateTimePicker1.Text = expectedreturndate;
            dateTimePicker2.Text = expectedreturntime;
            rstatus.SelectedIndex = 0;
            oldqty = qty.Value;
            olditem = itemName.Text;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {


            if(itemName.Text == "" || qty.Value<=0 || dateTimePicker1.Text == "" || dateTimePicker2.Text == "" || sID.Text == "" || sLName.Text == "" || sFName.Text == "" || yc.Text == "")
            {
                MessageBox.Show("Please do not leave a field empty");

            }
            else
            {
                string query = "SELECT itemID, quantity from item where itemName ='" + itemName.Text + "'";
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

                    if (qty.Value <= Convert.ToInt32(dt.Rows[0]["quantity"].ToString()))
                    {
                        if (!checkStudent())
                        {
                            MessageBox.Show("Student Doesn't Exist!");

                        }
                        else
                        {

                           
                            string query3 = "SELECT studentID from student WHERE schoolID=" + sID.Text;
                            conn.Open();
                            MySqlCommand comm3 = new MySqlCommand(query3, conn);
                            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                            conn.Close();
                            DataTable dt3 = new DataTable();
                            adp3.Fill(dt3);

                            int studentid = Convert.ToInt32(dt3.Rows[0]["studentID"].ToString());

                            String returndate = expectedreturndate +" "+ expectedreturntime;

                            //updating
                            DateTime dateValue = DateTime.Now;
                            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                            conn.Open();

                            string queryrequest = "UPDATE borrowing SET itemID = '" + itemid + "', qty = '" + qty.Value + "', measureType='" + label6.Text + "',returnDate = '" + returndate +
                            "', studentId='" + studentid + "', releasedBy='" + this.Adminid + "',requestStatus='" + rstatus.Text + "' WHERE borrowRequestId = '" + brequestid + "'";


                            MySqlCommand commrequest = new MySqlCommand(queryrequest, conn);
                            commrequest.ExecuteNonQuery();
                            conn.Close();


                            if (rstatus.SelectedIndex == 2)
                            {
                                conn.Open();
                                string updateqty3 = "UPDATE item SET quantity = quantity +" + oldqty + " WHERE itemName='" + olditem + "'";

                                MySqlCommand commupdate3 = new MySqlCommand(updateqty3, conn);
                                commupdate3.ExecuteNonQuery();
                                conn.Close();

                                MessageBox.Show("Success", "Request Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();

                            }
                            else
                            {
                                conn.Open();

                                string updateqty = "UPDATE item SET quantity = quantity +" + oldqty + " WHERE itemName='" + olditem + "'";

                                MySqlCommand commupdate = new MySqlCommand(updateqty, conn);
                                commupdate.ExecuteNonQuery();
                                conn.Close();

                                conn.Open();

                                string updateqty1 = "UPDATE item SET quantity = quantity -" + qty.Value + " WHERE itemID='" + itemid + "'";

                                MySqlCommand commupdate1 = new MySqlCommand(updateqty1, conn);
                                commupdate1.ExecuteNonQuery();
                                conn.Close();

                                MessageBox.Show("Success", "Request Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                this.Close();

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not enough quantity available");
                    }

                }
                else
                {
                    MessageBox.Show("The item you entered doesn't exist");
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

    }
}
