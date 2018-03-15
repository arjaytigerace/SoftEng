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
            colorCode.SelectedIndex = -1;
            classification.Text = "--";
            string query3 = "SELECT measurementType,itemTypeID from item WHERE itemName='" + sItemName.Text + "'";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                label16.Text = dt3.Rows[0]["measurementType"].ToString();
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


            sqty.Minimum = 0;
            sqty.Maximum = 9999;
            eqty.Minimum = 0;
            eqty.Maximum = 9999;
            aqty.Minimum = 0;
            aqty.Maximum = 9999;
            cqty.Minimum = 0;
            cqty.Maximum = 9999;
            cqty.DecimalPlaces = 3;
            cqty.Increment = 0.010m;
            ecritlevel.Maximum = 9999;
            ecritlevel.Minimum = 0;
            acritlevel.Maximum = 9999;
            acritlevel.Minimum = 0;
            ccritlevel.Maximum = 9999;
            ccritlevel.Minimum = 0;
            ccritlevel.DecimalPlaces = 3;
            ccritlevel.Increment = 0.010m;
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

        private void stockinbutton_Click(object sender, EventArgs e)
        {
            if (sItemName.Text == "" || sqty.Value <= 0 || comboBox1.Text == "")
            {

                MessageBox.Show("Please do not leave any of the fields as blank");
            }
            else if(sqty.Value > sqty.Maximum)
            {
                MessageBox.Show("Please input a lower quantity");
            }
            else
            {

                string query3 = "SELECT itemID from item WHERE itemName='" + sItemName.Text + "' AND itemstatus='Active'";
                conn.Open();
                MySqlCommand comm3 = new MySqlCommand(query3, conn);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                conn.Close();
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    DateTime dateValue = DateTime.Now;
                    string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                    string query = "UPDATE item SET quantity=quantity + " + sqty.Value + " WHERE itemName='" + sItemName.Text + "'";

                    conn.Open();
                    MySqlCommand comm1 = new MySqlCommand(query, conn);
                    comm1.ExecuteNonQuery();
                    conn.Close();

                    string query2 = "INSERT INTO item_log(itemID,quantity,mtype,date,stockStatus,status,userID,remarks) values((SELECT itemID from item where " +
                        "itemName='" + sItemName.Text + "')," + sqty.Value + ",'" + label16.Text + "','" + date + "','Stocked IN','" + comboBox1.Text + "'," + Adminid + ",'" + textBox9.Text + "')";

                    conn.Open();
                    MySqlCommand comm2 = new MySqlCommand(query2, conn);
                    comm2.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Successfully Stocked In");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Item does not exist or is inactive");
                }
                
            }
        }

        private void stocknew_Click(object sender, EventArgs e)
        {

            if (eitemname.Text == "" || eqty.Value <=0 || comboBox2.Text == "" || emeasuretype.Text == "" || brand.Text == "" || costunit.Text == "" || estlife.Text == "" || eItemCode.Text == "")
            {
                MessageBox.Show("Please do not leave a field empty");
            }
            else if (eqty.Value > eqty.Maximum)
            {
                MessageBox.Show("Please input a lower quantity");
            }
            else
            {
                string query3 = "SELECT itemID from item WHERE itemName='" + eitemname.Text + "' OR itemCode='"+ eItemCode.Text+"'";
                conn.Open();
                MySqlCommand comm3 = new MySqlCommand(query3, conn);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                conn.Close();
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    MessageBox.Show("There is already an item with this name or code");
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
                    comm1.Parameters.Add("?criticalLevel", MySqlDbType.Int32).Value = ecritlevel.Value;
                    comm1.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Success", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void stockInApp_Click(object sender, EventArgs e)
        {
            if (aitemname.Text == "" || aqty.Value <= 0 || adesc.Text == "" || aItemCode.Text == "" || comboBox3.Text=="")
            {
                MessageBox.Show("Please do not leave a field empty");
            }
            else if (aqty.Value > aqty.Maximum)
            {
                MessageBox.Show("Please input a lower quantity");
            }

            else
            {

                string query3 = "SELECT itemID from item WHERE itemName='" + aitemname.Text + "' OR itemCode='" + aItemCode.Text + "'";
                conn.Open();
                MySqlCommand comm3 = new MySqlCommand(query3, conn);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                conn.Close();
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    MessageBox.Show("There is already an item with this name or code");
                }
                else
                {

                    DateTime dateValue = DateTime.Now;
                    string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                    conn.Open();
                    MySqlCommand comm1 = new MySqlCommand("InsertApp", conn);
                    comm1.CommandType = CommandType.StoredProcedure;

                    comm1.Parameters.Add("?aitemcode", MySqlDbType.VarChar, 255).Value = aItemCode.Text;
                    comm1.Parameters.Add("?aitemname", MySqlDbType.VarChar, 255).Value = aitemname.Text;
                    comm1.Parameters.Add("?adate", MySqlDbType.DateTime).Value = date;
                    comm1.Parameters.Add("?aqty", MySqlDbType.Int32).Value = aqty.Value;
                    comm1.Parameters.Add("?ameasuretype", MySqlDbType.VarChar, 255).Value = amtype.Text;
                    comm1.Parameters.Add("?description", MySqlDbType.VarChar, 255).Value = adesc.Text;
                    comm1.Parameters.Add("?appStatus", MySqlDbType.VarChar, 255).Value = appStatus.Text;
                    comm1.Parameters.Add("?reason", MySqlDbType.VarChar, 255).Value = comboBox3.Text;
                    comm1.Parameters.Add("?userID", MySqlDbType.Int32).Value = Adminid;
                    comm1.Parameters.Add("?remarks", MySqlDbType.VarChar, 255).Value = textBox2.Text;
                    comm1.Parameters.Add("?criticalLevel", MySqlDbType.Int32).Value = acritlevel.Value;
                    comm1.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Success", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
                label16.Text = dt3.Rows[0]["measurementType"].ToString();
                if(int.Parse(dt3.Rows[0]["itemTypeID"].ToString()) ==3)
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

        private void colorCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorCode.SelectedIndex == 0)
            {

                classification.Text = "Health Hazard";
            }
            if (colorCode.SelectedIndex == 1)
            {

                classification.Text = "Flammable";
            }
            if (colorCode.SelectedIndex == 2)
            {

                classification.Text = "Moderate Hazard";
            }
            if (colorCode.SelectedIndex == 3)
            {

                classification.Text = "Corrosive";
            }
            if (colorCode.SelectedIndex == 4)
            {

                classification.Text = "Oxidizer";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || cqty.Value <= 0 || cItemCode.Text == "" || classification.Text=="--" || comboBox4.Text=="")
            {
                MessageBox.Show("Please do not leave a field empty");
            }
            else if (cqty.Value > cqty.Maximum)
            {
                MessageBox.Show("Please input a lower quantity");
            }
            else
            {
                string query3 = "SELECT itemID from item WHERE itemName='" + textBox3.Text + "' OR itemCode='" + cItemCode.Text + "'";
                conn.Open();
                MySqlCommand comm3 = new MySqlCommand(query3, conn);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                conn.Close();
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    MessageBox.Show("There is already an item with this name or code");
                }
                else
                {
                    DateTime dateValue = DateTime.Now;
                    string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                    purchasedate.CustomFormat = ("yyyy-MM-dd");

                    conn.Open();
                    MySqlCommand comm1 = new MySqlCommand("InsertChem", conn);
                    comm1.CommandType = CommandType.StoredProcedure;

                    comm1.Parameters.Add("?citemcode", MySqlDbType.VarChar, 255).Value = cItemCode.Text;
                    comm1.Parameters.Add("?cqty", MySqlDbType.Decimal).Value = cqty.Value;
                    comm1.Parameters.Add("?cmeasuretype", MySqlDbType.VarChar, 255).Value = cmtype.Text;
                    comm1.Parameters.Add("?cdate", MySqlDbType.DateTime).Value = date;
                    comm1.Parameters.Add("?citemname", MySqlDbType.VarChar, 255).Value = textBox3.Text;
                    comm1.Parameters.Add("?colorCode", MySqlDbType.VarChar, 255).Value = colorCode.Text;
                    comm1.Parameters.Add("?classification", MySqlDbType.VarChar, 255).Value = classification.Text;
                    comm1.Parameters.Add("?chemStatus", MySqlDbType.VarChar, 255).Value = chemStatus.Text;
                    comm1.Parameters.Add("?reason", MySqlDbType.VarChar, 255).Value = comboBox4.Text;
                    comm1.Parameters.Add("?userID", MySqlDbType.Int32).Value = Adminid;
                    comm1.Parameters.Add("?remarks", MySqlDbType.VarChar, 255).Value = textBox4.Text;
                    comm1.Parameters.Add("?criticalLevel", MySqlDbType.Decimal).Value = ccritlevel.Value;
                    comm1.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Success", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void ccritlevel_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
