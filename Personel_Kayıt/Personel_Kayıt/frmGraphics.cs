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
    public partial class frmGraphics : Form
    {
        public frmGraphics()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9QAJ9L8\\SQLEXPRESS;Initial Catalog=Personel_Veri_Tabanı;Integrated Security=True");


        private void frmGraphics_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select PerCity,Count(*) from Tbl_Personel group by PerCity",baglanti);
            SqlDataReader dr1= komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Citys"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select PerMeslek,avg(PerMaas) from Tbl_Personel group by PerMeslek", baglanti);
            SqlDataReader dr2=komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Job - Salary"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
