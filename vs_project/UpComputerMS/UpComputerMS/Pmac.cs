using System;
using PCOMMSERVERLib;   // PMAC 调用库
namespace PmacControl
{
    public class Pmac
    {
        //------------- 属性 --------------//
        /// <summary>
        /// PMAC卡
        /// </summary>
        public PmacDeviceClass PMAC;
        /// <summary>
        /// 选择状态
        /// </summary>
        public bool selectPmacSuccess = false;
        /// <summary>
        /// 打开状态
        /// </summary>
        public bool openPmacSuccess = false;  
        /// <summary>
        /// PMAC卡号
        /// </summary>
        public int pmacNumber;
        public Pmac()
        {
            PMAC = new PmacDeviceClass();
            openPmacSuccess = false;
        }
        //----------------- 方法 ----------------//
        /// <summary>
        /// 连接PMAC卡
        /// </summary>
        /// <returns></returns>
        public bool ConnectPMAC()
        {
            PMAC.SelectDevice(0, out pmacNumber, out selectPmacSuccess);
            try
            {
                if (selectPmacSuccess)    //检验Pmac是否能选择
                {
                    PMAC.Open(pmacNumber, out openPmacSuccess);
                    if (openPmacSuccess)   //PMac是否成功打开
                    {
                        return true;
                    }
                }
            }catch (Exception ex)
            {
                Console.Error.WriteLine("Exception: {0}", ex.Message);
                Console.WriteLine("连接失败");
            }
            return false;
        }
        /// <summary>
        /// 关闭连接，断开PMAC卡
        /// </summary>
        /// <returns></returns>
        public bool CloseConnect()
        {
            if (openPmacSuccess == true)
            {
                PMAC.GetResponse(pmacNumber, "k", out _); //kill all运行
                PMAC.Close(pmacNumber);  //关闭连接
                openPmacSuccess = false;
                PMAC.Abort(pmacNumber);
                selectPmacSuccess = false;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 电机正向点动
        /// </summary>
        /// <param name="motorNum">电机号(int)</param>
        /// <param name="response">回复信息</param>
        public void StepUp(int motorNum, out string response) 
        {   /*
             motorNum: 电机号 
                PLC: 代码 #1j+
             */
            string question = "#" + motorNum.ToString() + "j+";
            PMAC.GetResponse(pmacNumber, question, out response);
        }
        /// <summary>
        /// 电机反向点动
        /// </summary>
        /// <param name="motorNum">电机号</param>
        /// <param name="response">信息</param>
        public void StepDown(int motorNum, out string response)
        {
            string question = "#" + motorNum.ToString() + "j-";
            PMAC.GetResponse(pmacNumber, question, out response);
        }
        /// <summary>
        /// 电机停止
        /// </summary>
        /// <param name="motorNum">电机号</param>
        /// <param name="response">回复信息</param>
        public void MotorStop(int motorNum, out string response) 
        {
            string question = "#" + motorNum.ToString() + "j/";
            PMAC.GetResponse(pmacNumber, question, out response);
        }
        /// <summary>
        /// 电机移动到pos位置
        /// </summary>
        /// <param name="motorNum">电机号</param>
        /// <param name="pos">位置(单位:脉冲ct)</param>
        public void MoveToPos(int motorNum, double pos) 
        {   // pos 脉冲数
            string question = "#" + motorNum.ToString() + "j=" + pos.ToString();
            PMAC.GetResponse(pmacNumber, question, out _);
        }
        /// <summary>
        /// 在当前位置移动step脉冲
        /// </summary>
        /// <param name="motorNum">电机号</param>
        /// <param name="step">步长</param>
        /// <param name="response">回复信息</param>
        public void MoveStep(int motorNum, string step, out string response) 
        {
            string question = "#" + motorNum.ToString() + "j^" + step;
            PMAC.GetResponse(pmacNumber, question, out response);
        }
        /// <summary>
        /// 电机Jog速度
        /// </summary>
        /// <param name="motorNum">电机号</param>
        /// <param name="speed">速度 (单位:脉冲ct)</param>
        public void SetSpeed(string motorNum, string speed)
        {
            // speed: 单位cts/ms
            double s = Convert.ToDouble(speed);
            if (s > 15) s = 15;
            else if (s < 0) return;
            speed = s.ToString();
            string commond = "I" + motorNum + "22=" + speed;
            PMAC.GetResponse(pmacNumber, commond, out _);
        }
        /// <summary>
        /// 读取PMac卡代号为var变量当前的值、状态
        /// </summary>
        /// <param name="var">变量名</param>
        /// <param name="pmacStatus">pmac卡状态</param>
        /// <param name="pmacResponse">回复信息</param>
        public void ReadVar(string var, out int pmacStatus, out string pmacResponse) 
        {
            try
            {
                PMAC.GetResponseEx(pmacNumber, var, bAddLF: true, out pmacResponse, out pmacStatus);
                return;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            pmacStatus = 0;
            pmacResponse = "";
        }
        /// <summary>
        /// 下载程序文件到PMAC
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns>是否下载成功</returns>
        public bool DownloadFiletoPMac(string filepath)
        {
            // 如果文件路径有
            if (filepath == null) return false;
            bool flag = false;
            try
            {
                //下载文件到PMAC中
                PMAC.Download(pmacNumber, filepath, bMacro: false, bMap: false,
                    bLog: true, bDnld: true, out flag);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //返回下载的结果成功或者失败
            return flag;
        }
        /// <summary>
        /// 发送命令到命令行
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns></returns>
        public bool SendCommand(string command)
        {
            if (this.openPmacSuccess)
            {
                try
                {
                    if (command != "")
                    {
                        PMAC.GetResponseEx(pmacNumber, command, true, out string response, out int pstatus);
                        if (response != "")
                        {
                            Console.WriteLine(response);
                        }
                        else
                        {
                            return true;
                        }
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }

    }
}