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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        MySqlConnection sqlconnect = new MySqlConnection(Veri_Yolu.sqlconnection);
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        int hak = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz...");
            }
            else
            {
                if (!Regex.IsMatch(textBox1.Text, pattern))
                {
                    MessageBox.Show("Hatalı Mail Adresi Girdiniz Lütfen Tekrar Deneyin");
                    errorProvider1.SetError(textBox1, "Hata");
                    return;
                }
                else if (Regex.IsMatch(textBox1.Text, pattern))
                {
                    errorProvider1.Clear();


                    MySqlDataReader dr;
                    MySqlCommand sqlcommad = new MySqlCommand("Select * From kullanici_verileri where eposta=@eposta AND sifre=@sifre", sqlconnect);
                    sqlcommad.Parameters.AddWithValue("@eposta", textBox1.Text);
                    sqlcommad.Parameters.AddWithValue("@sifre", textBox2.Text);
                    sqlconnect.Open();//Bağlantıyı açtık
                    dr = sqlcommad.ExecuteReader();//Gelen Data bilgisini Okumaya Yarıyor

                    if (dr.Read())
                    {
                        /* MessageBox.Show("Bilet Sayfasına Şuan Gittin, Bilet Sayfasını Daha olusturmadım, Giriş Basarılı");*/
                        Bilet_Alma bm = new Bilet_Alma();
                        bm.Show();
                        sqlconnect.Close();
                        this.Hide();
                    }
                    else
                    {
                        sqlconnect.Close();
                        MessageBox.Show("E-postanızı veya Şifrenizi Kontrol Ediniz ");
                        hak--;
                        MessageBox.Show("Kalan Hakkınız:" + hak);
                        if (hak == 0)
                        {
                            MessageBox.Show("Başka hakkınız kalmamıştır. Sistem otomatik olarak kapatılacaktır....");
                            Application.Exit();
                        }

                    }
                }

            }
        }
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Yönetici_girisi ynt = new Yönetici_girisi();
            ynt.Show();
            //this.Close();Hide dediğimizde sadece gizliyor
            
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
