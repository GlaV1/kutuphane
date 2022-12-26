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
    


    public partial class Form1 : Form
    {
        SqlConnection baglantim;
        SqlDataReader dr;
        SqlCommand com;
        
        public Form1()
        {
            InitializeComponent();


        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            baglantim = new SqlConnection("Data Source=SERHAT\\SQLEXPRESS;Initial Catalog=Kutuphane_Otomasyonu;Integrated Security=True");
            com = new SqlCommand();
            baglantim.Open();
            com.Connection = baglantim;
            com.CommandText = "select *from admin  where  adminkullaniciAd='" + textBox1.Text + "'And adminşifre='" + textBox2.Text + "'";
            dr= com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Başarılı bir şekilde giriş sağladınız", "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                anasayfa anasyf =new anasayfa();
                anasyf.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz", "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglantim.Close();



        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mesafeokullari.com/%22");
        }
    }
}
