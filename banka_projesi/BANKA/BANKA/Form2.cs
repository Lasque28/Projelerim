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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
          
        }
        Form3 giris2 = new Form3();
        Form4 giris4 = new Form4();
        Form5 giris5 = new Form5();
        string no, ad, soyad, sifre, para;
        
        

        private void button3_Click(object sender, EventArgs e)
        {
            
            giris5.Show();
            giris5.label16.Text = label4.Text;
            giris5.label17.Text = para;
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris4.label1.Text = label4.Text;
            
               
            giris4.label4.Text = para;

            giris4.Show();
            this.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            giris2.label1.Text = label4.Text;
            giris2.label4.Text = para;
                
            giris2.Show();
            this.Visible = false;
        }
        public int art=0;
        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 giris1 = new Form1();
         
            if (art > 0) { label4.Text = label5.Text; }
            giris5.label17.Text = label4.Text;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlDataReader dr;
            SqlCommand com =new SqlCommand();
            con.Open();
            art++;
            com.Connection = con;
            com.CommandText = "Select*From kimlik_kayit where  kimlik_no= '"+ label4.Text + "'" ;
            dr = com.ExecuteReader();
            if (dr.Read())
            {
               
                no = dr[1].ToString();
               ad = dr[2].ToString();
                soyad = dr[3].ToString();
                sifre = dr[4].ToString();
                para = dr[5].ToString();
                label1.Text = "HOŞGELDİNİZ  "+ad+" "+soyad+" ";
                giris2.label3.Text = "HOŞGELDİNİZ  " + ad + " " + soyad + " Bakiyeniz : "+para+"TL";
                giris4.label3.Text = "HOŞGELDİNİZ  " + ad + " " + soyad + " Bakiyeniz : " + para + "TL";
                label3.Text = "Bakiyeniz " + para + " TL";
                con.Close();
               

            }
            else { MessageBox.Show("geçiş yapılıyor"); }
            
            if(label5.Text!="görünmez")
            {
                SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
                SqlDataReader dr2;
                SqlCommand com2 = new SqlCommand();
                con2.Open();
                com2.Connection = con2;
                com2.CommandText = "Select*From kimlik_kayit where  kimlik_no= '" + giris1.kimliktut + "' OR kimlik_no ='" + label5.Text + "'";
                dr2 = com2.ExecuteReader();
                if (dr2.Read())
                {

                    no = dr2[1].ToString();
                    ad = dr2[2].ToString();
                    soyad = dr2[3].ToString();
                    sifre = dr2[4].ToString();
                    para = dr2[5].ToString();
                    label1.Text = "HOŞGELDİNİZ  " + ad + " " + soyad + " ";
                    giris2.label3.Text = "HOŞGELDİNİZ  " + ad + " " + soyad + " Bakiyeniz : " + para + "TL";
                    giris4.label3.Text = "HOŞGELDİNİZ  " + ad + " " + soyad + " Bakiyeniz : " + para + "TL";
                    label3.Text = "Bakiyeniz " + para + " TL";
                    con2.Close();

                }

            }
            else { MessageBox.Show("zort"); }
        }
    }
}
