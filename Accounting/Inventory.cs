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
        decimal oldDmgLost { get; set; }
        public int Adminid { get; set; }
        public String equipitemname;
        private int selecteditemid;
        public String appitemname;
        public String chemitemname;

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

            itemCode.Text = "";
            cItemCode.Text = "";
            eItemCode.Text = "";
            aItemCode.Text = "";
            itemname.Text = "";
            itemtype.SelectedIndex = -1;
            
            eitemname.Text = "";
     
            brand.Text = "";
            costunit.Text = "";
            estlife.Text = "";
            aitemname.Text = "";
            adesc.Text = "";
            textBox3.Text = "";
            colorCode.SelectedIndex = -1;
            classification.Text = "--";
            equipStatus.SelectedIndex = -1;
            appStatus.SelectedIndex = -1;
            chemStatus.SelectedIndex = -1;

            updbutton.Enabled = false;
   
            addequipb.Enabled = true;
            deselectequipb.Enabled = false;
            updequipb.Enabled = false;
            

            deselectappb.Enabled = false;
            updappb.Enabled = false;

            button2.Enabled = false;
            button3.Enabled = false;


            equipitemname = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            string query = "SELECT itemID,itemCode,itemName,itemType,trim(round(quantity,4))+0 AS quantity,measurementType,addedon,modon,itemstatus FROM chem_lab.item a, chem_lab.itemtype b WHERE b.itemTypeID = a.itemTypeID";
            string queryequip = "SELECT a.itemID,itemCode,itemName,trim(round(quantity,4))+0 AS quantity,measurementType,brandAndModel,costPerUnit,dateOfPurchase,estimatedLife,addedon,modon,itemstatus " +
                "FROM chem_lab.item a,chem_lab.itemequipment b WHERE b.itemID = a.itemID";
            string queryapp = "SELECT a.itemID,itemCode,itemName,trim(round(quantity,4))+0 AS quantity,measurementType,description,addedon,modon,itemstatus " +
            "FROM chem_lab.item a,chem_lab.itemapparatus b WHERE b.itemID = a.itemID";
            string querychem = "SELECT a.itemID,itemCode,itemName,colorCode,classification,quantity,measurementType,addedon,modon,itemstatus " +
            "FROM chem_lab.item a,chem_lab.itemchemical b WHERE b.itemID = a.itemID";

            loadallgeneral(query);
            loadalle(queryequip);
            loadalla(queryapp);
            loadallc(querychem);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selecteditemid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
                itemCode.Text = dataGridView1.Rows[e.RowIndex].Cells["itemCode"].Value.ToString();
                itemname.Text = dataGridView1.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                itemtype.Text = dataGridView1.Rows[e.RowIndex].Cells["itemtype"].Value.ToString();
              
                status.Text = dataGridView1.Rows[e.RowIndex].Cells["itemstatus"].Value.ToString();

                updbutton.Enabled = true;
               

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
           

            string query = "UPDATE item SET itemCode='" + itemCode.Text +"',itemname='" + itemname.Text + "',itemtypeID='" + itype + "',modon='" + date + "', itemstatus='" + status.Text +"' WHERE itemID =" + selecteditemid;

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string query1 = "SELECT itemID,itemCode,itemName,itemType,trim(round(quantity,4))+0 AS quantity,measurementType,addedon,modon,itemstatus FROM chem_lab.item a, chem_lab.itemtype b WHERE b.itemTypeID = a.itemTypeID";
            loadallgeneral(query1);
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void addequipb_Click(object sender, EventArgs e)
        {
        
            stockin stockIn = new stockin();
            stockIn.main = this;
            stockIn.Adminid = this.Adminid;
            if (equipitemname == "")
            {
                stockIn.Tabindex = 1;
            }
            else
            {
                stockIn.Tabindex = 0;
                stockIn.Itemname= equipitemname;
            }
            stockIn.Show();
        }

        private void deselectequipb_Click(object sender, EventArgs e)
        {
            deselect();
            equipitemname = "";
        }

        

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

       
            if (e.RowIndex >= 0)
            {
                selecteditemid = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
                eItemCode.Text=dataGridView2.Rows[e.RowIndex].Cells["itemCode"].Value.ToString();
                eitemname.Text = dataGridView2.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
               equipitemname= dataGridView2.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                brand.Text = dataGridView2.Rows[e.RowIndex].Cells["brandAndModel"].Value.ToString();
                costunit.Text = dataGridView2.Rows[e.RowIndex].Cells["costPerUnit"].Value.ToString();
                purchasedate.Value = (DateTime)dataGridView2.Rows[e.RowIndex].Cells["dateOfPurchase"].Value;
                estlife.Text = dataGridView2.Rows[e.RowIndex].Cells["estimatedLife"].Value.ToString();
            
                equipStatus.Text= dataGridView2.Rows[e.RowIndex].Cells["itemstatus"].Value.ToString();
                deselectequipb.Enabled = true;
                updequipb.Enabled = true;


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

            if (eitemname.Text == "" || brand.Text == "" || costunit.Text == "" || estlife.Text == "" || eItemCode.Text == "")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }
            else
            {
                string query = "UPDATE item SET itemCode ='" + eItemCode.Text + "',itemName='" + eitemname.Text +
                "',modon='" + date + "',itemstatus='" + equipStatus.Text + "' WHERE itemID =" +
                        selecteditemid;

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query, conn);
                comm1.ExecuteNonQuery();


                string query1 = "UPDATE itemequipment SET brandandmodel='" + brand.Text + "',costPerunit ='" + costunit.Text + "',dateOfPurchase='" + purchasedate.Value.ToString("yyyy-MM-dd") + "',estimatedLife='" + estlife.Text + "' WHERE itemID =" + selecteditemid;

                MySqlCommand comm2 = new MySqlCommand(query1, conn);
                comm2.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string queryequip = "SELECT a.itemID,itemCode,itemName,trim(round(quantity,4))+0 AS quantity,measurementType,brandAndModel,costPerUnit,dateOfPurchase,estimatedLife,addedon,modon,itemstatus " +
                    "FROM chem_lab.item a,chem_lab.itemequipment b WHERE b.itemID = a.itemID";
                loadalle(queryequip);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //selecteditemid = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
            if (e.RowIndex >= 0)
            {
                selecteditemid = int.Parse(dataGridView3.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
                aItemCode.Text= dataGridView3.Rows[e.RowIndex].Cells["itemCode"].Value.ToString();
                aitemname.Text = dataGridView3.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                
                adesc.Text = dataGridView3.Rows[e.RowIndex].Cells["description"].Value.ToString();
                appitemname= dataGridView3.Rows[e.RowIndex].Cells["itemname"].Value.ToString();


                appStatus.Text = dataGridView3.Rows[e.RowIndex].Cells["itemstatus"].Value.ToString();
      
              
                deselectappb.Enabled = true;
                updappb.Enabled = true;

            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addappb_Click(object sender, EventArgs e)
        {

        }

        private void updappb_Click(object sender, EventArgs e)
        {
            purchasedate.CustomFormat = ("yyyy-MM-dd");
            DateTime dateValue = DateTime.Now;
            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

            if (aitemname.Text == "" || adesc.Text == "" || aItemCode.Text == "")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }
            else
            {
                string query;

                query = "UPDATE item SET itemCode='" + aItemCode.Text + "',itemName='" + aitemname.Text + "',modon='" + date + "',itemstatus='" + appStatus.Text + "' WHERE itemID =" + selecteditemid;



                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query, conn);
                comm1.ExecuteNonQuery();


                string query1 = "UPDATE itemapparatus SET description='" + adesc.Text + "' WHERE itemID =" + selecteditemid;

                MySqlCommand comm2 = new MySqlCommand(query1, conn);
                comm2.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string queryapp = "SELECT a.itemID,itemCode,itemName,trim(round(quantity,4))+0 AS quantity,measurementType,description,addedon,modon,itemstatus " +
                 "FROM chem_lab.item a,chem_lab.itemapparatus b WHERE b.itemID = a.itemID";
                loadalla(queryapp);
            }
        }



        private void deselectappb_Click(object sender, EventArgs e)
        {
            deselect();
            appitemname = "";
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selecteditemid = int.Parse(dataGridView4.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
                cItemCode.Text= dataGridView4.Rows[e.RowIndex].Cells["itemCode"].Value.ToString();
                textBox3.Text = dataGridView4.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                colorCode.Text = dataGridView4.Rows[e.RowIndex].Cells["colorCode"].Value.ToString();
                classification.Text = dataGridView4.Rows[e.RowIndex].Cells["classification"].Value.ToString();
                chemitemname = dataGridView4.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                chemStatus.Text= dataGridView4.Rows[e.RowIndex].Cells["itemstatus"].Value.ToString();
                
                button2.Enabled = true;
                button3.Enabled = true;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            deselect();
            chemitemname = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dateValue = DateTime.Now;
            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

            if (textBox3.Text == "" || cItemCode.Text == "" || colorCode.SelectedIndex==-1 || chemStatus.SelectedIndex==-1)
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }
            else
            {

                string query = "UPDATE item SET itemCode='" + cItemCode.Text + "',itemName='" + textBox3.Text + "',modon='" + date + "',itemstatus='" + chemStatus.Text + "' WHERE itemID =" + selecteditemid;

                conn.Open();
                MySqlCommand comm1 = new MySqlCommand(query, conn);
                comm1.ExecuteNonQuery();


                string query1 = "UPDATE itemchemical SET colorCode='" + colorCode.Text + "',classification ='" + classification.Text + "' WHERE itemID =" + selecteditemid;

                MySqlCommand comm2 = new MySqlCommand(query1, conn);
                comm2.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string querychem = "SELECT a.itemID,itemCode,itemName,colorCode,classification,quantity,measurementType,addedon,modon,itemstatus " +
                "FROM chem_lab.item a,chem_lab.itemchemical b WHERE b.itemID = a.itemID";
                loadallc(querychem);
            }
        }

        public void loadallgeneral(String query)
        {
            string numquery = "SELECT COUNT(*) AS num FROM item";
            conn.Open();
            MySqlCommand commnum = new MySqlCommand(numquery, conn);
            MySqlDataAdapter adpnum = new MySqlDataAdapter(commnum);
            conn.Close();
            DataTable dtnum = new DataTable();
            adpnum.Fill(dtnum);


            labelnum.Text = dtnum.Rows[0]["num"].ToString();


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["itemID"].Visible = false;
            dataGridView1.Columns["itemCode"].HeaderText = "Item Code";
            dataGridView1.Columns["itemName"].HeaderText = "Item Name";
            dataGridView1.Columns["quantity"].HeaderText = "Quantity";
            dataGridView1.Columns["quantity"].Width = 70;
            dataGridView1.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView1.Columns["itemType"].HeaderText = "Type";
            dataGridView1.Columns["addedon"].HeaderText = "Date Added";
            dataGridView1.Columns["modon"].HeaderText = "Last Modified";
            dataGridView1.Columns["itemstatus"].HeaderText = "Status";
            dataGridView1.ClearSelection();

            itemCode.Text = "";
            itemname.Text = "";
            itemtype.SelectedIndex=-1;
            status.SelectedIndex = -1;
          
            updbutton.Enabled = false;
            search.Text = "";
        }

        public void loadalle(String queryequip)
        {
            
            MySqlCommand comm1 = new MySqlCommand(queryequip, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["itemID"].Visible = false;
            dataGridView2.Columns["itemCode"].HeaderText = "Item Code";
            dataGridView2.Columns["itemName"].HeaderText = "Item Name";
            dataGridView2.Columns["quantity"].HeaderText = "Quantity";
            dataGridView2.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView2.Columns["brandAndModel"].HeaderText = "Brand/Model";
            dataGridView2.Columns["costPerUnit"].HeaderText = "Cost/Unit";
            dataGridView2.Columns["dateOfPurchase"].HeaderText = "Date of Purchase";
            dataGridView2.Columns["estimatedLife"].HeaderText = "Estimated Life";

            dataGridView2.Columns["addedon"].HeaderText = "Date Added";
            dataGridView2.Columns["modon"].HeaderText = "Last Modified";
            dataGridView2.Columns["itemstatus"].HeaderText = "Status";
            dataGridView2.ClearSelection();
            eItemCode.Text = "";
            eitemname.Text = "";
            brand.Text = "";
            costunit.Text = "";
            equipStatus.SelectedIndex = -1;
            estlife.Text = "";
            updequipb.Enabled = false;
            deselectequipb.Enabled = false;
         
            equipitemname = "";
            searche.Text = "";
        }

        public void loadalla(String queryapp)
        {

            conn.Open();
            MySqlCommand comm2 = new MySqlCommand(queryapp, conn);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
            conn.Close();
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);

            dataGridView3.RowHeadersVisible = false;
            dataGridView3.DataSource = dt2;
            dataGridView3.Columns["itemID"].Visible = false;
            dataGridView3.Columns["itemCode"].HeaderText = "Item Code";
            dataGridView3.Columns["itemName"].HeaderText = "Item Name";
            dataGridView3.Columns["quantity"].HeaderText = "Quantity";
            dataGridView3.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView3.Columns["description"].HeaderText = "Description";

            dataGridView3.Columns["modon"].HeaderText = "Last Modified";
            dataGridView3.Columns["itemstatus"].HeaderText = "Status";
            dataGridView3.ClearSelection();

            aItemCode.Text = "";
            aitemname.Text = "";
            adesc.Text = "";
            appStatus.SelectedIndex = -1;

            updappb.Enabled = false;
            deselectappb.Enabled = false;

            appitemname = "";
            searcha.Text = "";
        }


        public void loadallc(String querychem)
        {

            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(querychem, conn);
            MySqlDataAdapter adp3 = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt3 = new DataTable();
            adp3.Fill(dt3);

            dataGridView4.RowHeadersVisible = false;
            dataGridView4.DataSource = dt3;
            dataGridView4.Columns["itemID"].Visible = false;
            dataGridView4.Columns["itemCode"].HeaderText = "Item Code";
            dataGridView4.Columns["itemName"].HeaderText = "Item Name";
            dataGridView4.Columns["colorCode"].HeaderText = "Color Code";
            dataGridView4.Columns["classification"].HeaderText = "Classification";
            dataGridView4.Columns["quantity"].HeaderText = "Quantity";
            dataGridView4.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView4.Columns["addedon"].HeaderText = "Date Added";
            dataGridView4.Columns["modon"].HeaderText = "Last Modified";
            dataGridView4.Columns["itemstatus"].HeaderText = "Status";
            dataGridView4.ClearSelection();

            cItemCode.Text = "";
            textBox3.Text = "";
            colorCode.SelectedIndex = -1;
            chemStatus.SelectedIndex = -1;
            classification.Text = "--";

            button3.Enabled = false;
            button2.Enabled = false;
            chemitemname = "";
            searchc.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String x;
            if (comboBox1.SelectedIndex == 0)
            {
                x = "itemName";

            }
            else
            {
                x = "itemCode";
            }

            string query = "SELECT itemID,itemCode,itemName,itemType,trim(round(quantity,4))+0 AS quantity,measurementType,addedon,modon,itemstatus FROM chem_lab.item a, chem_lab.itemtype b WHERE b.itemTypeID = " +
                "a.itemTypeID AND "+x+" LIKE '"+ search.Text+"%'";

            loadallgeneral(query);
        }

        private void searchequip_Click(object sender, EventArgs e)
        {
            String x;
            if (comboBox2.SelectedIndex == 0)
            {
                x = "a.itemName";

            }
            else
            {
                x = "a.itemCode";
            }

            string query = "SELECT a.itemID,itemName,itemCode,trim(round(quantity,4))+0 AS quantity,measurementType,brandAndModel,costPerUnit,dateOfPurchase,estimatedLife,addedon,modon,itemstatus " +
            "FROM chem_lab.item a,chem_lab.itemequipment b WHERE b.itemID = a.itemID AND " + x + " LIKE '" + searche.Text + "%'";


            loadalle(query);


        }

        private void searchapp_Click(object sender, EventArgs e)
        {
            String x;
            if (comboBox3.SelectedIndex == 0)
            {
                x = "a.itemName";

            }
            else
            {
                x = "a.itemCode";
            }

            string queryapp = "SELECT a.itemID,itemName,itemCode,trim(round(quantity,4))+0 AS quantity,measurementType,description,addedon,modon,itemstatus " +
                   "FROM chem_lab.item a,chem_lab.itemapparatus b WHERE b.itemID = a.itemID AND " + x + " LIKE '" + searcha.Text + "%'";
            loadalla(queryapp);
        }

        private void searchchem_Click(object sender, EventArgs e)
        {
            String x;
            if (comboBox4.SelectedIndex == 0)
            {
                x = "a.itemName";

            }
            else
            {
                x = "a.itemCode";
            }

            string querychem = "SELECT a.itemID,itemName,itemCode,colorCode,classification,quantity,measurementType,addedon,modon,itemstatus " +
            "FROM chem_lab.item a,chem_lab.itemchemical b WHERE b.itemID = a.itemID AND " + x + " LIKE '" + searchc.Text + "%'";
            loadallc(querychem);
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

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void logbutton_Click(object sender, EventArgs e)
        {
            ItemLog itemlog = new ItemLog();
            itemlog.main = this;

            itemlog.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string queryequip = "SELECT a.itemID,itemCode,itemName,trim(round(quantity,4))+0 AS quantity,measurementType,brandAndModel,costPerUnit,dateOfPurchase,estimatedLife,addedon,modon,itemstatus " +
                "FROM chem_lab.item a,chem_lab.itemequipment b WHERE b.itemID = a.itemID";
            loadalle(queryequip);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stockout stockout = new Stockout();
            stockout.main = this;
            stockout.Adminid = this.Adminid;
            if (equipitemname=="")
            {
                stockout.Itemname = "";
            }
            else
            {
              
                stockout.Itemname = equipitemname;
            }
            stockout.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string queryapp = "SELECT a.itemID,itemCode,itemName,trim(round(quantity,4))+0 AS quantity,measurementType,description,addedon,modon,itemstatus " +
             "FROM chem_lab.item a,chem_lab.itemapparatus b WHERE b.itemID = a.itemID";
            loadalla(queryapp);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            stockin stockIn = new stockin();
            stockIn.main = this;
            stockIn.Adminid = this.Adminid;
            if (appitemname == "")
            {
                stockIn.Tabindex = 2;
            }
            else
            {
                stockIn.Tabindex = 0;
                stockIn.Itemname = appitemname;
            }
            stockIn.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Stockout stockout = new Stockout();
            stockout.main = this;
            stockout.Adminid = this.Adminid;
            if (appitemname=="")
            {
                stockout.Itemname = "";
            }
            else
            {

                stockout.Itemname = appitemname;
            }
            stockout.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ItemLog itemlog = new ItemLog();
            itemlog.main = this;

            itemlog.Show();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            ItemLog itemlog = new ItemLog();
            itemlog.main = this;

            itemlog.Show();
        }
        
        private void button12_Click(object sender, EventArgs e)
        {
            string querychem = "SELECT a.itemID,itemCode,itemName,colorCode,classification,quantity,measurementType,addedon,modon,itemstatus " +
            "FROM chem_lab.item a,chem_lab.itemchemical b WHERE b.itemID = a.itemID";
            loadallc(querychem);
        }

        private void chemstock_Click(object sender, EventArgs e)
        {
            stockin stockIn = new stockin();
            stockIn.main = this;
            stockIn.Adminid = this.Adminid;
            if (chemitemname=="")
            {
                stockIn.Tabindex = 3;
            }
            else
            {
                stockIn.Tabindex = 0;
                stockIn.Itemname = chemitemname;
            }
            stockIn.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string query = "SELECT itemID,itemCode,itemName,itemType,trim(round(quantity,4))+0 AS quantity,measurementType,addedon,modon,itemstatus FROM chem_lab.item a, chem_lab.itemtype b WHERE b.itemTypeID = a.itemTypeID";
            loadallgeneral(query);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Stockout stockout = new Stockout();
            stockout.main = this;
            stockout.Adminid = this.Adminid;
            if (chemitemname == "")
            {
                stockout.Itemname = "";
            }
            else
            {

                stockout.Itemname = chemitemname;
            }
            stockout.Show();
        }
    }
}
