using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BANKA
{
    public partial class Form4 : Form
    {
        int toplam = 0;
        int eski1tl = 0;
        int eski5tl = 0;
        int eski10tl = 0;
        int eski20tl = 0;
        int eski50tl = 0;
        int eski100tl = 0;
        int eski200tl = 0;
        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toplam -= eski1tl * 1;
            toplam += Convert.ToInt32(textBox1.Text) * 1;
            eski1tl = Convert.ToInt32(textBox1.Text);
            label20.Text = " TOPLAM TUTAR =" + toplam.ToString() + "TL";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            toplam -= eski5tl * 5;
            toplam += Convert.ToInt32(textBox2.Text) * 5;
            eski5tl = Convert.ToInt32(textBox2.Text);
            label20.Text = " TOPLAM TUTAR =" + toplam.ToString() + "TL";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            toplam -= eski10tl * 10;
            toplam += Convert.ToInt32(textBox3.Text) * 10;
            eski10tl = Convert.ToInt32(textBox3.Text);
            label20.Text = " TOPLAM TUTAR =" + toplam.ToString() + "TL";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            toplam -= eski20tl * 20;
            toplam += Convert.ToInt32(textBox6.Text) * 20;
            eski20tl = Convert.ToInt32(textBox6.Text);
            label20.Text = " TOPLAM TUTAR =" + toplam.ToString() + "TL";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            toplam -= eski50tl * 50;
            toplam += Convert.ToInt32(textBox4.Text) * 50;
            eski50tl = Convert.ToInt32(textBox4.Text);
            label20.Text = " TOPLAM TUTAR =" + toplam.ToString() + "TL";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            toplam -= eski100tl * 100;
            toplam += Convert.ToInt32(textBox5.Text) * 100;
            eski100tl = Convert.ToInt32(textBox5.Text);
            label20.Text = " TOPLAM TUTAR =" + toplam.ToString() + "TL";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            toplam -= eski200tl * 200;
            toplam += Convert.ToInt32(textBox7.Text) * 200;
            eski200tl = Convert.ToInt32(textBox7.Text);
            label20.Text = " TOPLAM TUTAR =" + toplam.ToString() + "TL";
        }

        private void button5_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            SqlCommand com2 = new SqlCommand();
            
            string para = label4.Text;
            com.Connection = con;
            con.Open();

            com = new SqlCommand("update kimlik_kayit set kimlik_para=@para where kimlik_no=@kimlik", con);
            string paraekle = Convert.ToString(Convert.ToInt32(label4.Text) - toplam);
            com.Parameters.AddWithValue("@kimlik",label1.Text);
            com.Parameters.AddWithValue("@para", paraekle);
            com.ExecuteNonQuery();
            con.Close();
            con2.Open();


            string tür = "Para Çekme";
            com2 = new SqlCommand("Insert into hesap_islem(hesap_sahibi,hesap_tür,hesap_para) Values('" + label1.Text + "','" + tür + "','" + toplam + "')", con2);
            com2.ExecuteNonQuery();

            con2.Close();

            MessageBox.Show("Tebrikler başarıyla "+toplam+" TL çektiniz şuanki bakiyeniz " + paraekle + "TL");




            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 giris = new Form2();
            Form1 giris1 = new Form1();
            
            giris.label5.Text = label1.Text;
            giris.label5.Text = label1.Text;
            giris.art = 1;
            giris.Show();
            this.Hide();
        }
    }
}
