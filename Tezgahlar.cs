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
    public partial class Tezgahlar : Form
    {
        public Tezgahlar()
        {
            InitializeComponent();
        }
        DateTimePicker tarih = new DateTimePicker();
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
        
        public void veri_ekle(string tablo_adi)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into " + tablo_adi + "(id) values(" + dataGridView1.CurrentCell.Value.ToString() + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            satir = dataGridView1.Rows.Count;
        }
        public void guncelle(string tablo_adi)
        {
            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("update " + tablo_adi + " set " + dataGridView1.CurrentCell.OwningColumn.HeaderText + " = '" + dataGridView1.CurrentCell.Value + "' where id= " + dataGridView1.CurrentRow.Cells[0].Value + "", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
        }
        public void sil(string tablo_adi)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete * from " + tablo_adi + " where id = " + dataGridView1.CurrentRow.Cells[0].Value + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void Tezgahlar_Load(object sender, EventArgs e)
        {
            liste("Tezgahlar");         
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 a = (Form1)Application.OpenForms["Form1"];
            a.dataGridView1.CurrentCell.Value = dataGridView1.CurrentRow.Cells[0].Value;
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.HeaderText == "Calisma_Tarihi" || dataGridView1.CurrentCell.OwningColumn.HeaderText == "Bitis_Tarihi")
            {
                tarih = new DateTimePicker();
                if (dataGridView1.CurrentCell.Value.ToString() != "")
                {
                    tarih.Value = Convert.ToDateTime(dataGridView1.CurrentCell.Value);
                }

                dataGridView1.Controls.Add(tarih);
                tarih.CustomFormat = "dd/MM/yyyy";
                tarih.Format = DateTimePickerFormat.Custom;
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                tarih.Size = new Size(oRectangle.Width, oRectangle.Height);
                tarih.Location = new Point(oRectangle.X, oRectangle.Y);
                tarih.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
                tarih.TextChanged += new EventHandler(dateTimePicker_OnTextChange);
                tarih.Visible = true;
            }
        }
        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            if (dataGridView1.NewRowIndex != satir-1)
                veri_ekle("Tezgahlar");
            if (dataGridView1.RowCount != 0)
                guncelle("Tezgahlar");

            //cl.liste(this, comboBox1.SelectedItem.ToString());
            

        }
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.HeaderText == "Baslangic_Tarihi" || dataGridView1.CurrentCell.OwningColumn.HeaderText == "Bitis_Tarihi")
                dataGridView1.CurrentCell.Value = tarih.Text;
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                baglanti.Open();
                OleDbDataAdapter adap = new OleDbDataAdapter("SELECT Tezgahlar.Tezgah_Adi, bakimcilar.ad_soyad as [Bakımcı Ad Soyad], Bakima_alinan_tezgahlar.Baslangic_Tarihi, Bakima_alinan_tezgahlar.Bitis_Tarihi, Bakima_alinan_tezgahlar.Bakim_Tipi, Bakima_alinan_tezgahlar.Durum FROM Tezgahlar INNER JOIN (bakimcilar INNER JOIN Bakima_alinan_tezgahlar ON bakimcilar.id = Bakima_alinan_tezgahlar.bakimci_id) ON Tezgahlar.id = Bakima_alinan_tezgahlar.Tezgah_id WHERE (((Bakima_alinan_tezgahlar.Durum)='Aktif'));",baglanti);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView2.DataSource = dt;
                baglanti.Close();
                this.Size = new Size(721, 647);
            }
            else
                this.Size = new Size(721, 302);
        }
    }
}
