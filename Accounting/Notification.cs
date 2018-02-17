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
    public partial class Notification : Form
    {
        MySqlConnection conn;
        public Form main { get; set; }
        public Notification()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");

        }

        private void Notification_Load(object sender, EventArgs e)
        {
            string query = "SELECT itemName,quantity,measurementType from item where quantity=0";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["itemName"].HeaderText = "Item Name";
            dataGridView1.Columns["quantity"].HeaderText = "Quantity";
            dataGridView1.Columns["quantity"].Width = 70;
            dataGridView1.Columns["measurementType"].HeaderText = "Unit of Measurement";
        }
    }
}
