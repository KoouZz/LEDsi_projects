using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private Bitmap diagrame_bmp;
        public Bitmap Diagrame
        {
            set { diagrame_bmp = value; }
        }

        private int col;
        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        private int rw; 
        public int Rws
        {
            get { return rw; }
            set { rw = value; }
        }

        private List<List<Control>> type = new List<List<Control>>();
        public List<List<Control>> Type
        {
            get { return type; }
        }

        private int count = 1;
        public int Cnt
        {
            get { return count; }
        }

        public List<string> info = new List<string>();


        public Form2(string login_sgn, string psw, string type)
        {
            InitializeComponent();
            Form2_InitComp(type);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        private void b_sendData_Click(object sender, EventArgs e)
        {
            string kk = "empty";
            for (int i = 0; i < count; i++)
            {
                if ((Controls.Find($"tb_sizeW{i}", true).FirstOrDefault().Text != "") && 
                    (Controls.Find($"tb_sizeH{i}", true).FirstOrDefault().Text != "") && 
                    (Controls.Find($"tb_count{i}", true).FirstOrDefault().Text != ""))
                {
                    kk = "done";
                }
            }

            if(kk =="done")
            {
                Close();
            } else
            {
                Label err = new Label();
                err.Text = "Заполните все поля в форме";
                err.Size = new Size(100, 60);
                err.TextAlign = ContentAlignment.TopCenter;
                err.ForeColor = Color.Red;
                err.Location = new Point(7, 100);
                Controls.Add(err);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void operationOfInformationRows(string func)
        {
            if (func == "add")
            {
                if (count < 5)
                {
                    //
                    //label - l_No
                    //
                    Label l_No_c = new Label();
                    l_No_c.Text = $"{count + 1}";
                    l_No_c.Name = $"l_No{count}";
                    l_No_c.Size = new Size(15, 30);
                    l_No_c.Location = new Point(105, 180 + 40 * (count - 1));
                    Controls.Add(l_No_c);
                    //
                    // textbox - tb_sizeW_c
                    //
                    TextBox tb_sizeW_c = new TextBox();
                    tb_sizeW_c.Size = new Size(40, 30);
                    tb_sizeW_c.Name = $"tb_sizeW{count}";
                    tb_sizeW_c.Location = new Point(l_No_c.Location.X + l_No_c.Width + 40, l_No_c.Location.Y);
                    tb_sizeW_c.TextAlign = HorizontalAlignment.Center;
                    Controls.Add(tb_sizeW_c);
                    //
                    //label - l_x
                    //
                    Label l_x_c = new Label();
                    l_x_c.Text = "x";
                    l_x_c.Name = $"l_x{count}";
                    l_x_c.Size = new Size(15, 30);
                    l_x_c.Location = new Point(tb_sizeW_c.Location.X + tb_sizeW_c.Width + 5, tb_sizeW_c.Location.Y);
                    Controls.Add(l_x_c);
                    //
                    //textbox - tb_sizeH
                    //
                    TextBox tb_sizeH_c = new TextBox();
                    tb_sizeH_c.Size = new Size(40, 30);
                    tb_sizeH_c.Name = $"tb_sizeH{count}";
                    tb_sizeH_c.Location = new Point(l_x_c.Location.X + l_x_c.Width + 5, l_x_c.Location.Y);
                    tb_sizeH_c.TextAlign = HorizontalAlignment.Center;
                    Controls.Add(tb_sizeH_c);
                    //
                    //textbox - tb_count
                    //
                    TextBox tb_count_c = new TextBox();
                    tb_count_c.Size = new Size(40, 30);
                    tb_count_c.Name = $"tb_count{count}";
                    tb_count_c.Location = new Point(tb_sizeH_c.Location.X + tb_sizeH_c.Width + 40, tb_sizeH_c.Location.Y);
                    tb_count_c.TextAlign = HorizontalAlignment.Center;
                    Controls.Add(tb_count_c);
                    count++;
                    type.Add(new List<Control> { tb_sizeW_c, tb_sizeH_c, tb_count_c });
                }
            }
            if (func == "rmv")
            {
                if (count > 1)
                {
                    var l_No = Controls.Find("l_No" + Convert.ToString(count - 1), true).FirstOrDefault() as Label;
                    var l_x = Controls.Find("l_x" + Convert.ToString(count - 1), true).FirstOrDefault() as Label;
                    var tb_sizeW = Controls.Find("tb_sizeW" + Convert.ToString(count - 1), true).FirstOrDefault() as TextBox;
                    var tb_sizeH = Controls.Find("tb_sizeH" + Convert.ToString(count - 1), true).FirstOrDefault() as TextBox;
                    var tb_count = Controls.Find("tb_count" + Convert.ToString(count - 1), true).FirstOrDefault() as TextBox;
                    Controls.Remove(l_No);
                    Controls.Remove(l_x);
                    Controls.Remove(tb_sizeW);
                    Controls.Remove(tb_sizeH);
                    Controls.Remove(tb_count);
                    count--;
                }
            }
        }
        private void b_add_Click(object sender, EventArgs e)
        {
            operationOfInformationRows("add");
        }

        private void b_autoEquip_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNumW = Int32.TryParse(Controls.Find("tb_screenWidth", true).FirstOrDefault().Text, out int screenW);
                bool isNumH = Int32.TryParse(Controls.Find("tb_screenHeight", true).FirstOrDefault().Text, out int screenH);
                if (!isNumW || !isNumH)
                {
                    throw new Exception("Размеры экрана заданы неверно");
                } else if ((screenW % 320 != 0) | (screenH % 160 != 0)) 
                {
                    throw new Exception("Размеры экрана не кратны модулю 320x160");
                } else 
                {
                    for (int i = 0; i < 5; i++)
                    {
                        operationOfInformationRows("rmv");
                    }
                    fillInfoCabinets(cabinetCalculator(screenW, screenH));
                }
            } catch (Exception ex)
            {
                DialogResult error = MessageBox.Show(ex.Message, "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (error == DialogResult.OK)
                {
                    Controls.Find("tb_screenWidth", true).FirstOrDefault().Text = "";
                    Controls.Find("tb_screenHeight", true).FirstOrDefault().Text = "";
                    Controls.Find("tb_screenWidth", true).FirstOrDefault().Focus();
                }
            }
        }

        private void b_rmv_Click(object sender, EventArgs e)
        {
            operationOfInformationRows("rmv");
        }

        private void Form2_InitComp (string type_form)
        {
            if (type_form == "reg")
            {
                login_Form();
                //
                //label2
                //
                Label label2 = new Label();
                Controls.Add(label2);
                label2.Text = "Name";
                label2.Height = 30;
                label2.Width = 100;
                label2.Location = new Point(Left + 20, Top + 20);
                //
                //label3
                //
                Label label3 = new Label();
                Controls.Add(label3);
                label3.Text = "Fename";
                label3.Height = 30;
                label3.Width = 100;
                label3.Location = new Point(Left + 20, label2.Location.Y + label2.Height + 10);
                //
                //label4
                //
                Label label4 = new Label();
                Controls.Add(label4);
                label4.Text = "Login";
                label4.Height = 30;
                label4.Width = 100;
                label4.Location = new Point(Left + 20, label3.Location.Y + label3.Height + 10);
                //
                //label5
                //
                Label label5 = new Label();
                Controls.Add(label5);
                label5.Text = "E-mail";
                label5.Height = 30;
                label5.Width = 100;
                label5.Location = new Point(Left + 20, label4.Location.Y + label4.Height + 10);
                //
                //label6
                //
                Label label6 = new Label();
                Controls.Add(label6);
                label6.Text = "Password";
                label6.Height = 30;
                label6.Width = 100;
                label6.Location = new Point(Left + 20, label5.Location.Y + label5.Height + 10);
                //
                //textbox - name
                //
                TextBox name = new TextBox();
                Controls.Add(name);
                name.Size = new Size(250, 30);
                name.Location = new Point(label2.Location.X + label2.Width + 10, label2.Location.Y);
                //
                //textbox - fename
                //
                TextBox fename = new TextBox();
                Controls.Add(fename);
                fename.Size = new Size(250, 30);
                fename.Location = new Point(label3.Location.X + label3.Width + 10, label3.Location.Y);
                //
                //textbox - login
                //
                TextBox login = new TextBox();
                Controls.Add(login);
                login.Size = new Size(250, 30);
                login.Location = new Point(label4.Location.X + label4.Width + 10, label4.Location.Y);
                //
                //textbox - email
                //
                TextBox email = new TextBox();
                Controls.Add(email);
                email.Size = new Size(250, 30);
                email.Location = new Point(label5.Location.X + label5.Width + 10, label5.Location.Y);
                //
                //textbox - psw
                //
                TextBox psw = new TextBox();
                Controls.Add(psw);
                psw.PasswordChar = '*';
                psw.Size = new Size(250, 30);
                psw.Location = new Point(label6.Location.X + label6.Width + 10, label6.Location.Y);
                //
                //button1
                //
                Button button1 = new Button();
                Controls.Add(button1);
                button1.Text = "Sign in";
                button1.Size = new Size(80, 30);
                button1.Location = new Point(this.Width / 2 - button1.Width / 2, label6.Location.Y + label6.Height + 10);
                button1.Click += button1_Click;
            } 
            if (type_form == "dataIN")
            {
                data_Form();

                Button b_autoEquip = new Button();
                b_autoEquip.Text = "Рекомендованные кабинеты";
                b_autoEquip.Size = new Size(250, 30);
                b_autoEquip.Location = new Point(Width - b_autoEquip.Width - 25, Height - 2 * b_autoEquip.Height - 20);
                b_autoEquip.Click += b_autoEquip_Click;
                Controls.Add(b_autoEquip);
                //
                //button - b_sendData
                //
                Button b_sendData = new Button();
                b_sendData.Text = "Save";
                b_sendData.Size = new Size(60, 30);
                b_sendData.Location = new Point(20, Height - 2 * b_sendData.Height - 20);
                b_sendData.Click += b_sendData_Click;
                Controls.Add(b_sendData);
                //
                //button - b_add
                //
                Button b_add = new Button();
                b_add.Text = "+";
                b_add.Size = new Size(30, 30);
                b_add.Location = new Point(20, 20);
                b_add.Click += b_add_Click;
                Controls.Add(b_add);
                //
                //button - b_rmv
                //
                Button b_rmv = new Button();
                b_rmv.Text = "-";
                b_rmv.Size = new Size(30, 30);
                b_rmv.Location = new Point(b_add.Location.Y + b_add.Width + 5, 20);
                b_rmv.Click += b_rmv_Click;
                Controls.Add(b_rmv);
                //
                //label - l_No
                //
                Label l_No = new Label();
                l_No.Text = "1";
                l_No.Name = "l_No0";
                l_No.Size = new Size(15, 30);
                l_No.Location = new Point(b_rmv.Location.X + b_rmv.Width + 20, b_rmv.Location.Y + b_rmv.Height + 10 + 80);
                Controls.Add(l_No);
                //
                //textbox - tb_sizeW
                //
                TextBox tb_sizeW = new TextBox();
                tb_sizeW.Name = "tb_sizeW0";
                tb_sizeW.Size = new Size(40, 30);
                tb_sizeW.Location = new Point(l_No.Location.X + l_No.Width + 40, l_No.Location.Y);
                tb_sizeW.TextAlign = HorizontalAlignment.Center;
                Controls.Add(tb_sizeW);
                //
                //label - l_x
                //
                Label l_x = new Label();
                l_x.Text = "x";
                l_x.Size = new Size(15, 30);
                l_x.Location = new Point(tb_sizeW.Location.X + tb_sizeW.Width + 5, tb_sizeW.Location.Y);
                Controls.Add(l_x);
                //
                //textbox - tb_sizeH
                //
                TextBox tb_sizeH = new TextBox();
                tb_sizeH.Size = new Size(40, 30);
                tb_sizeH.Name = "tb_sizeH0";
                tb_sizeH.Location = new Point(l_x.Location.X + l_x.Width + 5, l_x.Location.Y);
                tb_sizeH.TextAlign = HorizontalAlignment.Center;
                Controls.Add(tb_sizeH);
                //
                //textbox - tb_count
                //
                TextBox tb_count = new TextBox();
                tb_count.Size = new Size(40, 30);
                tb_count.Name = "tb_count0";
                tb_count.Location = new Point(tb_sizeH.Location.X + tb_sizeH.Width + 40, tb_sizeH.Location.Y);
                tb_count.TextAlign = HorizontalAlignment.Center;
                Controls.Add(tb_count);
                //
                //label - l_sizeW
                //
                Label l_sizeW = new Label();
                l_sizeW.Text = "W";
                l_sizeW.Size = new Size(20, 20);
                l_sizeW.Location = new Point(tb_sizeW.Location.X + tb_sizeW.Width/2 - l_sizeW.Width/2, b_rmv.Location.Y + b_rmv.Height/2 - l_sizeW.Height/2 + 80);
                Controls.Add(l_sizeW);
                //
                //label - l_sizeH
                //
                Label l_sizeH = new Label();
                l_sizeH.Text = "H";
                l_sizeH.Size = new Size(20, 20);
                l_sizeH.Location = new Point(tb_sizeH.Location.X + tb_sizeH.Width / 2 - l_sizeH.Width / 2, l_sizeW.Location.Y);
                Controls.Add(l_sizeH);
                //
                //label - l_count
                //
                Label l_count = new Label();
                l_count.Text = "Count";
                l_count.Size = new Size(60, 20);
                l_count.Location = new Point(tb_count.Location.X + tb_count.Width / 2 - l_count.Width / 2, l_sizeW.Location.Y);
                Controls.Add(l_count);

                Label l_screenWidth = new Label();
                Label l_screenHeight = new Label();
                TextBox tb_screenWidth = new TextBox();
                TextBox tb_screenHeight = new TextBox();
                Label l_screenX = new Label();

                l_screenWidth.Location = new Point(b_rmv.Location.X + b_rmv.Width + 20, b_rmv.Location.Y);
                l_screenWidth.Size = new Size(125, 23);
                l_screenWidth.Text = "Ширина экрана";
                Controls.Add(l_screenWidth);

                l_screenHeight.Location = new Point(l_screenWidth.Location.X + l_screenWidth.Width + 5, l_screenWidth.Location.Y);
                l_screenHeight.Size = new Size(125, 23);
                l_screenHeight.Text = "Высота экрана";
                Controls.Add(l_screenHeight);

                tb_screenWidth.Size = new Size(100, 25);
                tb_screenWidth.Location = new Point(l_screenWidth.Location.X + l_screenWidth.Width / 2 - tb_screenWidth.Width / 2, l_screenWidth.Location.Y + l_screenWidth.Height + 15);
                tb_screenWidth.TextAlign = HorizontalAlignment.Center;
                tb_screenWidth.Name = "tb_screenWidth";
                Controls.Add(tb_screenWidth);

                tb_screenHeight.Size = new Size(100, 25);
                tb_screenHeight.Location = new Point(l_screenHeight.Location.X + l_screenHeight.Width / 2 - tb_screenWidth.Width / 2, tb_screenWidth.Location.Y);
                tb_screenHeight.TextAlign = HorizontalAlignment.Center;
                tb_screenHeight.Name = "tb_screenHeight";
                Controls.Add(tb_screenHeight);

                l_screenX.Text = "x";
                l_screenX.Size = new Size(15, 23);
                l_screenX.Location = new Point(tb_screenHeight.Location.X + tb_screenWidth.Width - tb_screenWidth.Location.X - l_screenX.Width / 2, tb_screenWidth.Location.Y + tb_screenWidth.Height / 2 - l_screenX.Height / 2);
                Controls.Add(l_screenX);

                type.Add(new List<Control> { tb_sizeW, tb_sizeH, tb_count });

            }
        }

        public void A3Format()
        {
            Bitmap mountingDiagrame = new Bitmap(1587, 1123);
            drawBoardsOfPage(mountingDiagrame); //Рисует границы листа 
            drawTitleBlock(mountingDiagrame); //Рисует основную надпись
            writeTextInTitleBlock(mountingDiagrame); //Текст оформления
            writeDate(mountingDiagrame); //Дата в колонке "Дата"
            drawArrowsAndNumbersOfAssemb(mountingDiagrame, diagrame_bmp);
            drawNumbersAssemb(mountingDiagrame, diagrame_bmp);
            InputDiagrame(mountingDiagrame, diagrame_bmp);
            drawTableWithInfoOfCabinet(mountingDiagrame);
            mountingDiagrame.Save("C:\\Users\\user\\Desktop\\1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        private void drawTableWithInfoOfCabinet(Bitmap bmp)
        {
            drawLineGoriz(bmp, 60, 200, 0, 0.5, "left");
            drawLineGoriz(bmp, 45, 200, 0, 0.5, "left");
            drawLineGoriz(bmp, 30, 200, 0, 0.5, "left");
            drawLineVert(bmp, 15, 30, 30, 0.5, "left");
            drawLineVert(bmp, 75, 30, 30, 0.5, "left");
            drawLineVert(bmp, 150, 30, 30, 0.5, "left");
            drawLineVert(bmp, 165, 30, 30, 0.5, "left");
            drawLineVert(bmp, 200, 30, 30, 0.5, "left");
            writeText(bmp, 12, 0, 60, 15, 15, "left", "Поз.");
            writeText(bmp, 12, 15, 60, 60, 15, "left", "Обозначение");
            writeText(bmp, 12, 75, 60, 75, 15, "left", "Наименование");
            writeText(bmp, 12, 150, 60, 15, 15, "left", "Кол.");
            writeText(bmp, 12, 165, 60, 35, 15, "left", "Примечание");
            writeText(bmp, 12, 0, 45, 15, 15, "left", "1");
            insertTypeCabinetImg(bmp);
            writeText(bmp, 12, 75, 45, 75, 15, "left", $"Кабинет размером {info[6]}x{info[7]}");
            writeText(bmp, 12, 150, 45, 15, 15, "left", $"{Col * Rws}");

        }
        private void insertTypeCabinetImg(Bitmap a3)
        {
            Bitmap img = new Bitmap(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\type1.png");
            Bitmap imgScale = new Bitmap(img, new Size(ctToPx(13), ctToPx(13)));
            System.Drawing.Image imgInTable = (System.Drawing.Image)imgScale;
            Graphics gr = Graphics.FromImage(a3);
            gr.DrawImage(imgInTable, new Point(ctToPx(5) + ctToPx(0.5) + ctToPx(15) + ctToPx(60) / 2 - imgInTable.Width / 2, a3.Height - ctToPx(20) - ctToPx(0.5) - ctToPx(37) - imgInTable.Height / 2));
            gr.Dispose();
        }
        private void drawNumbersAssemb(Bitmap format, Bitmap diagrame)
        {
            int size = (int)Math.Ceiling(Convert.ToDouble(diagrame.Width) * 4 / (5 * Col));     // ПРИ СМЕНЕ ОТСТУПА МЕЖДУ КАБИНЕТАМИ МОГУТ ВОЗНИКНУТЬ ОШИБКИ В ПРОРИСОВКЕ ДИАГРАММЫ!!!
            
        }
        private void drawArrowsAndNumbersOfAssemb(Bitmap format, Bitmap diagrame)
        {
            int x0;
            int size = (int)Math.Ceiling(Convert.ToDouble(diagrame.Width) * 4 / (5 * Col));     // ПРИ СМЕНЕ ОТСТУПА МЕЖДУ КАБИНЕТАМИ МОГУТ ВОЗНИКНУТЬ ОШИБКИ В ПРОРИСОВКЕ ДИАГРАММЫ!!!
            System.Drawing.Image up;
            System.Drawing.Image down;
            System.Drawing.Image left;
            System.Drawing.Image right;
            up = System.Drawing.Image.FromFile(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\arrow_up" + size +"px.png");
            down = System.Drawing.Image.FromFile(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\arrow_down"+ size +"px.png");
            left = System.Drawing.Image.FromFile(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\arrow_left"+ size +"px.png");
            right = System.Drawing.Image.FromFile(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\arrow_right"+ size +"px.png");
            Graphics graphics = Graphics.FromImage(diagrame);
            if ((Col % 2 == 1) & (Col > 1)) 
            {
                x0 = Convert.ToInt32(Math.Ceiling((diagrame.Width - (double)size / 4) / 2 - (double)size / 2 - (double)size / 4));
            }
            else if ((Col % 2 == 0) & (Col > 1))
            {
                x0 = Convert.ToInt32(Math.Ceiling((diagrame.Width - (double)size / 4) / 2 - (double)size / 8));
            } else
            {
                x0 = 0;
            }
            if (Col > 1)
            {
                for (int y = diagrame.Height - size - size / 4, assemb = 1; y >= 0; y -= size + size / 4)     // ПРИ СМЕНЕ ОТСТУПА МЕЖДУ КАБИНЕТАМИ МОГУТ ВОЗНИКНУТЬ ОШИБКИ В ПРОРИСОВКЕ ДИАГРАММЫ!!!
                {
                    for (int x = x0, direction = size + size / 4; x < diagrame.Width - size / 4; x += size + size / 4 - 2 * direction, assemb += 2)
                    {

                        if ((x < (diagrame.Width - size / 4) / 2))
                        {
                            graphics.DrawImage(right, x, y);
                            drawNumbersAssemb(graphics, 14, x + size / 8 - 14, y + size / 4, 25, 18, Convert.ToString(assemb));
                        }
                        else
                        {
                            graphics.DrawImage(left, x, y);
                            drawNumbersAssemb(graphics, 14, x + size / 8 - 14, y + size / 4, 25, 18, Convert.ToString(assemb));
                        }


                        if ((x - size - size / 4) < 0)
                        {
                            x = x0;
                            assemb = Col * ((diagrame.Height - y) / (size + size / 4) - 1);
                            direction = 0;
                        }


                        if ((x + size / 4) / (size + size / 4) == Col / 2 + 1)
                        {
                            graphics.DrawImage(down, x - size, y - size / 4);
                            drawNumbersAssemb(graphics, 14, x - size / 2 + 7, y - size / 8 - 9, 25, 18, Convert.ToString(Col * (diagrame.Height - y) / (size + size / 4)));
                        }

                        if (Col == 2)
                        {
                            graphics.DrawImage(down, x + size / 4, y - size / 4);
                            drawNumbersAssemb(graphics, 14, x + size / 2 + 25, y - size / 8 - 9, 25, 18, Convert.ToString(Col * (diagrame.Height - y) / (size + size / 4)));
                        }

                    }

                    if (Col % 2 == 0)
                    {
                        assemb++;
                    }

                }
            }
            else if ((Col == 1) & (Rws != 1))
            {
                for (int y = diagrame.Height - size - size / 4, assemb = 1; y >= 0; y -= size + size / 4)     // ПРИ СМЕНЕ ОТСТУПА МЕЖДУ КАБИНЕТАМИ МОГУТ ВОЗНИКНУТЬ ОШИБКИ В ПРОРИСОВКЕ ДИАГРАММЫ!!!
                {
                    graphics.DrawImage(down, x0, y - size / 4);
                    drawNumbersAssemb(graphics, 14, x0 + size / 2 + 6, y - size / 8 - 5, 25, 18, Convert.ToString(assemb));
                    assemb++;
                }
            } else
            {
                int y = x0;
                graphics.DrawImage(left, x0 + size, y);
                drawNumbersAssemb(graphics, 14, x0 + size + 6, y + 20, 25, 18, "1");
            }
        }
        private int ctToPx(double mm)
        {
            // Перевод из милиметров в пиксели с dpi = 96
            mm = (int)Math.Round(mm * 96 / 25.4);
            return (int)mm;
        }
        private void drawBoardsOfPage(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    // 4 пикселя ~ 1 мм

                    //Рамка по краю листа
                    if (((i <= ctToPx(0.5) + ctToPx(5)) && (i > ctToPx(5)) && (j > ctToPx(0.5) + ctToPx(5)) && (j < bmp.Height - ctToPx(0.5) - ctToPx(20))) ||                                  // левое поле
                        ((i >= bmp.Width - ctToPx(0.5) - ctToPx(5)) && (i < bmp.Width - ctToPx(5)) && (j > ctToPx(0.5) + ctToPx(5)) && (j < bmp.Height - ctToPx(0.5) - ctToPx(20))) ||            // правое поле
                        ((j <= ctToPx(0.5) + ctToPx(5)) && (j > ctToPx(5)) && (i > ctToPx(0.5) + ctToPx(5) - ctToPx(0.5)) && (i < bmp.Width - ctToPx(0.5) - ctToPx(5) + ctToPx(0.5))) ||                            // верхнее поле
                        ((j >= bmp.Height - ctToPx(0.5) - ctToPx(20)) && (j < bmp.Height - ctToPx(20)) && (i > ctToPx(0.5) + ctToPx(5) - ctToPx(0.5)) && (i < bmp.Width - ctToPx(0.5) - ctToPx(5) + ctToPx(0.5))))    // нижнее поле
                    {
                        bmp.SetPixel(i, j, Color.Black);
                        // Рамка основной надписи
                    }
                    else
                    {
                        bmp.SetPixel(i, j, Color.White);
                    }
                }
            }
        }
        private void writeTextInTitleBlock(Bitmap bmp)
        {
            writeText(bmp, 12, 185, 35, 7, 5, "right", "Изм");
            writeText(bmp, 11, 178, 35, 10, 5, "right", "Кол.уч");
            writeText(bmp, 12, 169, 35, 12, 5, "right", "Лист");
            writeText(bmp, 12, 156, 35, 11, 5, "right", "№ док.");
            writeText(bmp, 12, 145, 35, 15, 5, "right", "Подп.");
            writeText(bmp, 12, 131, 35, 10, 5, "right", "Дата");
            writeText(bmp, 12, 131, 35, 10, 5, "right", "Дата");
            writeText(bmp, 11, 186, 30, 18, 5, "right", "Разработал");
            writeText(bmp, 12, 169, 30, 23, 5, "right", info[0]);
            writeText(bmp, 11, 186, 25, 18, 5, "right", "Проверил");
            writeText(bmp, 12, 169, 25, 23, 5, "right", info[1]);
            writeText(bmp, 11, 186, 10, 18, 5, "right", "Н.контроль");
            writeText(bmp, 12, 169, 10, 23, 5, "right", info[2]);
            writeText(bmp, 20, 120, 15, 70, 15, "right", "Схема монтажа кабинетов в экран (вид сзади)");
            writeText(bmp, 20, 120, 55, 120, 10, "right", info[3]);
            writeText(bmp, 20, 120, 45, 120, 15, "right", info[4]);
            writeText(bmp, 12, 50, 30, 15, 5, "right", "Стадия");
            writeText(bmp, 12, 50, 25, 15, 10, "right", "Р");
            writeText(bmp, 12, 36, 30, 17, 5, "right", "Лист");
            writeText(bmp, 12, 36, 25, 17, 10, "right", "1");
            writeText(bmp, 12, 19, 30, 18, 5, "right", "Листов");
            writeText(bmp, 12, 19, 25, 18, 10, "right", "1");
            writeText(bmp, 20, 50, 15, 50, 15, "right", "ООО 'ЗСП'");
            writeText(bmp, 12, 50, 0, 32, 5, "right", "Формат");
            writeText(bmp, 12, 18, 0, 18, 5, "right", "А3");
            writeText(bmp, 20, 120, 30, 70, 15, "right", $"Светодиодный экран\nP{info[5]}, (ШxВ) {Convert.ToInt32(info[6]) * Col}x{Convert.ToInt32(info[7]) * Rws}");
        }
        private void writeDate(Bitmap bmp)
        {
            DateTime thisDay = DateTime.Today;
            writeText(bmp, 12, 131, 30, 10, 5, "right", thisDay.ToString("MM") + "." + thisDay.ToString("yy"));
            writeText(bmp, 12, 131, 25, 10, 5, "right", thisDay.ToString("MM") + "." + thisDay.ToString("yy"));
            writeText(bmp, 12, 131, 10, 10, 5, "right", thisDay.ToString("MM") + "." + thisDay.ToString("yy"));
        }
        private void drawLineGoriz (Bitmap bmp, int height, int length, int x0, double widthPen, string mode)
        {
            int y = bmp.Height - ctToPx(20) - ctToPx(0.5) - ctToPx(height);
            if (mode == "right")
            {
                if (x0 > 0)
                {
                    for (int i = 0; i < ctToPx(widthPen); i++)
                    {
                        for (int x = bmp.Width - ctToPx(5) - ctToPx(0.5) - ctToPx(x0); x > bmp.Width - ctToPx(length) - ctToPx(5) - ctToPx(0.5) - ctToPx(x0) + 1; x--)
                        {
                            bmp.SetPixel(x, y + i, Color.Black);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ctToPx(widthPen); i++)
                    {
                        for (int x = bmp.Width - ctToPx(5) - ctToPx(0.5); x > bmp.Width - ctToPx(length) - ctToPx(5) - ctToPx(0.5); x--)
                        {
                            bmp.SetPixel(x, y + i, Color.Black);
                        }
                    }
                }
            }
            else
            {
                if (x0 > 0)
                {
                    for (int i = 0; i < ctToPx(widthPen); i++)
                    {
                        for (int x = ctToPx(5) + ctToPx(0.5) + ctToPx(x0); x < ctToPx(length) + ctToPx(5) + ctToPx(0.5) + ctToPx(x0) + 1; x++)
                        {
                            bmp.SetPixel(x, y + i, Color.Black);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ctToPx(widthPen); i++)
                    {
                        for (int x = ctToPx(5) + ctToPx(0.5); x < ctToPx(length) + ctToPx(5) + ctToPx(0.5); x++)
                        {
                            bmp.SetPixel(x, y + i, Color.Black);
                        }
                    }
                }
            }
        }
        private void drawLineVert (Bitmap bmp, int width, int length, int y0, double widthPen, string mode)
        {
            if (mode == "right")
            {
                int x = bmp.Width - ctToPx(5) - ctToPx(0.5) - ctToPx(width);
                if (y0 > 0)
                {
                    for (int i = 0; i < ctToPx(widthPen); i++)
                    {
                        for (int y = bmp.Height - ctToPx(20) - ctToPx(0.5) - ctToPx(y0); y > bmp.Height - ctToPx(length) - ctToPx(20) - ctToPx(0.5) - ctToPx(y0) - 1; y--)
                        {
                            bmp.SetPixel(x + i, y, Color.Black);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ctToPx(widthPen); i++)
                    {
                        for (int y = bmp.Height - ctToPx(20) - ctToPx(0.5); y > bmp.Height - ctToPx(length) - ctToPx(20) - ctToPx(0.5) - 1; y--)
                        {
                            bmp.SetPixel(x + i, y, Color.Black);
                        }
                    }
                }
            } else
            {
                int x = ctToPx(5) + ctToPx(0.5) + ctToPx(width);
                if (y0 > 0)
                {
                    for (int i = 0; i < ctToPx(widthPen); i++)
                    {
                        for (int y = bmp.Height - ctToPx(20) - ctToPx(0.5) - ctToPx(y0); y > bmp.Height - ctToPx(length) - ctToPx(20) - ctToPx(0.5) - ctToPx(y0) - 2; y--)
                        {
                            bmp.SetPixel(x + i, y, Color.Black);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ctToPx(widthPen); i++)
                    {
                        for (int y = bmp.Height - ctToPx(20) - ctToPx(0.5); y > bmp.Height - ctToPx(length) - ctToPx(20) - ctToPx(0.5) - 2; y--)
                        {
                            bmp.SetPixel(x + i, y, Color.Black);
                        }
                    }
                }
            }
        }
        private void drawTitleBlock(Bitmap bmp)
        {
            drawLineGoriz(bmp, 55, 185, 0, 0.5, "right");
            drawLineGoriz(bmp, 45, 120, 0, 0.5, "right");
            drawLineGoriz(bmp, 30, 185, 0, 0.5, "right");
            drawLineGoriz(bmp, 25, 50, 0, 0.5, "right");
            drawLineGoriz(bmp, 15, 120, 0, 0.5, "right");
            for (int i = 0; i < 3; i++)
            {
                drawLineGoriz(bmp, 50 - 5 * i, 65, 120, 0.25, "right");
            }
            for (int i = 0; i < 5; i++)
            {
                drawLineGoriz(bmp, 25 - 5 * i, 65, 120, 0.25, "right");
            }
            drawLineGoriz(bmp, 35, 65, 120, 0.5, "right");
            drawLineVert(bmp, 185, 55, 0, 0.5, "right");
            drawLineVert(bmp, 177, 25, 30, 0.5, "right");
            drawLineVert(bmp, 168, 55, 0, 0.5, "right");
            drawLineVert(bmp, 156, 25, 30, 0.5, "right");
            drawLineVert(bmp, 145, 55, 0, 0.5, "right");
            drawLineVert(bmp, 130, 55, 0, 0.5, "right");
            drawLineVert(bmp, 120, 55, 0, 0.5, "right");
            drawLineVert(bmp, 50, 30, 0, 0.5, "right");
            drawLineVert(bmp, 35, 15, 15, 0.5, "right");
            drawLineVert(bmp, 20, 15, 15, 0.5, "right");
        }
        private void writeText(Bitmap bmp, int FontHeight, int x0, int y0, int width, int height, string mode, string text)
        {
            if (mode == "right")
            {
                x0 = bmp.Width - ctToPx(5) - ctToPx(x0) + 1;
                y0 = bmp.Height - ctToPx(20) - ctToPx(y0);
                height = ctToPx(height) + ctToPx(0.5);
                width = ctToPx(width) + ctToPx(0.5);
                // Create a rectangle for the entire bitmap
                RectangleF rectf = new RectangleF(x0, y0, width, height);
                // Create graphic object that will draw onto the bitmap
                Graphics g = Graphics.FromImage(bmp);
                // ------------------------------------------
                // Ensure the best possible quality rendering
                // ------------------------------------------
                // The smoothing mode specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing). 
                // One exception is that path gradient brushes do not obey the smoothing mode. 
                // Areas filled using a PathGradientBrush are rendered the same way (aliased) regardless of the SmoothingMode property.
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // The interpolation mode determines how intermediate values between two endpoints are calculated.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                // This one is important
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                // Create string formatting options (used for alignment)
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // Draw the text onto the image
                g.DrawString(text, new Font("GOST Type A", FontHeight), Brushes.Black, rectf, format);

                // Flush all graphics changes to the bitmap
                g.Flush();
            } else
            {
                x0 = ctToPx(5) + ctToPx(x0) + 1;
                y0 = bmp.Height - ctToPx(20) - ctToPx(y0);
                height = ctToPx(height) + ctToPx(0.5);
                width = ctToPx(width) + ctToPx(0.5);
                // Create a rectangle for the entire bitmap
                RectangleF rectf = new RectangleF(x0, y0, width, height);
                // Create graphic object that will draw onto the bitmap
                Graphics g = Graphics.FromImage(bmp);
                // ------------------------------------------
                // Ensure the best possible quality rendering
                // ------------------------------------------
                // The smoothing mode specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing). 
                // One exception is that path gradient brushes do not obey the smoothing mode. 
                // Areas filled using a PathGradientBrush are rendered the same way (aliased) regardless of the SmoothingMode property.
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // The interpolation mode determines how intermediate values between two endpoints are calculated.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                // This one is important
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                // Create string formatting options (used for alignment)
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // Draw the text onto the image
                g.DrawString(text, new Font("GOST Type A", FontHeight), Brushes.Black, rectf, format);

                // Flush all graphics changes to the bitmap
                g.Flush();
            }
        }
        private void drawNumbersAssemb(Graphics g, int FontHeight, int x0, int y0, int width, int height, string text)
        {
            RectangleF rectf = new RectangleF(x0, y0, width, height);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            StringFormat strFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(text, new Font("GOST Type A", FontHeight), Brushes.Black, rectf, strFormat);

            g.Flush();
        }
        private void InputDiagrame(Bitmap format, Bitmap diagrame)
        {
            if(diagrame != null)
            {
                if (diagrame.Width > 1400 & diagrame.Height > 800)
                {
                    Bitmap diagrameResize = new Bitmap(diagrame, new Size(1400, 800));
                    System.Drawing.Image dgr = (System.Drawing.Image)diagrameResize;
                    Graphics g = Graphics.FromImage(format);
                    g.DrawImage(dgr, new Point((format.Width - 15) / 2 - dgr.Width / 2, (format.Height - 180) / 2 - dgr.Height / 2 - 50));
                    g.Dispose();
                } else if (diagrame.Width > 1400)
                {
                    Bitmap diagrameResize = new Bitmap(diagrame, new Size(1400, diagrame.Height));
                    System.Drawing.Image dgr = (System.Drawing.Image)diagrameResize;
                    Graphics g = Graphics.FromImage(format);
                    g.DrawImage(dgr, new Point((format.Width - 15) / 2 - dgr.Width / 2, (format.Height - 180) / 2 - dgr.Height / 2 - 50));
                    g.Dispose();
                } else if (diagrame.Height > 800)
                {
                    Bitmap diagrameResize = new Bitmap(diagrame, new Size(diagrame.Width, 800));
                    System.Drawing.Image dgr = (System.Drawing.Image)diagrameResize;
                    Graphics g = Graphics.FromImage(format);
                    g.DrawImage(dgr, new Point((format.Width - 15) / 2 - dgr.Width / 2, (format.Height - 180) / 2 - dgr.Height / 2 - 50));
                    g.Dispose();
                } else
                {
                    System.Drawing.Image dgr = (System.Drawing.Image)diagrame;
                    Graphics g = Graphics.FromImage(format);
                    g.DrawImage(dgr, new Point((format.Width - 15) / 2 - dgr.Width / 2, (format.Height - 180) / 2 - dgr.Height / 2 - 50));
                    g.Dispose();
                }
            }
        }
        private void data_Form()
        {
            this.Width = 380;
            this.Height = 450;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private List<Cabinets> cabinetCalculator(int W, int H)
        {
            int modulesW = W / 320;
            int modulesH = H / 160;
            List<Cabinets> cabinets = new List<Cabinets>();
            if ((modulesW >= 3) & (modulesW % 3 == 0))
            {
                cabinets.Add(new Cabinets { Value = modulesW / 3, Resolution = "960", Side = "width" });
            }
            else if ((modulesW >= 3) & (modulesW % 3 == 1))
            {
                cabinets.Add(new Cabinets { Value = (modulesW - 4) / 3, Resolution = "960", Side = "width" });
                cabinets.Add(new Cabinets { Value = 1, Resolution = "1280", Side = "width" });
            }
            else if ((modulesW >= 3) & (modulesW % 3 == 2))
            {
                cabinets.Add(new Cabinets { Value = (modulesW - 2) / 3, Resolution = "960", Side = "width" });
                cabinets.Add(new Cabinets { Value = 1, Resolution = "640", Side = "width" });
            }
            //////////////////////////////////
            if ((modulesH >= 6) & (modulesH % 6 == 0))
            {
                cabinets.Add(new Cabinets { Value = modulesH / 6, Resolution = "960", Side = "height" });
            }
            else if ((modulesH >= 6) & (modulesH % 6 == 1) & (modulesH % 5 != 0))
            {
                cabinets.Add(new Cabinets { Value = (modulesH - 7) / 6, Resolution = "960", Side = "height" });
                cabinets.Add(new Cabinets { Value = 1, Resolution = "1120", Side = "height" });
            }
            else if ((modulesH >= 6) & (modulesH % 6 == 2) & (modulesH % 5 != 0))
            {
                cabinets.Add(new Cabinets { Value = (modulesH - 8) / 6, Resolution = "960", Side = "height" });
                cabinets.Add(new Cabinets { Value = 1, Resolution = "1280", Side = "height" });
            }
            else if ((modulesH >= 6) & (modulesH % 6 == 4) & (modulesH % 5 != 0))
            {
                cabinets.Add(new Cabinets { Value = (modulesH - 4) / 6, Resolution = "960", Side = "height" });
                cabinets.Add(new Cabinets { Value = 1, Resolution = "640", Side = "height" });
            }
            else if ((modulesH >= 6) & (modulesH % 6 == 5) & (modulesH % 5 != 0))
            {
                cabinets.Add(new Cabinets { Value = (modulesH - 5) / 6, Resolution = "960", Side = "height" });
                cabinets.Add(new Cabinets { Value = 1, Resolution = "800", Side = "height" });
            }
            else if ((modulesH >= 6) & (modulesH % 2 == 0) & (modulesH % 6 == 3) & (modulesH % 5 != 0))
            {
                cabinets.Add(new Cabinets { Value = (modulesH - 15) / 6, Resolution = "960", Side = "height" });
                cabinets.Add(new Cabinets { Value = 3, Resolution = "800", Side = "height" });
            }
            else if ((modulesH >= 6) & (modulesH % 2 == 1) & (modulesH % 6 == 3) & (modulesH % 5 != 0))
            {
                cabinets.Add(new Cabinets { Value = (modulesH - 21) / 6, Resolution = "960", Side = "height" });
                cabinets.Add(new Cabinets { Value = 3, Resolution = "1120", Side = "height" });
            } 
            
            if (modulesW == 2)
            {
                cabinets.Add(new Cabinets { Value = 1, Resolution = "640", Side = "width" });
            }
            else
            {
                new Exception("Ширина кабинета слишком мала");
            }

            if (modulesH == 4)
            {
                cabinets.Add(new Cabinets { Value = 1, Resolution = "640", Side = "height" });
            } else if (modulesW == 5)
            {
                cabinets.Add(new Cabinets { Value = 1, Resolution = "800", Side = "height" });
            } else
            {
                new Exception("Высота кабинета слишком мала");
            }

            if((modulesH >= 6) & (modulesH % 5 == 0))
            {
                cabinets.Add(new Cabinets { Value = modulesH * 160 / 800, Resolution = "800", Side = "height" });
            }

                return cabinets;
        }
        private void fillInfoCabinets(List<Cabinets> info)
        {
            List<string> moduleH = new List<string>();
            List<string> moduleW = new List<string>();
            int N = 0;
            foreach (var i in info)
            {
                if((i.Side == "width"))
                {
                    moduleW.Add(i.Resolution);
                } 
                else if (i.Side == "height")
                {
                    moduleH.Add(i.Resolution);
                }
            }

            N = moduleW.Count * moduleH.Count;
            int k = 0;

            for (int i = 0; i < N - 1; i++)
            {
                operationOfInformationRows("add");
            }

            foreach (string w in  moduleW)
            {
                foreach (string h in moduleH)
                {
                    Controls.Find($"tb_sizeW{k}", true).FirstOrDefault().Text = w;
                    Controls.Find($"tb_sizeH{k}", true).FirstOrDefault().Text = h;
                    Controls.Find($"tb_count{k}", true).FirstOrDefault().Text = Convert.ToString(info.Find(v => v.Resolution == w & v.Side == "width").Value * info.Find(v => v.Resolution == h & v.Side == "height").Value);
                    k++;
                }
            }
        }

        private void login_Form()
        {
            this.Width = 420;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
    }
}
