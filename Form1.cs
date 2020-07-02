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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DateTimePicker tarih = new DateTimePicker();
        DateTimePicker saat = new DateTimePicker();
        

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

            for(int i = 0;i<dataGridView1.Rows.Count-1;i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "Pasif")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen; 
            }
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
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "Pasif")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
        public void sil(string tablo_adi)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete * from " + tablo_adi + " where id = " + dataGridView1.CurrentRow.Cells[0].Value + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            liste("Bakima_alinan_tezgahlar");
            
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].HeaderText == "Baslangic_Tarihi" || dataGridView1.Columns[i].HeaderText == "Bitis_Tarihi")
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                Bakimcilar bakimci = new Bakimcilar();
                bakimci.Show();
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                Tezgahlar tezgah = new Tezgahlar();
                tezgah.Show();
            }            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.Value.ToString() != "")
            {
                if (dataGridView1.NewRowIndex != satir - 1)
                    veri_ekle("Bakima_alinan_tezgahlar");
                else if (dataGridView1.RowCount != 0 && dataGridView1.CurrentCell.ColumnIndex != 0)
                    guncelle("Bakima_alinan_tezgahlar");              
            }           
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.NewRowIndex != satir - 1)
                veri_ekle("Bakima_alinan_tezgahlar");
            else if (dataGridView1.RowCount != 0 && dataGridView1.CurrentCell.ColumnIndex != 0)
                guncelle("bakima_alinan_tezgahlar");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.HeaderText == "Baslangic_Tarihi" || dataGridView1.CurrentCell.OwningColumn.HeaderText == "Bitis_Tarihi")
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
            if (dataGridView1.NewRowIndex != satir - 1)
                veri_ekle("Bakima_alinan_tezgahlar");
            else if (dataGridView1.RowCount != 0 && dataGridView1.CurrentCell.ColumnIndex != 0)
                guncelle("Bakima_alinan_tezgahlar");
        }
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.HeaderText == "Baslangic_Tarihi" || dataGridView1.CurrentCell.OwningColumn.HeaderText == "Bitis_Tarihi")
                dataGridView1.CurrentCell.Value = tarih.Text;
            if (dataGridView1.CurrentCell.OwningColumn.HeaderText == "giris_saati" || dataGridView1.CurrentCell.OwningColumn.HeaderText == "cikis_saati")
                dataGridView1.CurrentCell.Value = saat.Text;

            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "")
                dataGridView1.CurrentRow.Cells[6].Value = "Aktif";
            else
                dataGridView1.CurrentRow.Cells[6].Value = "Pasif";

            if (dataGridView1.NewRowIndex != satir - 1)
                veri_ekle("Bakima_alinan_tezgahlar");
            
            else if (dataGridView1.RowCount != 0 && dataGridView1.CurrentCell.ColumnIndex != 0)
            {
                baglanti.Open();
                OleDbCommand komut2 = new OleDbCommand("update Bakima_alinan_tezgahlar set durum = '" + dataGridView1.CurrentRow.Cells[6].Value + "' where id= " + dataGridView1.CurrentRow.Cells[0].Value + "", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
                
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            tarih.Visible = false;
            saat.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sil("Bakima_alinan_tezgahlar");
            liste("Bakima_alinan_tezgahlar");
        }

        
    }
}
