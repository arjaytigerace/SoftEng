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
    public partial class INDI : Form
    {
        MySqlConnection conn;
        public INDI()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=exam;uid=root; Pwd = root;");
            loadall();
        }

        public Form main { get; set; }
        private void INDI_Load(object sender, EventArgs e)
        {

        }

        private void INDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateValue = DateTime.Now;
            string date = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

            conn.Open();
            MySqlCommand comm1 = new MySqlCommand("Insert", conn);
            comm1.CommandType = CommandType.StoredProcedure;

            comm1.Parameters.Add("?etext", MySqlDbType.VarChar, 255).Value = textBox1.Text;
            comm1.Parameters.Add("?edate", MySqlDbType.Date).Value = dateTimePicker1.Value;
            comm1.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Success", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadall();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadall()
        {
            string query = "SELECT id,etext,edate FROM new_table";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["etext"].HeaderText = "Text";
            dataGridView1.Columns["edate"].HeaderText = "Date";

            string query1 = "SELECT COUNT(*) from new_table";
            MySqlCommand comm1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp1 = new MySqlDataAdapter(comm1);
            conn.Close();
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            textBox2.Text = dt1.Rows[0][0].ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
