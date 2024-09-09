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
    public partial class Form2 : Form
    {
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

        private void b_add_Click(object sender, EventArgs e)
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
                l_No_c.Location = new Point(105, 100 + 40 * (count - 1));
                Console.WriteLine(Controls.IndexOf(l_No_c));
                Controls.Add(l_No_c);
                //
                // textbox - tb_sizeW_c
                //
                TextBox tb_sizeW_c = new TextBox();
                tb_sizeW_c.Size = new Size(40, 30);
                tb_sizeW_c.Name = $"tb_sizeW{count}";
                tb_sizeW_c.Location = new Point(l_No_c.Location.X + l_No_c.Width + 40, l_No_c.Location.Y);
                tb_sizeW_c.TextAlign = HorizontalAlignment.Center;
                Console.WriteLine(Controls.IndexOf(tb_sizeW_c));
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
                Console.WriteLine(Controls.IndexOf(tb_count_c));
                Controls.Add(tb_count_c);
                count++;
                type.Add(new List<Control> { tb_sizeW_c, tb_sizeH_c, tb_count_c });
            }
        }

        private void b_rmv_Click(object sender, EventArgs e)
        {
            if (count > 1)
            {
                var l_No = Controls.Find("l_No" + Convert.ToString(count), true).FirstOrDefault() as Label;
                var l_x = Controls.Find("l_x" + Convert.ToString(count), true).FirstOrDefault() as Label;
                var tb_sizeW = Controls.Find("tb_sizeW" + Convert.ToString(count), true).FirstOrDefault() as TextBox;
                var tb_sizeH = Controls.Find("tb_sizeH" + Convert.ToString(count), true).FirstOrDefault() as TextBox;
                var tb_count = Controls.Find("tb_count" + Convert.ToString(count), true).FirstOrDefault() as TextBox;
                Controls.Remove(l_No);
                Controls.Remove(l_x);
                Controls.Remove(tb_sizeW);
                Controls.Remove(tb_sizeH);
                Controls.Remove(tb_count);
                count--;
            }
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
                //
                //button - b_sendData
                //
                Button b_sendData = new Button();
                b_sendData.Text = "Save";
                b_sendData.Size = new Size(60, 30);
                b_sendData.Location = new Point(20, 283 - b_sendData.Height - 20);
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
                l_No.Location = new Point(b_rmv.Location.X + b_rmv.Width + 20, b_rmv.Location.Y + b_rmv.Height + 10);
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
                l_sizeW.Location = new Point(tb_sizeW.Location.X + tb_sizeW.Width/2 - l_sizeW.Width/2, b_rmv.Location.Y + b_rmv.Height/2 - l_sizeW.Height/2);
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

                type.Add(new List<Control> { tb_sizeW, tb_sizeH, tb_count });

            }
        }

        private void data_Form()
        {
            this.Width = 380;
            this.Height = 320;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
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
