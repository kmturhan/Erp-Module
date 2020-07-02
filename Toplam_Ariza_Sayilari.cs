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
    public partial class Toplam_Ariza_Sayilari : Form
    {
        public Toplam_Ariza_Sayilari()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=dt.mdb");

        private void Toplam_Ariza_Sayilari_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter adap = new OleDbDataAdapter("SELECT Tezgahlar.Tezgah_Adi, Bakima_alinan_tezgahlar.Bakim_Tipi FROM Tezgahlar INNER JOIN Bakima_alinan_tezgahlar ON Tezgahlar.id = Bakima_alinan_tezgahlar.Tezgah_id GROUP BY Bakima_alinan_tezgahlar.Tezgah_id, Tezgahlar.Tezgah_Adi, Bakima_alinan_tezgahlar.Bakim_Tipi;",baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            int top1 = 0;int top2 = 0;int top3 = 0;

            for (int i = 0; i < dataGridView1.Rows.Count - 1;i++ )
            {
                if(dataGridView1.Rows[i].Cells[1].Value.ToString() == "periyodik")                
                    top1 = top1 + 1;

                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "arıza")
                    top2 = top2 + 1;

                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "çok acil")
                    top3 = top3 + 1;
                
            }
            label1.Text = "Toplam Periyodik \n" + top1 + "\n \n \n Toplam arıza \n" + top2+"\n \n \n Toplam Çok Acil Bakımı \n"+top3;
                baglanti.Close();
        }
    }
}
