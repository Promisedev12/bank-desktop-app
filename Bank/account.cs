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
    public partial class account : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Achu Promise\Documents\bank.mdf;Integrated Security=True;Connect Timeout=30");
        public account()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[register] where account_number like '%" + textBox3.Text + "%'", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }
        public static string accountNumber = "";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                accountNumber = row.Cells["account_number"].Value.ToString();

                con.Open();
                SqlCommand cmd = new SqlCommand("select name, account_number, desp, ammount, date  from [dbo].[transactions] where account_number = '" + accountNumber + "' and roll = '" + 11 + "'", con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;

                SqlCommand cmd1 = new SqlCommand("select name, account_number, desp, ammount, date   from [dbo].[transactions] where account_number = '" + accountNumber + "' and roll = '" + 12 + "'", con);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView4.DataSource = dt1;


                SqlCommand cmd2 = new SqlCommand("select name, account_number, desp, ammount, date   from [dbo].[transactions] where account_number = '" + accountNumber + "' and roll = '" + 13 + "'", con);
                cmd2.ExecuteNonQuery();
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                dataGridView3.DataSource = dt2;

                con.Close();
            }
        }
    }
}
