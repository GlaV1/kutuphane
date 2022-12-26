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
    public partial class anasayfa : Form
    {
        NewKütüphaneOtomasyonEntities db =new NewKütüphaneOtomasyonEntities();
        public anasayfa()
        {
            InitializeComponent();
        }
        
        private void anasayfa_Load(object sender, EventArgs e)
        {
            btnkullanıcıekle.Visible = false;
            btnkullanıcıgncl.Visible = false;
            btnkullanıcısil.Visible = false;
            
            dataGridView1.Visible = false;

            kitapeklebtn.Visible = false;
            kitapgüncellebtn.Visible = false;
            kitapsilbtn.Visible = false;
            gerialbtn.Visible = false;
            ödüçverbtn.Visible = false;
            dataGridView2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnkullanıcıekle.Visible==false)
            {
                btnkullanıcıekle.Visible = true;
                btnkullanıcıgncl.Visible = true;
                btnkullanıcısil.Visible = true;
                
                dataGridView1.Visible = true;
            }
            else
            {
                btnkullanıcıekle.Visible = false;
                btnkullanıcıgncl.Visible = false;
                btnkullanıcısil.Visible = false;
                dataGridView1.Visible=false;
            }

            

            var kullanicilar =db.uye.ToList();
            dataGridView1.DataSource= kullanicilar.ToList(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnkullanıcıekle_Click(object sender, EventArgs e)
        {
            eklefrm ekle =new eklefrm();
            
            ekle.Show();
        }

        private void btnkullanıcısil_Click(object sender, EventArgs e)
        {
            kullanıcısil ksil = new kullanıcısil();
            
            ksil.Show();
        }

        private void btnkullanıcıgncl_Click(object sender, EventArgs e)
        {
            kullanıcıgüncellefrm kullanıcıgncl = new kullanıcıgüncellefrm();
            kullanıcıgncl.Show();
        }

        private void Kitaplarbtn_Click(object sender, EventArgs e)
        {
            if (btnkullanıcıekle.Visible == false)
            {
                kitapeklebtn.Visible = true;
                kitapgüncellebtn.Visible = true;
                kitapsilbtn.Visible = true;
                ödüçverbtn.Visible = true;
                gerialbtn.Visible = true;
                dataGridView2.Visible = true;

            }
            else
            {
                kitapeklebtn.Visible = false;
                kitapgüncellebtn.Visible = false;
                kitapsilbtn.Visible = false;
                ödüçverbtn.Visible = false;
                gerialbtn.Visible = false;

                dataGridView2.Visible = false;
            }



            var kitaplar = db.Kitap.ToList();
            dataGridView2.DataSource = kitaplar.ToList();
        }

        private void kitapeklebtn_Click(object sender, EventArgs e)
        {
            kitapeklefrm kekle=new kitapeklefrm();
            kekle.Show();
        }

        private void kitapsilbtn_Click(object sender, EventArgs e)
        {
            kitapsil ksil = new kitapsil();
           
            ksil.Show();
        }

        private void kitapgüncellebtn_Click(object sender, EventArgs e)
        {
            kitapgüncellefrm kgüncelle = new kitapgüncellefrm();

            kgüncelle.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Columns[0].HeaderText = "Kitap İd";
            dataGridView2.Columns[1].HeaderText = "Kitip İsmi";
            dataGridView2.Columns[2].HeaderText = "Kitap Yazarı";

            dataGridView2.Columns[3].HeaderText = "Kitap Yayınevi";
            dataGridView2.Columns[4].HeaderText = "Kitap Sayfası";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ödünçverfrm ödüçver = new ödünçverfrm();
            ödüçver.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gerialfrm gerial =new gerialfrm();
            gerial.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "İd";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
        
            dataGridView1.Columns[3].HeaderText = "TC";
            dataGridView1.Columns[4].HeaderText = "Sınıf";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
