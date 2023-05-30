using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace CalenderProject
{
    public partial class FrmAdminGiris : Form
    {
        public FrmGiris frmGiris;
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_AdminBilgi Where AdminTC=@p1 and AdminSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                AdminEkran fr = new AdminEkran();
                fr.tc = MskTC.Text;
                fr.frmAdminGiris = this;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali TC ya da Sifre !!!");
            }

            bgl.baglanti().Close();
        }

        private void FrmAdminGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmGiris.Show();
        }
    }
}
