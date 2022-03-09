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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string fatura, vergi, havale, kira, sıra;

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            SqlCommand com2 = new SqlCommand();
            string para = label17.Text;
            kira = textBox6.Text;
            com.Connection = con;
            com2.Connection = con2;
            con.Open();
            
            com = new SqlCommand("update kimlik_kayit set kimlik_para=@para  where kimlik_no=@kimlik", con);
            string paraislem = Convert.ToString(Convert.ToInt32(para) - Convert.ToInt32(kira));
            MessageBox.Show("deneme   " + paraislem);
            com.Parameters.AddWithValue("@kimlik", label16.Text);
            com.Parameters.AddWithValue("@para", paraislem);
            com.ExecuteNonQuery();
            con.Close();
            con2.Open();

            label17.Text = "Bakiyeniz " + paraislem + " TL";
            string tür = "Kira";
            com2 = new SqlCommand("Insert into islemler(islem_sahibi,islem_türü,islem_bedeli,islem_alttür) Values('" + label16.Text + "','" + tür + "','" + kira + "','" + comboBox3.SelectedItem + "')", con2);
            com2.ExecuteNonQuery();
            MessageBox.Show("Tebrikler başarıyla " + kira+ " TL fatura ödediniz " + paraislem + "TL");
            con2.Close();
           
        }
        int sayac = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            sayac++;

            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
 
            SqlCommand com2 = new SqlCommand();
            
            con2.Open();
            
            com2 = new SqlCommand("Insert into sira_kayit(sira_sahibi,sira_şube,sira_no,sira_tarih) Values('" + label16.Text + "','" + comboBox4.SelectedItem + "','" + sayac + "','" + dateTimePicker1.Text +"')", con2);
            com2.ExecuteNonQuery();
            MessageBox.Show("Tebrikler başarıyla tarih : "+dateTimePicker1+" gününe  " + sayac+ " nolu sırayı aldınız");
            
            
            con2.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 giris = new Form2();
            giris.label5.Text = label16.Text;
            giris.art = 1;
            giris.Show();



            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            SqlCommand com2 = new SqlCommand();
            string para = label17.Text;
            havale = textBox3.Text;
            com.Connection = con;
            com2.Connection = con2;
            con.Open();

            com = new SqlCommand("update kimlik_kayit set kimlik_para=@para  where kimlik_no=@kimlik", con);
            string paraislem = Convert.ToString(Convert.ToInt32(para) - Convert.ToInt32(havale));
            MessageBox.Show("deneme   " + paraislem);
            com.Parameters.AddWithValue("@kimlik", label16.Text);
            com.Parameters.AddWithValue("@para", paraislem);
            com.ExecuteNonQuery();
            con.Close();
            con2.Open();

            label17.Text = "Bakiyeniz " + paraislem + " TL";
            string tür = "Havale";
            com2 = new SqlCommand("Insert into islemler(islem_sahibi,islem_türü,islem_bedeli,islem_kisi,islem_kisi_iban) Values('" + label16.Text + "','" + tür + "','" + havale + "','"+textBox4.Text+ "','" + textBox5.Text + "')", con2);
            com2.ExecuteNonQuery();
            MessageBox.Show("Tebrikler başarıyla " + havale + " TL fatura ödediniz " + paraislem + "TL");
            con2.Close();
            con.Close();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            SqlCommand com2 = new SqlCommand();
            string para = label17.Text;
            vergi = textBox2.Text;
            com.Connection = con;
            com2.Connection = con2;
            con.Open();

            com = new SqlCommand("update kimlik_kayit set kimlik_para=@para where kimlik_no=@kimlik", con);
            string paraislem = Convert.ToString(Convert.ToInt32(para) - Convert.ToInt32(vergi));
            MessageBox.Show("deneme   " + paraislem);
            com.Parameters.AddWithValue("@kimlik", label16.Text);
            com.Parameters.AddWithValue("@para", paraislem);
            com.ExecuteNonQuery();
            con.Close();
            con2.Open();

            label17.Text = "Bakiyeniz " + paraislem + " TL";
            string tür = "Vergi";
            com2 = new SqlCommand("Insert into islemler(islem_sahibi,islem_türü,islem_bedeli,islem_alttür) Values('" + label16.Text + "','" + tür + "','" + vergi + "','" + comboBox2.SelectedItem + "')", con2);
            com2.ExecuteNonQuery();
            MessageBox.Show("Tebrikler başarıyla " + vergi + " TL fatura ödediniz " + paraislem + "TL");
            con2.Close();
            con.Close();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Form2 giris = new Form2();
            Form1 giris1 = new Form1();

            
            

            
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-6A7GN3P;Initial Catalog=bank;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            SqlCommand com2 = new SqlCommand();
            string para = label17.Text;
            fatura = textBox1.Text;
            com.Connection = con;
            com2.Connection = con2;
            con.Open();

            com = new SqlCommand("update kimlik_kayit set kimlik_para=@para  where kimlik_no=@kimlik", con);
            string paraislem = Convert.ToString(Convert.ToInt32(para) - Convert.ToInt32(fatura));
            MessageBox.Show("deneme   " + paraislem);
            com.Parameters.AddWithValue("@kimlik", label16.Text);
            com.Parameters.AddWithValue("@para", paraislem);
            com.ExecuteNonQuery();
            con.Close();
            con2.Open();
            
            label17.Text = "Bakiyeniz " + paraislem + " TL";
            string tür = "Fatura";
            com2 =new SqlCommand("Insert into islemler(islem_sahibi,islem_türü,islem_bedeli,islem_alttür) Values('"+label16.Text+"','"+tür+ "','" + fatura + "','" + comboBox1.SelectedItem + "')",con2 );
            com2.ExecuteNonQuery();
            MessageBox.Show("Tebrikler başarıyla " + fatura + " TL fatura ödediniz " + paraislem + "TL");
            con2.Close();
            con.Close();
        }
    }
}
