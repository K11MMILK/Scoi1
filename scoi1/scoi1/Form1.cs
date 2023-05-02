using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scoi1
{
    public partial class Form1 : Form
    {

        int kto (int a, int min, int max)
        {
            if (a < min) a = min;
            if (a > max) a = max;
            return a;
        }

        Bitmap image = new Bitmap("..//..//..//sad//null.png");
        Bitmap image1 = null;
        Bitmap image2 = null;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "RGB";
            comboBox2.Text = "Круг";
            comboBox3.Text = "наложить";
            pictureBox3.Image = image;           
            pictureBox2.Image = image;
            image1 = new Bitmap("..//..//..//sad//null.png");
            image2 = new Bitmap("..//..//..//sad//null.png");
            
        }

     

        private void bSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileFialog = new SaveFileDialog();
            saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            saveFileFialog.RestoreDirectory = true;

            if (saveFileFialog.ShowDialog() == DialogResult.OK)
            {
                if (image != null)
                {
                    image.Save(saveFileFialog.FileName);
                    saveFileFialog.Dispose();
                }
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            int w, h;
            if (image2 == new Bitmap("..//..//..//sad//null.png")) { w = image1.Width; h = image1.Height; }
            else
            {
                w = Math.Max(image1.Width, image2.Width);
                h = Math.Max(image1.Height, image2.Height);
            }
            image = new Bitmap(w, h);
            var img1 = new Bitmap(image1, w, h);
            var img2 = new Bitmap(image2, w, h);
            switch (comboBox3.Text)
            {
                case "среднее-арифметическое":
                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            var pix1 = img1.GetPixel(x, y);
                            var pix2 = img2.GetPixel(x, y);
                            var r = (pix1.R + pix2.R) / 2;
                            var g = (pix1.G + pix2.G) / 2;
                            int b = (pix1.B + pix2.B) / 2;
                            switch (comboBox1.Text)
                            {
                                case "RGB":
                                    {
                                        break;
                                    }
                                case "R":
                                    {
                                        g = 0;
                                        b = 0;
                                        break;
                                    }
                                case "G":
                                    {
                                        r = 0;
                                        b = 0;
                                        break;
                                    }
                                case "B":
                                    {
                                        r = 0;
                                        g = 0;
                                        break;
                                    }
                                case "RG":
                                    {
                                        b = 0;
                                        break;
                                    }
                                case "RB":
                                    {
                                        g = 0;
                                        break;
                                    }
                                case "GB":
                                    {
                                        r = 0;
                                        break;
                                    }
                            }
                            var pix = Color.FromArgb(r, g, b);
                            image.SetPixel(x, y, pix);
                        }
                    }
                    break;
                case "попиксельно сумма":
                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            var pix1 = img1.GetPixel(x, y);
                            var pix2 = img2.GetPixel(x, y);
                            var r = (pix1.R + pix2.R);
                            var g = (pix1.G + pix2.G);
                            int b = (pix1.B + pix2.B);
                            r = kto(r, 0, 255);
                            g = kto(g, 0, 255);
                            b = kto(b, 0, 255);
                            switch (comboBox1.Text)
                            {
                                case "RGB":
                                    {
                                        break;
                                    }
                                case "R":
                                    {
                                        g = 0;
                                        b = 0;
                                        break;
                                    }
                                case "G":
                                    {
                                        r = 0;
                                        b = 0;
                                        break;
                                    }
                                case "B":
                                    {
                                        r = 0;
                                        g = 0;
                                        break;
                                    }
                                case "RG":
                                    {
                                        b = 0;
                                        break;
                                    }
                                case "RB":
                                    {
                                        g = 0;
                                        break;
                                    }
                                case "GB":
                                    {
                                        r = 0;
                                        break;
                                    }
                            }
                            var pix = Color.FromArgb(r, g, b);
                            image.SetPixel(x, y, pix);
                        }
                    }
                    break;
                case "произведение":
                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            var pix1 = img1.GetPixel(x, y);
                            var pix2 = img2.GetPixel(x, y);
                            var r = (pix1.R * pix2.R) / 255;
                            var g = (pix1.G * pix2.G) / 255;
                            var b = (pix1.B * pix2.B) / 255;
                            switch (comboBox1.Text)
                            {
                                case "RGB":
                                    {
                                        break;
                                    }
                                case "R":
                                    {
                                        g = 0;
                                        b = 0;
                                        break;
                                    }
                                case "G":
                                    {
                                        r = 0;
                                        b = 0;
                                        break;
                                    }
                                case "B":
                                    {
                                        r = 0;
                                        g = 0;
                                        break;
                                    }
                                case "RG":
                                    {
                                        b = 0;
                                        break;
                                    }
                                case "RB":
                                    {
                                        g = 0;
                                        break;
                                    }
                                case "GB":
                                    {
                                        r = 0;
                                        break;
                                    }
                            }
                            var pix = Color.FromArgb(r, g, b);
                            image.SetPixel(x, y, pix);
                        }
                    }
                    break;
                case "минимум":
                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            var pix1 = img1.GetPixel(x, y);
                            var pix2 = img2.GetPixel(x, y);
                            var r = Math.Min (pix1.R, pix2.R);
                            var g = Math.Min(pix1.G, pix2.G);
                            int b = Math.Min(pix1.B, pix2.B);
                            switch (comboBox1.Text)
                            {
                                case "RGB":
                                    {
                                        break;
                                    }
                                case "R":
                                    {
                                        g = 0;
                                        b = 0;
                                        break;
                                    }
                                case "G":
                                    {
                                        r = 0;
                                        b = 0;
                                        break;
                                    }
                                case "B":
                                    {
                                        r = 0;
                                        g = 0;
                                        break;
                                    }
                                case "RG":
                                    {
                                        b = 0;
                                        break;
                                    }
                                case "RB":
                                    {
                                        g = 0;
                                        break;
                                    }
                                case "GB":
                                    {
                                        r = 0;
                                        break;
                                    }
                            }
                            var pix = Color.FromArgb(r, g, b);
                            image.SetPixel(x, y, pix);
                        }
                    }
                    break;
                case "максимум":
                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            var pix1 = img1.GetPixel(x, y);
                            var pix2 = img2.GetPixel(x, y);
                            var r = Math.Max(pix1.R, pix2.R);
                            var g = Math.Max(pix1.G, pix2.G);
                            int b = Math.Max(pix1.B, pix2.B);
                            switch (comboBox1.Text)
                            {
                                case "RGB":
                                    {
                                        break;
                                    }
                                case "R":
                                    {
                                        g = 0;
                                        b = 0;
                                        break;
                                    }
                                case "G":
                                    {
                                        r = 0;
                                        b = 0;
                                        break;
                                    }
                                case "B":
                                    {
                                        r = 0;
                                        g = 0;
                                        break;
                                    }
                                case "RG":
                                    {
                                        b = 0;
                                        break;
                                    }
                                case "RB":
                                    {
                                        g = 0;
                                        break;
                                    }
                                case "GB":
                                    {
                                        r = 0;
                                        break;
                                    }
                            }
                            var pix = Color.FromArgb(r, g, b);
                            image.SetPixel(x, y, pix);
                        }
                    }
                    break;
                case "наложить":
                    image = img1;
                    switch (comboBox2.Text)
                    {

                        case "Круг":
                            var D = Math.Min(h, w);

                            int[] Q = new int[] {w/2, h/2 };
                            int R = D / 2;
                            for (int x = 0; x < w; x++)
                            {
                                for (int y = 0; y < h; y++)
                                {
                                    if (Math.Sqrt((Math.Max(x, Q[0]) - Math.Min(x, Q[0])) * (Math.Max(x, Q[0]) - Math.Min(x, Q[0])) + (Math.Max(y, Q[1]) - Math.Min(y, Q[1])) * (Math.Max(y, Q[1]) - Math.Min(y, Q[1]))) > R)
                                    {
                                        var pix = Color.Empty;
                                        image.SetPixel(x, y, pix);
                                    }
                                    else
                                    {
                                        var pix1 = img1.GetPixel(x, y);
                                        var r = (pix1.R);
                                        var g = (pix1.G);
                                        int b = (pix1.B);
                                        switch (comboBox1.Text)
                                        {
                                            case "RGB":
                                                {
                                                    break;
                                                }
                                            case "R":
                                                {
                                                    g = 0;
                                                    b = 0;
                                                    break;
                                                }
                                            case "G":
                                                {
                                                    r = 0;
                                                    b = 0;
                                                    break;
                                                }
                                            case "B":
                                                {
                                                    r = 0;
                                                    g = 0;
                                                    break;
                                                }
                                            case "RG":
                                                {
                                                    b = 0;
                                                    break;
                                                }
                                            case "RB":
                                                {
                                                    g = 0;
                                                    break;
                                                }
                                            case "GB":
                                                {
                                                    r = 0;
                                                    break;
                                                }
                                        }
                                        var pix = Color.FromArgb(r, g, b);
                                        image.SetPixel(x, y, pix);
                                    }
                                }
                            }
                            break;


                        case "Квадрат":
                            D = Math.Min(h, w);

                            Q = new int[] { w / 2, h / 2 };
                            R = D / 2-D/10;
                            for (int x = 0; x < w; x++)
                            {
                                for (int y = 0; y < h; y++)
                                {
                                    if (((x < Q[0] - R) || (x > Q[0] + R)) || ((y < Q[1] - R) || (y > Q[1] + R)))
                                    {
                                        var pix = Color.Empty;
                                        image.SetPixel(x, y, pix);
                                    }
                                    else
                                    {
                                        var pix1 = img1.GetPixel(x, y);
                                        var r = (pix1.R);
                                        var g = (pix1.G);
                                        int b = (pix1.B);
                                        switch (comboBox1.Text)
                                        {
                                            case "RGB":
                                                {
                                                    break;
                                                }
                                            case "R":
                                                {
                                                    g = 0;
                                                    b = 0;
                                                    break;
                                                }
                                            case "G":
                                                {
                                                    r = 0;
                                                    b = 0;
                                                    break;
                                                }
                                            case "B":
                                                {
                                                    r = 0;
                                                    g = 0;
                                                    break;
                                                }
                                            case "RG":
                                                {
                                                    b = 0;
                                                    break;
                                                }
                                            case "RB":
                                                {
                                                    g = 0;
                                                    break;
                                                }
                                            case "GB":
                                                {
                                                    r = 0;
                                                    break;
                                                }
                                        }
                                        var pix = Color.FromArgb(r, g, b);
                                        image.SetPixel(x, y, pix);
                                    }
                                }
                            }
                            break;
                        case "Прямоугольник":
                            D = Math.Min(h, w);

                            Q = new int[] { w / 2, h / 2 };
                            R = D / 2 - D / 10;
                            for (int x = 0; x < w; x++)
                            {
                                for (int y = 0; y < h; y++)
                                {
                                    if (((x < Q[0] - R*1.5) || (x > Q[0] + R*1.5)) || ((y < Q[1] - R) || (y > Q[1] + R)))
                                    {
                                        var pix = Color.Empty;
                                        image.SetPixel(x, y, pix);
                                    }
                                    else
                                    {
                                        var pix1 = img1.GetPixel(x, y);
                                        var r = (pix1.R);
                                        var g = (pix1.G);
                                        int b = (pix1.B);
                                        switch (comboBox1.Text)
                                        {
                                            case "RGB":
                                                {
                                                    break;
                                                }
                                            case "R":
                                                {
                                                    g = 0;
                                                    b = 0;
                                                    break;
                                                }
                                            case "G":
                                                {
                                                    r = 0;
                                                    b = 0;
                                                    break;
                                                }
                                            case "B":
                                                {
                                                    r = 0;
                                                    g = 0;
                                                    break;
                                                }
                                            case "RG":
                                                {
                                                    b = 0;
                                                    break;
                                                }
                                            case "RB":
                                                {
                                                    g = 0;
                                                    break;
                                                }
                                            case "GB":
                                                {
                                                    r = 0;
                                                    break;
                                                }
                                        }
                                        var pix = Color.FromArgb(r, g, b);
                                        image.SetPixel(x, y, pix);
                                    }
                                }
                            }
                            break;
                    }
                    
                    break;
            }
            
            pictureBox1.Image = image;
            //image1.Dispose();
            //image2.Dispose();
            //img1.Dispose();
            //img2.Dispose();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image1 != null)
                {
                    pictureBox1.Image = null;
                    image1.Dispose();
                }

                image1 = new Bitmap(openFileDialog.FileName);
                pictureBox2.Load(openFileDialog.FileName); ;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image2 != null)
                {
                    pictureBox1.Image = null;
                    image2.Dispose();
                }

                image2 = new Bitmap(openFileDialog.FileName);
                pictureBox3.Load(openFileDialog.FileName); ;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();

            f.ShowDialog();

            this.Show();
        }
    }
}
