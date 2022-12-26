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
    public partial class kitapeklefrm : Form
    {
        NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
        public kitapeklefrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kitap kaynaklar = new Kitap();
            kaynaklar.kitap_isim = txtkitapismi.Text;
            kaynaklar.kitap_yazar =txtyazar.Text;
            kaynaklar.kitap_yayınevi = txtyayınevi.Text;
            kaynaklar.kitap_sayfasayisi = Convert.ToInt16(numericUpDown1.Value);
            db.Kitap.Add(kaynaklar);
            db.SaveChanges();

            var kliste = db.Kitap.ToString();
            dataGridView1.DataSource = kliste.ToList();
            
        }

        private void kitapeklefrm_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "Kitip_İd";
            dataGridView1.Columns[1].HeaderText = "Kitip_İsmi";
            dataGridView1.Columns[2].HeaderText = "Kitap_Yazarı";

            dataGridView1.Columns[3].HeaderText = "Kitap_Yayınevi";
            dataGridView1.Columns[4].HeaderText = "Kitap_Sayfası";
        }
    }
}
