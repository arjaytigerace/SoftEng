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
    public partial class StudentsFaculty : Form
    {
        public Form main { get; set; }

        MySqlConnection conn;

        public StudentsFaculty()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentsFaculty_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student stud = new Student();
            stud.main = this;
            stud.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Faculty fac = new Faculty();
            fac.main = this;
            fac.Show();
        }
    }
}
