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

namespace Personel_Kayıt
{
    public partial class frmStatıstıcs : Form
    {
        public frmStatıstıcs()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9QAJ9L8\\SQLEXPRESS;Initial Catalog=Personel_Veri_Tabanı;Integrated Security=True");
        private void frmStatıstıcs_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            baglanti.Open();
            SqlCommand cmdselect = new SqlCommand("Select Count(*)from Tbl_Personel",baglanti);
            SqlDataReader dr1=cmdselect.ExecuteReader();
            while (dr1.Read())
            {
                LToplam.Text = dr1[0].ToString();
            }
            baglanti.Close();

            // Evli Personel sayısı
            baglanti.Open();
            SqlCommand kmtEvli = new SqlCommand("Select Count(*) from Tbl_Personel Where PerDurum=1",baglanti);
            SqlDataReader dr2=kmtEvli.ExecuteReader();
            while (dr2.Read())
            {
                LEvli.Text = dr2[0].ToString();
            }
            baglanti.Close();

            // Bekar Personel Sayısı
            baglanti.Open();
            SqlCommand kmtBekar = new SqlCommand("Select Count(*) From Tbl_Personel Where PerDurum=0",baglanti);
            SqlDataReader dr3=kmtBekar.ExecuteReader();
            while (dr3.Read())
            {
                LBekar.Text= dr3[0].ToString();
            }
            baglanti.Close();

            // Sehir sayısı
            baglanti.Open();
            SqlCommand kmtsehir = new SqlCommand("select count(distinct(PerCity)) from Tbl_Personel",baglanti);
            SqlDataReader dr4=kmtsehir.ExecuteReader();
            while (dr4.Read())
            {
                LSehir.Text= dr4[0].ToString();
            }
            baglanti.Close();
             // Toplam Maas

            baglanti.Open();
            SqlCommand kmttoplam = new SqlCommand("select sum(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr5=kmttoplam.ExecuteReader();
            while (dr5.Read())
            {
                LMaasToplam.Text= dr5[0].ToString();
            }
            baglanti.Close();

            // Maas Ortalama
            baglanti.Open();
            SqlCommand kmtort = new SqlCommand("select avg(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6=kmtort.ExecuteReader();
            while (dr6.Read())
            {
                LOrt.Text= dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
