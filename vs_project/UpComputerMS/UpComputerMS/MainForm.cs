using System;
using System.Windows.Forms;
using PmacControl;
using MyCalibration;
namespace UpComputerMS
{
    /// <summary>
    /// 主窗口类
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 主窗口各种子窗口、静态变量，从而提供接口，让其他Form能够共享该变量
        /// </summary>
        public static Pmac myPmac;
        public static Calibration myCalib;
        public static PMacControlFrom frm1;
        public static DetectForm frm2;
        public static CalibrationForm frm3;
        public static DB_Login frm4;
        public MainForm()
        {
            InitializeComponent();
            // 定义各种子窗口
            frm1 = new PMacControlFrom
            {
                TopLevel = false,
                Parent = this
            };
            frm1.Hide();
            frm2 = new DetectForm
            {
                Parent = this
            };
            frm2.Hide();
            frm3 = new CalibrationForm
            {
                Parent = this
            };
            frm3.Hide();
            frm4 = new DB_Login
            {
                Parent = this
            };
            frm4.Hide();
            myPmac = new Pmac();
            myCalib = new Calibration();
            timerCurrentDateTime.Start();
        }
        private void Show_PMACControl_Click(object sender, System.EventArgs e)
        {
            Main_Panel.Controls.Clear();
            frm1.Show();
            Main_Panel.Controls.Add(frm1);
        }

        private void Show_DC_Click(object sender, System.EventArgs e)
        {
            Main_Panel.Controls.Clear();
            frm2.Show();
            Main_Panel.Controls.Add(frm2);
        }

        private void Show_Calibration_Click(object sender, System.EventArgs e)
        {
            Main_Panel.Controls.Clear();
            frm3.Show();
            Main_Panel.Controls.Add(frm3);
        }

        private void TimerCurrentDateTime_Tick(object sender, System.EventArgs e)
        {
            dateCurrent.Text = DateTime.Now.ToString("d");
            timeCurrent.Text = DateTime.Now.ToString("t");
            timerCurrentDateTime.Interval = 1000;
            timerCurrentDateTime.Start();
        }

        private void Show_DB_Click(object sender, EventArgs e)
        {
            Main_Panel.Controls.Clear();
            frm4.Show();
            Main_Panel.Controls.Add(frm4);
        }
    }
}
