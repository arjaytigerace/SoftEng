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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        public Form main { get; set; }
        MySqlConnection conn;


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string getItemName{get; set;}
        public int getTab { get; set; }

        private void Search_Load(object sender, EventArgs e)
        {


            if (getTab == 1)
            {
                string query = "SELECT itemID,itemName,itemType,quantity,measurementType,addedon,modon FROM chem_lab.item a, chem_lab.itemtype b WHERE b.itemTypeID = a.itemTypeID AND a.itemName LIKE '" + getItemName + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["itemID"].Visible = false;
                dataGridView1.Columns["itemName"].HeaderText = "Item Name";
                dataGridView1.Columns["quantity"].HeaderText = "Quantity";
                dataGridView1.Columns["quantity"].Width = 70;
                dataGridView1.Columns["measurementType"].HeaderText = "Unit of Measurement";
                dataGridView1.Columns["itemType"].HeaderText = "Type";
                dataGridView1.Columns["addedon"].HeaderText = "Date Added";
                dataGridView1.Columns["modon"].HeaderText = "Last Modified";
            }
            if(getTab == 2)
            {

                string queryequip = "SELECT a.itemID,itemName,quantity,measurementType,numdmg,numlost,brandAndModel,costPerUnit,dateOfPurchase,estimatedLife,addedon,modon " +
                "FROM chem_lab.item a,chem_lab.itemequipment b WHERE b.itemID = a.itemID AND a.itemName LIKE '" + getItemName + "%'";

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(queryequip, conn);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
                conn.Close();
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns["itemID"].Visible = false;
                dataGridView1.Columns["itemName"].HeaderText = "Item Name";
                dataGridView1.Columns["quantity"].HeaderText = "Quantity";
                dataGridView1.Columns["measurementType"].HeaderText = "Unit of Measurement";
                dataGridView1.Columns["brandAndModel"].HeaderText = "Brand/Model";
                dataGridView1.Columns["costPerUnit"].HeaderText = "Cost/Unit";
                dataGridView1.Columns["dateOfPurchase"].HeaderText = "Date of Purchase";
                dataGridView1.Columns["estimatedLife"].HeaderText = "Estimated Life";
                dataGridView1.Columns["numdmg"].HeaderText = "# Damaged";
                dataGridView1.Columns["numlost"].HeaderText = "# Lost";
                dataGridView1.Columns["addedon"].HeaderText = "Date Added";
                dataGridView1.Columns["modon"].HeaderText = "Last Modified";

            }

            if (getTab == 3)
            {


                string queryapp = "SELECT a.itemID,itemName,quantity,measurementType,description,numdmg,numlost,addedon,modon " +
                   "FROM chem_lab.item a,chem_lab.itemapparatus b WHERE b.itemID = a.itemID AND a.itemName LIKE '" + getItemName + "%'";

                conn.Open();
                MySqlCommand comm2 = new MySqlCommand(queryapp, conn);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                conn.Close();
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.DataSource = dt2;
                dataGridView1.Columns["itemID"].Visible = false;
                dataGridView1.Columns["itemName"].HeaderText = "Item Name";
                dataGridView1.Columns["quantity"].HeaderText = "Quantity";
                dataGridView1.Columns["measurementType"].HeaderText = "Unit of Measurement";
                dataGridView1.Columns["description"].HeaderText = "Description";
                dataGridView1.Columns["numdmg"].HeaderText = "# Damaged";
                dataGridView1.Columns["numlost"].HeaderText = "# Lost";
                dataGridView1.Columns["addedon"].HeaderText = "Date Added";
                dataGridView1.Columns["modon"].HeaderText = "Last Modified";


            }

            if (getTab == 4)
            {


                string querychem = "SELECT a.itemID,itemName,colorCode,classification,quantity,measurementType,addedon,modon " +
                   "FROM chem_lab.item a,chem_lab.itemchemical b WHERE b.itemID = a.itemID AND a.itemName LIKE '" + getItemName + "%'";

                conn.Open();
                MySqlCommand comm3 = new MySqlCommand(querychem, conn);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
                conn.Close();
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.DataSource = dt3;
                dataGridView1.Columns["itemID"].Visible = false;
                dataGridView1.Columns["itemName"].HeaderText = "Item Name";
                dataGridView1.Columns["colorCode"].HeaderText = "Color Code";
                dataGridView1.Columns["classification"].HeaderText = "Classification";
                dataGridView1.Columns["quantity"].HeaderText = "Quantity";
                dataGridView1.Columns["measurementType"].HeaderText = "Unit of Measurement";
                dataGridView1.Columns["addedon"].HeaderText = "Date Added";
                dataGridView1.Columns["modon"].HeaderText = "Last Modified";


            }


        }
    }
}
