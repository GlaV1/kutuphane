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

    public partial class eklefrm : Form
    {

        NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
        public eklefrm()
        {
            InitializeComponent();
        }
      

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            

            uye kullanıcılar = new uye();
            kullanıcılar.kullanıcı_ad = txtAd.Text;
            kullanıcılar.kullanıcı_soyad=txtSoyad.Text;
           
            kullanıcılar.kullanıcı_tc=txtTc.Text;
            kullanıcılar.kullanıcı_sınıf=txtSınıf.Text;

           
            db.uye.Add(kullanıcılar);
            db.SaveChanges();
            listelete();
            
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

        private void eklefrm_Load(object sender, EventArgs e)
        {
            listelete();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
