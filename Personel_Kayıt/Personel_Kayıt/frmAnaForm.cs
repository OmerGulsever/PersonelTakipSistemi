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
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9QAJ9L8\\SQLEXPRESS;Initial Catalog=Personel_Veri_Tabanı;Integrated Security=True");
        void clearfrom()
        {
            TB_ID.Text = "";
            TB_name.Text = "";
            tb_surname.Text = "";
            cb_city.Text = "";
            mtb_salary.Text = "";
            tb_job.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TB_name.Focus();
        }






        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personel_Veri_TabanıDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personel_Veri_TabanıDataSet.Tbl_Personel);

           
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personel_Veri_TabanıDataSet.Tbl_Personel);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerName,PerSurname,PerCity,PerMaas,PerDurum,PerMeslek)values(@Name,@Surname,@city,@maas,@durum,@meslek)",baglanti);
            komut.Parameters.AddWithValue("@Name",TB_name.Text);
            komut.Parameters.AddWithValue("@Surname", tb_surname.Text);
            komut.Parameters.AddWithValue("@city", cb_city.Text);
            komut.Parameters.AddWithValue("@maas",mtb_salary.Text);
            komut.Parameters.AddWithValue("@durum", label9.Text);
            komut.Parameters.AddWithValue("@meslek",tb_job.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel eklendi!");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label9.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked== true)
            {
                label9.Text = "False";
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearfrom();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TB_ID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TB_name.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            tb_surname.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cb_city.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mtb_salary.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label9.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            tb_job.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label9_TextChanged(object sender, EventArgs e)
        {
            if (label9.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(label9.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel where PerID=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", TB_ID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutupdate = new SqlCommand("Update Tbl_Personel set PerName=@a1,PerSurname=@a2,PerCity=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where PerID=@a7",baglanti);
            komutupdate.Parameters.AddWithValue("@a1",TB_name.Text);
            komutupdate.Parameters.AddWithValue("@a2",tb_surname.Text);
            komutupdate.Parameters.AddWithValue("@a3", cb_city.Text);
            komutupdate.Parameters.AddWithValue("@a4",mtb_salary.Text);
            komutupdate.Parameters.AddWithValue("@a5", label9.Text);
            komutupdate.Parameters.AddWithValue("@a6",tb_job.Text);
            komutupdate.Parameters.AddWithValue("@a7",TB_ID.Text);
            komutupdate.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel bilgileri güncellendi");
        }

        private void btn_statistics_Click(object sender, EventArgs e)
        {
            frmStatıstıcs fr=new frmStatıstıcs();
            fr.Show();
        }

        private void btn_graphichs_Click(object sender, EventArgs e)
        {
            frmGraphics frg=new frmGraphics();
            frg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReports frp = new frmReports();
            frp.Show();
        }
    }
}
