using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Primus_Stadyumu
{
    public partial class Fikstür : Form
    {
        public Fikstür()
        {
            InitializeComponent();
        }
        MySqlConnection sqlconnect = new MySqlConnection(Veri_Yolu.sqlconnection);

        int engelli = 30;
        int Çocuk = 40;
        int Kadın = 50;
        int fiyat;
        public void listele()
        {
            sqlconnect.Open();
            string Select = "Select  karsilasmalar.karsilasmaID, karsilasmalar.Tarih,karsilasmalar.Ev_Sahibi_Takimi ,karsilasmalar.Saat,karsilasmalar.Deplasman_Takimi,stadyumlar.Stadyum From karsilasmalar inner join stadyumlar on karsilasmalar.StadyumID = stadyumlar.stadyumID;";
            MySqlDataAdapter da = new MySqlDataAdapter(Select, sqlconnect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconnect.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Gideceginiz Macı, Maç Fikstüründen Seçiniz ve Bilet Alma İşlemini Gerçeklestiriniz");
            }
            else
            {
                MessageBox.Show("Bilet Alma İşleminiz Tamamlanmıştır Primus Uygulamasını Tercih Ettiğiniz İçin Tesekkür Ederiz. İyi Günler...");
                Application.Exit();
                /*Kale_Arkası_Biletislemleri kl = new Kale_Arkası_Biletislemleri();
                kl.Show();*/
            }
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;//Kacıncı satırı tuttuğumuz secime atadık
            textBox6.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();//değeri stringe cevir öyle yazdır dedik
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
        }

        private void Fikstür_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Fikstür_Load(object sender, EventArgs e)
        {
            listele();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
           
            com2();
            com1();
        }
        public void com1()
        {
            try
            {
                if (sqlconnect.State != ConnectionState.Open)
                {
                    sqlconnect.Open();
                    MySqlCommand veri_al = new MySqlCommand("Select koltukkategori From koltukfiyatları", sqlconnect);
                    MySqlDataReader read = veri_al.ExecuteReader();
                    while (read.Read())
                    {
                        comboBox1.Items.Add(read[0]).ToString();
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }

        }
        public void com2()
        {
            try
            {
                if (sqlconnect.State != ConnectionState.Open)
                {
                    sqlconnect.Open();
                    MySqlCommand veri_al = new MySqlCommand("Select Stadyum From stadyumlar", sqlconnect);
                    MySqlDataReader read = veri_al.ExecuteReader();
                    while (read.Read())
                    {
                        comboBox4.Items.Add(read[0]).ToString();
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }

        }
        public void com3()
        {
            try
            {
                if (sqlconnect.State != ConnectionState.Open)
                {
                    sqlconnect.Open();
                    MySqlCommand veri_al = new MySqlCommand("Select fiyat From koltukfiyatları where koltukkategori=@kk", sqlconnect);
                    veri_al.Parameters.AddWithValue("@kk",comboBox1.SelectedItem);
                    if (comboBox1.SelectedIndex==0)
                    {
                        //textBox9.Text=
                    }
                   
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox4.SelectedIndex==0 && comboBox2.Text == "Doğu Tribünü")
            {
                comboBox3.Items.Clear();
                for (int i = 1; i <= 20; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("Select* From biletler where koltukno=@no", sqlconnect);
                    string a = "TD" + i;
                    cmd.Parameters.AddWithValue("@no",a);
                    sqlconnect.Open();
                    MySqlDataReader read = cmd.ExecuteReader();
                    
                    if (!read.Read())
                    {
                        comboBox3.Items.Add("TD" + i.ToString());
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }
            else if (comboBox4.SelectedIndex == 0 && comboBox2.Text == "Batı Tribünü")
            {
                comboBox3.Items.Clear();
                for (int i = 1; i <= 20; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("Select* From biletler where koltukno=@no", sqlconnect);
                    string a = "TB" + i;
                    cmd.Parameters.AddWithValue("@no", a);
                    sqlconnect.Open();
                    MySqlDataReader read = cmd.ExecuteReader();

                    if (!read.Read())
                    {
                        comboBox3.Items.Add("TB" + i.ToString());
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }
            else if (comboBox4.SelectedIndex == 0 && comboBox2.Text == "Kale Arkası Tribünü")
            {
                comboBox3.Items.Clear();
                for (int i = 1; i <= 10; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("Select* From biletler where koltukno=@no", sqlconnect);
                    string a = "TK" + i;
                    cmd.Parameters.AddWithValue("@no", a);
                    sqlconnect.Open();
                    MySqlDataReader read = cmd.ExecuteReader();

                    if (!read.Read())
                    {
                        comboBox3.Items.Add("TK" + i.ToString());
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }

            else if (comboBox4.SelectedIndex == 0 && comboBox2.Text == "Kale Arkası Tribünü2")
            {
                comboBox3.Items.Clear();
                for (int i = 1; i <= 10; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("Select* From biletler where koltukno=@no", sqlconnect);
                    string a = "TKK" + i;
                    cmd.Parameters.AddWithValue("@no", a);
                    sqlconnect.Open();
                    MySqlDataReader read = cmd.ExecuteReader();

                    if (!read.Read())
                    {
                        comboBox3.Items.Add("TKK" + i.ToString());
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }
            else if (comboBox4.SelectedIndex == 1 && comboBox2.Text == "Doğu Tribünü")
            {
                comboBox3.Items.Clear();
                for (int i = 1; i <= 15; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("Select* From biletler where koltukno=@no", sqlconnect);
                    string a = "KD" + i;
                    cmd.Parameters.AddWithValue("@no", a);
                    sqlconnect.Open();
                    MySqlDataReader read = cmd.ExecuteReader();

                    if (!read.Read())
                    {
                        comboBox3.Items.Add("KD" + i.ToString());
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }
            else if (comboBox4.SelectedIndex == 1 && comboBox2.Text == "Batı Tribünü")
            {
                comboBox3.Items.Clear();
                for (int i = 1; i <= 15; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("Select* From biletler where koltukno=@no", sqlconnect);
                    string a = "KB" + i;
                    cmd.Parameters.AddWithValue("@no", a);
                    sqlconnect.Open();
                    MySqlDataReader read = cmd.ExecuteReader();

                    if (!read.Read())
                    {
                        comboBox3.Items.Add("KB" + i.ToString());
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }
            else if (comboBox4.SelectedIndex == 1 && comboBox2.Text == "Kale Arkası Tribünü")
            {
                comboBox3.Items.Clear();
                for (int i = 1; i <= 8; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("Select* From biletler where koltukno=@no", sqlconnect);
                    string a = "KK" + i;
                    cmd.Parameters.AddWithValue("@no", a);
                    sqlconnect.Open();
                    MySqlDataReader read = cmd.ExecuteReader();

                    if (!read.Read())
                    {
                        comboBox3.Items.Add("KK" + i.ToString());
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }

            else if (comboBox4.SelectedIndex == 1 && comboBox2.Text == "Kale Arkası Tribünü2")
            {
                comboBox3.Items.Clear();
                for (int i = 1; i <= 8; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("Select* From biletler where koltukno=@no", sqlconnect);
                    string a = "KKK" + i;
                    cmd.Parameters.AddWithValue("@no", a);
                    sqlconnect.Open();
                    MySqlDataReader read = cmd.ExecuteReader();

                    if (!read.Read())
                    {
                        comboBox3.Items.Add("KKK" + i.ToString());
                    }
                    sqlconnect.Close();
                    read.Close();
                }
            }
            else { comboBox3.Items.Clear(); }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrEmpty(textBox9.Text)|| String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrEmpty(comboBox2.Text) || String.IsNullOrEmpty(comboBox3.Text) || String.IsNullOrEmpty(comboBox4.Text))
            {
                MessageBox.Show("Bilet İşlemlerindeki Alanları Boş Geçmeyin");
            }
            else
            {
                    if (comboBox1.SelectedIndex == 0)//Çalısan kod Engelli Sadece
                                                     //Cascade li versiyonu ile dene
                                                     // Hepsi Beraber ile dene bide para üstü ne kadar onu yaz
                    {
                        fiyat = Convert.ToInt32(textBox9.Text);
                        int hesap = fiyat - engelli;
                        textBox9.Enabled = false;
                        if (hesap < 0)
                        {
                            MessageBox.Show("Girdiğiniz Para Yeterli Değildir...");
                        }
                        else
                        {
                            try
                            {
                                if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                                {
                                    textBox9.Text = fiyat.ToString();
                                    textBox10.Text = hesap.ToString();
                                    sqlconnect.Open();//Bağlantıyı açtık
                                    MySqlCommand sqlcommad = new MySqlCommand("insert into biletler (ad,soyad,durum,fiyat,koltukno,k_ID) values (@ad,@soyad,@durum,@fiyat,@koltukno,@k_ID)", sqlconnect);

                                    sqlcommad.Parameters.AddWithValue("@ad", textBox7.Text);
                                    sqlcommad.Parameters.AddWithValue("@soyad", textBox8.Text);
                                    sqlcommad.Parameters.AddWithValue("@durum", comboBox1.Text);
                                    sqlcommad.Parameters.AddWithValue("@koltukno", comboBox3.Text);
                                    sqlcommad.Parameters.AddWithValue("@fiyat", textBox9.Text);
                                    sqlcommad.Parameters.AddWithValue("@k_ID", textBox6.Text);
                                    sqlcommad.ExecuteNonQuery();//Göndermiş oldugumuz parametreleri çalıştırır.
                                    sqlconnect.Close();//Bağlantıyı kapattık.

                                    MessageBox.Show("Bilet Alma/Onaylama İşlemimiz Tamamlanmıştır...");
                                    MessageBox.Show("Para Üstünüz: " + hesap.ToString());
                                    textBox9.Enabled = false;
                                    MessageBox.Show("Biletinizi Aldıktan Sonra Tekrardan Bilet Almak İçin Stadyum Seçimini Tekrar Yapınız...");
                                    MessageBox.Show("Çıkış için Son Tuşuna Basınız...");
                                    comboBox3.Items.Clear();
                                    comboBox2.Items.Clear();
                                
                                    textBox10.Text = "";

                            }
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show("Hata Meydana Geldi0" + hata.Message);
                                //throw;
                            }
                        }
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        fiyat = Convert.ToInt32(textBox9.Text);
                        int hesap = fiyat - Çocuk;

                        textBox9.Enabled = false;
                        if (hesap < 0)
                        {
                            MessageBox.Show("Girdiğiniz Para Yeterli Değildir...");
                        }
                        else
                        {
                            try
                            {
                                if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                                {
                                    textBox9.Text = fiyat.ToString();
                                    textBox10.Text = hesap.ToString();
                                    sqlconnect.Open();//Bağlantıyı açtık
                                    MySqlCommand sqlcommad = new MySqlCommand("insert into biletler (ad,soyad,durum,fiyat,koltukno,k_ID) values (@ad,@soyad,@durum,@fiyat,@koltukno,@k_ID)", sqlconnect);
                                    sqlcommad.Parameters.AddWithValue("@ad", textBox7.Text);
                                    sqlcommad.Parameters.AddWithValue("@soyad", textBox8.Text);
                                    sqlcommad.Parameters.AddWithValue("@durum", comboBox1.Text);
                                    sqlcommad.Parameters.AddWithValue("@koltukno", comboBox3.Text);
                                    sqlcommad.Parameters.AddWithValue("@fiyat", textBox9.Text);
                                    sqlcommad.Parameters.AddWithValue("@k_ID", textBox6.Text);
                                    sqlcommad.ExecuteNonQuery();//Göndermiş oldugumuz parametreleri çalıştırır.
                                    sqlconnect.Close();//Bağlantıyı kapattık.

                                MessageBox.Show("Bilet Alma/Onaylama İşlemimiz Tamamlanmıştır...");
                                MessageBox.Show("Para Üstünüz: " + hesap.ToString());
                                textBox9.Enabled = false;
                                MessageBox.Show("Biletinizi Aldıktan Sonra Tekrardan Bilet Almak İçin Stadyum Seçimini Tekrar Yapınız...");
                                MessageBox.Show("Çıkış için Son Tuşuna Basınız...");
                                comboBox3.Items.Clear();
                                comboBox2.Items.Clear();
                                textBox10.Text = "";
                            }
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show("Hata Meydana Geldi0" + hata.Message);
                                //throw;
                            }
                        }
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        fiyat = Convert.ToInt32(textBox9.Text);
                        int hesap = fiyat - Kadın;
                        textBox9.Enabled = false;
                        if (hesap < 0)
                        {
                            MessageBox.Show("Girdiğiniz Para Yeterli Değildir...");
                        }
                        else
                        {
                            try
                            {
                                if (sqlconnect.State == ConnectionState.Closed)//Bağlantı kapalı ise
                                {
                                    textBox9.Text = fiyat.ToString();
                                    textBox10.Text = hesap.ToString();
                                    sqlconnect.Open();//Bağlantıyı açtık
                                    MySqlCommand sqlcommad = new MySqlCommand("insert into biletler (ad,soyad,durum,fiyat,koltukno,k_ID) values (@ad,@soyad,@durum,@fiyat,@koltukno,@k_ID)", sqlconnect);
                                    sqlcommad.Parameters.AddWithValue("@ad", textBox7.Text);
                                    sqlcommad.Parameters.AddWithValue("@soyad", textBox8.Text);
                                    sqlcommad.Parameters.AddWithValue("@durum", comboBox1.Text);
                                    sqlcommad.Parameters.AddWithValue("@koltukno", comboBox3.Text);
                                    sqlcommad.Parameters.AddWithValue("@fiyat", textBox9.Text);
                                    sqlcommad.Parameters.AddWithValue("@k_ID", textBox6.Text);
                                    sqlcommad.ExecuteNonQuery();//Göndermiş oldugumuz parametreleri çalıştırır.
                                    sqlconnect.Close();//Bağlantıyı kapattık.

                                MessageBox.Show("Bilet Alma/Onaylama İşlemimiz Tamamlanmıştır...");
                                MessageBox.Show("Para Üstünüz: " + hesap.ToString());
                                textBox9.Enabled = false;
                                MessageBox.Show("Çıkış için Son Tuşuna Basınız...");
                                comboBox3.Items.Clear();
                                comboBox2.Items.Clear();
                                textBox10.Text = "";

                            }
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show("Hata Meydana Geldi0" + hata.Message);
                                //throw;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seçtiğiniz Koltuk Doludur Lütfen Bos Koltuk Seçiniz");
                    }
                   /* read.Close();
                    sqlconnect.Close();
                }
                */
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("Lütfen Metinsel Karakter Giriniz");
                e.Handled = true;
                /*textBox1.BackColor = Color.Red;*/
                textBox7.BackColor = Color.White;
                textBox7.ForeColor = Color.Black;

            }
            else
            {

                e.Handled = false;
                textBox7.BackColor = Color.Green;
                textBox7.ForeColor = Color.White;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("Lütfen Metinsel Karakter Giriniz");
                e.Handled = true;
                /*textBox1.BackColor = Color.Red;*/
                textBox8.BackColor = Color.White;
                textBox8.ForeColor = Color.Black;

            }
            else
            {

                e.Handled = false;
                textBox8.BackColor = Color.Green;
                textBox8.ForeColor = Color.White;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Lütfen Sayısal Karakter Giriniz");
                e.Handled = true;
                textBox9.BackColor = Color.White;
                textBox9.ForeColor = Color.Black;
            }
            else
            {
                e.Handled = false;
                textBox9.BackColor = Color.Green;
                textBox9.ForeColor = Color.White;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           /* int secim = dataGridView2.SelectedCells[0].RowIndex;//Kacıncı satırı tuttuğumuz secime atadık
            textBox11.Text = dataGridView2.Rows[secim].Cells[0].Value.ToString();
            textBox12.Text = dataGridView2.Rows[secim].Cells[1].Value.ToString();//değeri stringe cevir öyle yazdır dedik
            textBox13.Text = dataGridView2.Rows[secim].Cells[2].Value.ToString();
            textBox14.Text = dataGridView2.Rows[secim].Cells[3].Value.ToString();
            textBox15.Text = dataGridView2.Rows[secim].Cells[4].Value.ToString();
            textBox16.Text = dataGridView2.Rows[secim].Cells[5].Value.ToString();
            textBox17.Text = dataGridView2.Rows[secim].Cells[6].Value.ToString();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Ad ve Soyad Bölümlerini Boş Geçmeyin");
            }
            else
            {
                MySqlCommand getir = new MySqlCommand("SELECT `ad`,`soyad`,`durum`,`fiyat`,`koltukno` FROM `biletler` where ad=@adi AND soyad=@soyad", sqlconnect);
                getir.Parameters.AddWithValue("@adi", textBox7.Text);
                getir.Parameters.AddWithValue("@soyad", textBox8.Text);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(getir);
                sqlconnect.Open();
                da.Fill(dt);
                sqlconnect.Close();
                dataGridView2.DataSource = dt;
            }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* MySqlCommand cmd = new MySqlCommand("Select* From biletler where koltukno=@no", sqlconnect);
            cmd.Parameters.AddWithValue("@no",comboBox3.Text);
            sqlconnect.Open();
            MySqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                MessageBox.Show("Seçmiş Oldugunuz Koltuk, Baskası Tarafından Alınmıştır Lütfen Baska Koltuklara Yöneliniz Bu Uyarıdan Sonra Stadyum Seçimini Tekrar Yapınız O Zaman Tekrardan Koltuklar Gözükecektir... ");
                textBox18.Text = "";
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
            }
            else
            {
                
            }
            sqlconnect.Close();
            read.Close();*/
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `stadyumlar` INNER JOIN stadyumbm on stadyumlar.stadyumID=stadyumbm.stadyumBM where `Stadyum`=@s", sqlconnect);
            cmd.Parameters.AddWithValue("@s", comboBox4.Text);
            sqlconnect.Open();
            MySqlDataReader read = cmd.ExecuteReader();
            if (String.IsNullOrEmpty(comboBox4.Text))
            {
                MessageBox.Show("Lütfen Gideceğiniz Stadyumunu Seçiniz");
            }
            else
            {
                comboBox2.Items.Clear();
                while (read.Read())
                {

                    comboBox2.Items.Add(read["bolumadi"].ToString());

                }
            }
            read.Close();
            sqlconnect.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM koltukfiyatları where `koltukkategori`=@kk", sqlconnect);
            cmd.Parameters.AddWithValue("@kk", comboBox1.Text);
            sqlconnect.Open();
            MySqlDataReader read = cmd.ExecuteReader();
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Lütfen Durumunuzu Seçiniz");
            }
            else
            {
                textBox9.Text = "";
                while (read.Read())
                {

                    //comboBox2.Items.Add(read["bolumadi"].ToString());
                    textBox9.Text = read["fiyat"].ToString();

                }
            }
            read.Close();
            sqlconnect.Close();
        }
    }
}