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
    public partial class deposit : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Achu Promise\Documents\bank.mdf;Integrated Security=True;Connect Timeout=30");
        public deposit()
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
                textBox7.Text = row.Cells["addess_type"].Value.ToString();

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 0 && textBox8.Text !="")
            {
                textBox9.Text = (Convert.ToInt64(textBox2.Text) + Convert.ToInt64(textBox8.Text)).ToString();

            }
    }
        public static string transid, input, name, acnumber, acbalance, idno, actype, payed, des = ""; 

        private void button11_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num = rnd.Next(100, 500);
            int roll;
            roll = 11;
            input = textBox8.Text;

            DateTime currentDate = DateTime.Now;



            name = textBox1.Text;
            acnumber = textBox4.Text;
            acbalance = textBox2.Text;
            idno = textBox5.Text;
            actype = textBox7.Text;
             
            con.Open();

            payed = textBox9.Text;

            des = "Deposit";

            SqlCommand cmdsp1x2 = con.CreateCommand();
            cmdsp1x2.CommandType = CommandType.Text;
            cmdsp1x2.CommandText = "UPDATE [dbo].[register] set account_type ='" + textBox9.Text+ "' where account_number = '"+textBox4.Text+"'";
            cmdsp1x2.CommandTimeout = 300000000;
                cmdsp1x2.ExecuteNonQuery();


            SqlCommand cmdsp1x = con.CreateCommand();
            cmdsp1x.CommandType = CommandType.Text;

            cmdsp1x.CommandText = " insert into [dbo].[transactions] (name,account_number,account_type,trans_id,roll, date,ammount, desp) values ('" + name + "', '" + acnumber + "','" + actype + "','" + num + "','" + roll + "', '"+currentDate+"', '"+input+"', '"+des+"')";


            cmdsp1x.CommandTimeout = 300000000;
            cmdsp1x.ExecuteNonQuery();
            MessageBox.Show("Account Topped up");
        }

        private void deposit_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            textBox9.Enabled = false;
            textBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
        }
    }
}
    