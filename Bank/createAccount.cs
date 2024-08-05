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
    public partial class createAccount : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Achu Promise\Documents\bank.mdf;Integrated Security=True;Connect Timeout=30");
        public createAccount()
        {
            InitializeComponent();
        }

        private void createAccount_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "image files (*.png)|*.png|(*.jpg)|(*.jpg|(*.gif)|*.gif|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imageLocation = ofd.FileName.ToString();
                pictureBox2.ImageLocation = imageLocation;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        public static string name, contact, addres, transaction_pin, sex, next_of_king, password, email, id_number, DOB, account_type, other_descriptions, amount_type, profile_pic, signature_pic = "";
        private void button11_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            contact = textBox3.Text;
            addres = textBox9.Text;
            transaction_pin = textBox2.Text;
            next_of_king = textBox4.Text;
            password = textBox7.Text;
            email = textBox5.Text;
            id_number = textBox6.Text;
            account_type = comboBox1.Text;
            other_descriptions = comboBox6.Text;
            amount_type = textBox8.Text;
            profile_pic = pictureBox1.Text;
            signature_pic = pictureBox2.Text;
           
            DOB = comboBox2.Text + "/" + comboBox3.Text + "/" + comboBox4.Text;
            if (checkBox1.Checked == true)
            {
                sex = "male";
            }
            else
            {
                sex = "female";
            }
            Random rnd = new Random();
            int num = rnd.Next(100000012, 199999999);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into dbo.[register] (full_name, contact, adress, transaction_pin, next_of_king, password, email, id_number, DOB, addess_type, other_descriptions, account_type, sex, profile_pic, signature_pic, account_number) values('" + name + "', '" + contact + "', '" + addres + "', '" + transaction_pin + "', '" + next_of_king + "', '" + password + "', '" + email + "', '" + id_number + "', '" + DOB + "', '" + account_type + "', '" + other_descriptions + "', '" + amount_type + "', '" + sex + "', '" + profile_pic + "', '" + signature_pic + "', '"+num+"')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert Secces");
            con.Close();
        }
        public static string imageLocation, idcard = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "image files (*.png)|*.png|(*.jpg)|(*.jpg|(*.gif)|*.gif|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imageLocation = ofd.FileName.ToString();
                pictureBox1.ImageLocation = imageLocation;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
