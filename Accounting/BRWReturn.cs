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
        public int qty { get; set; }
        public String mtype { get; set; }
        public String borrowdate { get; set; }


        MySqlConnection conn;

        public returnbutton()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=chem_lab;uid=root; Pwd = root;");

        }

        private void BRWReturn_Load(object sender, EventArgs e)
        {
            label8.Text= DateTime.Now.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {




        }
    }
}
