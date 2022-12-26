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
    public partial class gerialfrm : Form
    {
        NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
        public gerialfrm()
        {
            InitializeComponent();
        }

        private void gerialfrm_Load(object sender, EventArgs e)
        {
            var kayitlar = db.odunc.Where(x=> x.durum ==false).ToList();
            dataGridView1.DataSource = kayitlar.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenKayit = Convert.ToInt16( dataGridView1.CurrentRow.Cells[0].Value);
            var kayit=db.odunc.Where(x=> x.kayıt_id == secilenKayit).FirstOrDefault();
            kayit.durum = true;
            //liste tazele
            var kayitlar = db.odunc.Where(x => x.durum == false).ToList();
            dataGridView1.DataSource = kayitlar.ToList();
            db.SaveChanges();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "Kayıt_İd";
            dataGridView1.Columns[1].HeaderText = "Kullanıcı_İd";
            dataGridView1.Columns[2].HeaderText = "Kitap_İd";

            dataGridView1.Columns[3].HeaderText = "Alis_Tarihi";
            dataGridView1.Columns[4].HeaderText = "Son_Tarih";
            dataGridView1.Columns[5].HeaderText = "Durum";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
