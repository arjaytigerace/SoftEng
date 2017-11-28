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
    public partial class Inventory : Form
    {


        public Form main { get; set; }
        MySqlConnection conn;


        private int selecteditemid;

        public Inventory()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");

        }

        private void deselect()
        {

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();

            itemname.Text = "";
            itemtype.SelectedIndex = 0;
            qty.Value = 0;
            measuretype.SelectedIndex = 0;
            emeasuretype.SelectedIndex = 0;
            cmeasuretype.SelectedIndex = 0;
            numdmg.Value = 0;
            numlost.Value = 0;
            eitemname.Text = "";
            eqty.Value = 0;
            brand.Text = "";
            costunit.Text = "";
            estlife.Text = "";
            aitemname.Text = "";
            adesc.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";

            aqty.Value = 0;
            ameasuretype.SelectedIndex = 0;


            updbutton.Enabled = false;
            delbutton.Enabled = false;
            addequipb.Enabled = true;
            deselectequipb.Enabled = false;
            updequipb.Enabled = false;
            delequipb.Enabled = false;

            addappb.Enabled = true;
            deselectappb.Enabled = false;
            updappb.Enabled = false;
            delappb.Enabled = false;

            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            qty.Minimum = 0;
            qty.Maximum = 9999;
            eqty.Minimum = 0;
            eqty.Maximum = 9999;
            aqty.Minimum = 0;
            aqty.Maximum = 9999;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 9999;

            loadall();
        }


        private void loadall()
        {

            string query = "SELECT itemID,itemName,itemType,quantity,measurementType,addedon,modon FROM chem_lab.item a, chem_lab.itemtype b WHERE b.itemTypeID = a.itemTypeID";

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



            string queryequip = "SELECT a.itemID,itemName,quantity,measurementType,numdmg,numlost,brandAndModel,costPerUnit,dateOfPurchase,estimatedLife,addedon,modon " +
                "FROM chem_lab.item a,chem_lab.itemequipment b WHERE b.itemID = a.itemID";

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(queryequip, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["itemID"].Visible = false;
            dataGridView2.Columns["itemName"].HeaderText = "Item Name";
            dataGridView2.Columns["quantity"].HeaderText = "Quantity";
            dataGridView2.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView2.Columns["brandAndModel"].HeaderText = "Brand/Model";
            dataGridView2.Columns["costPerUnit"].HeaderText = "Cost/Unit";
            dataGridView2.Columns["dateOfPurchase"].HeaderText = "Date of Purchase";
            dataGridView2.Columns["estimatedLife"].HeaderText = "Estimated Life";
            dataGridView2.Columns["numdmg"].HeaderText = "# Damaged";
            dataGridView2.Columns["numlost"].HeaderText = "# Lost";
            dataGridView2.Columns["addedon"].HeaderText = "Date Added";
            dataGridView2.Columns["modon"].HeaderText = "Last Modified";



            string queryapp = "SELECT a.itemID,itemName,quantity,measurementType,description,numdmg,numlost,addedon,modon " +
               "FROM chem_lab.item a,chem_lab.itemapparatus b WHERE b.itemID = a.itemID";

            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(queryapp, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            dataGridView3.RowHeadersVisible = false;
            dataGridView3.DataSource = dt2;
            dataGridView3.Columns["itemID"].Visible = false;
            dataGridView3.Columns["itemName"].HeaderText = "Item Name";
            dataGridView3.Columns["quantity"].HeaderText = "Quantity";
            dataGridView3.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView3.Columns["description"].HeaderText = "Description";
            dataGridView3.Columns["numdmg"].HeaderText = "# Damaged";
            dataGridView3.Columns["numlost"].HeaderText = "# Lost";
            dataGridView3.Columns["addedon"].HeaderText = "Date Added";
            dataGridView3.Columns["modon"].HeaderText = "Last Modified";


            string querychem = "SELECT a.itemID,itemName,colorCode,classification,quantity,measurementType,addedon,modon " +
               "FROM chem_lab.item a,chem_lab.itemchemical b WHERE b.itemID = a.itemID";

            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(querychem, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);

            dataGridView4.RowHeadersVisible = false;
            dataGridView4.DataSource = dt3;
            dataGridView4.Columns["itemID"].Visible = false;
            dataGridView4.Columns["itemName"].HeaderText = "Item Name";
            dataGridView4.Columns["colorCode"].HeaderText = "Color Code";
            dataGridView4.Columns["classification"].HeaderText = "Classification";
            dataGridView4.Columns["quantity"].HeaderText = "Quantity";
            dataGridView4.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView4.Columns["addedon"].HeaderText = "Date Added";
            dataGridView4.Columns["modon"].HeaderText = "Last Modified";



            deselect();

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selecteditemid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
                itemname.Text = dataGridView1.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                itemtype.Text = dataGridView1.Rows[e.RowIndex].Cells["itemtype"].Value.ToString();

                qty.Value = (int)dataGridView1.Rows[e.RowIndex].Cells["quantity"].Value;
                measuretype.Text = dataGridView1.Rows[e.RowIndex].Cells["measurementType"].Value.ToString();

                updbutton.Enabled = true;
                delbutton.Enabled = true;

            }
        }

        private void updbutton_Click(object sender, EventArgs e)
        {


            DateTime dateValue = DateTime.Now;
            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");


            if (itemname.Text == "" || itemtype.Text == "")
            {
                MessageBox.Show("Please do not leave the item name and type as blank");
            }

            int itype;
            if (itemtype.SelectedIndex == 0)
            {

                itype = 1;


            }
            else if (itemtype.SelectedIndex == 1)
            {

                itype = 2;
            }

            else
            {
                itype = 3;

            }

            string query = "UPDATE item SET itemname='" + itemname.Text + "',itemtypeID='" + itype + "',quantity='" + qty.Value + "',measurementtype='" + measuretype.Text + "',modon='" + date + "' WHERE itemID =" + selecteditemid;

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadall();
        }

        private void delbutton_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM item WHERE itemID =" + selecteditemid;
            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully deleted the item", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadall();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void addequipb_Click(object sender, EventArgs e)
        {

            if (eitemname.Text == "" || itemtype.Text == "" || brand.Text == "" || costunit.Text == "" || estlife.Text == "")
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

                comm1.Parameters.Add("?eitemname", MySqlDbType.VarChar, 255).Value = eitemname.Text;
                comm1.Parameters.Add("?eqty", MySqlDbType.Int32).Value = eqty.Value;
                comm1.Parameters.Add("?emeasuretype", MySqlDbType.VarChar, 255).Value = emeasuretype.Text;
                comm1.Parameters.Add("?edate", MySqlDbType.DateTime).Value = date;
                comm1.Parameters.Add("?brandAndModel", MySqlDbType.VarChar, 255).Value = brand.Text;
                comm1.Parameters.Add("?costPerUnit", MySqlDbType.VarChar, 255).Value = costunit.Text;
                comm1.Parameters.Add("?dateOfPurchase", MySqlDbType.Date).Value = purchasedate.Value;
                comm1.Parameters.Add("?estimatedLife", MySqlDbType.VarChar, 255).Value = estlife.Text;
                comm1.Parameters.Add("?numdmg", MySqlDbType.VarChar, 255).Value = numdmg.Value;
                comm1.Parameters.Add("?numlost", MySqlDbType.VarChar, 255).Value = numlost.Value;
                comm1.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Success", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadall();

            }
        }

        private void deselectequipb_Click(object sender, EventArgs e)
        {
            deselect();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //selecteditemid = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
            if (e.RowIndex >= 0)
            {
                selecteditemid = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
                eitemname.Text = dataGridView2.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                eqty.Value = (int)dataGridView2.Rows[e.RowIndex].Cells["quantity"].Value;
                emeasuretype.Text = dataGridView2.Rows[e.RowIndex].Cells["measurementType"].Value.ToString();
                brand.Text = dataGridView2.Rows[e.RowIndex].Cells["brandAndModel"].Value.ToString();
                costunit.Text = dataGridView2.Rows[e.RowIndex].Cells["costPerUnit"].Value.ToString();
                purchasedate.Value = (DateTime)dataGridView2.Rows[e.RowIndex].Cells["dateOfPurchase"].Value;
                estlife.Text = dataGridView2.Rows[e.RowIndex].Cells["estimatedLife"].Value.ToString();
                numlost.Value = (int)dataGridView2.Rows[e.RowIndex].Cells["numlost"].Value;
                numdmg.Value = (int)dataGridView2.Rows[e.RowIndex].Cells["numdmg"].Value;
                addequipb.Enabled = false;
                deselectequipb.Enabled = true;
                updequipb.Enabled = true;
                delequipb.Enabled = true;

            }

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            deselect();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void updequipb_Click(object sender, EventArgs e)
        {
            purchasedate.CustomFormat = ("yyyy-MM-dd");
            DateTime dateValue = DateTime.Now;
            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

            if (eitemname.Text == "" || brand.Text == "" || costunit.Text == "" || estlife.Text == "")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }


            string query = "UPDATE item SET itemName='" + eitemname.Text + "',quantity='" + (eqty.Value - (numdmg.Value + numlost.Value)) + "',measurementtype='" + emeasuretype.Text + "',modon='" + date + "' WHERE itemID =" + selecteditemid;

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();


            string query1 = "UPDATE itemequipment SET brandandmodel='" + brand.Text + "',costPerunit ='" + costunit.Text + "',dateOfPurchase='" + purchasedate.Value.ToString("yyyy-MM-dd") + "',estimatedLife='" + estlife.Text + "',numdmg=" + numdmg.Value + ",numlost=" + numlost.Value + " WHERE itemID =" + selecteditemid;

            MySqlCommand comm2 = new MySqlCommand(query1, conn);
            comm2.ExecuteNonQuery();


            conn.Close();
            MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadall();

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //selecteditemid = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
            if (e.RowIndex >= 0)
            {
                selecteditemid = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
                aitemname.Text = dataGridView3.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                aqty.Value = (int)dataGridView3.Rows[e.RowIndex].Cells["quantity"].Value;
                ameasuretype.Text = dataGridView3.Rows[e.RowIndex].Cells["measurementType"].Value.ToString();
                adesc.Text = dataGridView3.Rows[e.RowIndex].Cells["description"].Value.ToString();


                anumlost.Value = (int)dataGridView3.Rows[e.RowIndex].Cells["numlost"].Value;
                anumdmg.Value = (int)dataGridView3.Rows[e.RowIndex].Cells["numdmg"].Value;
                addappb.Enabled = false;
                deselectappb.Enabled = true;
                updappb.Enabled = true;
                delappb.Enabled = true;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addappb_Click(object sender, EventArgs e)
        {
            if (aitemname.Text == "" || adesc.Text == "")
            {
                MessageBox.Show("Please do not leave a field empty");
            }
            else
            {

                DateTime dateValue = DateTime.Now;
                string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");


                conn.Open();
                MySqlCommand comm1 = new MySqlCommand("InsertApp", conn);
                comm1.CommandType = CommandType.StoredProcedure;

                comm1.Parameters.Add("?aitemname", MySqlDbType.VarChar, 255).Value = aitemname.Text;
                comm1.Parameters.Add("?aqty", MySqlDbType.Int32).Value = aqty.Value;
                comm1.Parameters.Add("?ameasuretype", MySqlDbType.VarChar, 255).Value = ameasuretype.Text;
                comm1.Parameters.Add("?adate", MySqlDbType.DateTime).Value = date;
                comm1.Parameters.Add("?description", MySqlDbType.VarChar, 255).Value = adesc.Text;
                comm1.Parameters.Add("?numdmg", MySqlDbType.VarChar, 255).Value = anumdmg.Value;
                comm1.Parameters.Add("?numlost", MySqlDbType.VarChar, 255).Value = anumlost.Value;
                comm1.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Success", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadall();

            }
        }

        private void updappb_Click(object sender, EventArgs e)
        {
            purchasedate.CustomFormat = ("yyyy-MM-dd");
            DateTime dateValue = DateTime.Now;
            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

            if (aitemname.Text == "" || adesc.Text == "")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }


            string query = "UPDATE item SET itemName='" + aitemname.Text + "',quantity='" + (aqty.Value - (anumdmg.Value + anumlost.Value)) + "',measurementtype='" + ameasuretype.Text + "',modon='" + date + "' WHERE itemID =" + selecteditemid;

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();


            string query1 = "UPDATE itemapparatus SET description='" + adesc.Text + "',numdmg=" + anumdmg.Value + ",numlost=" + anumlost.Value + " WHERE itemID =" + selecteditemid;

            MySqlCommand comm2 = new MySqlCommand(query1, conn);
            comm2.ExecuteNonQuery();


            conn.Close();
            MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadall();
        }

        private void delappb_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM item WHERE itemID =" + selecteditemid;
            string query2 = "DELETE FROM itemapparatus WHERE itemID =" + selecteditemid;


            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            comm2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully deleted the item", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadall();
        }

        private void delequipb_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM item WHERE itemID =" + selecteditemid;
            string query2 = "DELETE FROM itemequipment WHERE itemID =" + selecteditemid;


            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            comm2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully deleted the item", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadall();
        }

        private void deselectappb_Click(object sender, EventArgs e)
        {
            deselect();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selecteditemid = int.Parse(dataGridView4.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
                textBox3.Text = dataGridView4.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                textBox1.Text = dataGridView4.Rows[e.RowIndex].Cells["colorCode"].Value.ToString();
                textBox2.Text = dataGridView4.Rows[e.RowIndex].Cells["classification"].Value.ToString();
                numericUpDown1.Value = (int)dataGridView4.Rows[e.RowIndex].Cells["quantity"].Value;
                cmeasuretype.Text = dataGridView4.Rows[e.RowIndex].Cells["measurementType"].Value.ToString();

        

                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please do not leave a field empty");
            }

            else
            {

                DateTime dateValue = DateTime.Now;
                string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                purchasedate.CustomFormat = ("yyyy-MM-dd");

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand("InsertChem", conn);
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add("?cqty", MySqlDbType.Int32).Value = numericUpDown1.Value;
                comm1.Parameters.Add("?cmeasuretype", MySqlDbType.VarChar, 255).Value = cmeasuretype.Text;
                comm1.Parameters.Add("?cdate", MySqlDbType.DateTime).Value = date;
                comm1.Parameters.Add("?citemname", MySqlDbType.VarChar, 255).Value = textBox3.Text;
                comm1.Parameters.Add("?colorCode", MySqlDbType.VarChar, 255).Value = textBox1.Text;
                comm1.Parameters.Add("?classification", MySqlDbType.VarChar, 255).Value = textBox2.Text;
                comm1.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Success", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadall();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deselect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dateValue = DateTime.Now;
            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

            if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }


            string query = "UPDATE item SET itemName='" + textBox3.Text + "',quantity='" + numericUpDown1.Text + "',measurementtype='" + cmeasuretype.Text + "',modon='" + date + "' WHERE itemID =" + selecteditemid;

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();


            string query1 = "UPDATE itemchemical SET colorCode='" + textBox1.Text + "',classification ='" + textBox2.Text + "' WHERE itemID =" + selecteditemid;

            MySqlCommand comm2 = new MySqlCommand(query1, conn);
            comm2.ExecuteNonQuery();


            conn.Close();
            MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM item WHERE itemID =" + selecteditemid;
            string query2 = "DELETE FROM itemchemical WHERE itemID =" + selecteditemid;


            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();
            MySqlCommand comm2 = new MySqlCommand(query2, conn);
            comm2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully deleted the item", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadall();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string itemsearch = search.Text;
            Search searchform = new Search();
            searchform.getItemName = itemsearch;
            searchform.getTab = 1;
            searchform.main = this;
            searchform.Show();


        }

        private void searchequip_Click(object sender, EventArgs e)
        {
            string itemsearch = searche.Text;
            Search searchform = new Search();
            searchform.getItemName = itemsearch;
            searchform.getTab = 2;
            searchform.main = this;
            searchform.Show();


        }

        private void searchapp_Click(object sender, EventArgs e)
        {
            string itemsearch = searcha.Text;
            Search searchform = new Search();
            searchform.getItemName = itemsearch;
            searchform.getTab = 3;
            searchform.main = this;
            searchform.Show();
        }

        private void searchchem_Click(object sender, EventArgs e)
        {
            string itemsearch = searchc.Text;
            Search searchform = new Search();
            searchform.getItemName = itemsearch;
            searchform.getTab = 4;
            searchform.main = this;
            searchform.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void cmeasuretype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
