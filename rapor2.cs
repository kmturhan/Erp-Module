using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication15
{
    public partial class rapor2 : Form
    {
        public rapor2()
        {
            InitializeComponent();
        }
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=dt.mdb");

        private void rapor2_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter adap = new OleDbDataAdapter("SELECT bakimcilar.ad_soyad, Bakima_alinan_tezgahlar.Baslangic_Tarihi, Bakima_alinan_tezgahlar.Bitis_Tarihi FROM bakimcilar INNER JOIN Bakima_alinan_tezgahlar ON bakimcilar.id = Bakima_alinan_tezgahlar.bakimci_id WHERE (((Bakima_alinan_tezgahlar.Durum)='Pasif'));", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            int top = 0; int top2 = 0;
            dataGridView1.Columns.Add("ucret", "Saatler");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DateTime ilk = DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                DateTime son = DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                
                int gun = (son.Day - ilk.Day);
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "haydar")
                {
                    top = top + gun;
                    dataGridView1.Rows[i].Cells["ucret"].Value = gun;
                }
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "hüseyin")
                {
                    top2 = top2 + gun;
                    dataGridView1.Rows[i].Cells["ucret"].Value = gun;
                }

            }
            label1.Text = "Haydar'ın çalışma süresi \n " + top + " \n \n \n Hüseyin'in çalışma süresi \n " + top2;
            
        }
    }
}
