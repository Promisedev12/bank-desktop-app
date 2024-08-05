using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bank
{
    public partial class Dashboad : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Achu Promise\Documents\bank.mdf;Integrated Security=True;Connect Timeout=30");
        public Dashboad()
        {
            InitializeComponent();
            con.Open();
            SqlCommand cmd = new SqlCommand("select full_name, account_type from dbo.[register]", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sdad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdad.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            createAccount1.Visible = true;
            createAccount1.BringToFront();
            deposit1.Visible = false;
            withdraw1.Visible = false;
            balance1.Visible = false;
            
        }

        private void account1_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboad_Load(object sender, EventArgs e)
        {
            deposit1.Visible = false;
            withdraw1.Visible = false;
            balance1.Visible = false;
            createAccount1.Visible = false;
            account1.Visible = false;
            transferMoney1.Visible = false;
            search_account1.Visible = false;
           
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            deposit1.Visible = true;
            deposit1.BringToFront();
            
            withdraw1.Visible = false;
            balance1.Visible = false;
            createAccount1.Visible = false;
            account1.Visible = false;
            transferMoney1.Visible = false;
            search_account1.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            withdraw1.Visible = true;
            withdraw1.BringToFront();
            deposit1.Visible = false;
            balance1.Visible = false;
            deposit1.Visible = false;
            
            balance1.Visible = false;
            createAccount1.Visible = false;
            account1.Visible = false;
            transferMoney1.Visible = false;
            search_account1.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            balance1.Visible = true;
            balance1.BringToFront();
            deposit1.Visible = false;
            withdraw1.Visible = false;
            deposit1.Visible = false;
            withdraw1.Visible = false;
            
            createAccount1.Visible = false;
            account1.Visible = false;
            transferMoney1.Visible = false;
            search_account1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            transferMoney1.Visible = true;
            transferMoney1.BringToFront();
            deposit1.Visible = false;
            withdraw1.Visible = false;
            balance1.Visible = false;
            createAccount1.Visible = false;
            account1.Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            account1.Visible = true;
            account1.BringToFront();
            deposit1.Visible = false;
            withdraw1.Visible = false;
            balance1.Visible = false;
            createAccount1.Visible = false;
            transferMoney1.Visible = false;
            search_account1.Visible = false;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            search_account1.Visible = true;
            search_account1.BringToFront();
            deposit1.Visible = false;
            withdraw1.Visible = false;
            balance1.Visible = false;
            createAccount1.Visible = false;
            account1.Visible = false;
            transferMoney1.Visible = false;
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
