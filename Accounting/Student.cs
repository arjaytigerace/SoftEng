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
    public partial class Student : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void Student_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
