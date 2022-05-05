using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;//Eposta Kontrolü için yaptım
using MySql.Data.MySqlClient;

namespace Primus_Stadyumu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection sqlconnect = new MySqlConnection(Veri_Yolu.sqlconnection);
        int yas, kadın;
        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(maskedTextBox1.Text) || String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz...");
            }
            else
            {
                if (!Regex.IsMatch(textBox5.Text, pattern))
                {
                    MessageBox.Show("Hatalı Mail Adresi Girdiniz Lütfen Tekrar Deneyin");
                    errorProvider1.SetError(textBox5, "Hata");
                    return;
                }
                else// if  (Regex.IsMatch(textBox5.Text, pattern))
                {
                    errorProvider1.Clear();
                }
                yas = Convert.ToInt32(textBox3.Text);
                kadın = Convert.ToInt32(textBox3.Text);
                if (comboBox1.SelectedIndex == 2 && yas > 18)
                {

                    MessageBox.Show(" Çocuk Kategorisinde 18 ve Altı Sisteme Kayıt olabilir");
                }
                else if (comboBox1.SelectedIndex == 1 && yas <= 18)
                {
                    MessageBox.Show(" Kadın Kategorisinde 19 ve Üstü Sisteme Kayıt olabilir");
                }
                else
                {

                    try
                    {
                        if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                        {
                            sqlconnect.Open();//Bağlantıyı açtık
                            MySqlCommand sqlcommad = new MySqlCommand("insert into kullanici_verileri (kullaniciAdi,kullaniciSoyadi,yas,eposta,sifre,durum,telefon) values (@kullaniciAdi,@kullaniciSoyadi,@yas,@eposta,@sifre,@durum,@telefon)", sqlconnect);
                            sqlcommad.Parameters.AddWithValue("@kullaniciAdi", textBox1.Text);
                            sqlcommad.Parameters.AddWithValue("@kullaniciSoyadi", textBox2.Text);
                            sqlcommad.Parameters.AddWithValue("@yas", textBox3.Text);
                            sqlcommad.Parameters.AddWithValue("@eposta", textBox5.Text);
                            sqlcommad.Parameters.AddWithValue("@sifre", textBox4.Text);
                            sqlcommad.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
                            sqlcommad.Parameters.AddWithValue("@durum", comboBox1.Text);//parametrelerimizi inswet komutuna gönderdik
                            sqlcommad.ExecuteNonQuery();//Göndermiş oldugumuz parametreleri çalıştırır.
                            sqlconnect.Close();//Bağlantıyı kapattık.
                            MessageBox.Show("Kayıt Bilgileriniz Sistemimize Kaydedilmiştir...");

                        }
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Hata Meydana Geldi" + hata.Message);
                        //throw;
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar)&& !char.IsControl(e.KeyChar) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("Lütfen Metinsel Karakter Giriniz");
                e.Handled = true;
                /*textBox1.BackColor = Color.Red;*/
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;

            }
            else
            {
                
                e.Handled = false;
                textBox1.BackColor = Color.Green;
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Lütfen Metinsel Karakter Giriniz");
                e.Handled = true;
                textBox2.BackColor = Color.White;
                textBox2.ForeColor = Color.Black;
            }
            else
            {
                e.Handled = false;
                textBox2.BackColor = Color.Green;
                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Lütfen Sayısal Karakter Giriniz");
                e.Handled = true;
                textBox3.BackColor = Color.White;
                textBox3.ForeColor = Color.Black;
            }
            else
            {
                e.Handled = false;
                textBox3.BackColor = Color.Green;
                textBox3.ForeColor = Color.White;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("Lütfen Şifrenizde Sayı ve Yazı Karakterleri Giriniz");
                e.Handled = true;
                textBox4.BackColor = Color.White;
                textBox4.ForeColor = Color.Black;
            }
            else
            {
                e.Handled = false;
                textBox4.BackColor = Color.Green;
                textBox4.ForeColor = Color.White;
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
            
        }

        
        
        private void button2_Click(object sender, EventArgs e)
        {
            Giris grm = new Giris();
            grm.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState==CheckState.Checked)
            {
                textBox4.UseSystemPasswordChar = true;
                checkBox1.Text="Gizle";
            }
            else if (checkBox1.CheckState==CheckState.Unchecked)
            {
                textBox4.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Lütfen Sayısal Karakter Giriniz");
                e.Handled = true;
                maskedTextBox1.BackColor = Color.White;
                maskedTextBox1.ForeColor = Color.Black;

            }
            else
            {
                e.Handled = false;
                maskedTextBox1.BackColor = Color.Green;
                maskedTextBox1.ForeColor = Color.White;
            }
        }
    }
}
