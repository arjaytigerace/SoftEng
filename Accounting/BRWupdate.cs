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
    public partial class BRWupdate : Form
    {
        public Form main { get; set; }
        public int Adminid { get; set; }
        public string Getfname { get; set; }
        public string Getlname { get; set; }
        public int brequestid { get; set; }
        public int studentid { get; set; }
        public String itemname { get; set; }
        public int quantity { get; set; }
        public String measuretype { get; set; }
        public String sfname { get; set; }
        public String slname { get; set; }
        public String yearcourse { get; set; }
        public String status { get; set; }
        public String borrowdate { get; set; }

        MySqlConnection conn;
        public BRWupdate()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");
        }

        private void BRWupdate_Load(object sender, EventArgs e)
        {
            itemName.Text = itemname;
            qty.Value = quantity;
            label6.Text = measuretype;
            label1.Text = borrowdate;
            sID.Text = studentid.ToString();
            sFName.Text = sfname;
            sLName.Text = slname;
            yc.Text = yearcourse;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
