using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Primus_Stadyumu
{
    public partial class Bilet_Alma : Form
    {
        public Bilet_Alma()
        {
            InitializeComponent();
        }
        Graphics saha = null;
        private void Bilet_Alma_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saha = CreateGraphics();
            Point baslangic = new Point(180, 70);
            Size boyut = new Size(600, 400);
            Rectangle saha_olustur = new Rectangle(baslangic, boyut);
            Brush firca = new SolidBrush(Color.Green);
            saha.FillRectangle(firca, saha_olustur);

            saha = CreateGraphics();
            Point baslangic_a = new Point(185, 75);
            Size boyut_a = new Size(590, 390);
            Rectangle saha_olustur_a = new Rectangle(baslangic_a, boyut_a);
            Pen firca_a = new Pen(Color.White);
            saha.DrawRectangle(firca_a, saha_olustur_a);


            saha = CreateGraphics();
            Pen kalem = new Pen(Color.White, 2);
            Point baslangic_1 = new Point(440, 215);
            Size boyut_1 = new Size(80, 80);
            Rectangle saha_olustur_1 = new Rectangle(baslangic_1, boyut_1);
            saha.DrawEllipse(kalem, saha_olustur_1);

            saha = CreateGraphics();
            Pen Cizgi = new Pen(Color.White, 3);
            Point baslangic_2 = new Point(480, 70);
            Point baslangic_22 = new Point(480, 470);
            saha.DrawLine(Cizgi, baslangic_2, baslangic_22);
            //
            saha = CreateGraphics();
            Point baslangic_b = new Point(185, 170);
            Size boyut_b = new Size(100, 180);
            Rectangle saha_olustur_b = new Rectangle(baslangic_b, boyut_b);
            Pen firca_b = new Pen(Color.White, 2);
            saha.DrawRectangle(firca_b, saha_olustur_b);

            saha = CreateGraphics();      //sağa sol - yukarı asağa
            Point baslangic_c = new Point(185, 215);
            Size boyut_c = new Size(50, 90);
            Rectangle saha_olustur_c = new Rectangle(baslangic_c, boyut_c);
            Pen firca_c = new Pen(Color.White, 2);
            saha.DrawRectangle(firca_c, saha_olustur_c);

            saha = CreateGraphics();      //sağa sol - yukarı asağa
            Point baslangic_d = new Point(260, 215);
            Size boyut_d = new Size(50, 90);
            Rectangle saha_olustur_d = new Rectangle(baslangic_d, boyut_d);
            Pen firca_d = new Pen(Color.White, 2);
            saha.DrawPie(firca_d, saha_olustur_d, 270, 180);
            ////
            //
            saha = CreateGraphics();
            Point baslangic_e = new Point(675, 170);
            Size boyut_e = new Size(100, 180);
            Rectangle saha_olustur_e = new Rectangle(baslangic_e, boyut_e);
            Pen firca_e = new Pen(Color.White, 2);
            saha.DrawRectangle(firca_e, saha_olustur_e);

            saha = CreateGraphics();      //sağa sol - yukarı asağa
            Point baslangic_f = new Point(725, 215);
            Size boyut_f = new Size(50, 90);
            Rectangle saha_olustur_f = new Rectangle(baslangic_f, boyut_f);
            Pen firca_f = new Pen(Color.White, 2);
            saha.DrawRectangle(firca_f, saha_olustur_f);

            saha = CreateGraphics();      //sağa sol - yukarı asağa
            Point baslangic_g = new Point(650, 215);
            Size boyut_g = new Size(50, 90);
            Rectangle saha_olustur_g = new Rectangle(baslangic_g, boyut_g);
            Pen firca_g = new Pen(Color.White, 2);
            saha.DrawPie(firca_d, saha_olustur_g, 90, 180);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            D_Tribün d = new D_Tribün();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            K_Tribün k = new K_Tribün();
            k.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            B_Tribünü b = new B_Tribünü();
            b.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fikstür fk = new Fikstür();
            fk.Show();
            this.Hide();
        }

        private void Bilet_Alma_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
