using System;
using System.Windows.Forms;

namespace UpComputerMS
{
    public partial class PMacControlFrom : Form
    {
        public int xMotorNum=1, yMotorNum=2;
        public double xPrePos = 0, yPrePos = 0, prePos = 0;
        string[] xy_Speed;
        private readonly object is_move_symbol = new object();
        public PMacControlFrom()
        {
            InitializeComponent();
            xMotorNum = 1;yMotorNum = 2;
            timerCurrentPosAndSpeedInfo.Start();
        }

        private void SelectDevice_Click(object sender, EventArgs e)
        {
            MainForm.myPmac.ConnectPMAC();
            if (MainForm.myPmac.openPmacSuccess)
            {
                selectStatus.ResetText();
                selectStatus.AppendText("通信中!");
                selectStatus.BackColor = System.Drawing.Color.Green;
                selectStatus.Show();
                MessageBox.Show($"Successful to Open PMac {MainForm.myPmac.pmacNumber} card!");
            }
            else
            {
                MessageBox.Show("File to Open PMAC card!");
                selectStatus.BackColor = System.Drawing.Color.Red;
            }
        }

        private void DotUp_Click(object sender, EventArgs e)
        {

        }

        private void DotUp_MouseDown(object sender, MouseEventArgs e)
        {
            yMotorNum = Convert.ToInt32(this.yMotor.Text);
            string response;
            if (this.stepOne.Checked)
            {
                string step = this.dotStep.Text;
                MainForm.myPmac.MoveStep(yMotorNum, step, out response);
            }
            else
            {
                MainForm.myPmac.StepUp(yMotorNum, out response);
            }
            if (response != "")
            {
                MessageBox.Show(response);
            }
        }

