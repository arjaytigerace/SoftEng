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
    public partial class ChemicalManagement : Form
    {
        public Form main { get; set; }
        public ChemicalManagement()
        {
            InitializeComponent();
        }

        private void ChemicalManagement_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChemicalManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChemMgtCreate chemcreate = new ChemMgtCreate();
            chemcreate.main = this;
            chemcreate.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChemMgtUpdate chemupd = new ChemMgtUpdate();
            chemupd.main = this;
            chemupd.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
