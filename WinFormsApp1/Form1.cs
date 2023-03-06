using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        bool [,] dizi = new bool[4, 4];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    PictureBox resimKutusu = new PictureBox();
                    resimKutusu.Name = "resim" + x.ToString() + y.ToString();
                    resimKutusu.Top = 10+60*y;
                    resimKutusu.Left = 10+60*x;
                    resimKutusu.Width = 50;
                    resimKutusu.Height = 50;
                    resimKutusu.BackColor = Color.Black;
                    resimKutusu.BackgroundImage  = Image.FromFile("C:\\Users\\OgrenciPC\\Desktop\\WinFormsApp1\\images.png");
                    resimKutusu.BackgroundImageLayout = ImageLayout.Stretch;
                    resimKutusu.Click+=new System.EventHandler(this.PictureBoxTiklama);
                    Controls.Add(resimKutusu);

                }
            }
            DiziRastgele();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deneme");
        }
         void PictureBoxTiklama(object sender, EventArgs e)
        {
            PictureBox tiklanan = sender as PictureBox;
            //resim79 Bu değişiklik yakup tarafından yapılmıştır
            int satir= Convert.ToInt32( tiklanan.Name[5].ToString());
            int sutun= Convert.ToInt32( tiklanan.Name[6].ToString());
            
            if (dizi[satir,sutun]) {
                
                tiklanan.BackgroundImage= Image.FromFile("C:\\Users\\OgrenciPC\\Desktop\\WinFormsApp1\\ok.png");
                label2.Text = (Convert.ToInt32(label2.Text) + 1).ToString();
                MessageBox.Show("Tebrikler!!!" + label2.Text + " denemede buldunuz");
                Sifirla();

            } else { tiklanan.BackgroundImage = Image.FromFile("C:\\Users\\OgrenciPC\\Desktop\\WinFormsApp1\\hata.png");
                label2.Text = (Convert.ToInt32(label2.Text)+1).ToString();
                
            }


        }

        void Sifirla()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    PictureBox bulunacak = Controls.Find("resim" + x.ToString() + y.ToString(), true)[0] as PictureBox;
                    bulunacak.BackgroundImage = Image.FromFile("C:\\Users\\OgrenciPC\\Desktop\\WinFormsApp1\\images.png");
                    bulunacak.BackgroundImageLayout = ImageLayout.Stretch;
                    dizi[y, x] = false;
                    DiziRastgele();
               }
            }
            label2.Text = "0";


           

        }
        void DiziRastgele()
        {
            Random rnd = new Random();
            int satir = rnd.Next(4);
            int sutun = rnd.Next(4);
            dizi[satir, sutun] = true;
        }
    }
}
