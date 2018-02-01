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

        }
        private void getData(AutoCompleteStringCollection dataCollection)
        {


            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "SELECT itemName FROM item where itemTypeID!=3";


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

                MessageBox.Show("Please do not leave any of the fields as blank");
            }
            else
            {
                MySqlDataReader reader = null;
                string selectCmd = "SELECT quantity FROM item where itemName='" + sItemName.Text + "'";
                conn.Open();
                MySqlCommand command = new MySqlCommand(selectCmd, conn);
                reader = command.ExecuteReader();
                int qty=0;
                while (reader.Read())
                {
                   qty = (Int32)reader["quantity"];
                }
                conn.Close();
                int stockoutqty=Convert.ToInt32(Math.Round(sqty.Value, 0));

                if (stockoutqty > qty)
                {
                    MessageBox.Show("The quantity you have typed exceeds the quantity of the item");
                }
                else{
                    DateTime dateValue = DateTime.Now;
                    string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                    string query = "UPDATE item SET quantity=quantity - " + sqty.Value + " WHERE itemName='" + sItemName.Text + "'";

                    conn.Open();
                    MySqlCommand comm1 = new MySqlCommand(query, conn);
                    comm1.ExecuteNonQuery();
                    conn.Close();

                    string query2 = "INSERT INTO item_log(itemID,quantity,date,stockStatus,status,userID,remarks) values((SELECT itemID from item where " +
                        "itemName='" + sItemName.Text + "')," + sqty.Value + ",'" + date + "','Stocked OUT','" + comboBox1.Text + "'," + Adminid + ",'" + textBox9.Text + "')";

                    conn.Open();
                    MySqlCommand comm2 = new MySqlCommand(query2, conn);
                    comm2.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Successfully Stocked out");
                    this.Close();
                }

            }
        }
    }
}
