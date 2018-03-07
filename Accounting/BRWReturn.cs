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
    public partial class returnbutton : Form
    {
        public Form main { get; set; }
        public String returnitem {get;set;}
        public decimal qty { get; set; }
        public String mtype { get; set; }
        public String borrowdate { get; set; }
        public int borrowid { get; set; }
        public int Adminid { get; set; }

        MySqlConnection conn;

        public returnbutton()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");

        }

        private void BRWReturn_Load(object sender, EventArgs e)
        {
            label8.Text= DateTime.Now.ToString();
            itemname.Text = returnitem;
            label4.Text = qty.ToString();
            label9.Text = mtype;
            label1.Text = borrowdate;
            
            dmged.Minimum = 0;
            string query3 = "SELECT qty from borrowing WHERE borrowRequestId='" + borrowid + "'";
            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                dmged.Maximum = Convert.ToInt32(dt3.Rows[0]["qty"].ToString());

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            DateTime dateValue = DateTime.Now;
            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
            string queryrequest = "UPDATE borrowing SET requestStatus = 'Returned' WHERE borrowRequestId = '" + borrowid + "'";


            MySqlCommand commrequest = new MySqlCommand(queryrequest, conn);
            commrequest.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            string returnrequest = "INSERT INTO returnrequests(borrowRequestId,returnDate,numdmg,remarks,userId) VALUES ('"+borrowid+"','"+date+"','"+dmged.Value+"','"+ textBox9.Text+"','"+Adminid+"')";

            MySqlCommand commrequest2 = new MySqlCommand(returnrequest, conn);
            commrequest2.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            string qtyupdate = "UPDATE item SET quantity = quantity + " + qty + " WHERE itemName='"+returnitem+"'";

            MySqlCommand commrequest1 = new MySqlCommand(qtyupdate, conn);
            commrequest1.ExecuteNonQuery();
            conn.Close();

           

            if (dmged.Value > 0)
            {
                string query = "UPDATE item SET quantity=quantity - " + dmged.Value + " WHERE itemName='" + itemname.Text + "'";

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query, conn);
                comm1.ExecuteNonQuery();
                conn.Close();

                string query2 = "INSERT INTO item_log(itemID,quantity,mtype,date,stockStatus,status,userID,remarks) values((SELECT itemID from item where " +
                    "itemName='" + itemname.Text + "')," + dmged.Value + ",'" + label9.Text + "','" + date + "','Stocked OUT','Damaged','" + Adminid + "','" + textBox9.Text + "')";

                conn.Open();
                MySqlCommand comm2 = new MySqlCommand(query2, conn);
                comm2.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Successfully Stocked out damaged items from inventory");
            }
            MessageBox.Show("Successfully Returned");
            this.Close();
        }
    }
}
