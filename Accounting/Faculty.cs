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
    public partial class Faculty : Form
    {
        public Form main { get; set; }
        MySqlConnection conn;
        public Faculty()
        {
            InitializeComponent();
        }

        private void Faculty_Load(object sender, EventArgs e)
        {

        }
    }
}
