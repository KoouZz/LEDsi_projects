using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int number = 1;
        private string key = "";
        private int height;
        private int width;
        private int count;
        private string clearKey = "clear";
        private List<List<Control>> ctrls;
        private Bitmap bm;
        private int col;
        private int rws;
        public int Columns
        {
            set { col = value; }
            get { return col; }
        }
        public int Rows
        {
            get { return rws; }
            set { rws = value; }
        }
        public Bitmap BM
        {
            set { bm = value; }
            get { return bm; }
        }
        public int countAc
        {
            get { return count; }
            set { count = value; }
        }
        public int widthtAc
        {
            get { return width; }
            set { width = value; }
        }
        public int heightAc
        {
            get { return height; }
            set { height = value; }
        }
        public string keyAc
        {
            get { return key; }
            set { key = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Form1_InitComp();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login_Form();
            textBox1.Text = "KoouZz";
            textBox2.Text = "123321";
        }

        private void login_Form()
        {
            Width = 800;
            Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void work_Form(string keyAc)
        {
            this.Width = 1200;
            this.Height = 600;
            this.MinimumSize = new Size(950, 240);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(10, 10);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.BackColor = System.Drawing.Color.White;
            Controls.Cast<Control>().ToList().ForEach(i => i.Visible = false);

            //
            // button - dataIN
            //
            Button dataIN = new Button();
            dataIN.Size = new Size(100, 60);
            dataIN.Text = "Enter data";
            dataIN.Click += dataIN_Click;
            dataIN.Location = new Point(1200 - dataIN.Width - 30, 600 - dataIN.Height - 50);
            dataIN.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
            Controls.Add(dataIN);

            if (keyAc == "param")
            {
                for (int i = 0; i < count; i++)
                {
                    //
                    //label - number
                    //
                    Label l_number = new Label();
                    l_number.Text = "Type " + Convert.ToString(i + 1);
                    l_number.Size = new Size(60, 20);
                    l_number.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                    l_number.Location = new Point(20, 600 - 60 - l_number.Height - 50 * i);
                    Controls.Add(l_number);
                    if (i == 0)
                    {
                        //
                        //picturebox - 0
                        //
                        PictureBox pb_type = new PictureBox();
                        pb_type.Size = new Size(30, 30);
                        pb_type.Location = new Point(l_number.Location.X + l_number.Width + 20, l_number.Location.Y - 3);
                        pb_type.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                        Pen blackPen = new Pen(Color.Black, 2);
                        pb_type.Image = new Bitmap(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\type1.png");
                        Controls.Add(pb_type);
                    }
                    else if (i == 1)
                    {
                        //
                        //picturebox - 1
                        //
                        PictureBox pb_type = new PictureBox();
                        pb_type.Size = new Size(30, 30);
                        pb_type.Location = new Point(l_number.Location.X + l_number.Width + 20, l_number.Location.Y - 3);
                        pb_type.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                        Pen blackPen = new Pen(Color.Black, 2);
                        pb_type.Image = new Bitmap(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\type2.png");
                        Controls.Add(pb_type);
                    }
                    else if (i == 2)
                    {
                        //
                        //picturebox - 2
                        //
                        PictureBox pb_type = new PictureBox();
                        pb_type.Size = new Size(30, 30);
                        pb_type.Location = new Point(l_number.Location.X + l_number.Width + 20, l_number.Location.Y - 3);
                        pb_type.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                        Pen blackPen = new Pen(Color.Black, 2);
                        pb_type.Image = new Bitmap(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\type3.png");
                        Controls.Add(pb_type);
                    }
                    else if (i == 3)
                    {
                        //
                        //picturebox - 3
                        //
                        PictureBox pb_type = new PictureBox();
                        pb_type.Size = new Size(30, 30);
                        pb_type.Location = new Point(l_number.Location.X + l_number.Width + 20, l_number.Location.Y - 3);
                        pb_type.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
                        Pen blackPen = new Pen(Color.Black, 2);
                        pb_type.Image = new Bitmap(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\type4.png");
                        Controls.Add(pb_type);
                    }
                    else
                    {
                        //
                        //picturebox - 4
                        //
                        PictureBox pb_type = new PictureBox();
                        pb_type.Size = new Size(30, 30);
                        pb_type.Location = new Point(l_number.Location.X + l_number.Width + 20, l_number.Location.Y - 3);
                        pb_type.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                        Pen blackPen = new Pen(Color.Black, 2);
                        pb_type.Image = new Bitmap(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\type5.png");
                        Controls.Add(pb_type);
                    }
                    //
                    //label - width
                    //
                    Label l_width = new Label();
                    l_width.Name = $"l_width{i}";
                    l_width.Text = ctrls[i].Find(x => x.Name == "tb_sizeW" + Convert.ToString(i)).Text;
                    l_width.TextAlign = ContentAlignment.TopCenter;
                    l_width.Size = new Size(40, 20);
                    l_width.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                    l_width.Location = new Point(140, l_number.Location.Y);
                    Controls.Add(l_width);
                    //
                    //label - x
                    //
                    Label l_xx = new Label();
                    l_xx.Text = "x";
                    l_xx.Size = new Size(13, 20);
                    l_xx.Location = new Point(l_width.Location.X + l_width.Width + 5, l_width.Location.Y);
                    l_xx.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                    Controls.Add(l_xx);
                    //
                    //label - height
                    //
                    Label l_height = new Label();
                    l_height.Name = $"l_height{i}";
                    l_height.Text = ctrls[i].Find(x => x.Name == "tb_sizeH" + Convert.ToString(i)).Text;
                    l_height.TextAlign = ContentAlignment.TopCenter;
                    l_height.Size = new Size(40, 20);
                    l_height.Location = new Point(l_xx.Location.X + l_xx.Width + 5, l_xx.Location.Y);
                    l_height.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                    Controls.Add(l_height);
                    //
                    //label - count
                    //
                    Label l_count = new Label();
                    l_count.Name = $"l_count{i}";
                    l_count.Text = ctrls[i].Find(x => x.Name == "tb_count" + Convert.ToString(i)).Text;
                    l_count.TextAlign = ContentAlignment.TopCenter;
                    l_count.Size = new Size(60, 20);
                    l_count.Location = new Point(l_height.Location.X + l_height.Width + 20, l_height.Location.Y);
                    l_count.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                    Controls.Add(l_count);
                    //
                    //textbox - column
                    //
                    TextBox tb_column = new TextBox();
                    tb_column.Name = $"tb_column{i}";
                    tb_column.Size = new Size(40, 20);
                    tb_column.Location = new Point(l_count.Location.X + 15 + l_count.Width, l_count.Location.Y - 2);
                    tb_column.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                    Controls.Add(tb_column);
                    //
                    //textbox - row
                    //
                    TextBox tb_rows = new TextBox();
                    tb_rows.Name = $"tb_rows{i}";
                    tb_rows.Size = new Size(40, 20);
                    tb_rows.Location = new Point(tb_column.Location.X + 5 + tb_column.Width, tb_column.Location.Y);
                    tb_rows.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
                    Controls.Add(tb_rows);
                }
                //
                // btn - to draw source-diagrame
                //
                Button pictSource = new Button();
                pictSource.Size = new Size(150, 60);
                pictSource.Location = new Point(dataIN.Location.X - 20 - pictSource.Width, dataIN.Location.Y);
                pictSource.Text = "Draw diagrame by source";
                pictSource.Click += pictSource_Click;
                pictSource.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
                pictSource.Visible = true;
                Controls.Add(pictSource);
                //
                // btn - clear picturebox
                //
                Button clspict1 = new Button();
                clspict1.Size = new Size(150, 60);
                clspict1.Location = new Point(pictSource.Location.X - clspict1.Width - 20, pictSource.Location.Y);
                clspict1.Text = "Clear Mounting diagram";
                clspict1.Click += clspict1_Click; ;
                clspict1.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
                clspict1.Visible = true;
                Controls.Add(clspict1);
                //
                // btn - to draw mounting diagrame
                //
                Button pict1 = new Button();
                pict1.Size = new Size(100, 60);
                pict1.Location = new Point(dataIN.Location.X, dataIN.Location.Y - pict1.Height - 20);
                pict1.Text = "Mounting diagram";
                pict1.Click += pict1_Click;
                pict1.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
                pict1.Visible = true;
                Controls.Add(pict1);
            }
        }

        private void clspict1_Click(object sender, EventArgs e)
        {
            Control pb = Controls.Find("mnt diagrame", true).FirstOrDefault() as PictureBox;
            if (clearKey == "draw")
            {
                Controls.Remove(pb);
                clearKey = "clear";
            }
        }

        private void pictSource_Click(object sender, EventArgs e)
        {
            if (clearKey == "clear")
            {
                try
                {
                    Columns = Convert.ToInt32(Controls.Find($"tb_column0", true).FirstOrDefault().Text);
                    Rows = Convert.ToInt32(Controls.Find($"tb_rows0", true).FirstOrDefault().Text);
                    PictureBox pb_mountingDiagrame = new PictureBox();
                    Image img = (Image)chooseResolution(Columns, Rows);
                    if (img != null)
                    {
                        drawDiagrame(Convert.ToInt32(Columns), Convert.ToInt32(Rows), pb_mountingDiagrame, img);
                        clearKey = "draw";
                    }
                }
                catch
                {
                    MessageBox.Show("В колонках и строках допустимы только целые числа!");
                }
            }
        }

        private void errorUser()
        {
            this.Width = 800;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //
            //label - error
            //
            Label error = new Label();
            Controls.Add(error);
            error.Show();
            error.Width = 550;
            error.Height = 50;
            error.Location = new Point(this.Width / 2 - error.Width / 2, 400);
            error.ForeColor = Color.Red;
            error.Font = new Font(FontFamily.GenericSansSerif, 16F, FontStyle.Bold);
            error.Text = "Error. User not found. Please try to login in again.";
        }

        private void drawDiagrame(int c, int r, PictureBox pb, Image img)
        {
            pb.Name = "mnt diagrame";
            pb.BackColor = Color.Transparent;
            Controls.Add(pb);
            BM = new Bitmap((img.Width + img.Width / 4) * c, (img.Height + img.Height / 4) * r);
            Graphics gp = Graphics.FromImage(BM);
            pb.Size = new Size((img.Width + img.Width / 4) * c, (img.Height + img.Height / 4) * r);
            pb.Location = new Point(this.Width / 2 - pb.Width / 2, this.Height / 2 - pb.Height / 2);
            pb.Anchor = AnchorStyles.None;
            for (int x = 0; x < BM.Width; x += img.Width + img.Width / 4)
            {
                for (int y = 0; y < BM.Height; y += img.Height + img.Height / 4)
                {
                    gp.DrawImage(img, new Point(x, y));
                }
            }
            gp.Dispose();
            pb.Image = BM;
            pb.Invalidate();
        }

        private void Form1_InitComp()
        {
            //
            // label - reg
            //
            Label reg = new Label();
            Controls.Add(reg);
            reg.Text = "Sign in";
            reg.Width = 60;
            reg.Height = 30;
            reg.Location = new Point(button1.Location.X + button1.Width / 2 - reg.Width / 2, button1.Location.Y + button1.Height + 10);
            reg.ForeColor = Color.Blue;
            reg.Click += reg_Click;
        }

        private void reg_Click(object sender, EventArgs e)
        {
            new Form2(textBox1.Text, textBox2.Text, "reg").ShowDialog();
        }
        private void pict1_Click(object sender, EventArgs e)
        {
            Form2 mntdgr = new Form2("KoouZz", "123321", "Mounting");
            mntdgr.Col = Columns;
            mntdgr.Rws = Rows;
            mntdgr.Diagrame = BM;
            mntdgr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = "KoouZz",
                password = "123321";
            if ((this.textBox1.Text == login) && (this.textBox2.Text == password))
            {
                work_Form(null);
            }
            else
            {
                errorUser();
            }
        }

        private void dataIN_Click(object sender, EventArgs e)
        {
            Form2 dataForm = new Form2("KoouZz", "123321", "dataIN");
            dataForm.ShowDialog();
            count = dataForm.Cnt;
            ctrls = new List<List<Control>>(dataForm.Type);
            work_Form("param");
        }
        private object chooseResolution(int c, int r)
        {
            if ((c <= 13) && (r <= 7))
            {
                Image img = Image.FromFile(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\1_diagrame100px.png");
                return img;
            }
            else if ((c <= 30) && (r <= 15))
            {
                Image img = Image.FromFile(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\1_diagrame45px.png");
                return img;
            }
            else if ((c < 45) && (r < 22))
            {
                Image img = Image.FromFile(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\1_diagrame30px.png");
                return img;
            }
            else if ((c <= 90) && (r <= 45))
            {
                Image img = Image.FromFile(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\1_diagrame15px.png");
                return img;
            }
            else
            {
                MessageBox.Show("Размер экрана превышает допустимые значения");
                return null;
            }
        }
    }
}
