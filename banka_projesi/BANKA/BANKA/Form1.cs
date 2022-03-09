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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public string kimliktut;

        public Form1()
        {
            InitializeComponent();
        }

        private void lable1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kimlik =textBox1.Text;
            string sifre = textBox2.Text;
            con = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select*From kimlik_kayit where CONVERT(VARCHAR, kimlik_no) ='" + textBox1.Text + "'And CONVERT(VARCHAR, kimlik_sifre)='" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler giriş yaptınız");
                Form2 giris = new Form2();
               
                
                giris.label4.Text = kimlik;
                kimliktut = kimlik;
                

                giris.Show();
                this.Hide();
                con.Close();

            }
            else { MessageBox.Show("hatalı"); }











        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 giris6 = new Form6();




            giris6.Show();
            this.Hide();

        }
    }
}
