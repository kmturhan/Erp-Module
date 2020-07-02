using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication15
{
    public partial class Islemler : Form
    {
        public Islemler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tezgahlar tzg = new Tezgahlar();
            tzg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ceza_Ucreti ceza = new Ceza_Ucreti();
            ceza.Show();
        }

        private void aktifBakımlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rapor1 rp1 = new Rapor1();
            rp1.Show();
        }

        private void toplamArızaSayılarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Toplam_Ariza_Sayilari tas = new Toplam_Ariza_Sayilari();
            tas.Show();
        }

        private void bakımcıÇalışmaSüreleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rapor2 rp2 = new rapor2();
            rp2.Show();

        }

        private void Islemler_Load(object sender, EventArgs e)
        {

        }
    }
}
