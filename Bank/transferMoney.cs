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
    public partial class transferMoney : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Achu Promise\Documents\bank.mdf;Integrated Security=True;Connect Timeout=30");
        public transferMoney()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[register] where full_name like '%" + textBox1.Text + "%'", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;

            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox7.Text = row.Cells["full_name"].Value.ToString();
                textBox4.Text = row.Cells["account_number"].Value.ToString();
                textBox5.Text = row.Cells["id_number"].Value.ToString();
                textBox2.Text = row.Cells["account_type"].Value.ToString();
                

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            textBox10.Text = row.Cells["full_name"].Value.ToString();
            textBox8.Text = row.Cells["account_number"].Value.ToString();
            textBox3.Text = row.Cells["id_number"].Value.ToString();
            textBox9.Text = row.Cells["account_type"].Value.ToString();
                
        }
        public static string newAcc1Blnc, newAcc2Blnc,  input, name, fromAccNum,toAccNum, nameFrom, nameTo, des = "";
        
        private void button11_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt64(textBox2.Text) > Convert.ToInt64(textBox11.Text))
            {
                newAcc1Blnc = (Convert.ToInt64(textBox2.Text) - Convert.ToInt64(textBox11.Text)).ToString();
                newAcc2Blnc = (Convert.ToInt64(textBox9.Text) + Convert.ToInt64(textBox11.Text)).ToString();

                Random rnd = new Random();
                int num = rnd.Next(100, 500);
                int roll;
                roll = 13;
                input = textBox11.Text;

                DateTime currentDate = DateTime.Now;

                name = textBox7.Text;
                fromAccNum = textBox4.Text;
                toAccNum = textBox8.Text;
                nameFrom = textBox7.Text;
                nameTo = textBox10.Text;
                des = "Money transfer";

                con.Open();
                SqlCommand cmdsp1x1 = con.CreateCommand();
                cmdsp1x1.CommandType = CommandType.Text;
                cmdsp1x1.CommandText = "UPDATE [dbo].[register] set account_type ='" + newAcc1Blnc + "' where account_number = '" + textBox4.Text + "'";
                cmdsp1x1.CommandTimeout = 300000000;
                cmdsp1x1.ExecuteNonQuery();

                SqlCommand cmdsp1x2 = con.CreateCommand();
                cmdsp1x2.CommandType = CommandType.Text;
                cmdsp1x2.CommandText = "UPDATE [dbo].[register] set account_type ='" + newAcc2Blnc + "' where account_number = '" + textBox8.Text + "'";
                cmdsp1x2.CommandTimeout = 300000000;
                cmdsp1x2.ExecuteNonQuery();

                SqlCommand cmdsp1x = con.CreateCommand();
                cmdsp1x.CommandType = CommandType.Text;

                cmdsp1x.CommandText = " insert into [dbo].[transactions] (name,trans_id,roll, date,ammount, desp, to_account, from_account, to_name, from_name) values ('" + name + "','" + num + "','" + roll + "', '" + currentDate + "', '" + input + "', '" + des + "', '" + fromAccNum + "', '" + toAccNum + "', '" + nameTo + "', '" + nameFrom + "')";


                cmdsp1x.CommandTimeout = 300000000;
                cmdsp1x.ExecuteNonQuery();
                MessageBox.Show("Transfer Succesfull");


            }
            else {
                MessageBox.Show("Insuficient balance to perfom this transfer");
            }
        }

        private void transferMoney_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            textBox7.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox2.Enabled = false;
            textBox10.Enabled = false;
            textBox8.Enabled = false;
            textBox3.Enabled = false;
            textBox9.Enabled = false;

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
