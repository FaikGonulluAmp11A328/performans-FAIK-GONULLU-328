using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTOPARK
{
    public partial class frmARAÇ : Form
    {
        public frmARAÇ()
        {
            InitializeComponent();
        }
        private void listele()
        {
            SQLiteConnection baglanti =
                new SQLiteConnection("Data Source=proje.db;version=3");
            baglanti.Open();
            SQLiteDataAdapter da =
                new SQLiteDataAdapter("SELECT * FROM ARAÇ", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "ARAÇ");
             dataGridView1.DataSource = ds.Tables["ARAÇ"];
            baglanti.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            SQLiteConnection baglanti =
             new SQLiteConnection("Data Source=proje.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText = "INSERT INTO ARAÇ VALUES('" + textBox1.Text + "','" + 
            textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')";
            komut.ExecuteNonQuery();

            baglanti.Close();
        }

        private void frmARAÇ_Load(object sender, EventArgs e)
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
            komut.CommandText = $"DELETE FROM ARAÇ WHERE PARK YERİ='" + textBox5.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }
    }
}
