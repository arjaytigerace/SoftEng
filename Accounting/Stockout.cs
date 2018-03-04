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
    public partial class Stockout : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public int Adminid { get; set; }
        public String Itemname { get; set; }
        public Stockout()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void Stockout_Load(object sender, EventArgs e)
        {
            sItemName.AutoCompleteMode = AutoCompleteMode.Suggest;
            sItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            sItemName.AutoCompleteCustomSource = DataCollection;
            sItemName.Text = Itemname;
            sqty.Maximum = 9999;
            sqty.Minimum = 0;
            string query3 = "SELECT measurementType,itemTypeID from item WHERE itemName='" + sItemName.Text + "'";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                label2.Text = dt3.Rows[0]["measurementType"].ToString();
                if (int.Parse(dt3.Rows[0]["itemTypeID"].ToString()) == 3)
                {
                    sqty.DecimalPlaces = 3;
                    sqty.Increment = 0.010m;
                }
                else
                {

                    sqty.DecimalPlaces = 0;

                }
            }


        }
        private void getData(AutoCompleteStringCollection dataCollection)
        {


            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "SELECT itemName FROM item where itemstatus='Active'";


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

        private void stockobutton_Click(object sender, EventArgs e)
        {

            if (sItemName.Text == "" || sqty.Value <= 0 || comboBox1.Text == "")
            {

                MessageBox.Show("Please do not leave any of the fields blank");
            }
            else
            {
               
                string selectCmd = "SELECT quantity FROM item where itemName='" + sItemName.Text + "'";
                conn.Open();
                MySqlCommand command = new MySqlCommand(selectCmd, conn);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(command);
                conn.Close();
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    if (sqty.Value > (decimal)dt3.Rows[0]["quantity"])
                    {
                        MessageBox.Show("The quantity you have typed exceeds the quantity of the item");

                    }
                    else
                    {

                        string query3 = "SELECT itemID from item WHERE itemName='" + sItemName.Text + "' AND itemstatus='Active'";
                        conn.Open();
                        MySqlCommand comm3 = new MySqlCommand(query3, conn);
                        MySqlDataAdapter adp4 = new MySqlDataAdapter(comm3);
                        conn.Close();
                        DataTable dt4 = new DataTable();
                        adp4.Fill(dt4);
                        if (dt4.Rows.Count > 0)
                        {

                            DateTime dateValue = DateTime.Now;
                            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                            string query = "UPDATE item SET quantity=quantity - " + sqty.Value + " WHERE itemName='" + sItemName.Text + "'";

                            conn.Open();
                            MySqlCommand comm1 = new MySqlCommand(query, conn);
                            comm1.ExecuteNonQuery();
                            conn.Close();

                            string query2 = "INSERT INTO item_log(itemID,quantity,mtype,date,stockStatus,status,userID,remarks) values((SELECT itemID from item where " +
                                "itemName='" + sItemName.Text + "')," + sqty.Value + ",'" + label2.Text + "','" + date + "','Stocked OUT','" + comboBox1.Text + "'," + Adminid + ",'" + textBox9.Text + "')";

                            conn.Open();
                            MySqlCommand comm2 = new MySqlCommand(query2, conn);
                            comm2.ExecuteNonQuery();
                            conn.Close();

                            MessageBox.Show("Successfully Stocked out");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Item does not exist or is inactive");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Item does not exist or is inactive");
                }
            }
        }

        private void sItemName_Leave(object sender, EventArgs e)
        {
            string query3 = "SELECT measurementType,itemTypeID from item WHERE itemName='" + sItemName.Text + "'";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                label2.Text = dt3.Rows[0]["measurementType"].ToString();
                if (int.Parse(dt3.Rows[0]["itemTypeID"].ToString()) == 3)
                {
                    sqty.DecimalPlaces = 3;
                    sqty.Increment = 0.010m;
                }
                else
                {

                    sqty.DecimalPlaces = 0;

                }
            }
            else
            {
                MessageBox.Show("Item does not exist");
            }
        }
    }
}
