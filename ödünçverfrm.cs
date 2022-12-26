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
    public partial class ödünçverfrm : Form
    {
        NewKütüphaneOtomasyonEntities db = new NewKütüphaneOtomasyonEntities();
        public ödünçverfrm()
        {
            InitializeComponent();
        }

        private void ödünçverfrm_Load(object sender, EventArgs e)
        {

            





            var kayitlist = db.odunc.ToList();
            dataGridView1.DataSource = kayitlist.ToList();

            var kaynaklarList = db.Kitap.ToList();
            dataGridView2.DataSource=kaynaklarList.ToList();
            
           

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arananSecilen = textBox1.Text;
            var kullaniciVarMi =db.uye.Where(x=>x.kullanıcı_tc==arananSecilen).FirstOrDefault();
            if (kullaniciVarMi != null)
                label2.Text = kullaniciVarMi.kullanıcı_ad + "-" + kullaniciVarMi.kullanıcı_soyad;
            else
                label2.Text = "Bötle Bir Kullanıcı Bulunmamakta";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string gelenad=textBox1.Text;
            var bulunankaynaklar = db.Kitap.Where(x => x.kitap_isim.Contains(gelenad)).ToList();
            dataGridView2.DataSource = bulunankaynaklar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string secilenkisiTC = textBox1.Text;
            var seçilenkisi=db.uye.Where(x=> x.kullanıcı_tc.Equals(secilenkisiTC)).FirstOrDefault();

            int secilenkitapId =Convert.ToInt16 (dataGridView2.CurrentRow.Cells[0].Value);
            var secilenkitap = db.Kitap.Where(x=> x.kitap_id==secilenkitapId).FirstOrDefault();


            odunc yenikayıt = new odunc();
            yenikayıt.kitap_id = secilenkitap.kitap_id;
            yenikayıt.kullanıcı_id = seçilenkisi.kullanıcı_id;
            yenikayıt.alis_tarih = DateTime.Today;
            yenikayıt.son_tarih = DateTime.Today.AddDays(15);
            yenikayıt.durum = false;
            db.odunc.Add(yenikayıt);
            db.SaveChanges();

            var kayitlist = db.uye.ToList();
            dataGridView2.DataSource = kayitlist.ToList();



        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Columns[0].HeaderText = "Kitip_İd";
            dataGridView2.Columns[1].HeaderText = "Kitip_İsmi";
            dataGridView2.Columns[2].HeaderText = "Kitap_Yazarı";

            dataGridView2.Columns[3].HeaderText = "Kitap_Yayınevi";
            dataGridView2.Columns[4].HeaderText = "Kitap_Sayfası";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
