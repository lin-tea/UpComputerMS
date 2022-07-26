using System;
using System.Windows.Forms;
using OpenCvSharp;

namespace UpComputerMS
{
    /// <summary>
    /// 标定类
    /// </summary>
    public partial class CalibrationForm : UserControl
    {
        public CalibrationForm()
        {
            InitializeComponent();
        }
        private void CalibrationForm_Load(object sender, EventArgs e)
        {
            //this.MaximizeBox = false;//使最大化窗口失效
            this.textBox_shuzhi.Text = MainForm.myCalib.Parameter_Process_Return()[1].ToString();
            this.textBox_shiping.Text = MainForm.myCalib.Parameter_Process_Return()[0].ToString();
            this.textBox_bianchang.Text = MainForm.myCalib.Parameter_Process_Return()[2].ToString();
            this.label_pic_biaoding.Text = MainForm.myCalib.Pic_Process_Return()[0].Substring(0, 6) + " ... " + MainForm.myCalib.Pic_Process_Return()[0].Substring(MainForm.myCalib.Pic_Process_Return()[0].Length - 10);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (true)
                {
                    OpenFileDialog ofd = new OpenFileDialog
                    {
                        Filter = "jpeg|*.jpg|png|*.png|bmp|*.bmp",
                        Multiselect = false
                    };
                    DialogResult result = ofd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string fName = ofd.FileName;
                        MainForm.myCalib.Pic_Process_Return().Clear();
                        MainForm.myCalib.Pic_Process_Return().Add(fName);
                        this.label_pic_biaoding.Text = MainForm.myCalib.Pic_Process_Return()[0].Substring(0, 6) + " ... " + MainForm.myCalib.Pic_Process_Return()[0].Substring(MainForm.myCalib.Pic_Process_Return()[0].Length - 10);
                        MessageBox.Show("图片选择成功！！");
                    }
                    else
                    {
                        Console.Error.WriteLine("取消图片选择");
                    }
                }
            }
            catch (Exception see)
            {
                Console.Error.WriteLine("Exception: {0}", see.Message);
                Console.WriteLine("图片选择异常！！！");
            }
        }

        private void Button_yunsuan_Click(object sender, EventArgs e)
        {
            //设置参数
            MainForm.myCalib.Parameter_Process_Set(new int[] { int.Parse(textBox_shuzhi.Text), int.Parse(textBox_shiping.Text), int.Parse(textBox_bianchang.Text) });
            try
            {
                MainForm.myCalib.Calibration_Main();//求解参数
            }
            catch
            {
                Console.WriteLine("求解参数异常");
            }


            if (MainForm.myCalib.Parameter_Mat_Return()[0] == null)
            {
                MessageBox.Show("标定参数异常");
            }
            else
            {        
                Display_Text(MainForm.myCalib.Parameter_Mat_Return()[0], MainForm.myCalib.Parameter_Mat_Return()[1], MainForm.myCalib.Parameter_Mat_Return()[2],
                    MainForm.myCalib.Parameter_Mat_Return()[3], MainForm.myCalib.Parameter_Mat_Return()[4]);
                MainForm.frm2.Set_Paramete(MainForm.myCalib.Parameter_Mat_Return()[0], MainForm.myCalib.Parameter_Mat_Return()[1],
                    MainForm.myCalib.Parameter_Mat_Return()[2], MainForm.myCalib.Parameter_Mat_Return()[3], MainForm.myCalib.Parameter_Mat_Return()[4]);
                MessageBox.Show("已求出相机参数");
            }
        }
        void Display_Text(Mat newCameraMatrix, Mat cameraMatrix, Mat distCoeffs, Mat rvecs, Mat tvecs)
        {
            Mat m1 = new Mat(), m2 = new Mat(), m3 = new Mat(), m4 = new Mat(), m5 = new Mat();
            newCameraMatrix.ConvertTo(m1, MatType.CV_32SC1);
            cameraMatrix.ConvertTo(m2, MatType.CV_32SC1);
            distCoeffs.ConvertTo(m3, MatType.CV_32SC1);
            rvecs.ConvertTo(m4, MatType.CV_32SC1);
            tvecs.ConvertTo(m5, MatType.CV_32SC1);
            this.label6.Text = "校正后内参:\n" + Cv2.Format(m1) + "\n校正前内参:\n" + Cv2.Format(m2)
                + "\n畸变系数:\n" + Cv2.Format(m3) + "\n旋转向量:\n" + Cv2.Format(m4) + "\n平移向量:\n" +
                 Cv2.Format(m5);
        }
    }
}
