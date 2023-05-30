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
    public partial class FrmKullaniciKayit : Form
    {
        public FrmKullaniciGiris frmKullaniciGiris;
        public FrmKullaniciKayit()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_KullaniciBilgi(KullaniciAd,KullaniciSoyad,KullaniciTC,KullaniciKulAd,KullaniciSifre,KullaniciTelefon,KullaniciEmail,KullaniciAdres) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut.Parameters.AddWithValue("@p6", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p7", TxtEmail.Text);
            komut.Parameters.AddWithValue("@p8", TxtAdres.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir Şifreniz :  "+TxtSifre.Text);
        }

        private void FrmKullaniciKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmKullaniciGiris.Show();
        }
    }
}
