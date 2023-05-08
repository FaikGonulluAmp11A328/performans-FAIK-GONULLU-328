using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace OTOPARK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void listele()
        {
            SQLiteConnection baglanti =
                new SQLiteConnection("Data Source=proje.db;version=3");
            baglanti.Open();
            SQLiteDataAdapter da =
                new SQLiteDataAdapter("SELECT * FROM müşteri", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "müşteri");
            dataGridView1.DataSource = ds.Tables["müşteri"];
            baglanti.Close();
        }
            private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglanti =
              new SQLiteConnection("Data Source=proje.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO müşteri VALUES('" + textBox1.Text + "','" +
                    textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmARAÇ araç = new frmARAÇ();
            araç.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglanti =
            new SQLiteConnection("Data Source=proje.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText ="DELETE FROM müşteri WHERE TC='" + textBox6.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string AD = textBox1.Text;
            string SOYAD = textBox2.Text;
            string TELNO = textBox3.Text;
            string EPOSTA = textBox4.Text;
            SQLiteConnection baglanti =
                new SQLiteConnection("Data Source=proje.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText =
                "UPDATE müşteri SET AD='" + AD + "', SOYAD='" + SOYAD + "',TELNO='" + TELNO + "' " +
              "',EPOSTA='" + EPOSTA + "' " + "WHERE TC='" + textBox5.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
