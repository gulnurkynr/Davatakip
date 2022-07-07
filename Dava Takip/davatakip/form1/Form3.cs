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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void dosyalarıgörüntüle()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CASPER\\OneDrive\\Masaüstü\\giriş.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select * from dosyaislemleri";
            OleDbDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["mahkemeadı"].ToString();
                ekle.SubItems.Add(oku["esasno"].ToString());
                ekle.SubItems.Add(oku["dosyatürü"].ToString());
                ekle.SubItems.Add(oku["davaacilisnedeni"].ToString());
                ekle.SubItems.Add(oku["dosyadurumu"].ToString());
                ekle.SubItems.Add(oku["davaacilistarihi"].ToString());

                listView1.Items.Add(ekle);


            }
        }

            private void button1_Click(object sender, EventArgs e)
        {
            Form2 menü = new Form2();
            menü.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CASPER\\OneDrive\\Masaüstü\\giriş.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("insert into dosyaislemleri (mahkemeadı,esasno,dosyatürü,davaacilisnedeni,dosyadurumu,davaacilistarihi) values('"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+ textBox4.Text.ToString() + "','" +comboBox1.Text.ToString() +"','"+dateTimePicker1.Value.ToString()+"')",baglanti);
            sorgu.ExecuteNonQuery();
            baglanti.Close();
            dosyalarıgörüntüle();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text="";
            dateTimePicker1.Text = "";
            MessageBox.Show("Yeni Dosya Başarıyla Eklenmiştir.");


        }
      
            private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CASPER\\OneDrive\\Masaüstü\\giriş.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand(Text);
            sorgu.Connection = baglanti;
            sorgu.CommandText = "Delete from dosyaislemleri where esasno ='" + textBox5.Text + "'";
            sorgu.ExecuteNonQuery();
            baglanti.Close();
            dosyalarıgörüntüle();
            textBox5.Clear();
            MessageBox.Show("Bilgileriniz Başarıyla Silinmiştir.");


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
