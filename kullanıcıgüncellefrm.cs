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
    public partial class kullanıcıgüncellefrm : Form
    {
        NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
        public kullanıcıgüncellefrm()
        {
            InitializeComponent();
        }
        public void listelete()
        {
            NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
            var kullanicilar = db.uye.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
        }
        private void kullanıcıgüncellefrm_Load(object sender, EventArgs e)
        {
            listelete();
            dataGridView1.Columns[0].HeaderText = "İd";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";

            dataGridView1.Columns[3].HeaderText = "TC";
            dataGridView1.Columns[4].HeaderText = "Sınıf";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSınıf.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

           
           





        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var kullanıcı = db.uye.Where(x=> x.kullanıcı_id==secilenId).FirstOrDefault();
            kullanıcı.kullanıcı_ad = txtAd.Text;
            kullanıcı.kullanıcı_soyad = txtSoyad.Text;
            kullanıcı.kullanıcı_tc = txtTc.Text;
            kullanıcı.kullanıcı_ad = txtAd.Text;
           
            db.SaveChanges();
            listelete();
        }
        private void temizle()
        {
            txtAd.Clear();
            txtTc.Clear();
            txtSoyad.Clear();
            txtSınıf.Clear();
            txtSınıf.Clear();
            
            txtAd.Focus();
            
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtAd.Text = dataGridView1.CurrentRow.Cells["kullanıcı_ad"].Value.ToString();
                txtSoyad.Text = dataGridView1.CurrentRow.Cells["kullanıcı_soyad"].Value.ToString();
               
                txtTc.Text = dataGridView1.CurrentRow.Cells["kullanıcı_tc"].Value.ToString();
                txtSınıf.Text = dataGridView1.CurrentRow.Cells["kullanıcı_sınıf"].Value.ToString();
                
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
