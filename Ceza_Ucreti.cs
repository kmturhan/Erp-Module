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
    public partial class Ceza_Ucreti : Form
    {
        public Ceza_Ucreti()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=dt.mdb");

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Columns.Add("ucret","Toplam Ücret");
            
            int dev_top = 0;
            
            for(int i = 0;i<dataGridView1.Rows.Count-1;i++)
            {
                DateTime ilk = DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                DateTime son = DateTime.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                int gun = (son.Day - ilk.Day);
                
                if (textBox1.Text != "")
                {
                    int tek = gun * int.Parse(textBox1.Text);
                    dataGridView1.Rows[i].Cells["ucret"].Value = tek;
                    dev_top = dev_top + tek;
                }
                label2.Text = "Toplam Ödenecek Tutar \n "+dev_top.ToString();
                label2.Visible = true;
                
            }
            
        }

        private void Ceza_Ucreti_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter adap = new OleDbDataAdapter("SELECT Tezgahlar.Tezgah_Adi, Bakima_alinan_tezgahlar.Baslangic_Tarihi, Bakima_alinan_tezgahlar.Bitis_Tarihi, Bakima_alinan_tezgahlar.Bakim_Tipi FROM Tezgahlar INNER JOIN Bakima_alinan_tezgahlar ON Tezgahlar.id = Bakima_alinan_tezgahlar.Tezgah_id WHERE (((Bakima_alinan_tezgahlar.Bitis_Tarihi) Is Not Null) AND ((Bakima_alinan_tezgahlar.Bakim_Tipi)='çok acil'));", baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Visible = false;
            baglanti.Close();
        }

        private void aktifOlanBakımlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
