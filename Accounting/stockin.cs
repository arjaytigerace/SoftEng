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
    public partial class stockin : Form
    {

        public Form main { get; set; }
        MySqlConnection conn;
        public int Adminid { get; set; }
        public int Tabindex { get; set; }
        public String Itemname { get; set; }
        public stockin()
        {
            InitializeComponent();
           
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void stockin_Load(object sender, EventArgs e)
        {
            sItemName.AutoCompleteMode = AutoCompleteMode.Suggest;
            sItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            sItemName.AutoCompleteCustomSource = DataCollection;
            equipStatus.SelectedIndex = 0;
            tabControl1.SelectedIndex = Tabindex;
            sItemName.Text = Itemname;
        }

        private void getData(AutoCompleteStringCollection dataCollection)
        {


            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "SELECT itemName FROM item";


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

        private void stockinbutton_Click(object sender, EventArgs e)
        {
            if (sItemName.Text == "" || sqty.Value <= 0 || comboBox1.Text == "")
            {

                MessageBox.Show("Please do not leave any of the fields as blank");
            }
            else
            {
                DateTime dateValue = DateTime.Now;
                string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                string query = "UPDATE item SET quantity=quantity + " + sqty.Value + " WHERE itemName='" + sItemName.Text + "'";

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query, conn);
                comm1.ExecuteNonQuery();
                conn.Close();

                string query2 = "INSERT INTO item_log(itemID,quantity,date,stockStatus,status,userID,remarks) values((SELECT itemID from item where " +
                    "itemName='" + sItemName.Text + "')," + sqty.Value + ",'" + date + "','Stocked IN','" + comboBox1.Text + "'," + Adminid + ",'" + textBox9.Text + "')";

                conn.Open();
                MySqlCommand comm2 = new MySqlCommand(query2, conn);
                comm2.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Successfully Stocked In");
                this.Close();
            }
        }

        private void stocknew_Click(object sender, EventArgs e)
        {

            if (eitemname.Text == "" || comboBox2.Text == "" || emeasuretype.Text == "" || brand.Text == "" || costunit.Text == "" || estlife.Text == "" || eItemCode.Text == "")
            {
                MessageBox.Show("Please do not leave a field empty");
            }
            else
            {
                DateTime dateValue = DateTime.Now;
                string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                purchasedate.CustomFormat = ("yyyy-MM-dd");

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand("InsertEquip", conn);
                comm1.CommandType = CommandType.StoredProcedure;

                comm1.Parameters.Add("?eitemcode", MySqlDbType.VarChar, 255).Value = eItemCode.Text;
                comm1.Parameters.Add("?eitemname", MySqlDbType.VarChar, 255).Value = eitemname.Text;
                comm1.Parameters.Add("?qty", MySqlDbType.Int32).Value = eqty.Value;
                comm1.Parameters.Add("?mtype", MySqlDbType.VarChar, 255).Value = emeasuretype.Text;
                comm1.Parameters.Add("?edate", MySqlDbType.DateTime).Value = date;
                comm1.Parameters.Add("?brandAndModel", MySqlDbType.VarChar, 255).Value = brand.Text;
                comm1.Parameters.Add("?costPerUnit", MySqlDbType.VarChar, 255).Value = costunit.Text;
                comm1.Parameters.Add("?dateOfPurchase", MySqlDbType.Date).Value = purchasedate.Value;
                comm1.Parameters.Add("?estimatedLife", MySqlDbType.VarChar, 255).Value = estlife.Text;
                comm1.Parameters.Add("?equipStatus", MySqlDbType.VarChar, 255).Value = equipStatus.Text;
                comm1.Parameters.Add("?reason", MySqlDbType.VarChar, 255).Value = comboBox2.Text;
                comm1.Parameters.Add("?userID", MySqlDbType.Int32).Value = Adminid;
                comm1.Parameters.Add("?remarks", MySqlDbType.VarChar, 255).Value = textBox1.Text;
                comm1.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Success", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
