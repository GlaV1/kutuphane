using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KütüphaneotomasyonuSe
{
    public partial class kullanıcısil : Form
    {
        NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
        public kullanıcısil()
        {
            InitializeComponent();
        }
        
        public void listelete()
        {
            NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
            var kullanicilar = db.uye.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();

            dataGridView1.Columns[0].HeaderText = "İd";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";

            dataGridView1.Columns[3].HeaderText = "TC";
            dataGridView1.Columns[4].HeaderText = "Sınıf";
        }
        private void kullanıcısil_Load(object sender, EventArgs e)
        {
            listelete();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult silinsinmi = MessageBox.Show("Silmek İstediginden Eminmisin", "KütüphaneOtomasyonu", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (silinsinmi == DialogResult.Yes)
            {
                int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                var kullanici = db.uye.Where(x => x.kullanıcı_id == secilenId).FirstOrDefault();
                db.uye.Remove(kullanici);
                db.SaveChanges();
                listelete();
                MessageBox.Show("Silindi");
            }


            
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
