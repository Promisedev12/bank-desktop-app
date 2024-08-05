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
    public partial class withdraw : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Achu Promise\Documents\bank.mdf;Integrated Security=True;Connect Timeout=30");

        public withdraw()
        {
            InitializeComponent();
        }

        private void withdraw_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            textBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
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
                textBox7.Text = row.Cells["full_name"].Value.ToString();
                textBox4.Text = row.Cells["account_number"].Value.ToString();
                textBox5.Text = row.Cells["id_number"].Value.ToString();
                textBox2.Text = row.Cells["account_type"].Value.ToString();
                textBox1.Text = row.Cells["addess_type"].Value.ToString();

            }
        }
        public static string transid, input, name, acnumber, acbalance, idno, actype, payed, des, balance, amount, withdrawAmount = ""; 
        private void button11_Click(object sender, EventArgs e)
        {

            //int balance = int.Parse(textBox2.Text);
            //int amount = int.Parse(textBox8.Text);
            if (Convert.ToInt64(textBox2.Text) > Convert.ToInt64(textBox8.Text))
            {
                //int withdrawAmount = balance - amount;
                withdrawAmount = (Convert.ToInt64(textBox2.Text) - Convert.ToInt64(textBox8.Text)).ToString();
                Random rnd = new Random();
                int num = rnd.Next(100, 500);
                int roll;
                roll = 12;
                input = textBox8.Text;

                DateTime currentDate = DateTime.Now;



                name = textBox7.Text;
                acnumber = textBox4.Text;
                acbalance = textBox2.Text;
                idno = textBox5.Text;
                actype = textBox1.Text;

                con.Open();

                //payed = textBox9.Text;

                des = "Withdrawal";

                SqlCommand cmdsp1x2 = con.CreateCommand();
                cmdsp1x2.CommandType = CommandType.Text;
                cmdsp1x2.CommandText = "UPDATE [dbo].[register] set account_type ='" + withdrawAmount + "' where account_number = '" + textBox4.Text + "'";
                cmdsp1x2.CommandTimeout = 300000000;
                cmdsp1x2.ExecuteNonQuery();


                SqlCommand cmdsp1x = con.CreateCommand();
                cmdsp1x.CommandType = CommandType.Text;

                cmdsp1x.CommandText = " insert into [dbo].[transactions] (name,account_number,account_type,trans_id,roll, date,ammount, desp) values ('" + name + "', '" + acnumber + "','" + actype + "','" + num + "','" + roll + "', '" + currentDate + "', '" + input + "', '" + des + "')";


                cmdsp1x.CommandTimeout = 300000000;
                cmdsp1x.ExecuteNonQuery();
                MessageBox.Show("Withdrawal succesfull");

            }
            else {
                MessageBox.Show("Insuficient balance");
            }
            

            
        }
    }
}
