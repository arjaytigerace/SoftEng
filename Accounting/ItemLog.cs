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
            string query = "SELECT itemName,item_log.quantity,item_log.date,stockStatus,item_log.status,CONCAT(firstname,' ',lastname) AS User,remarks from item,item_log LEFT OUTER JOIN administrativeassociate ON admin_ID = item_log.userID" +
                " WHERE itemName = (SELECT itemName from item WHERE item_log.itemID = item.itemID)";

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
            dataGridView1.Columns["quantity"].Width = 90;
            dataGridView1.Columns["date"].HeaderText = "Date";
            dataGridView1.Columns["stockStatus"].HeaderText = "Action";
            dataGridView1.Columns["status"].HeaderText = "Reason";
            dataGridView1.Columns["User"].HeaderText = "User";
            dataGridView1.Columns["remarks"].HeaderText = "Remarks";

        }
    }
}
