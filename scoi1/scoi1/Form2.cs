using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace scoi1
{
    
    public partial class Form2 : Form
    {
        public class Comp : IComparer<Point>
        {
            public int Compare(Point o1, Point o2)
            {
                if (o1.X > o2.X) return 1; else if (o1.X < o2.X) return -1; return 0;
            }
        }
        int R = 7;
        bool go = false;
        List<Point> points = new List<Point>();
        Point start = new Point();
        Point end = new Point();
        bool st = false;
        bool en = false;
        Bitmap image1 = null;
        Bitmap image2 = new Bitmap(512, 512);
        Graphics _graphics;

        Bitmap input=new Bitmap(512,512);
        Bitmap output = new Bitmap(512,512);
        bool isPressedL = false;
        bool isPressedR = false;
        Point _point1;
        Timer t = new Timer();
        double[,] br=new double[1024,1024];
        Comp comp = new Comp();
        bool pic=false;
        

public Form2()
        {
            InitializeComponent();
            start = new Point(0, pictureBox1.Height-1);
            points.Add(new Point(pictureBox1.Width / 2, pictureBox1.Height / 2));
            end = new Point(pictureBox1.Width-1, 0);
            points.Add(start);
            points.Add(end);
            _graphics = Graphics.FromImage(image2);
            _graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            input = new Bitmap("..//..//..//sad//null.png");
            pictureBox2.Image = new Bitmap("..//..//..//sad//null.png");
            pictureBox1.Image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            for (var i = 0; i < input.Width; i++)
            {
                for (var j = 0; j < input.Height; j++)
                {
                   
                        var pix = input.GetPixel(i, j);
                        br[i, j] = (pix.R + pix.G + pix.B) / 3.0;
                }

            }



        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            _graphics.Clear(Color.Empty);
            points.Clear();
            start = new Point(0, pictureBox1.Height - 5);
            points.Add(new Point(pictureBox1.Width / 2, pictureBox1.Height / 2));
            end = new Point(pictureBox1.Width - 5, 0);
            points.Add(start);
            points.Add(end);
            points.Sort(comp);
            foreach (Point point in points)
            {
                _graphics.DrawRectangle(new Pen(Color.Red, 5f), point.X, point.Y, 5, 5);

                _graphics.DrawLines(new Pen(Color.FromArgb(1,1,1),1f), points.ToArray());
               // _graphics.DrawBeziers(new Pen(Color.FromArgb(1, 1, 1), 1f), points.ToArray());

            }

            pictureBox2.Image = input;
            pictureBox1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (input != null)
                {
                    pictureBox1.Image = null;
                    input.Dispose();
                }

                input = new Bitmap(openFileDialog.FileName);
                
                output = new Bitmap(input);
                pictureBox2.Image = output;
                //for (var i = 0; i < input.Width; i++)
                //{
                //    for (var j = 0; j < input.Height; j++)
                //    {
                //        var pix = input.GetPixel(i,j);
                //        br[i, j] = (pix.R + pix.G + pix.B) / 3.0;
                //        br[i + 1, j] = -1;
                //        br[i, j + 1] = -1; 
                //    }

                //}

                
            }
            pic = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isPressedL = true;
            else isPressedR = true;
            if (isPressedL)
            {
                foreach (Point point in points)
                {
                    int x = e.X;
                    int y = e.Y;


                   

                    if ((x > point.X - R) && (x < point.X + R) && (y > point.Y - R) && (y < point.Y + R))
                    {
                        if (point == start) st = true; else if (point == end) en = true;
                        points.Remove(point);
                        pictureBox1.Refresh();
                        break;
                        
                        
                    }
                }
            }
            else if (isPressedR)
            {
                foreach (Point point in points)
                {
                    int x = e.X;
                    int y = e.Y;
                    if ((x > point.X - R) && (x < point.X + R) && (y > point.Y - R) && (y < point.Y + R))
                    {
                        points.Remove(point);
                        _graphics.Clear(Color.Empty);
                        pictureBox1.Refresh();
                        break;
                    }
                }
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (isPressedL)
            {
                isPressedL = false;

                if (st)
                {
                    _point1 = e.Location;
                    _graphics.DrawRectangle(new Pen(Color.Red, 5f),
                        0, _point1.Y, 5, 5);
                    foreach (Point point in points)
                    {
                        _graphics.DrawRectangle(new Pen(Color.Red, 5f),
                    point.X, point.Y, 5, 5);


                    }
                    points.Add(new Point(0, e.Y));
                    start = new Point(0, e.Y);
                    st = false;

                }
                else if (en)
                {
                    en = false;
                    _point1 = e.Location;
                    _graphics.DrawRectangle(new Pen(Color.Red, 5f),
                        513, _point1.Y, 5, 5);
                    foreach (Point point in points)
                    {
                        _graphics.DrawRectangle(new Pen(Color.Red, 5f),
                    point.X, point.Y, 5, 5);
                        pictureBox1.Image = image2;

                    }
                    points.Add(new Point(pictureBox1.Width-1, e.Y));
                    end = new Point(pictureBox1.Width-1, e.Y);
                    

                }
                else

                {
                    _point1 = e.Location;
                    _graphics.DrawRectangle(new Pen(Color.Red, 5f),
                        _point1.X, _point1.Y, 5, 5);
                    pictureBox1.Image = image2;
                    foreach (Point point in points)
                    {
                        _graphics.DrawRectangle(new Pen(Color.Red, 5f),
                    point.X, point.Y, 5, 5);
                        pictureBox1.Image = image2;

                    }
                    points.Add(new Point(e.X, e.Y));
                }
                pictureBox1.Refresh();
               // _graphics.Clear(Color.Empty);
                
                points.Sort(comp);
            }
            else if (isPressedR&&!en&&!st)
            {
                isPressedR = false;
                _point1 = e.Location;
                _graphics.DrawRectangle(new Pen(Color.Red, 5f),
                    _point1.X, _point1.Y, 5, 5);
                pictureBox1.Image = image2;
                foreach (Point point in points)
                {
                    _graphics.DrawRectangle(new Pen(Color.Red, 5f),
                point.X, point.Y, 5, 5);
                    pictureBox1.Image = image2;

                }

                
                pictureBox1.Refresh();
                _graphics.Clear(Color.Empty);
                points.Sort(comp);
            }
            go = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressedL)
            {
                if (e.X > 0 && e.Y > 0 && e.X < 512 && e.Y < 512)
                {
                    if (st)
                    {

                        _point1 = e.Location;
                        _point1.X = 0;
                        _graphics.DrawRectangle(new Pen(Color.Red, 5f), _point1.X, _point1.Y, 5, 5);
                        points.Add(_point1);
                        points.Sort(comp);
                        _graphics.DrawLines(new Pen(Color.FromArgb(1,1,1), 1f), points.ToArray());
                       // _graphics.DrawBeziers(new Pen(Color.FromArgb(1, 1, 1), 1f), points.ToArray());
                        pictureBox1.Image = image2;
                        
                    }
                    else if (en)
                    {
                        _point1 = e.Location;
                        _point1.X = pictureBox1.Width-1;
                        _graphics.DrawRectangle(new Pen(Color.Red, 5f), _point1.X, _point1.Y, 5, 5);
                        points.Add(_point1);
                        points.Sort(comp);
                        _graphics.DrawLines(new Pen(Color.FromArgb(1,1,1), 1f), points.ToArray());
                        //_graphics.DrawBeziers(new Pen(Color.FromArgb(1, 1, 1), 1f), points.ToArray());
                        pictureBox1.Image = image2;
                    }
                    else
                    {
                        _point1 = e.Location;

                        _graphics.DrawRectangle(new Pen(Color.Red, 5f), _point1.X, _point1.Y, 5, 5);
                        points.Add(_point1);
                        points.Sort(comp);
                        _graphics.DrawLines(new Pen(Color.FromArgb(1,1,1), 1f), points.ToArray());
                        //_graphics.DrawBeziers(new Pen(Color.FromArgb(1, 1, 1), 1f), points.ToArray());
                        pictureBox1.Image = image2;
                    }
                    _graphics.Clear(Color.Empty);
                    pictureBox1.Refresh();
                    points.Remove(_point1);
                    
                }
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            this.SetStyle(
            System.Windows.Forms.ControlStyles.UserPaint |
            System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
            System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
            true);
            if (isPressedL)
            {
                
                points.Add(_point1);
                points.Sort(comp);
                foreach (Point point in points)
                {
                    _graphics.DrawRectangle(new Pen(Color.Red, 5f), point.X, point.Y, 5, 5);
                    
                    _graphics.DrawLines(new Pen(Color.FromArgb(1,1,1), 1f), points.ToArray());
                   // _graphics.DrawBeziers(new Pen(Color.FromArgb(1, 1, 1), 1f), points.ToArray());
                    pictureBox1.Image = image2;
                }
                points.Remove(_point1);
                pictureBox1.Refresh();
               _graphics.Clear(Color.Empty);
            }
            else
            {
                points.Sort(comp);
                foreach (Point point in points)
                {
                    _graphics.DrawRectangle(new Pen(Color.Red, 5f), point.X, point.Y, 5, 5);

                    _graphics.DrawLines(new Pen(Color.FromArgb(1,1,1), 1f), points.ToArray());
                    //_graphics.DrawBeziers(new Pen(Color.FromArgb(1, 1, 1), 1f), points.ToArray());
                    pictureBox1.Image = image2;

                }








                //SaveFileDialog saveFileFialog = new SaveFileDialog();
                //saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
                //saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
                //saveFileFialog.RestoreDirectory = true;

                //if (saveFileFialog.ShowDialog() == DialogResult.OK)
                //{
                //    if (image2 != null)
                //    {
                //        image2.Save(saveFileFialog.FileName);
                //        saveFileFialog.Dispose();
                //    }
                //}



                if (pic&&go)
                {
                    
                    go = false;
                    for (var i = 0; i < input.Width; i++)
                    {
                        for (var j = 0; j < input.Height; j++)
                        {
                            Point pr2 = new Point();
                            Point pr1 = points.ToArray()[0];
                            Point pg2 = new Point();
                            Point pg1 = points.ToArray()[0];
                            Point pb2 = new Point();
                            Point pb1 = points.ToArray()[0];
                            int r =0, g = 0, b = 0; 
                            var pixIn = input.GetPixel(i, j);
                            bool rr = false;
                            bool gg = false;
                            bool bb = false;







                            foreach (Point point in points)
                            {
                                //if (pixIn.R > 150)
                                //    points = points;

                                if (!rr && pixIn.R <= point.X) { pr2 = point; rr = true; } else if (!rr) pr1 = point;
                                if (!gg && pixIn.G <= point.X) { pg2 = point; gg = true; } else if (!gg) pg1 = point;
                                if (!bb && pixIn.B <= point.X) { pb2 = point; bb = true; } else if (!bb) pb1 = point;

                            }

                            int x1 = pr1.X;
                            int x2 = pr2.X;
                            int x = pixIn.R;
                            int y1 = 255- pr1.Y;
                            int y2 = 255-pr2.Y;
                            if (y1 == y2 || x1 == x2) { 
                                r = y1;
                            } else
                             r = ((y2 - y1) * (x - x1) / (x2 - x1) + y1);



                             x1 = pg1.X;
                             x2 = pg2.X;
                             x = pixIn.G;
                             y1 = 255 - pg1.Y;
                             y2 = 255 - pg2.Y;
                            if (y1 == y2 || x1 == x2) { g = y1; }
                            else
                                g = ((y2 - y1) * (x - x1) / (x2 - x1) + y1);

                            x1 = pb1.X;
                            x2 = pb2.X;
                            x = pixIn.B;
                            y1 = 255 - pb1.Y;
                            y2 = 255 - pg2.Y;
                            if (y1 == y2 || x1==x2) {
                                b = y1; 
                            }
                            else
                                b = ((y2 - y1) * (x - x1) / (x2 - x1) + y1);


                            var pix1 = Color.FromArgb(kto(r, 0, 255), kto(g, 0, 255), kto(b, 0, 255));
                            output.SetPixel(i, j, pix1);
                            int progress = i * j / (input.Width * input.Height);
                           
                        }
                    }
                    pictureBox2.Image = output;


                   


                }
                PrintGistogramma();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
        int kto(int a, int min, int max)
        {
            if (a < min) a = min;
            if (a > max) a = max;
            return a;
        }
        public void PrintGistogramma()
        {
            Graphics graphics = pictureBox3.CreateGraphics();
            var gist = new Bitmap(256, 202);
            int[] N = new int[256];
            for (int y = 0; y < output.Height; y++)
            {
                for (int x = 0; x < output.Width; x++)
                {
                    var pix = output.GetPixel(x, y);
                    int c = (pix.R + pix.G + pix.B) / 3;
                    N[c]++;
                }
            }

            int max = N.Max();
            decimal k = 202m / max;
            for (int i = 0; i < 255; i++)
            {
                Point a = new Point(i, 201);
                Point b = new Point(i, (int)(201 - k * N[i]));
                for (int j = 201; j > b.Y; j--)
                {
                    gist.SetPixel(i, j, Color.Black);
                }


            }
            pictureBox3.Image = gist;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
 