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
    public partial class Bakimcilar : Form
    {
        public Bakimcilar()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=dt.mdb");
        int satir = 0;
        public void liste(string tablo_adi)
        {
            baglanti.Open();
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from " + tablo_adi, baglanti);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            satir = dataGridView1.Rows.Count;
        }
        private void Bakimcilar_Load(object sender, EventArgs e)
        {           
            liste("bakimcilar");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 a = (Form1)Application.OpenForms["Form1"];
            a.dataGridView1.CurrentCell.Value = dataGridView1.CurrentRow.Cells[0].Value;
            this.Close();
        }
    }
}
