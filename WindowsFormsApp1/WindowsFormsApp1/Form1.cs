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
        private int count = 1;
        private string key = "";
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

        private void work_Form()
        {
            this.Width = 1200;
            this.Height = 600;
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
            dataIN.Size = new Size(100, 30);
            dataIN.Text = "Enter data";
            dataIN.Click += dataIN_Click;
            dataIN.Location = new Point(this.Width/2 - dataIN.Width/2, this.Height/2 - dataIN.Height/2);
            dataIN.Anchor = AnchorStyles.None;
            Controls.Add(dataIN);



            if (keyAc == "param")
            {
                for (int i = 0; i < count; i++)
                {
                    //
                    //label - null
                    //
                    Label l_null = new Label();
                    l_null.Text = "";
                    l_null.Size = new Size(10, 40);
                    l_null.Location = new Point(20, 600 - 40 - l_null.Height - 30 * i);
                    Controls.Add(l_null);
                    //
                    //label - number
                    //
                    Label l_number = new Label();
                    l_number.Text = "Type " + Convert.ToString(i + 1);
                    l_number.Size = new Size(60, 20);
                    l_number.Location = new Point(20, 600 - 40 - l_null.Height - l_number.Height - 30 * i);
                    Controls.Add(l_number);
                    //
                    //picturebox
                    //
                    PictureBox pb_type = new PictureBox();
                    pb_type.Size = new Size(30, 30);
                    pb_type.Location = new Point(l_number.Location.X + l_number.Width + 20, l_number.Location.Y - 3);
                    Pen blackPen = new Pen(Color.Black, 2);
                    pb_type.Image = new Bitmap(@"D:\Projects\C# learning\Console\LEDsi_projects\WindowsFormsApp1\WindowsFormsApp1\Pictures\type1.png");
                    Controls.Add(pb_type);
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
            error.Location = new Point(this.Width/2 - error.Width/2, 400);
            error.ForeColor = Color.Red;
            error.Font = new Font(FontFamily.GenericSansSerif, 16F, FontStyle.Bold);
            error.Text = "Error. User not found. Please try to login in again.";
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
            reg.Location = new Point(button1.Location.X + button1.Width/2 - reg.Width/2, button1.Location.Y + button1.Height + 10);
            reg.ForeColor = Color.Blue;
            reg.Click += reg_Click;
        }

        private void reg_Click(object sender, EventArgs e)
        {
            new Form2(textBox1.Text, textBox2.Text, "reg").ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = "KoouZz",
                password = "123321";
            if ((this.textBox1.Text == login) && (this.textBox2.Text == password))
            {
                work_Form();
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
            work_Form();
            keyAc = "param";

        }
    }
}
