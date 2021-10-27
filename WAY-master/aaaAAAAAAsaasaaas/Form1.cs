using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aaaAAAAAAsaasaaas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        bool tr = false;
        bool ped = false;
        bool st = false;
        bool crs = false;
        int[,] matrix = new int[20, 20];
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //Timer t = new Timer();
            //t.Interval = 1;
            //t.Enabled = true;


            // Enable timer.  

            
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    PictureBox pic = new PictureBox
                    {
                        Name = $"{j}_{i}",
                        Size = new Size(35, 35),
                        Location = new Point(35 * i, 35 * j),
                        BackColor = Color.White,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                    };
                    panel1.Controls.Add(pic);
                    pic.MouseHover += new System.EventHandler(this.pic_MouseHover);    
                    pic.Click += new System.EventHandler(this.pic_Click);



                }
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if ((i == 1) && (j < 2 || j == 4 || j == 7 || j == 8 || (j > 10 && j < 16) || j == 18 || j == 19) || (i == 6) && (j < 2 || j == 4 || j == 5 || j == 8 || (j > 12 && j < 16) || j == 18 || j == 19) || (i == 12) && (j < 2 || j == 4 || j == 5 || j == 10 || (j > 12 && j < 16)) || (i == 16) && (j > 3 && j < 8 || j > 9 && j < 16 || j == 18 || j == 19))
                    {
                        matrix[i, j] = 3;
                    }
                    if ((i == 2) && (j < 2 || j == 4 || j == 7 || j == 8 || (j > 10 && j < 16) || j == 18 || j == 19) || (i == 7) && (j < 2 || j == 4 || j == 5 || j == 8 || (j > 12 && j < 16) || j == 18 || j == 19) || (i == 13) && (j < 2 || j == 4 || j == 5 || j == 10 || (j > 12 && j < 16)) || (i == 17) && (j > 3 && j < 8 || j > 9 && j < 16 || j == 18 || j == 19))
                    {
                        matrix[i, j] = 4;
                    }


                    if (((i == 1 || i == 2) && (j == 2 || j == 3 || j == 5 || j == 6 || j == 16 || j == 17 || j == 9 || j == 10)) || ((i == 6 || i == 7 || i == 12 || i == 13 || i == 16 || i == 17) && (j == 2 || j == 3 || j == 16 || j == 17)) || ((i == 6 || i == 7 || i == 12 || i == 13) && (j == 6 || j == 7 || j == 11 || j == 12)) || ((i == 6 || i == 7) && (j == 9 || j == 10)) || ((i == 16 || i == 17 || i == 12 || i == 13) && (j == 9 || j == 8)))
                    {
                        matrix[i, j] = 5;
                    }
                    if ((i == 0 && (j == 5 || j == 16)) || (i == 3 || i == 4 || i == 5) && (j == 2 || j == 9 || j == 16) || (i == 8 || i == 9 || i == 10 || i == 11) && (j == 2 || j == 6 || j == 11 || j == 16) || (i == 14 || i == 15 || i == 18 || i == 19) && (j == 2 || j == 8 || j == 16))
                    {
                        matrix[i, j] = 1;
                    }
                    if ((i == 0 && (j == 6 || j == 17)) || (i == 3 || i == 4 || i == 5) && (j == 3 || j == 10 || j == 17) || (i == 8 || i == 9 || i == 10 || i == 11) && (j == 3 || j == 7 || j == 12 || j == 17) || (i == 14 || i == 15 || i == 18 || i == 19) && (j == 3 || j == 9 || j == 17))
                    {
                        matrix[i, j] = 2;
                    }
                }
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    switch (matrix[i, j])
                    {

                        case 1:
                            PictureBox pic1 = panel1.Controls[$"{i}_{j}"] as PictureBox;
                            pic1.Image = Image.FromFile(@"RSvertical1.png");
                            break;
                        case 2:
                            PictureBox pic2 = panel1.Controls[$"{i}_{j}"] as PictureBox;

                            pic2.Image = Image.FromFile(@"RSvertical2.png");
                            break;
                        case 3:
                            PictureBox pic3 = panel1.Controls[$"{i}_{j}"] as PictureBox;

                            pic3.Image = Image.FromFile(@"RSvertical3.png");
                            break;
                        case 4:
                            PictureBox pic4 = panel1.Controls[$"{i}_{j}"] as PictureBox;

                            pic4.Image = Image.FromFile(@"RSvertical4.png");
                            break;
                        case 5:
                            PictureBox pic5 = panel1.Controls[$"{i}_{j}"] as PictureBox;

                            pic5.Image = Image.FromFile(@"Rcrossroads.png");
                            break;
                    }





                }
            }








            //for (int i = 0; i < 20; i++)
            //{
            //    for (int j = 0; j < 20; j++)
            //    {
            //        PictureBox pic = panel1.Controls[$"{i}_{j}"] as PictureBox;

            //        pic.MouseHover += (o, p) =>
            //        {
            //            label1.Text = ((35 * i) + " " + (35 * j));
            //        };
            //    }
            //}



        }


        private void pic_MouseHover(object s, EventArgs e)
        {
            PictureBox pic = s as PictureBox;
            
            label1.Text = "X: "+Convert.ToString(pic.Location.X/35)+" "+ "Y: " + Convert.ToString(pic.Location.Y / 35);
        }
        private void pic_Click(object s, EventArgs e)
        {
            PictureBox pic = s as PictureBox;
            int x = pic.Location.X/35;
            int y = pic.Location.Y/35;
            if (tr)
            {
                if (matrix[y,x]==1|| matrix[y, x] == 2 || matrix[y, x] == 3 || matrix[y, x] == 4 || matrix[y, x] == 5)
                {
                    PictureBox pic1 = new PictureBox
                    {
                        Name = $"1",
                        Size = new Size(35, 35),
                        Location = new Point(0, 0),
                        Image = Image.FromFile(@"TLred.png"),

                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent,


                    };
                    pic.Controls.Add(pic1);
                    pic1.BringToFront();
                }
                else
                {
                    tr = false;
                    ped = false;
                    st = false;
                    crs = false;
                }

            }
            else if (ped)
            {
                PictureBox pic1 = new PictureBox
                {
                    Name = $"1",
                    Size = new Size(35, 35),
                    Location = new Point(0, 0),
                    Image = Image.FromFile(@"Pedestrain.png"),

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,


                };
                pic.Controls.Add(pic1);
                pic1.BringToFront();
            }
            else if (st)
            {
                if (matrix[y, x] == 1 || matrix[y, x] == 2 || matrix[y, x] == 3 || matrix[y, x] == 4 || matrix[y, x] == 5)
                {
                    PictureBox pic1 = new PictureBox
                {
                    Name = $"1",
                    Size = new Size(35, 35),
                    Location = new Point(0, 0),
                    Image = Image.FromFile(@"Rblock.png"),

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,


                };
                pic.Controls.Add(pic1);
                pic1.BringToFront();
                }
                else
                {
                    tr = false;
                    ped = false;
                    st = false;
                    crs = false;
                }
            }
            else if (crs)
            {
                if (matrix[y, x] == 1 || matrix[y, x] == 2 || matrix[y, x] == 3 || matrix[y, x] == 4 || matrix[y, x] == 5)
                {
                    PictureBox pic1 = new PictureBox
                {
                    Name = $"1",
                    Size = new Size(35, 35),
                    Location = new Point(0, 0),
                    Image = Image.FromFile(@"Zvertical.png"),

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,


                };
                pic.Controls.Add(pic1);
                pic1.BringToFront();
                }
                else
                {
                    tr = false;
                    ped = false;
                    st = false;
                    crs = false;
                }
            }
        }
        //private void pic_Click(object s, EventArgs e)
        //{

        //    PictureBox pic = s as PictureBox;
        //    PictureBox pic1 = new PictureBox
        //    {
        //        Name = $"{j}_{i}",
        //        Size = new Size(35, 35),
        //        Location = new Point(35 * i, 35 * j),
        //        BackColor = Color.White,
        //        SizeMode = PictureBoxSizeMode.StretchImage,
        //    };
        //    panel1.Controls.Add(pic1);
        //}

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tr = false;
            ped = false;
            st = true;
            crs = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tr = false;
            ped = true;
            st = false;
            crs = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tr = false;
            ped = false;
            st = false;
            crs = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tr = true;
            ped = false;
            st = false;
            crs = false;
        }
    }
}
