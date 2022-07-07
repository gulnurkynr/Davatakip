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
    public partial class Form2 : Form
    {
        public Form2()
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
        private void duruşmalarıgörüntüle()
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

                listView2.Items.Add(ekle);


            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Form3 dosyaislemleri = new Form3();
            dosyaislemleri.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 durusmaislemleri = new Form4();
            durusmaislemleri.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dosyalarıgörüntüle();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            duruşmalarıgörüntüle();
        }
    }
}
