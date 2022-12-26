using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneotomasyonuSe
{
    
    public partial class kitapgüncellefrm : Form
    {
        NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
        public kitapgüncellefrm()
        {
            InitializeComponent();
        }

        private void kitapgüncellefrm_Load(object sender, EventArgs e)
        {
            var kaynaklar = db.Kitap.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();
            dataGridView1.Columns[0].HeaderText = "Kitap İd";
            dataGridView1.Columns[1].HeaderText = "Kitip İsmi";
            dataGridView1.Columns[2].HeaderText = "Kitap Yazarı";

            dataGridView1.Columns[3].HeaderText = "Kitap Yayınevi";
            dataGridView1.Columns[4].HeaderText = "Kitap Sayfası";
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int seçilenkaynak = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var güncellenecekKaynak = db.Kitap.Where(x => x.kitap_id == seçilenkaynak).FirstOrDefault();
            güncellenecekKaynak.kitap_isim = txtkitapismi.Text;
            güncellenecekKaynak.kitap_yazar = txtyazar.Text;
            güncellenecekKaynak.kitap_yayınevi =txtyayınevi.Text;
            güncellenecekKaynak.kitap_sayfasayisi = Convert.ToInt16(txtsyfSayısı.Value);
            db.SaveChanges();

            var kaynaklar = db.Kitap.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtkitapismi.Text = dataGridView1.CurrentRow.Cells["kitap_isim"].Value.ToString();
                txtyazar.Text = dataGridView1.CurrentRow.Cells["kitap_yazar"].Value.ToString();
                txtyayınevi.Text = dataGridView1.CurrentRow.Cells["kitap_yayınevi"].Value.ToString();
                txtsyfSayısı.Text = dataGridView1.CurrentRow.Cells["kitap_sayfasayisi"].Value.ToString();
                


            }
        }
    }
}
