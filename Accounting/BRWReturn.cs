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
            comboBox1.SelectedIndex = 0;

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
            string queryrequest = "UPDATE borrowing SET returnState = '" + comboBox1.Text + "', isReturned = 1, actualReturnDate='" +date + "',requestStatus='Returned' WHERE borrowRequestId = '" + borrowid + "'";


            MySqlCommand commrequest = new MySqlCommand(queryrequest, conn);
            commrequest.ExecuteNonQuery();
            conn.Close();

            conn.Open();

            string qtyupdate = "UPDATE item SET quantity = quantity + " + qty + " WHERE itemName='"+returnitem+"'";

            MySqlCommand commrequest1 = new MySqlCommand(qtyupdate, conn);
            commrequest1.ExecuteNonQuery();
            conn.Close();

            this.Close();

        }
    }
}
