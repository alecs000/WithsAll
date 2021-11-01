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
        int[,] pedicLeft = new int[20, 20];//pedestrian
        int[,] pedicRight = new int[20, 20];//pedestrian1
        int[,] pedicUp = new int[20, 20];//pedestrian2
        int[,] pedicDown = new int[20, 20];//pedestrian3        
        int[,] timerPedArr = new int[20, 20];
        int[,] stopArr = new int[20, 20];
        
        PictureBox stopPic = new PictureBox();
        PictureBox pic1111 = new PictureBox();
        PictureBox stop = new PictureBox();
        int StopX = 0;
        int StopY = 0;
        int PedicPositionX = 0;
        int PedicPositionY = 0;
        int[,] trColor = new int[21, 21];
        int[,] trColor1 = new int[21, 21];
        int nameFourPic = 0;
        string nameCreatBox = "";
        bool pedPress = false;
        bool pedPress1 = false;
        bool stopPress = false;
        bool stopPress1 = false;
        bool stopPressIn = false;
        bool stopPressIn1 = false;
        int numStopPress = 0;
        

        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            button4.Visible = false;
            button3.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            carR.Visible = false;
            carB.Visible = false;
            button2.Enabled = false;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    timerPedArr[i, j] = 5;
                }
            }
           
            //создание поля и событий
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
            //заполнение массива
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
            //swith 1, 2, 3... массив и picter box
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
        }      
        bool pressBox = true;
        //Событие по клику на созданный один из 4 picterBox-ов
        private void picDezine_Click(object s, EventArgs e)
        {
            
            PictureBox pic = s as PictureBox;
            
            PictureBox pic11;
            PictureBox pic222 = new PictureBox();
            for (int i = 0; i < 20; i++)
            {

                for (int j = 0; j < 20; j++)
                {

                    pic222 = this.panel1.Controls[$"{j}_{i}"] as PictureBox;
                    for (int o = 0; o < nameFourPic; o++)
                    {
                        pic11 = pic222.Controls[$"{o}"] as PictureBox;
                        int x = pic222.Location.X;
                        int y = pic222.Location.Y;
                        for (int l = 0; l < numStopPress; l++)
                        {
                            if (pic11 != null)
                            {

                                PictureBox picp = pic11.Controls[$"{l}"] as PictureBox;

                                if (picp == pic && stopPressIn1)
                                {
                                    carR.Visible = false;
                                    carB.Visible = false;
                                    stopPressIn = false;
                                }


                                if (picp == pic && stopArr[i, j] != 0)
                                {
                                    carR.Visible = true;
                                    carR.Location = new Point(x + 35, y + 20);
                                    carB.Visible = true;
                                    carB.Location = new Point(x + 35, y - 20);
                                    stopPressIn = true;
                                    StopX = x;
                                    StopY = y;
                                    stopPic = pic11;

                                }
                            }
                        }
                        if (stopPressIn != true)
                        {


                            if (pic11 == pic && stopPress1)
                            {
                                carR.Visible = false;
                                carB.Visible = false;
                                stopPress = false;
                            }


                            if (pic11 == pic && stopArr[i, j] != 0)
                            {
                                carR.Visible = true;
                                carR.Location = new Point(x + 35, y + 20);
                                carB.Visible = true;
                                carB.Location = new Point(x + 35, y - 20);
                                stopPress = true;
                                StopX = x;
                                StopY = y;
                                stopPic = pic11;

                            }
                        }

                        if (pic11 == pic && pedPress1)
                        {
                            button3.Visible = false;
                            button4.Visible = false;
                            label2.Visible = false;
                            pedPress = false;
                        }

                        

                        if (pic11 == pic && pedicLeft[i, j] != 0)
                        {
                            
                            label2.Visible = true;
                            label2.Location = new Point(x - 64, y +4);
                            button4.Visible = true;
                            button4.Location = new Point(x - 27, y + 4);
                            button3.Visible = true;
                            button3.Location = new Point(x - 91, y + 4);
                            
                            pedPress = true;
                            PedicPositionX = x;
                            PedicPositionY = y;
                            label2.Text = $"{timerPedArr[y/35, x/35]}";
                        }
                        else  if (pic11 == pic && pedicRight[i, j] != 0)
                        {
                            
                            label2.Visible = true;
                            label2.Location = new Point(x + 62, y + 4);
                            button4.Visible = true;
                            button4.Location = new Point(x + 35, y + 4);
                            button3.Visible = true;
                            button3.Location = new Point(x + 99, y + 4);
                            
                            pedPress = true;
                            PedicPositionX = x;
                            PedicPositionY = y;
                            label2.Text = $"{timerPedArr[y / 35, x / 35]}";
                        }
                        else if (pic11 == pic && pedicUp[i, j] != 0)
                        {
                            
                            label2.Visible = true;
                            label2.Location = new Point(x  , y + 62);
                            button4.Visible = true;
                            button4.Location = new Point(x + 5, y + 35);
                            button3.Visible = true;
                            button3.Location = new Point(x +5, y + 89);
                            
                            pedPress = true;
                            PedicPositionX = x;
                            PedicPositionY = y;
                            label2.Text = $"{timerPedArr[y / 35, x / 35]}";
                        }
                        else if (pic11 == pic && pedicDown[i, j] != 0)
                        {
                            
                            label2.Visible = true;
                            label2.Location = new Point(x, y - 54);
                            button4.Visible = true;
                            button4.Location = new Point(x + 5, y - 27);
                            button3.Visible = true;
                            button3.Location = new Point(x + 5, y - 81);
                            
                            pedPress = true;
                            PedicPositionX = x;
                            PedicPositionY = y;
                            label2.Text = $"{timerPedArr[y / 35, x / 35]}";
                        }
                        
                            
                        
                        if (pic11 != null)
                        {
                            pic11.BorderStyle = BorderStyle.None;
                            button2.Enabled = false;
                            
                        }

                    }

                }

            }
            pedPress1 = pedPress;
            stopPress1 = stopPress;
            stopPressIn1 = stopPressIn;
            
                nameCreatBox = pic.Name;
                pic.BorderStyle = BorderStyle.FixedSingle;
                button2.Enabled = true;
                pressBox = false;
                pic1111 = pic;
            



        }



        private void pic_MouseHover(object s, EventArgs e)
        {
            PictureBox pic = s as PictureBox;
            
            label1.Text = "X: "+Convert.ToString(pic.Location.X/35)+" "+ "Y: " + Convert.ToString(pic.Location.Y / 35);
        }        
        private void pic_Click(object s, EventArgs e)
        {
            
            
                        
                            
                                
                            
                        
                               
                      
                            if (pressBox == false)
                            {
                                pic1111.BorderStyle = BorderStyle.None;
                                pressBox = true;
                                button2.Enabled = false;
                                button3.Visible = false;
                                button4.Visible = false;
                                label2.Visible = false; 
                                pedPress1 = false;
                                pedPress = false;
                                stopPress = false;
                                carB.Visible = false;
                                carR.Visible = false;
                                
                                stopPress1 = false;
                stopPressIn = false;
                stopPressIn1 = false;

            }

                      

                   
            PictureBox pic = s as PictureBox;
            int x = pic.Location.X/35;
            int y = pic.Location.Y/35;
            if (tr)
            {
                if (matrix[y, x] == 5)
                {
                    PictureBox pic1 = new PictureBox
                    {
                        Name = $"{nameFourPic}",
                        Size = new Size(35, 35),
                        Location = new Point(0, 0),
                        Image = Image.FromFile(@"TLred.png"),

                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent,


                    };
                    pic.Controls.Add(pic1);
                    pic1.Click += new System.EventHandler(picDezine_Click);
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
                if (trColor[y, x + 1] != 0 )
                {
                    PictureBox pic1 = new PictureBox
                    {
                        Name = $"{nameFourPic}",
                        Size = new Size(35, 35),
                        Location = new Point(0, 0),
                        Image = Image.FromFile(@"Pedestrain.png"),

                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent,


                    };
                    pic.Controls.Add(pic1);
                    pic1.BringToFront();
                    pic1.Click += new System.EventHandler(picDezine_Click);
                    pedicRight[x,y]++;
                   
                }
                else if ( trColor1[y + 1, x] != 0 )
                {
                    PictureBox pic1 = new PictureBox
                    {
                        Name = $"{nameFourPic}",
                        Size = new Size(35, 35),
                        Location = new Point(0, 0),
                        Image = Image.FromFile(@"Pedestrain.png"),

                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent,


                    };
                    pic.Controls.Add(pic1);
                    pic1.BringToFront();
                    pic1.Click += new System.EventHandler(picDezine_Click);
                    pedicUp[x, y]++;
                }
                else if (y != 0 && trColor1[y - 1, x] != 0)
                {
                    PictureBox pic1 = new PictureBox
                    {
                        Name = $"{nameFourPic}",
                        Size = new Size(35, 35),
                        Location = new Point(0, 0),
                        Image = Image.FromFile(@"Pedestrain.png"),

                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent,


                    };
                    pic.Controls.Add(pic1);
                    pic1.BringToFront();
                    pic1.Click += new System.EventHandler(picDezine_Click);
                    pedicDown[x, y]++;
                }
                else if ( (y != 0 && trColor[y, x - 1] != 0))
                {
                    PictureBox pic1 = new PictureBox
                    {
                        Name = $"{nameFourPic}",
                        Size = new Size(35, 35),
                        Location = new Point(0, 0),
                        Image = Image.FromFile(@"Pedestrain.png"),

                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent,


                    };
                    pic.Controls.Add(pic1);
                    pic1.BringToFront();
                    pic1.Click += new System.EventHandler(picDezine_Click);
                    pedicLeft[x, y]++;
                }
                else
                {
                    tr = false;
                    ped = false;
                    st = false;
                    crs = false;
                }

            }
            else if (st)
            {
                if (matrix[y, x] == 1 || matrix[y, x] == 2 || matrix[y, x] == 3 || matrix[y, x] == 4 || matrix[y, x] == 5)
                {
                    PictureBox pic1 = new PictureBox
                {
                    Name = $"{nameFourPic}",
                    Size = new Size(35, 35),
                    Location = new Point(0, 0),
                    Image = Image.FromFile(@"Rblock.png"),

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,


                };
                pic.Controls.Add(pic1);
                    stopArr[x, y]++;
                    stop = pic1;
                pic1.BringToFront();
                    pic1.Click += new System.EventHandler(picDezine_Click);
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
                if (matrix[y, x] == 1 || matrix[y, x] == 2  )
                {
                    PictureBox pic1 = new PictureBox
                {
                    Name = $"{nameFourPic}",
                    Size = new Size(35, 35),
                    Location = new Point(0, 0),
                    Image = Image.FromFile(@"Zhorizontal.png"),

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,


                };
                    trColor[y, x]++;
                pic.Controls.Add(pic1);
                    pic1.Click += new System.EventHandler(picDezine_Click);
                    pic1.BringToFront();
                }
                else if (matrix[y, x] == 3 || matrix[y, x] == 4)
                {
                    PictureBox pic1 = new PictureBox
                    {
                        Name = $"{nameFourPic}",
                        Size = new Size(35, 35),
                        Location = new Point(0, 0),
                        Image = Image.FromFile(@"Zvertical.png"),

                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent,

                       
                };
                    pic.Controls.Add(pic1);
                    pic1.Click += new System.EventHandler(picDezine_Click);
                    pic1.BringToFront();

                    trColor1[y, x]++;
                }
                else
                {
                    tr = false;
                    ped = false;
                    st = false;
                    crs = false;
                }
            }
            nameFourPic++;
        }
        //stopSpawnArr
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
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            tr = false;
            ped = false;
            st = true;
            crs = false;
        }
        bool designerOfOn = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (designerOfOn)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                button2.Visible = true;
                designerOfOn = false;
            }
            else
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                button2.Visible = false;
                designerOfOn = true;
            }

        }     
        private void button2_Click(object sender, EventArgs e)
        {
            if (pressBox == false)
            {
                
                PictureBox pic1;
                for (int i = 0; i < 20; i++)
                {
                    
                    for (int j = 0; j < 20; j++)
                    {
                        PictureBox pic = this.panel1.Controls[$"{j}_{i}"] as PictureBox;
                        for (int o = 0; o < nameFourPic; o++)
                        {
                            pic1 = pic.Controls[nameCreatBox] as PictureBox;
                            if (pic1 != null)
                            {
                                pic1.Visible = false;
                                button2.Enabled = false;
                                button3.Visible = false;
                                button4.Visible = false;
                                label2.Visible = false;
                            }
                            
                        }
                        
                    }
                    
                }
                

            }       
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            int x = PedicPositionX / 35;
            int y = PedicPositionY / 35;
            timerPedArr[y, x]++;
            label2.Text = $"{timerPedArr[y, x]}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = PedicPositionX / 35;
            int y = PedicPositionY / 35;
            timerPedArr[y, x]--;
            label2.Text = $"{timerPedArr[y, x]}";
        }

        private void carR_Click(object sender, EventArgs e)
        {
            int x = StopX / 35;
            int y = StopY / 35;
            PictureBox pic1 = new PictureBox
            {
                Name = $"{numStopPress}",
                Size = new Size(35, 35),
                Location = new Point(0, 0),
                Image = Image.FromFile(@"Cvertical.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,


            };
            stopPic.Controls.Add(pic1);
            pic1.Click += new System.EventHandler(picDezine_Click);
            pic1.BringToFront();

            numStopPress++;
        }

        private void carB_Click(object sender, EventArgs e)
        {
            int x = StopX / 35;
            int y = StopY / 35;
            PictureBox pic1 = new PictureBox
            {
                Name = $"{numStopPress}",
                Size = new Size(35, 35),
                Location = new Point(0, 0),
                Image = Image.FromFile(@"BCvertical.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,


            };
            stopPic.Controls.Add(pic1);
            pic1.Click += new System.EventHandler(picDezine_Click);
            //picDezine_Click(stop, EventArgs.Empty);
            pic1.BringToFront();
            numStopPress++;
            
        }
    }
}
