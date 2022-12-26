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
    public partial class kitapsil : Form
    {
        NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
        public kitapsil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult silinsinmi = MessageBox.Show("Silmek İstediginden Eminmisin", "KütüphaneOtomasyonu", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (silinsinmi == DialogResult.Yes)
            {
                int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                var silinenkaynak = db.Kitap.Where(x => x.kitap_id == secilenId).FirstOrDefault();
                db.Kitap.Remove(silinenkaynak);
                db.SaveChanges();
            }


            var kitaplar = db.Kitap.ToList();
            dataGridView1.DataSource = kitaplar.ToList();


        }

        private void kitapsil_Load(object sender, EventArgs e)
        {
            var kitaplar =db.Kitap.ToList();
            dataGridView1.DataSource = kitaplar.ToList();

            dataGridView1.Columns[0].HeaderText = "Kitap İd";
            dataGridView1.Columns[1].HeaderText = "Kitip İsmi";
            dataGridView1.Columns[2].HeaderText = "Kitap Yazarı";

            dataGridView1.Columns[3].HeaderText = "Kitap Yayınevi";
            dataGridView1.Columns[4].HeaderText = "Kitap Sayfası";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
