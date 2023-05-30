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

namespace CalenderProject
{
    public partial class KullaniciEkran : Form
    {
        public FrmKullaniciGiris frmKullaniciGiris;
        public KullaniciEkran()
        {
            InitializeComponent();
        }

        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void KullaniciEkran_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;

            //Ad Soyad çekme;

            SqlCommand komut = new SqlCommand("Select KullaniciAd,KullaniciSoyad From Tbl_KullaniciBilgi where KullaniciTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",LblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            // Plan Geçmişi 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Plan where KullaniciTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Plan(KullaniciTC,KullaniciPlan,PlanTarih) values(@p1,@p2,@p3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",LblTC.Text);
            komut.Parameters.AddWithValue("@p2",RchPlan.Text);
            komut.Parameters.AddWithValue("@p3",timePicker.Value);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Plan Oluşturuldu.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From tbl_Plan where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Lblid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Animsatici Silindi.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Lblid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            RchPlan.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Plan where KullaniciTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Plan set KullaniciPlan=@p1 where ID=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", RchPlan.Text);
            komut.Parameters.AddWithValue("@p2", Lblid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Guncelleme Tamamlandi ! ");
        }

        private void KullaniciEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmKullaniciGiris.Show();
        }
    }
}
