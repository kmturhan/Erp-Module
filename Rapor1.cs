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
    public partial class Rapor1 : Form
    {
        public Rapor1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=dt.mdb");

        private void Rapor1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter adap = new OleDbDataAdapter("SELECT Bakima_alinan_tezgahlar.* FROM Bakima_alinan_tezgahlar WHERE (((Bakima_alinan_tezgahlar.Durum)='Aktif'));",baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
