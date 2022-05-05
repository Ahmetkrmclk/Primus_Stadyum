using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
namespace Primus_Stadyumu
{
    public partial class Yönetici_girisi : Form
    {
        public Yönetici_girisi()
        {
            InitializeComponent();
        }
        MySqlConnection sqlconnect = new MySqlConnection(Veri_Yolu.sqlconnection);
        int hak = 3;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";
            }
            else if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (!Regex.IsMatch(textBox1.Text, pattern))
            {
                MessageBox.Show("Hatalı Mail Adresi Girdiniz Lütfen Tekrar Deneyin");
                errorProvider1.SetError(textBox1, "Hata");
                return;
            }
            else if (Regex.IsMatch(textBox1.Text, pattern))
            {
                errorProvider1.Clear();
            }
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Boş Geçilemez...");
            }
            else
            {
                MySqlDataReader dr;
                MySqlCommand sqlcommad = new MySqlCommand("Select * From admin where e_posta=@eposta AND sifre=@sifre", sqlconnect);
                sqlcommad.Parameters.AddWithValue("@eposta", textBox1.Text);
                sqlcommad.Parameters.AddWithValue("@sifre", textBox2.Text);
                sqlconnect.Open();//Bağlantıyı açtık
                dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                if (dr.Read())
                {
                    /*MessageBox.Show("Admin Sayfasına Şuan Gittin, Admin Sayfasını Daha olusturmadım, Giriş Basarılı");
                    sqlconnect.Close();*/
                    Admin adm = new Admin();
                    adm.Show();
                    this.Hide();
                   
                }
                else
                {
                    sqlconnect.Close();
                    MessageBox.Show("E-postanızı veya Şifrenizi Kontrol Ediniz ");
                    hak--;
                    MessageBox.Show("Kalan Hakkınuz:" + hak);
                    if (hak == 0)
                    {
                        MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                        Application.Exit();
                    }

                }
            }
        }

        private void Yönetici_girisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