        private void DotUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.stepOne.Checked) MainForm.myPmac.MotorStop(yMotorNum, out _);
        }

        private void StopMove_Click(object sender, EventArgs e)
        {
            if (MainForm.myPmac.openPmacSuccess)
            {
                MainForm.myPmac.PMAC.GetResponse(MainForm.myPmac.pmacNumber, "k", out _);
                MainForm.myPmac.MotorStop(xMotorNum, out _);
                MainForm.myPmac.MotorStop(yMotorNum, out _);
                MainForm.myPmac.MotorStop(Convert.ToInt32(motorCombo.Text), out _);
            }
        }

        private void DotDown_MouseDown(object sender, MouseEventArgs e)
        {
            yMotorNum = Convert.ToInt32(this.yMotor.Text);
            string response;
            if (this.stepOne.Checked)
            {
                string step = "-" + this.dotStep.Text;
                MainForm.myPmac.MoveStep(yMotorNum, step, out response);
            }
            else
            {
                MainForm.myPmac.StepDown(yMotorNum, out response);
            }
            if (response != "")
            {
                MessageBox.Show(response);
            }
        }

        private void DotDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (!stepOne.Checked) MainForm.myPmac.MotorStop(yMotorNum, out _);
        }

        private void SetSpeedBTN_Click(object sender, EventArgs e)
        {
            if (MainForm.myPmac.openPmacSuccess)
            {
                if (this.speed.Text != "")
                {
                    MainForm.myPmac.SetSpeed(this.xMotorNum.ToString(), this.speed.Text);
                    MainForm.myPmac.SetSpeed(this.yMotorNum.ToString(), this.speed.Text);
                }
                if (Convert.ToDouble(this.speed.Text) > 15)
                {
                    MessageBox.Show("速度大于15时，自动设置为15cts/ms");
                }
            }
        }

        private void DotRight_MouseDown(object sender, MouseEventArgs e)
        {
            xMotorNum = Convert.ToInt32(this.xMotor.Text);
            string response;
            if (this.stepOne.Checked)
            {
                string step = "-" + this.dotStep.Text;
                MainForm.myPmac.MoveStep(xMotorNum, step, out response);
            }
            else
            {
                MainForm.myPmac.StepDown(xMotorNum, out response);
            }
            if (response != "")
            {
                MessageBox.Show(response);
            }
        }

        private void DotRight_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.stepOne.Checked) MainForm.myPmac.MotorStop(xMotorNum, out _);
        }

        private void DotLeft_MouseDown(object sender, MouseEventArgs e)
        {
            xMotorNum = Convert.ToInt32(this.xMotor.Text);
            string response;
            if (this.stepOne.Checked)
            {
                string step = this.dotStep.Text;
                MainForm.myPmac.MoveStep(xMotorNum, step, out response);
            }
            else
            {
                MainForm.myPmac.StepUp(xMotorNum, out response);
            }
            if (response != "")
            {
                MessageBox.Show(response);
            }
        }

        private void DotLeft_MouseUp(object sender, MouseEventArgs e)
        {
            if (!stepOne.Checked) MainForm.myPmac.MotorStop(xMotorNum, out _);
        }

        private void DeSelectDevice_Click(object sender, EventArgs e)
        {
            if (MainForm.myPmac.openPmacSuccess)
            {
                MainForm.myPmac.CloseConnect();
                this.selectStatus.ResetText();
                this.selectStatus.AppendText("已断开!");
                selectStatus.BackColor = System.Drawing.Color.Red;
            }
        }

        private void HomeZMotor_Click(object sender, EventArgs e)
        {
            if (MainForm.myPmac!=null&&MainForm.myPmac.openPmacSuccess) MainForm.myPmac.SendCommand( "#" + motorCombo.Text + "HOMEZ");
        }

        private void JogHere_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainForm.myPmac != null && MainForm.myPmac.openPmacSuccess) MainForm.myPmac.MoveToPos(Convert.ToInt32(motorCombo.Text), Convert.ToDouble(jogHerePos.Text));
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TimerCurrentPosAndSpeedInfo_Tick(object sender, EventArgs e)
        {
            chooseMotorLabel.Text = "电机" + motorCombo.Text + "位置";
            try
            {
                if (MainForm.myPmac!=null && MainForm.myPmac.openPmacSuccess) //如果与PMAC卡通讯连接成功
                {
                    //string motor1P, motor2P, motorP;   // 保存各电机位置

                    string question = "#" + xMotorNum.ToString() + "P";  //X轴电机位置命令
                    MainForm.myPmac.PMAC.GetResponse(MainForm.myPmac.pmacNumber, question, out string motor1P);
                    question = "#" + yMotorNum.ToString() + "P";     //Y轴电机位置命令
                    MainForm.myPmac.PMAC.GetResponse(MainForm.myPmac.pmacNumber, question, out string motor2P);
                    question = "#" + motorCombo.Text + "P";          //所选电机位置命令
                    MainForm.myPmac.PMAC.GetResponse(MainForm.myPmac.pmacNumber, question, out string motorP);
                    // 位置显示
                    this.xPosition.Text = motor1P;
                    this.yPosition.Text = motor2P;
                    this.chooseMotorPos.Text = motorP;
                    // 速度计算、显示
                    this.xCurrentSpeed.Text = Convert.ToString((Convert.ToDouble(motor1P) - xPrePos) / 2);
                    this.yCurrentSpeed.Text = Convert.ToString((Convert.ToDouble(motor2P) - yPrePos) / 2);
                    this.chooseMotorV.Text = Convert.ToString((Convert.ToDouble(motorP) - prePos) / 2);
                    lock (is_move_symbol)
                    {
                        xy_Speed = new string[] { Convert.ToString((Convert.ToDouble(motor1P) - xPrePos) / 2), Convert.ToString((Convert.ToDouble(motor2P) - yPrePos) / 2) };
                    }

                    // 保存当前位置
                    xPrePos = Convert.ToDouble(motor1P);
                    yPrePos = Convert.ToDouble(motor2P);
                    prePos = Convert.ToDouble(motorP);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 开启定时器
            this.timerCurrentPosAndSpeedInfo.Interval = 2;
            this.timerCurrentPosAndSpeedInfo.Start();
        }

        public void XYMoveSteps(object str)
        {
            try
            {
                if (MainForm.myPmac.openPmacSuccess)
                {
                    MainForm.myPmac.MoveStep(xMotorNum, (str as string[])[1], out _);
                    MainForm.myPmac.MoveStep(yMotorNum, (str as string[])[0], out _);
                }
                else
                {
                    Console.WriteLine("未连接");
                }
            }
            catch (Exception ss)
            {
                Console.WriteLine(ss.Message);
            }
        }
        public string[] Get_Speed()
        {
            return xy_Speed;
        }
    }
}
