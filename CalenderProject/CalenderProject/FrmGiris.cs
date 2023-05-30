using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalenderProject
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void BtnKullaniciGiris_Click(object sender, EventArgs e)
        {
            FrmKullaniciGiris frm1 = new FrmKullaniciGiris();
            frm1.Show();
            frm1.frmGiris = this;
            this.Hide();    
        }

        private void BtnAdminGiris_Click(object sender, EventArgs e)
        {
            FrmAdminGiris frm2 = new FrmAdminGiris();
            frm2.Show();
            frm2.frmGiris = this;
            this.Hide();
        }
    }
}
