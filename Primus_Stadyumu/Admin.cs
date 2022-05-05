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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        MySqlConnection sqlconnect = new MySqlConnection(Veri_Yolu.sqlconnection);
        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            Listele();
        }

       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Lütfen Sayısal Karakter Giriniz");
                e.Handled = true;
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Lütfen Metinsel Karakter Giriniz");
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Lütfen Sayısal Karakter Giriniz");
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
        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(maskedTextBox1.Text) || String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz...");
            }
            else
            {
                sqlconnect.Open();
                MySqlCommand sil = new MySqlCommand("Delete From kullanici_verileri Where kullaniciID=@ıd", sqlconnect);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                sqlconnect.Close();
                MessageBox.Show("Seçtiğiniz Kullanıcı Kayıdı Silinmiştir...");
                Listele();
            }


        }
        int kadın, yas;
        private void button4_Click(object sender, EventArgs e)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(maskedTextBox1.Text) || String.IsNullOrEmpty(comboBox1.Text))
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
                else
                {
                    errorProvider1.Clear();
                }
                yas = Convert.ToInt32(textBox4.Text);
                kadın = Convert.ToInt32(textBox4.Text);
                if (comboBox1.SelectedIndex == 1 && yas > 18)
                {

                    MessageBox.Show(" Çocuk Kategorisinde 18 ve Altı Sisteme Kayıt olabilir");
                }
                else if (comboBox1.SelectedIndex == 2 && yas <= 18)
                {
                    MessageBox.Show(" Kadın Kategorisinde 19 ve Üstü Sisteme Kayıt olabilir");
                }
                else
                {

                    sqlconnect.Open();
                    MySqlCommand güncelle = new MySqlCommand("Update kullanici_verileri set kullaniciAdi=@ad,kullaniciSoyadi=@soyad,yas=@yas,eposta=@eposta,sifre=@sifre,durum=@durum,telefon=@telefon where kullaniciID=@ıd", sqlconnect);
                    güncelle.Parameters.AddWithValue("@ıd", textBox1.Text);
                    güncelle.Parameters.AddWithValue("@ad", textBox2.Text);
                    güncelle.Parameters.AddWithValue("@soyad", textBox3.Text);
                    güncelle.Parameters.AddWithValue("@yas", textBox4.Text);
                    güncelle.Parameters.AddWithValue("@eposta", textBox5.Text);
                    güncelle.Parameters.AddWithValue("@sifre", textBox6.Text);
                    güncelle.Parameters.AddWithValue("@durum", comboBox1.Text);
                    güncelle.Parameters.AddWithValue("@telefon", maskedTextBox1.Text);
                    güncelle.ExecuteNonQuery();
                    sqlconnect.Close();
                    MessageBox.Show("Kullanıcı Güncellemesi Tamamlandı...");
                    Listele();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;//Kacıncı satırı tuttuğumuz secime atadık
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();//değeri stringe cevir öyle yazdır dedik
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secim].Cells[7].Value.ToString();
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void Listele()
        {
            sqlconnect.Open();
            string Select = "Select * From kullanici_verileri";
            MySqlDataAdapter da = new MySqlDataAdapter(Select, sqlconnect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconnect.Close();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            maskedTextBox1.MaxLength = 14;

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
