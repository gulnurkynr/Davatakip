using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
     
        private void button2_Click(object sender, EventArgs e)
        {
           
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CASPER\\OneDrive\\Masaüstü\\giriş.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select kullaniciadi,sifre from kullanicislemleri where kullaniciadi=@kullaniciadi and sifre=@sifre", baglanti);
            sorgu.Parameters.AddWithValue("@kullaniciadi",textBox1.Text);
            sorgu.Parameters.AddWithValue("@sifre", textBox2.Text);
            OleDbDataReader dr;
            dr = sorgu.ExecuteReader();
            if (dr.Read())
            {
                Form2 ac = new Form2();
                ac.Show();
                 this.Hide();  
            }
            else
            {
                
                MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış Girdiniz. Lütfen Tekrar Deneyiniz.");
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İletişim için ghoshukukburosu.2022@gmail.com  adresine e-posta atabilirsiniz.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CASPER\\OneDrive\\Masaüstü\\giriş.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into kullanicislemleri(kullaniciadi, sifre) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
