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

            itemCode.Text = "";
            cItemCode.Text = "";
            eItemCode.Text = "";
            aItemCode.Text = "";
            itemname.Text = "";
            itemtype.SelectedIndex = 0;
            
            eitemname.Text = "";
     
            brand.Text = "";
            costunit.Text = "";
            estlife.Text = "";
            aitemname.Text = "";
            adesc.Text = "";
            textBox3.Text = "";
            colorCode.SelectedIndex = -1;
            classification.Text = "--";
            equipStatus.SelectedIndex = 0;
            appStatus.SelectedIndex = 0;
            chemStatus.SelectedIndex = 0;

            updbutton.Enabled = false;
   
            addequipb.Enabled = true;
            deselectequipb.Enabled = false;
            updequipb.Enabled = false;
            

            deselectappb.Enabled = false;
            updappb.Enabled = false;

            button2.Enabled = false;
            button3.Enabled = false;
        
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

            loadall();
        }


        private void loadall()
        {

            string numquery = "SELECT COUNT(*) AS num FROM item";
            conn.Open();
            MySqlCommand commnum = new MySqlCommand(numquery, conn);
            MySqlDataAdapter adpnum = new MySqlDataAdapter(commnum);
            conn.Close();
            DataTable dtnum = new DataTable();
            adpnum.Fill(dtnum);


            labelnum.Text= dtnum.Rows[0]["num"].ToString();


            string query = "SELECT itemID,itemCode,itemName,itemType,quantity,measurementType,addedon,modon,itemstatus FROM chem_lab.item a, chem_lab.itemtype b WHERE b.itemTypeID = a.itemTypeID";

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



            string queryequip = "SELECT a.itemID,itemCode,itemName,quantity,measurementType,brandAndModel,costPerUnit,dateOfPurchase,estimatedLife,addedon,modon,itemstatus " +
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


            string queryapp = "SELECT a.itemID,itemCode,itemName,quantity,measurementType,description,addedon,modon,itemstatus " +
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
            dataGridView3.Columns["itemCode"].HeaderText = "Item Code";
            dataGridView3.Columns["itemName"].HeaderText = "Item Name";
            dataGridView3.Columns["quantity"].HeaderText = "Quantity";
            dataGridView3.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView3.Columns["description"].HeaderText = "Description";
      
            dataGridView3.Columns["modon"].HeaderText = "Last Modified";
            dataGridView3.Columns["itemstatus"].HeaderText = "Status";

            string querychem = "SELECT a.itemID,itemCode,itemName,colorCode,classification,quantity,measurementType,addedon,modon,itemstatus " +
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
            dataGridView4.Columns["itemCode"].HeaderText = "Item Code";
            dataGridView4.Columns["itemName"].HeaderText = "Item Name";
            dataGridView4.Columns["colorCode"].HeaderText = "Color Code";
            dataGridView4.Columns["classification"].HeaderText = "Classification";
            dataGridView4.Columns["quantity"].HeaderText = "Quantity";
            dataGridView4.Columns["measurementType"].HeaderText = "Unit of Measurement";
            dataGridView4.Columns["addedon"].HeaderText = "Date Added";
            dataGridView4.Columns["modon"].HeaderText = "Last Modified";
            dataGridView4.Columns["itemstatus"].HeaderText = "Status";


            deselect();

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

            loadall();
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void addequipb_Click(object sender, EventArgs e)
        {
        
            stockin stockIn = new stockin();
            stockIn.main = this;
            stockIn.Adminid = this.Adminid;
            if (eitemname.Text == "" || brand.Text == "" || costunit.Text == "" || estlife.Text == "" || eItemCode.Text == "")
            {
                stockIn.Tabindex = 1;
            }
            else
            {
                stockIn.Tabindex = 0;
                stockIn.Itemname=eitemname.Text;
            }
            stockIn.Show();
        }

        private void deselectequipb_Click(object sender, EventArgs e)
        {
            deselect();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

       
            if (e.RowIndex >= 0)
            {
                selecteditemid = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["itemID"].Value.ToString());
                eItemCode.Text=dataGridView2.Rows[e.RowIndex].Cells["itemCode"].Value.ToString();
                eitemname.Text = dataGridView2.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
               
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

            if (eitemname.Text == "" || brand.Text == "" || costunit.Text == "" || estlife.Text == "" || eItemCode.Text=="")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }

            string query= "UPDATE item SET itemCode ='" + eItemCode.Text + "',itemName='" + eitemname.Text +
            "',modon='" + date + "',itemstatus='" + equipStatus.Text + "' WHERE itemID =" +
                    selecteditemid;

            //string query = "UPDATE item SET itemName='" + eitemname.Text + "',quantity='" + (eqty.Value - (numdmg.Value + numlost.Value)) + "',measurementtype='" + emeasuretype.Text + "',modon='" + date + "',status='"+equipStatus.Text+"' WHERE itemID =" + selecteditemid;

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();


            string query1 = "UPDATE itemequipment SET brandandmodel='" + brand.Text + "',costPerunit ='" + costunit.Text + "',dateOfPurchase='" + purchasedate.Value.ToString("yyyy-MM-dd") + "',estimatedLife='" + estlife.Text + "' WHERE itemID =" + selecteditemid;

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
                aItemCode.Text= dataGridView3.Rows[e.RowIndex].Cells["itemCode"].Value.ToString();
                aitemname.Text = dataGridView3.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                
                adesc.Text = dataGridView3.Rows[e.RowIndex].Cells["description"].Value.ToString();
               

           
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

            if (aitemname.Text == "" || adesc.Text == "" || aItemCode.Text=="")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }

            string query;
                
            query = "UPDATE item SET itemCode='" + aItemCode.Text + "',itemName='" + aitemname.Text + "',modon='" + date + "',itemstatus='" + appStatus.Text + "' WHERE itemID =" + selecteditemid;

            

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();


            string query1 = "UPDATE itemapparatus SET description='" + adesc.Text +  "' WHERE itemID =" + selecteditemid;

            MySqlCommand comm2 = new MySqlCommand(query1, conn);
            comm2.ExecuteNonQuery();


            conn.Close();
            MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cItemCode.Text= dataGridView4.Rows[e.RowIndex].Cells["itemCode"].Value.ToString();
                textBox3.Text = dataGridView4.Rows[e.RowIndex].Cells["itemname"].Value.ToString();
                colorCode.Text = dataGridView4.Rows[e.RowIndex].Cells["colorCode"].Value.ToString();
                classification.Text = dataGridView4.Rows[e.RowIndex].Cells["classification"].Value.ToString();
               
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dateValue = DateTime.Now;
            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

            if (textBox3.Text == "" || cItemCode.Text=="")
            {
                MessageBox.Show("Please do not leave any of the fields as blank");
            }


            string query = "UPDATE item SET itemCode='"+cItemCode.Text+"',itemName='" + textBox3.Text + "',modon='" + date + "',itemstatus='"+ chemStatus.Text +"' WHERE itemID =" + selecteditemid;

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand(query, conn);
            comm1.ExecuteNonQuery();


            string query1 = "UPDATE itemchemical SET colorCode='" + colorCode.Text + "',classification ='" + classification.Text + "' WHERE itemID =" + selecteditemid;

            MySqlCommand comm2 = new MySqlCommand(query1, conn);
            comm2.ExecuteNonQuery();


            conn.Close();
            MessageBox.Show("Successfully updated the item", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            loadall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stockout stockout = new Stockout();
            stockout.main = this;
            stockout.Adminid = this.Adminid;
            if (eitemname.Text == "" || brand.Text == "" || costunit.Text == "" || estlife.Text == "" || eItemCode.Text == "")
            {
                stockout.Itemname = "";
            }
            else
            {
              
                stockout.Itemname = eitemname.Text;
            }
            stockout.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadall();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            stockin stockIn = new stockin();
            stockIn.main = this;
            stockIn.Adminid = this.Adminid;
            if (aitemname.Text == "" || adesc.Text == "" || aItemCode.Text == "")
            {
                stockIn.Tabindex = 2;
            }
            else
            {
                stockIn.Tabindex = 0;
                stockIn.Itemname = aitemname.Text;
            }
            stockIn.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Stockout stockout = new Stockout();
            stockout.main = this;
            stockout.Adminid = this.Adminid;
            if (aitemname.Text == "" || adesc.Text == "" || aItemCode.Text == "")
            {
                stockout.Itemname = "";
            }
            else
            {

                stockout.Itemname = aitemname.Text;
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
            loadall();
        }

        private void chemstock_Click(object sender, EventArgs e)
        {
            stockin stockIn = new stockin();
            stockIn.main = this;
            stockIn.Adminid = this.Adminid;
            if (textBox3.Text == "" || classification.Text == "--" || cItemCode.Text == "")
            {
                stockIn.Tabindex = 3;
            }
            else
            {
                stockIn.Tabindex = 0;
                stockIn.Itemname = textBox3.Text;
            }
            stockIn.Show();
        }
    }
}
