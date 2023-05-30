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
using System.Net.Sockets;

namespace CalenderProject
{
    public partial class FrmKullaniciGiris : Form
    {
        public FrmGiris frmGiris;
        public FrmKullaniciGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKullaniciKayit frmKayit = new FrmKullaniciKayit();
            frmKayit.frmKullaniciGiris = this;
            frmKayit.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_KullaniciBilgi Where KullaniciTC=@p1 and KullaniciSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read()) 
            { 
                KullaniciEkran frmEkran = new KullaniciEkran();
                frmEkran.tc = MskTC.Text;
                frmEkran.frmKullaniciGiris = this;
                frmEkran.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali TC ya da Sifre !!!");
            }

            bgl.baglanti().Close();
        }

        private void FrmKullaniciGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmGiris.Show();
        }
    }
}
