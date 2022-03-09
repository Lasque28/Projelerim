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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            
            SqlCommand com = new SqlCommand();
            
            con.Open();

            com = new SqlCommand("Insert into kimlik_kayit(kimlik_no,kimlik_ad,kimlik_soyad,kimlik_sifre,kimlik_para) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + "0"+ "')", con);
            MessageBox.Show("Yükselen banka hoşgeldin " + textBox2.Text + "hemen para yatırarak işlemlere başlayabilirsin");
            com.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 giris1 = new Form1();
            giris1.Show();
            this.Hide();

        }
    }
}
