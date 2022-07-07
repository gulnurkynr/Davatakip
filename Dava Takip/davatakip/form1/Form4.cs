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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void durusmalarıgörüntüle()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CASPER\\OneDrive\\Masaüstü\\giriş.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select * from durusmaislemleri";
            OleDbDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["durusmatarihi"].ToString();
                ekle.SubItems.Add(oku["durusmasaati"].ToString());
                ekle.SubItems.Add(oku["kesiftarihi"].ToString());
                ekle.SubItems.Add(oku["kesifsaati"].ToString());
                ekle.SubItems.Add(oku["dosyano"].ToString());
                ekle.SubItems.Add(oku["müracaattarihi"].ToString());

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
            OleDbCommand sorgu = new OleDbCommand("insert into durusmaislemleri (durusmatarihi,durusmasaati,kesiftarihi,kesifsaati,dosyano,müracaattarihi) values('" + dateTimePicker1.Value.ToString() + "','" + maskedTextBox1.Text.ToString() + "','" + dateTimePicker2.Value.ToString() + "','" + maskedTextBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + dateTimePicker3.Value.ToString() + "')", baglanti);
            sorgu.ExecuteNonQuery();
            baglanti.Close();
            durusmalarıgörüntüle();
            dateTimePicker1.Text = "";
            maskedTextBox1.Clear();
            dateTimePicker2.Text = "";
            maskedTextBox2.Clear();
            textBox3.Clear();
            dateTimePicker3.Text = "";
            MessageBox.Show("Yeni Dosya Başarıyla Eklenmiştir.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\CASPER\\OneDrive\\Masaüstü\\giriş.accdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand(Text);
            sorgu.Connection = baglanti;
            sorgu.CommandText = "Delete from durusmaislemleri where dosyano ='" + textBox5.Text + "'";
            sorgu.ExecuteNonQuery();
            baglanti.Close();
            durusmalarıgörüntüle();
            textBox5.Clear();

        }

    }
}
