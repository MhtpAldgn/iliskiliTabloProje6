using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace iliskiliTabloProje6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B2AV4A5\\SQLDEVELOPER;Initial Catalog=İliskiliTabloProje;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
           // sqlden proedür getirme
            //SqlDataAdapter da5 = new SqlDataAdapter("execute proje6", baglanti);
            //DataTable dt5 = new DataTable();
            //da5.Fill(dt5);
            //dataGridView1.DataSource = dt5;

            this.proje6TableAdapter.Fill(this.İliskiliTabloProjeDataSet.Proje6);

            //combobox a ürünleri çekme
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblurunler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbUrun.ValueMember = "ID";
            cmbUrun.DisplayMember = "AD";
            cmbUrun.DataSource = dt;
            baglanti.Close();

            baglanti.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tblmusterıler", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cmbMusteri.ValueMember = "ID";
            cmbMusteri.DisplayMember = "ADSOYAD";
            cmbMusteri.DataSource = dt2;
            baglanti.Close();

            baglanti.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select * from tblPERSONELLER", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cmbPersonel.ValueMember = "ID";
            cmbPersonel.DisplayMember = "AD";
            cmbPersonel.DataSource = dt3;
            baglanti.Close();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into tblhareketler (URUN,MUSTERI,PERSONEL,FIYAT) values(@E1,@E2,@E3,@E4)", baglanti);
            kmt.Parameters.AddWithValue("@E1", cmbUrun.SelectedValue);
            kmt.Parameters.AddWithValue("@E2", cmbMusteri.SelectedValue);
            kmt.Parameters.AddWithValue("@E3", cmbPersonel.SelectedValue);
            kmt.Parameters.AddWithValue("@E4", short.Parse(txtFiyat.Text));
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgiler Eklendi");
            this.proje6TableAdapter.Fill(this.İliskiliTabloProjeDataSet.Proje6);

        }
    }
}
