using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting
{
    public partial class Inventory2 : Form
    {
        public Form main { get; set; }

        public Inventory2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Inventory2_Load(object sender, EventArgs e)
        {

        }

        private void Inventory2_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }
    }
}
