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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        Bitmap imageOriginal = null;
        Bitmap imageBinar = null;
        Bitmap imageMono = null;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "RGB";
            comboBox2.Text = "Круг";
            comboBox3.Text = "наложить";
            comboBox4.Text = "Гаврилов";
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
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save(saveFileFialog.FileName);
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
                imageOriginal = new Bitmap(openFileDialog.FileName);
                imageMono = makeMono(imageOriginal);
                image1 = new Bitmap(openFileDialog.FileName);
                pictureBox2.Image=imageOriginal;
                imageBinar = new Bitmap(imageMono.Width, imageMono.Height);
                //pictureBox1.Image = imageMono;
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

        private void Binary_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = imageMono;
            switch (comboBox4.Text)
            {
                case "Гаврилов":
                    double threshold = 0.0;
                    for (int i = 0; i < imageMono.Width; i++)
                    {
                        for (int j = 0; j < imageMono.Height; j++)
                        {
                            threshold += imageMono.GetPixel(i, j).R;
                        }
                    }

                    threshold /= (imageMono.Width * imageMono.Height);


                    for (int i = 0; i < imageMono.Width; i++)
                    {
                        for (int j = 0; j < imageMono.Height; j++)
                        {
                            var biPix = imageMono.GetPixel(i, j);

                            imageBinar.SetPixel(i, j,
                                biPix.R <= (byte)threshold ? Color.Black : Color.White);
                        }
                    }

                    pictureBox1.Image = imageBinar;
                    break;

                case "Отсу":

                    var all_intensity_sum = 0.0;
                    int[] gist_values = new int[256];
                    for (int i = 0; i < imageMono.Width; i++)
                        for (int j = 0; j < imageMono.Height; j++)
                        {
                            var pix = imageMono.GetPixel(i, j);

                            all_intensity_sum += pix.R;

                            gist_values[pix.R]++;
                        }

                    int best_thresh = 0;
                    double best_sigma = 0.0;

                    int first_class_pixel_count = 0;
                    int first_class_intensity_sum = 0;

                    for (int thresh = 0; thresh < 255; ++thresh)
                    {
                        first_class_pixel_count += gist_values[thresh];
                        first_class_intensity_sum += thresh * gist_values[thresh];

                        double first_class_prob = first_class_pixel_count / (double)(imageMono.Width * imageMono.Height);
                        double second_class_prob = 1.0 - first_class_prob;

                        double first_class_mean = first_class_intensity_sum / (double)first_class_pixel_count;
                        double second_class_mean = (all_intensity_sum - first_class_intensity_sum)
                            / (double)(imageMono.Width * imageMono.Height - first_class_pixel_count);

                        double mean_delta = first_class_mean - second_class_mean;

                        double sigma = first_class_prob * second_class_prob * mean_delta * mean_delta;

                        if (sigma > best_sigma)
                        {
                            best_sigma = sigma;
                            best_thresh = thresh;
                        }
                    }


                    for (int i = 0; i < imageMono.Width; i++)
                    {
                        for (int j = 0; j < imageMono.Height; j++)
                        {
                            var biPix = imageMono.GetPixel(i, j);

                            imageBinar.SetPixel(i, j,
                                biPix.R <= (byte)best_thresh ? Color.Black : Color.White);
                        }
                    }


                   
                    pictureBox1.Image = imageBinar;

                    break;

                case "Ниблек":
                    double sensitivity = -0.2;
                    int n = 15;
                    int[,] pix_matrix = new int[n, n];
                    int n_forMatrix = (int)Math.Floor((double)n / 2);
                    for (int i = 0; i < imageMono.Height; i++)
                        for (int j = 0; j < imageMono.Width; j++)
                        {

                            var pix = imageMono.GetPixel(j, i);
                            pix_matrix[n_forMatrix, n_forMatrix] = pix.R;   

                            double math_expec = 0.0;
                            double math_expec_powered = 0.0;
                            double math_dispersion = 0.0;

                            for (int i_matrix = 0; i_matrix < n; i_matrix++)
                            {
                                for (int j_matrix = 0; j_matrix < n; j_matrix++)
                                {
                                    if ((i - n_forMatrix + i_matrix) == n_forMatrix && (j - n_forMatrix + j_matrix) == n_forMatrix)
                                        continue;

                                    if ((j - n_forMatrix + j_matrix) >= 0 && (j - n_forMatrix + j_matrix) < imageMono.Width)

                                        if ((i - n_forMatrix + i_matrix) >= 0 && (i - n_forMatrix + i_matrix) < imageMono.Height)

                                            pix_matrix[i_matrix, j_matrix] = imageMono.GetPixel(j - n_forMatrix + j_matrix, i - n_forMatrix + i_matrix).R;
                                       
                                        else { pix_matrix[i_matrix, j_matrix] = 0; }
                                    else { pix_matrix[i_matrix, j_matrix] = 0; }


                                    math_expec += pix_matrix[i_matrix, j_matrix];
                                    math_expec_powered += Math.Pow(pix_matrix[i_matrix, j_matrix], 2);
                                }
                            }

                            math_expec /= (n * n);
                            math_expec_powered /= (n * n);
                            math_dispersion = math_expec_powered - Math.Pow(math_expec, 2);

                            double avg_deviation = Math.Sqrt(math_dispersion);

                            int local_threshold = kto((int)(math_expec + sensitivity * avg_deviation), 0, 255);

                            imageBinar.SetPixel(j, i,
                               pix.R <= local_threshold ? Color.Black : Color.White);

                            
                        }

                    pictureBox1.Image = imageBinar;
                    break;

                case "Саувола":
                    double sens = 0.25;
                    int n1 = 15;
                    int[,] pixMatr = new int[n1, n1];


                    int nMatr = (int)Math.Floor((double)n1 / 2);
                    for (int i = 0; i < imageMono.Height; i++)

                        for (int j = 0; j < imageMono.Width; j++)
                        {

                            var pix = imageMono.GetPixel(j, i);
                            pixMatr[nMatr, nMatr] = pix.R;   

                            double math1 = 0.0;
                            double math2 = 0.0;
                            double math3 = 0.0;

                            for (int iMatr = 0; iMatr < n1; iMatr++)
                            {
                                for (int jMatr = 0; jMatr < n1; jMatr++)
                                {
                                    if ((i - nMatr + iMatr) == nMatr && (j - nMatr + jMatr) == nMatr)
                                        continue;

                                    if ((j - nMatr + jMatr) >= 0 && (j - nMatr + jMatr) < imageMono.Width)

                                        if ((i - nMatr + iMatr) >= 0 && (i - nMatr + iMatr) < imageMono.Height)

                                            pixMatr[iMatr, jMatr] = imageMono.GetPixel(j - nMatr + jMatr, i - nMatr + iMatr).R;
                                       
                                        else { pixMatr[iMatr, jMatr] = 0; }
                                    else { pixMatr[iMatr, jMatr] = 0; }


                                    math1 += pixMatr[iMatr, jMatr];
                                    math2 += Math.Pow(pixMatr[iMatr, jMatr], 2);
                                }

                            }

                            math1 /= (n1 * n1);
                            math2 /= (n1 * n1);
                            math3 = math2 - Math.Pow(math1, 2);

                            double avg_deviation = Math.Sqrt(math3);

                            int tresold = kto((int)(math1 * (1 + sens * (avg_deviation / 128 - 1))),
                                                             0, 255);

                            imageBinar.SetPixel(j, i,
                               pix.R <= tresold ? Color.Black : Color.White);

                            
                        }
                    pictureBox1.Image = imageBinar;
                    break;

                case "Вульф":
                    double sensitivity1 = 0.5;
                    int n2 = 15;
                    int[,] pixMatr1 = new int[n2, n2];

                    int nMatr1 = (int)Math.Floor((double)n2 / 2);

                    int tuhly = 128;

                   

                    int[,] pixMatr2 = new int[imageMono.Width, imageMono.Height];

                    int[,] math_11_Matrix = new int[imageMono.Width, imageMono.Height];
                    int[,] deviation_matrix = new int[imageMono.Width, imageMono.Height];
                    double deviation_max = 0.0;

                    for (int i = 0; i < imageMono.Height; i++)

                        for (int j = 0; j < imageMono.Width; j++)
                        {

                            var pix = imageMono.GetPixel(j, i);
                            pixMatr1[nMatr1, nMatr1] = pix.R; 
                            double math_expec = 0.0;
                            double math_expec_powered = 0.0;
                            double math_dispersion = 0.0;

                            for (int i_matrix = 0; i_matrix < n2; i_matrix++)
                            {
                                for (int j_matrix = 0; j_matrix < n2; j_matrix++)
                                {
                                    if ((i - nMatr1 + i_matrix) == nMatr1 && (j - nMatr1 + j_matrix) == nMatr1)
                                        continue;

                                    if ((j - nMatr1 + j_matrix) >= 0 && (j - nMatr1 + j_matrix) < imageMono.Width)

                                        if ((i - nMatr1 + i_matrix) >= 0 && (i - nMatr1 + i_matrix) < imageMono.Height)

                                            pixMatr1[i_matrix, j_matrix] = imageMono.GetPixel(j - nMatr1 + j_matrix, i - nMatr1 + i_matrix).R;
                                      
                                        else { pixMatr1[i_matrix, j_matrix] = 0; }
                                    else { pixMatr1[i_matrix, j_matrix] = 0; }


                                    math_expec += pixMatr1[i_matrix, j_matrix];
                                    math_expec_powered += Math.Pow(pixMatr1[i_matrix, j_matrix], 2);
                                }
                            }

                            math_expec /= (n2 * n2);
                            math_expec_powered /= (n2 * n2);
                            math_dispersion = math_expec_powered - Math.Pow(math_expec, 2);

                            double avg_deviation = Math.Sqrt(math_dispersion);

                            math_11_Matrix[j, i] = (int)math_expec;
                            deviation_matrix[j, i] = (int)avg_deviation;
                            pixMatr2[j, i] = pix.R;


                            if (avg_deviation > deviation_max)
                                deviation_max = avg_deviation;

                            if (tuhly > pix.R)
                                tuhly = pix.R;

                           
                        }

                    for (int i = 0; i < imageBinar.Height; i++)
                    {
                        for (int j = 0; j < imageBinar.Width; j++)
                        {

                            int local_threshold = kto((int)((1 - sensitivity1) * math_11_Matrix[j, i]
                                                                  + sensitivity1 * tuhly
                                                                  + sensitivity1 * (deviation_matrix[j, i] / deviation_max) * (math_11_Matrix[j, i] - tuhly)),
                                                                0, 255);

                            imageBinar.SetPixel(j, i,
                               pixMatr2[j, i] <= local_threshold ? Color.Black : Color.White);

                        }
                    }

                    pictureBox1.Image = imageBinar;

                    break;

                case "Брэдли-Рот":



                    break;
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        Bitmap makeMono(Bitmap img)
        {
            Bitmap result = new Bitmap(img);

            int monoPx = 0;

            for (int i = 0; i < result.Width; i++)
            {
                for (int j = 0; j < result.Height; j++)
                {
                    var pix = result.GetPixel(i, j);

                    monoPx = (int)kto((int)(pix.R * 0.2125 + pix.G * 0.7154 + pix.B * 0.0721), 0, 255);

                    result.SetPixel(i, j, Color.FromArgb(monoPx, monoPx, monoPx));
                }
            }

            return result;
        }

    }
}
