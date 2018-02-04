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
    public partial class ItemLog : Form
    {

        public Form main { get; set; }
        MySqlConnection conn;


        public ItemLog()
          
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void ItemLog_Load(object sender, EventArgs e)
        {
            string query = "SELECT itemName,item_log.quantity,item_log.mtype,item_log.date,stockStatus,item_log.status,CONCAT(firstname,' ',lastname) AS User,remarks from item,item_log LEFT OUTER JOIN administrativeassociate ON admin_ID = item_log.userID" +
                " WHERE itemName = (SELECT itemName from item WHERE item_log.itemID = item.itemID) AND stockStatus='Stocked IN' ORDER BY date DESC";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["itemName"].HeaderText = "Item Name";
            dataGridView1.Columns["quantity"].HeaderText = "QTY";
            dataGridView1.Columns["mtype"].HeaderText = "Unit";
            dataGridView1.Columns["quantity"].Width = 90;
            dataGridView1.Columns["date"].HeaderText = "Date";
            dataGridView1.Columns["stockStatus"].HeaderText = "Action";
            dataGridView1.Columns["status"].HeaderText = "Reason";
            dataGridView1.Columns["User"].HeaderText = "User";
            dataGridView1.Columns["remarks"].HeaderText = "Remarks";

            string query1 = "SELECT itemName,item_log.quantity,item_log.date,stockStatus,item_log.status,CONCAT(firstname,' ',lastname) AS User,remarks from item,item_log LEFT OUTER JOIN administrativeassociate ON admin_ID = item_log.userID" +
    " WHERE itemName = (SELECT itemName from item WHERE item_log.itemID = item.itemID) AND stockStatus='Stocked OUT' ORDER BY date DESC";

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = dt1;

            dataGridView2.Columns["itemName"].HeaderText = "Item Name";
            dataGridView2.Columns["quantity"].HeaderText = "QTY";
            dataGridView2.Columns["mtype"].HeaderText = "Unit";
            dataGridView2.Columns["quantity"].Width = 90;
            dataGridView2.Columns["date"].HeaderText = "Date";
            dataGridView2.Columns["stockStatus"].HeaderText = "Action";
            dataGridView2.Columns["status"].HeaderText = "Reason";
            dataGridView2.Columns["User"].HeaderText = "User";
            dataGridView2.Columns["remarks"].HeaderText = "Remarks";


            string query3 = "SELECT itemName,item_log.quantity,item_log.date,stockStatus,item_log.status,CONCAT(firstname,' ',lastname) AS User,remarks from item,item_log LEFT OUTER JOIN administrativeassociate ON admin_ID = item_log.userID" +
" WHERE itemName = (SELECT itemName from item WHERE item_log.itemID = item.itemID) ORDER BY date DESC";

            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(query3, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            dataGridView3.RowHeadersVisible = false;
            dataGridView3.DataSource = dt2;

            dataGridView3.Columns["itemName"].HeaderText = "Item Name";
            dataGridView3.Columns["quantity"].HeaderText = "QTY";
            dataGridView3.Columns["mtype"].HeaderText = "Unit";
            dataGridView3.Columns["quantity"].Width = 90;
            dataGridView3.Columns["date"].HeaderText = "Date";
            dataGridView3.Columns["stockStatus"].HeaderText = "Action";
            dataGridView3.Columns["status"].HeaderText = "Reason";
            dataGridView3.Columns["User"].HeaderText = "User";
            dataGridView3.Columns["remarks"].HeaderText = "Remarks";

        }
    }
}
