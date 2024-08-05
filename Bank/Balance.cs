using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bank
{
    public partial class Balance : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Achu Promise\Documents\bank.mdf;Integrated Security=True;Connect Timeout=30");
        public Balance()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[register] where full_name like '%" + textBox6.Text + "%'", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["full_name"].Value.ToString();
                textBox4.Text = row.Cells["account_number"].Value.ToString();
                textBox5.Text = row.Cells["id_number"].Value.ToString();
                textBox2.Text = row.Cells["account_type"].Value.ToString();
                textBox3.Text = row.Cells["addess_type"].Value.ToString();

            }
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            
            textBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            textBox3.Enabled = false;
            
        }
    }
}
