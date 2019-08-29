using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;


namespace tokend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(Form_MouseDown);
            pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(Form_MouseMove);
            pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(Form_MouseUp);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region 无边框窗体拖动
        //-------------------无边框窗体拖动---------------------------
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                (((System.Windows.Forms.PictureBox)sender).Parent).Location = mouseSet;
            }
        }
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        //------------------------end 无边框窗体拖动-----------------------------------
        #endregion

        private void Button1_Click_1(object sender, EventArgs e)
        {
            //退出程序
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //string str = System.AppDomain.CurrentDomain.FriendlyName;
            //MessageBox.Show(str);
            //System.Diagnostics.Process.Start(str);
            //上面的写法在Win7上面可能会有点问题，换一种思路试一试
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);            
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Red;
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.button1, "关闭程序");

        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.Red;
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.button2, "加一个新箭头");
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Lime;
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.Lime;
        }
    }
}
