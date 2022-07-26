using System;
using System.Windows.Forms;
using System.Drawing;
using OpenCvSharp;
using BaslerCameras;
using System.Threading;
using System.Threading.Tasks;
using yoloDC;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace UpComputerMS
{
    public partial class DetectForm : UserControl
    {
        //public Form1 f2;
        //异步加委托
        public delegate void Send_Move(object str);    //控制XY轴移动
        public delegate string[] Get_Speed();          //查询速度，是否为0
        public delegate bool Is_Zero();
        //标定缩放
        readonly double Zoom_Factor = 3.15;
        //3.2768
        public event Send_Move Send_Move_Event;
        public event Get_Speed Get_Speed_Event;
        BaslerCamcs camera = new BaslerCamcs();
        //检测目标
        readonly Yolo myyolo = new Yolo();
        //标定参数
        public Mat newCameraMatrix = new Mat();
        public Mat cameraMatrix = new Mat(), distCoeffs = new Mat();
        public Mat rvecs = new Mat();//旋转向量   
        public Mat tvecs = new Mat();//位移向量
        //多线程
        readonly CancellationTokenSource source = new CancellationTokenSource(); 
        readonly CancellationTokenSource source1 = new CancellationTokenSource();
        readonly CancellationTokenSource source2 = new CancellationTokenSource();
        private bool Is_Sleep = true;//检测线程是否休眠 false为在检测
        private bool Is_Detect_Con = false;//是否进行检测
        private readonly Is_Detect IS_detect = new Is_Detect(); //是否在检测
        private readonly Is_Process Is_process = new Is_Process(); //拍摄图像以及检测结果
        private readonly object is_sleep_symbol = new object();    //检测线程是否在睡眠
        // MAP芯片结果
        private readonly List<DetectOutput> mapResults;                   //保存芯片像素坐标
        private List<System.Drawing.Point> mapPix;               //保存MAPPING像素坐标
        public List<LedParameters> mapLEDs;                      // 芯片数据
        private readonly object lock_mapResults = new object(); //mapResults锁
        private readonly object lock_mapLEDs = new object();    //mapLEDs锁
        private bool isMAPPED = false;                          //是否完成MAPPING
        private int mapDX, mapDY;                               //MAPPING像素步长
        private int worldDX,worldDY;                            //MAPPING世界坐标系相对原点步长(累积)
        private int mapIdX,mapIdY;                              //MAPPING像素累计步长(用于换行)
        private int direct = 1;                                 //MAPPING方向 
        private bool Is_MAPPING = false;                        //是否在MAPPING
        private bool Is_Click = true;
        private readonly object lock_isClick = new object();
        //private readonly Mat MatchImg;
        //private readonly object lock_MatchImg = new object();
        public int using_id = 0;
        public int ac_id;
        /// <summary>
        /// DetectForm初始化函数
        /// </summary>
        public DetectForm()
        {
            InitializeComponent();
            camera.CameraImageEvent += Camera_CameraImageEvent;
            bool f = myyolo.ReadModel(@"..\..\Resources\best.onnx");                                   // 读取网络模型
            myyolo.SetThresholds(scoreThreshold: 0.55f, nmsThreshold: 0.35f, classThreshold: 0.90f); // 设置网络的概率阈值
            //MatchImg = Cv2.ImRead(@"..\..\Resources\MatchImage.jpg");
            //Console.WriteLine("SS" + Convert.ToString(MatchImg.Width));
            //Cv2.ImShow("ss", MatchImg);
            //Cv2.WaitKey(0);
            pictureBox1.Image = null;
            comboBox1.SelectedIndex = 0;

            // 事件添加委托，方便调用
            Send_Move_Event += MainForm.frm1.XYMoveSteps;
            Get_Speed_Event += MainForm.frm1.Get_Speed;

            Task tk1 = Task.Factory.StartNew(DCprocess, source.Token);
            //注册任务取消的事件
            source.Token.Register(() =>
            {
                Console.WriteLine("任务被取消后执行xx操作！");
            });
            mapResults = new List<DetectOutput>();
            mapLEDs = new List<LedParameters>();
            mapPix = new List<System.Drawing.Point>();
            timer1.Start();
        }
        /// <summary>
        /// Form load事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetectForm_Load(object sender, EventArgs e)
        {
            //下一句用来禁止对窗口大小进行拖拽
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            if (camera.CameraNumber > 0)
            {
                camera.CameraInit();
                label_Check.Text = "已连接";
                button_Tryconnect.Enabled = false;
            }
            else
            {
                label_Check.Text = "未连接到相机";
            }
        }
        /// <summary>
        /// 目标检测线程函数
        /// </summary>
        private void DCprocess()
        {
            Bitmap img = null;
            while (true)
            {
                if (!Is_Sleep && !Is_MAPPING)
                {
                    lock (Is_process)
                    {
                        if (Is_process.img_copy != null)
                        {
                            img = new Bitmap(Is_process.img_copy);
                        }
                        if (img != null)
                        {
                            Mat temp = OpenCvSharp.Extensions.BitmapConverter.ToMat(img);
                            Cv2.CvtColor(temp, temp, ColorConversionCodes.RGBA2RGB);
                            bool flag = myyolo.Detect(temp, out List<DetectOutput> t_res);
                            Is_process.dcRes.Clear();
                            if (flag)
                            {
                                Is_process.dcRes = t_res;
                            }
                        }
                    }
                    Thread.Sleep(500);
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }

        }
        /// <summary>
        /// MAPPING线程函数
        /// </summary>
        private void MappingProcess()
        {
            // 移动
            int cnt = 0;
            long mapIX = 0,mapIY = 0;
            int image_cnt = 1;
            bool is_save = false;
            // 确认是否拍照
            checkBox1.Invoke(new MethodInvoker(delegate {
                if (checkBox1.Checked) is_save = true;
            }));
            int map_width=5600, map_row=3;
            MAPPINGWidth.Invoke(new MethodInvoker(delegate {
                map_width = Convert.ToInt32(MAPPINGWidth.Text);
            }));
            MAPPINGHeight.Invoke(new MethodInvoker(delegate {
                map_row = Convert.ToInt32(MAPPINGHeight.Text)-1;
            }));
            if (map_width < 0 || map_width > 9000) map_width = 5600;
            if (map_row < 0 || map_row > 8) map_row = 2;
            while (true)
            {
                // 根据方向进行移动检测
                if (Cv2.Format(newCameraMatrix) == "[]")
                {
                    MessageBox.Show("请先通过标定确定参数！！！");
                    return;
                }
                int ddx = 4, ddy=-4;
                int[] d;
                switch (direct)
                {
                    case 1: //X 右
                        d = MoveTo(new Point2d(0.0, 0.0), new Point2d(0.0, mapDX+ddx));
                        mapIX += (mapDX+ddx);
                        mapIdX += (mapDX+ddx);
                        worldDX += d[1];
                        break;
                    case 2: //X 左
                        d = MoveTo(new Point2d(0.0, 0.0), new Point2d(0.0, -mapDX-ddx));
                        mapIX += (mapDX+ddx);
                        mapIdX -= (mapDX+ddx);
                        worldDX += d[1];
                        break;
                    case 3: //Y 上
                        d = MoveTo(new Point2d(0.0, 0.0), new Point2d(mapDY+ddy, 0.0));
                        direct = 2;
                        mapIdY += (mapDY+ddy);
                        worldDY += d[0];
                        break;
                    case 4: //Y 上
                        d = MoveTo(new Point2d(0.0, 0.0), new Point2d(mapDY+ddy, 0.0));
                        direct = 1;
                        mapIdY += (mapDY+ddy);
                        worldDY += d[0];
                        break;
                    default: break;
                }
                Thread.Sleep(100);
                // 检测
                Bitmap img = null;
                lock (Is_process)
                {
                    if (Is_process.img_copy != null)
                    {
                        img = new Bitmap(Is_process.img_copy);
                    }
                    if (img != null)
                    {
                        Mat temp = OpenCvSharp.Extensions.BitmapConverter.ToMat(img);
                        Cv2.CvtColor(temp, temp, ColorConversionCodes.RGBA2RGB);
                        // 保存图片
                        if(is_save)
                        {
                            Save_Images(temp, @"..\..\MapingPicture\"+cnt.ToString()+image_cnt.ToString()+".jpg");
                            ++image_cnt;
                        }
                        Is_process.dcRes.Clear();
                        //bool flag = myyolo.Detect(temp,out List<DetectOutput> t_res);
                        bool flag = false;
                        //List<DetectOutput> t_res;
                        flag = myyolo.Detect(temp,out List<DetectOutput> t_res);
                        int right = 0, bottom = 0;
                        int left = 494/2, top = 659/2;
                        if (flag)
                        {
                            Is_process.dcRes = t_res;
                            foreach (DetectOutput output in t_res)
                            {
                                if (direct == 1)
                                {
                                    left = Math.Min(left, output.box.Top);
                                    top =  Math.Min(top, output.box.Left);
                                    right = 494;
                                    bottom = 659;
                                }
                                else if (direct == 2)
                                {
                                    left = 0;
                                    top = Math.Min(top, output.box.Left);
                                    right = Math.Max(right, output.box.Bottom);
                                    bottom = 659;
                                }
                            }
                            List<Point2d> worldPoint = new List<Point2d>();
                            // t_res为检测结果，box为预测框(Rect类型)
                            for(int i=0;i<t_res.Count;i++)
                            {
                                int[] posT = Coordinate_Conversion2(new Point2d((double)(t_res[i].box.Location.X), (double)(t_res[i].box.Location.Y)), new Point2d(659/2,494/2));
                                worldPoint.Add(new Point2d((double)(posT[1] * Zoom_Factor+worldDX), (double)(posT[0] * Zoom_Factor + worldDY)));
                                // 像素位置变换，加上移动的余量
                                (t_res[i].box.Y, t_res[i].box.X) = (t_res[i].box.X, t_res[i].box.Y); //由于X、Y相反，因此需要交换
                                t_res[i].box.X = 494 - t_res[i].box.X;
                                t_res[i].box.Y = 659 - t_res[i].box.Y;

                                t_res[i].box.X += mapIdX; // 叠加移动的增量
                                t_res[i].box.Y += mapIdY;
                            };
                            System.Drawing.Point[] pS;
                            lock (lock_mapResults)
                            {
                                mapResults.AddRange(t_res);     //添加当前结果到全局变量中，保存结果
                                lock(lock_mapLEDs) mapLEDs.AddRange(DcRes2LedPara(t_res,worldPoint));
                                pS = Norm_Position(mapResults); //坐标转换，得到Point[]，并且对其缩放
                                mapPix = new List<System.Drawing.Point>(pS);
                                Draw_points(pS, 4f);            //画图，矩形块宽高为3
                            }
                            mapDX = right - left;
                            mapDY = Math.Max(mapDY,bottom - top);
                        }
                    }
                }
                // 遍历行结束，换行
                if (mapIX >= map_width)
                {
                    mapIY += mapDY;
                    direct = (direct == 1 ? 3 : 4);
                    mapIX = 0;
                    ++cnt;
                    image_cnt = 0;
                }
                //if (mapIY >= 20000) break;
                if (direct == 0) break;
                // 10行结束
                if (cnt > map_row) break;
                Thread.Sleep(300); //1000
            }
            lock (is_sleep_symbol)
            {
                Is_Sleep = true;
            }
            MainForm.myPmac.MoveToPos(1, 0); MainForm.myPmac.MoveToPos(2, 0);
            bool Is_Sleep_get()
            {
                //查询电机速度
                string[] str = Get_Speed_Event();
                if (str != null)
                {
                    Console.WriteLine(str[0] + "坐标" + str[1]);
                    return str[0] != "0" || str[1] != "0";
                }
                return false;

            }
            //Thread.Sleep(5000);
            while (Is_Sleep_get()) //倘若电机速度不为0，表示仍在运动，等待
            {
                Thread.Sleep(1000);
            }
            Thread.Sleep(24000);
            lock (is_sleep_symbol)
            {
                Is_Sleep = false;
            }
            Is_MAPPING = false;
            isMAPPED = true;
            if (is_save) MessageBox.Show("Images保存到"+ @"..\..\MapingPicture\");
            lock (lock_isClick)
            {
                Is_Click = true;
            }
        }
        /// <summary>
        /// 尝试连接相机按钮事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void Button_Tryconnect_Click(object sender, EventArgs e)
        {
            try
            {
                camera = new BaslerCamcs();
                camera.CameraImageEvent += Camera_CameraImageEvent;
                pictureBox1.Image = null;
                if (camera.CameraNumber > 0)
                {
                    camera.CameraInit();
                    label_Check.Text = "已连接";
                }
                else
                {
                    MessageBox.Show("请检查设备是否正常连接");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Stop_Click(object sender, EventArgs e)
        {
            lock (is_sleep_symbol)
            {
                if (Is_Detect_Con)
                {
                    MessageBox.Show("请先关闭检测！");
                    return;
                }
                if (!Is_Sleep)
                {
                    //Is_Detect_Con = false;
                    Is_Sleep = true;
                }
            }
            pictureBox1.Image = null;
            camera.Stop();
            label_Check.Text = "相机捕捉已关闭";
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pp = new Pen(Color.Red, 1);//线为红色，线宽为一个像素
            e.Graphics.DrawLine(pp, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);//第一条线
            e.Graphics.DrawLine(pp, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);//第二条线  
        }
        private void Button_Start_Click(object sender, EventArgs e)
        {
            lock (is_sleep_symbol)
            {
                if (Is_Sleep)
                    Is_Sleep = false;
            }
            camera.Start();
            label_Check.Text = "已连接";
        }
        /// <summary>
        /// 将点击图像像素坐标所在芯片移动到视野中心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //像素转世界
            bool is_go = false;
            lock (lock_isClick)
            {
                is_go = Is_Click;
            }
            if (!is_go) return; 
            try
            {
                Point2d Local_click = new Point2d(double.Parse(e.X.ToString()), double.Parse(e.Y.ToString()));
                this.label_x.Text = e.X.ToString();
                this.label_y.Text = e.Y.ToString();

                Local_click = Judge_Where(Local_click);

                if (Cv2.Format(newCameraMatrix) == "[]")
                {
                    MessageBox.Show("请先通过标定确定参数！！！");
                    return;
                }

                int[] Diretion = Coordinate_Conversion(Local_click);
                int xfang = (int)(Diretion[0] * Zoom_Factor);
                int yfang = (int)(Diretion[1] * (Zoom_Factor));

                //Console.WriteLine($"x_speed:{Get_Speed_Event()[0]},,y_speed:{Get_Speed_Event()[1]}");
                lock (is_sleep_symbol)//只读锁定的数据
                {
                    IS_detect.isMove = true;
                    //在移动，在检测
                    if (IS_detect.isMove && !Is_Sleep)
                        Is_Sleep = true;
                    Console.WriteLine($"移动：{IS_detect.isMove}");
                    IAsyncResult result_1 = Send_Move_Event.BeginInvoke(new string[] { xfang.ToString(), yfang.ToString() }, new AsyncCallback((IAsyncResult ar) => {
                        if (IS_detect.isMove && Is_Sleep)
                        {
                            Thread.Sleep(1000);
                            bool Is_Sleep_get()
                            {

                                string[] str = Get_Speed_Event();
                                if (str != null)
                                {
                                    Console.WriteLine(str[0] + "坐标" + str[1]);
                                    return str[0]!="0" || str[1] != "0";
                                }
                                return false;

                            }
                            while (Is_Sleep_get())
                            {
                                Thread.Sleep(100);
                            }
                            Console.WriteLine("跳出循环");
                            Is_process.dcRes.Clear();
                            Is_Sleep = false;
                            IS_detect.isMove = false;
                            Console.WriteLine($"睡眠：{Is_Sleep}");
                        }
                    }), null);

                }

                Console.WriteLine("x:{0},y{1}", xfang, yfang);

            }
            catch (Exception aaa)
            {
                Console.WriteLine("坐标换算错误{0}\n", aaa.Message);
                MessageBox.Show("坐标换算错误");
            }
        }
        /// <summary>
        /// 将target移动到start位置
        /// </summary>
        /// <param name="start"></param>
        /// <param name="target"></param>
        private int[] MoveTo(Point2d start, Point2d target)
        {
            //将target移动到start位置
            int[] Diretion = null;
            try
            {
                if (Cv2.Format(newCameraMatrix) == "[]")
                {
                    MessageBox.Show("请先通过标定确定参数！！！");
                    return null;
                }
                Diretion = Coordinate_Conversion2(start,target);
                int xfang = (int)(Diretion[0] * Zoom_Factor);
                int yfang = (int)(Diretion[1] * Zoom_Factor);
                if(start.X==target.X) xfang = 0;
                if(start.Y==target.Y) yfang = 0;
                Diretion[0] = xfang;
                Diretion[1] = yfang;
                lock (is_sleep_symbol)//只读锁定的数据
                {
                    IS_detect.isMove = true;
                    //在移动，在检测
                    if (IS_detect.isMove && !Is_Sleep)
                        Is_Sleep = true;
                    Console.WriteLine($"移动：{IS_detect.isMove}");
                    IAsyncResult result_1 = Send_Move_Event.BeginInvoke(new string[] { xfang.ToString(), yfang.ToString() }, new AsyncCallback((IAsyncResult ar) => { return; }), null);
                    if (IS_detect.isMove && Is_Sleep)
                    {
                        Thread.Sleep(1500);
                        bool Is_Sleep_get()
                        {

                            string[] str = Get_Speed_Event();
                            if (str != null)
                            {
                                Console.WriteLine(str[0] + "坐标" + str[1]);
                                return str[0] != "0" || str[1] != "0";
                            }
                            return false;

                        }
           
                        while (Is_Sleep_get())
                        {
                            Thread.Sleep(1000);
                        }
                        Console.WriteLine("跳出循环");
                        Is_process.dcRes.Clear();
                        Is_Sleep = false;
                        IS_detect.isMove = false;
                        Console.WriteLine($"睡眠：{Is_Sleep}");
                    }
                }
            }
            catch (Exception aaa)
            {
                Console.WriteLine("坐标换算错误{0}\n", aaa.Message);
                MessageBox.Show("坐标换算错误\n"+ aaa.Message);
            }
            return Diretion;
        }
        /// <summary>
        /// pictureBox1像素坐标得到所在芯片坐标
        /// </summary>
        /// <param name="Local_click"></param>
        /// <returns></returns>
        Point2d Judge_Where(Point2d Local_click)
        {
            if (Is_process.dcRes.Count != 0)
            {
                for (int i = 0; i < Is_process.dcRes.Count; i++)
                {
                    if (Local_click.X > Is_process.dcRes[i].box.X && Local_click.X < Is_process.dcRes[i].box.X + Is_process.dcRes[i].box.Width && Local_click.Y > Is_process.dcRes[i].box.Y && Local_click.Y < Is_process.dcRes[i].box.Y + Is_process.dcRes[i].box.Height)
                    {
                        return new Point2d(Is_process.dcRes[i].box.X + Is_process.dcRes[i].box.Width / 2, Is_process.dcRes[i].box.Y + Is_process.dcRes[i].box.Height / 2);
                    }
                }
            }
            return Local_click;
        }
        /// <summary>
        /// 设置、更新检测的标定参数接口
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="a3"></param>
        /// <param name="a4"></param>
        /// <param name="a5"></param>
        public void Set_Paramete(Mat a1, Mat a2, Mat a3, Mat a4, Mat a5)
        {
            newCameraMatrix = a1;
            cameraMatrix = a2;
            distCoeffs = a3;
            rvecs = a4;
            tvecs = a5;
        }
        int[] Coordinate_Conversion(Point2d Local_click)
        {
            double[] a = new double[3] { Local_click.X, Local_click.Y, 1 };
            Mat imagePointsPre = new Mat(3, 1, MatType.CV_64FC1, a);

            double[] b = new double[3] { 329.5, 247, 1 };
            Mat imagePointsYuan = new Mat(3, 1, MatType.CV_64FC1, b);

            Mat Matrix_Ca = cameraMatrix;
            if (comboBox1.Text == "校正畸变") Matrix_Ca = newCameraMatrix;
            if (comboBox1.Text == "未校正畸变") Matrix_Ca = cameraMatrix;

            //畸变校正
            Mat jieguo = MainForm.myCalib.Pix2world(imagePointsPre, rvecs, tvecs, Matrix_Ca);
            this.label_shijie_x.Text = Cv2.Format(jieguo).Split(';')[0].Substring(1).Split('.')[0];
            this.label_shijie_y.Text = Cv2.Format(jieguo).Split(';')[1].Substring(2).Split('.')[0];

            Mat jieguo1 = MainForm.myCalib.Pix2world(imagePointsYuan, rvecs, tvecs, Matrix_Ca);
            jieguo1 -= jieguo;
            int xfang = int.Parse(Cv2.Format(jieguo1).Split(';')[0].Substring(1).Split('.')[0]);
            int yfang = int.Parse(Cv2.Format(jieguo1).Split(';')[1].Substring(2).Split('.')[0]);

            return new int[] { xfang, yfang };
        }
        /// <summary>
        /// 得到在世界坐标系下start->target需要移动的X、Y距离，单位ct
        /// </summary>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        int[] Coordinate_Conversion2(Point2d start, Point2d target)
        {
            double[] a = new double[3] { start.X, start.Y, 1 };
            Mat imagePointsPre = new Mat(3, 1, MatType.CV_64FC1, a);

            double[] b = new double[3] { target.X, target.Y, 1 };
            Mat imagePointsYuan = new Mat(3, 1, MatType.CV_64FC1, b);

            Mat Matrix_Ca = cameraMatrix;
            //畸变校正
            //comboBox1.Invoke(new MethodInvoker(delegate {
            //    if (comboBox1.Text == "校正畸变") Matrix_Ca = newCameraMatrix;
            //    if (comboBox1.Text == "未校正畸变") Matrix_Ca = cameraMatrix;
            //}));
            Mat jieguo = MainForm.myCalib.Pix2world(imagePointsPre, rvecs, tvecs, Matrix_Ca);
            Mat jieguo1 = MainForm.myCalib.Pix2world(imagePointsYuan, rvecs, tvecs, Matrix_Ca);
            jieguo1 -= jieguo;
            int xfang = int.Parse(Cv2.Format(jieguo1).Split(';')[0].Substring(1).Split('.')[0]);
            int yfang = int.Parse(Cv2.Format(jieguo1).Split(';')[1].Substring(2).Split('.')[0]);
            return new int[] { xfang, yfang };
        }
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="img">图片,MAT格式</param>
        /// <param name="path">保存路径</param>
        private void Save_Images(Mat img,string path)
        {
            if (camera.Is_Grab() == true)
            {

                string fileName = path;
                if (fileName != "" && fileName != null)
                {
                    Cv2.ImWrite(path, img);
                }
            }
            else
            {
                Console.WriteLine("相机未打开，不能截图");
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (camera.Is_Grab() == true)
            {
                SaveFileDialog saveImageDialog = new SaveFileDialog
                {
                    Title = "图片保存",
                    Filter = @"jpeg|*.jpg|png|*.png",
                    //设置默认文件名（可以不设置）
                    FileName = "芯片图",
                    //主设置默认文件extension（可以不设置）
                    DefaultExt = "jpg"
                };
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveImageDialog.FileName.ToString();
                    if (fileName != "" && fileName != null)
                    {
                        string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToString();
                        if (fileExtName != "")
                        {
                            System.Drawing.Imaging.ImageFormat imgformat;
                            switch (fileExtName)
                            {
                                case "jpg":
                                    imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                    break;
                                case "png":
                                    imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                    break;
                                default:
                                    imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                    break;
                            }
                            try
                            {
                                Bitmap bit = new Bitmap(pictureBox1.Image);
                                MessageBox.Show("保存路径：" + fileName, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pictureBox1.Image.Save(fileName, imgformat);
                            }
                            catch
                            {

                            }

                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("相机未打开，不能截图");
            }
        }
        /// <summary>
        /// 检测按钮Click触发事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Detect_Click(object sender, EventArgs e)
        {
            if (camera != null&&camera.Is_Grab())
            {
                lock (is_sleep_symbol)
                {
                    if (!Is_Detect_Con)
                    {
                        //t.Start();
                        //在睡眠
                        //Is_Sleep = false;
                        Is_Detect_Con = true;
                    }
                    else
                    {
                        MessageBox.Show("检测已开始");
                    }
                }
            }
            else
            {
                MessageBox.Show("相机还未捕捉！");
            }
        }

        private void Button_stopDetect_Click(object sender, EventArgs e)
        {
            lock (is_sleep_symbol)
            {
                if (!Is_Detect_Con)
                {
                    MessageBox.Show("检测已经停止");
                }
                else
                {
                    //Is_Sleep=true;
                    Is_Detect_Con = false;
                }
            }
        }
        /// <summary>
        /// 定时显示MAPPING芯片数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Mapping芯片数量
            int cnt = 0;
            lock (lock_mapResults) cnt = mapResults.Count;
            textBox1.Text = cnt.ToString();
            textBox1.Show();
            timer1.Interval = 200;
            timer1.Start();
        }

        /// <summary>
        /// 在MAPPING画板上画出图像
        /// </summary>
        /// <param name="pS">Point数组</param>
        private void Draw_points(System.Drawing.Point []pS,float r=5f)
        {
            // 子线程，委托
            pictureBox2.BeginInvoke(new MethodInvoker(delegate
            {
                if (pS != null)
                {
                    // 遍历点画图
                    Graphics g = pictureBox2.CreateGraphics();
                    foreach (System.Drawing.Point p in pS)
                    {
                        //g.FillEllipse(Brushes.Black, p.X, p.Y, r, r);
                        g.FillRectangle(Brushes.Black, p.X, p.Y, r, r);
                    }
                    g.Dispose();
                    return;
                }
            }));
        }
        /// <summary>
        /// 转化坐标函数
        /// </summary>
        /// <param name="_list">预测框</param>
        /// <returns></returns>
        private System.Drawing.Point[] Norm_Position(List<DetectOutput> _list)
        {
            int n = _list.Count;
            System.Drawing.Point[] res = new System.Drawing.Point[n]; 
            int max_X = 11,max_Y = 11;   
            for(int i = 0; i < n; i++)
            {
                int new_X = (_list[i].box.Location.X / max_X)+5;
                int new_Y = (_list[i].box.Location.Y / max_Y)+5;
                res[i] = new System.Drawing.Point(new_X,new_Y);
            }
            return res;
        }

        private void Scan_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.Items.Clear();
            string date = this.date.Text;
            ac_id = DB_Login.id;
            using_id = 0;
            String connetStr = "server=127.0.0.1;port=3306;user=root;password=123456; database=teammates;";
            //创建数据库连接
            MySqlConnection use_con = new MySqlConnection(connetStr);
            //打开连接
            use_con.Open();
            try
            {
                String use_sql = string.Format("select using_id from using_inf where id='{0}' and using_time='{1}';", ac_id, date);
                MySqlCommand use_cmd = new MySqlCommand(use_sql, use_con);
                MySqlDataReader use_reader = use_cmd.ExecuteReader();
                
                while (use_reader.Read())
                {
                    using_id = use_reader.GetInt32("using_id");
                    Console.WriteLine("{0}", using_id);
                }
                use_con.Close();
            }
            catch
            {
                MessageBox.Show("未找到使用日志");
            }
            MySqlConnection con = new MySqlConnection(connetStr);

            if (using_id != 0)
            {
                //打开连接
                con.Open();
                Console.WriteLine("已经建立连接");
                String sql = string.Format("select * from chips where using_id='{0}';", using_id);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                listView1.Columns.Add("编号");

                listView1.Columns.Add("X轴坐标");

                listView1.Columns.Add("Y轴坐标");

                while (reader.Read())
                {
                    ListViewItem lt = new ListViewItem();
                    lt.Text = reader["id"].ToString();
                    lt.SubItems.Add(reader["x_coordinate"].ToString());
                    lt.SubItems.Add(reader["y_coordinate"].ToString());
                    listView1.Items.Add(lt);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("未找到使用日志");
            }
        }
        // 点击MAPPING图，是否要移动这个芯片
        private void PictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isMAPPED) return;
            Point2d Local_click = new Point2d(double.Parse(e.X.ToString()), double.Parse(e.Y.ToString()));
            int r = 8;
            int idx = -1;
            if (mapPix != null && mapPix.Count > 0)
            {
                for (int i = 0; i < mapPix.Count; i++)
                {
                    if (Local_click.X > (mapPix[i].X - r / 2) && Local_click.X < (mapPix[i].X + r / 2) && Local_click.Y > mapPix[i].Y - r / 2 && Local_click.Y < (mapPix[i].Y + r / 2))
                    {
                        idx = i; break;
                    }
                }
                LedParameters led = new LedParameters();
                lock (lock_mapLEDs) if (idx >= 0 && idx < mapLEDs.Count) led = mapLEDs[idx];
                if (led != null)
                {
                        // 获取机床坐标，MOVE
                        int p_x = led.X;
                    int p_y = led.Y;
                    textBox2.Text = idx.ToString();
                    Task.Factory.StartNew(() => {
                        lock (is_sleep_symbol)//只读锁定的数据
                        {
                            IS_detect.isMove = true;
                        }
                        MainForm.myPmac.SendCommand("#1j=" + (p_x-1500).ToString() + ",#2j=" + (p_y-1000).ToString());
                        Thread.Sleep(1000);
                        bool Is_Sleep_get()
                        {
                            string[] str = Get_Speed_Event();
                            if (str != null)
                            {
                                Console.WriteLine(str[0] + "坐标" + str[1]);
                                return str[0] != "0" || str[1] != "0";
                            }
                            return false;

                        }
                        while (Is_Sleep_get())
                        {
                            Thread.Sleep(100);
                        }
                        Thread.Sleep(1000);
                        lock (is_sleep_symbol)//只读锁定的数据
                        {
                            IS_detect.isMove = false;
                        }
                    });
                }
            }
        }

        private void Button_ClearMAP_Click(object sender, EventArgs e)
        {
            isMAPPED = false;   
            pictureBox2.Image = null;
            pictureBox2.Refresh();
            lock (lock_mapResults) mapResults.Clear();
        }

        private void Write_in_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(WriteIn_Process, source2.Token);
            //注册任务取消的事件
            source2.Token.Register(() =>
            {
                Console.WriteLine("WriteIn_Process任务被取消！");
            });
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Point[] pS;
            lock (lock_mapResults)
            {
                if (mapResults != null && mapResults.Count > 0)
                {
                    pS = Norm_Position(mapResults); //坐标转换，得到Point[]，并且对其缩放
                    mapPix = new List<System.Drawing.Point>(pS);
                    Draw_points(pS, 4f);            //画图，矩形块宽高为3
                }
            }
        }
        
        private void query_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (using_id != 0)
            {
                id = Convert.ToInt32(this.id_chip.Text.Trim());
                String connetStr = "server=127.0.0.1;port=3306;user=root;password=123456; database=teammates;";
                MySqlConnection con = new MySqlConnection(connetStr);

                con.Open();
                String sql = string.Format("select x_coordinate,y_coordinate from chips where id='{0}' and using_id = '{1}';", id, using_id);
                MySqlCommand mySqlCommand = new MySqlCommand(sql, con);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                int X = 0;
                int Y = 0;
                while (mySqlDataReader.Read())
                {
                    X = mySqlDataReader.GetInt32("x_coordinate");
                    Y = mySqlDataReader.GetInt32("y_coordinate");
                }
                listBox1.Items.Insert(0, "芯片编号：" + id + "   机床坐标：" + X + "," + Y);
                con.Close();
            }
            else
            {
                MessageBox.Show("请先扫描芯片信息");
            }
        }

        private void button_out_Click(object sender, EventArgs e)
        {
            using_id = 0;
            DB_Login.id = 0;
            ac_id = 0;
            listView1.Clear();
            listView1.Items.Clear();
            listBox1.Items.Clear();
            cur_user.Text = "无";
        }

        private void check_using_Click(object sender, EventArgs e)
        {
            if(DB_Login.id!=0)
            {
                
                DBLogForm form5 = new DBLogForm();
                form5.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先登录！");
            }
        }

        // 写入线程函数
        private void WriteIn_Process()
        {
            //String connetStr = "server=127.0.0.1;port=3306;user=root;password=123456;database=teammates;";
            ////创建数据库连接
            //MySqlConnection con = new MySqlConnection(connetStr);
            ////打开连接
            //con.Open();
            //String sql = string.Format("delete from chips;");
            //MySqlCommand mySqlCommand = new MySqlCommand(sql, con);
            //mySqlCommand.ExecuteNonQuery();
            //con.Close();
            //con.Open();
            //if (isMAPPED)
            //{
            //    if (cur_user == null || cur_user.Text == "无")
            //    {
            //        con.Close();return;
            //    }
            //    int id = 0;
            //    lock (lock_mapResults)
            //    {
            //        while (id < mapResults.Count)
            //        {
            //            int X = mapResults[id].box.X;
            //            int Y = mapResults[id].box.Y;
            //            string now = System.DateTime.Now.ToString();
            //            string insert = string.Format("insert into chips values ({0},'{1}','{2}',{3},'{4}');", id, X, Y,Convert.ToInt32(cur_user.Text), now);
            //            MySqlCommand mycmd1 = new MySqlCommand(insert, con);
            //            mycmd1.ExecuteNonQuery();
            //            id++;
            //        }
            //    }
            //    MessageBox.Show("录入成功！");
            //}
            //con.Close();
            if (isMAPPED)
            {
                string date = this.date.Text;
                try
                {
                    ac_id = DB_Login.id;
                }
                catch
                {
                    MessageBox.Show("未登录！");
                    return;
                }
                String connetStr = "server=127.0.0.1;port=3306;user=root;password=123456;database=teammates;";
                try
                {

                    //创建数据库连接
                    MySqlConnection con = new MySqlConnection(connetStr);
                    //打开连接
                    con.Open();
                    String use_insert = string.Format("insert into using_inf(id,using_time) values ('{0}','{1}');", ac_id, date);
                    MySqlCommand re_mycmd1 = new MySqlCommand(use_insert, con);
                    re_mycmd1.ExecuteNonQuery();

                    con.Close();
                    con.Open();

                    String use_sql = string.Format("select using_id from using_inf where id='{0}' and using_time='{1}';", ac_id, date);
                    MySqlCommand use_cmd = new MySqlCommand(use_sql, con);
                    MySqlDataReader use_reader = use_cmd.ExecuteReader();
                    using_id = 0;
                    while (use_reader.Read())
                    {
                        using_id = use_reader.GetInt32("using_id");
                        Console.WriteLine("{0}", using_id);
                    }
                    con.Close();
                    con.Open();
                    //int[] id = { 1, 2, 3, 4, 5 };
                    //int[] X = { 2, 2, 3, 4, 5 };
                    //int[] Y = { 1, 2, 3, 4, 5 };
                    //int a = 0;
                    //for (int i = 0; i < id.Length; i++)
                    //{
                    //    String insert = string.Format("insert into chips(ac_id,using_id,id,x_coordinate,y_coordinate) values ('{0}','{1}','{2}','{3}','{4}');", ac_id, using_id, id[i], X[i], Y[i]);
                    //    MySqlCommand re_insert1 = new MySqlCommand(insert, con);
                    //    if (re_insert1.ExecuteNonQuery() == 1)
                    //    {
                    //        a++;
                    //    }
                    //}
                    int id = 0;
                    lock (lock_mapLEDs)
                    {
                        while (id < mapLEDs.Count)
                        {
                            int X = mapLEDs[id].X;
                            int Y = mapLEDs[id].Y;
                            string insert = string.Format("insert into chips(ac_id,using_id,id,x_coordinate,y_coordinate) values ({0},'{1}','{2}',{3},'{4}');", ac_id, using_id, id, X, Y);
                            MySqlCommand mycmd1 = new MySqlCommand(insert, con);
                            mycmd1.ExecuteNonQuery();
                            id++;
                        }
                    }
                    MessageBox.Show("录入成功！");
                    con.Close();
                }
                catch
                {

                    MessageBox.Show("芯片信息添加失败");

                }
            }
        }

        /// <summary>
        /// 格式转换，转为标准的LED数据结构，并且由像素坐标得到机床坐标
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        private List<LedParameters> DcRes2LedPara(List<DetectOutput> _list,List<Point2d> worldPoint)
        {
            List<LedParameters> res = new List<LedParameters>();
            for(int i=0;i<_list.Count;i++)
            {
                LedParameters temp = new LedParameters
                {
                    Pix_X = _list[i].box.Location.X,
                    Pix_Y = _list[i].box.Location.Y,
                    Led_type = _list[i].id,
                    Width = _list[i].box.Width,
                    Height = _list[i].box.Height,
                    X = Convert.ToInt32(worldPoint[i].X),
                    Y = Convert.ToInt32(worldPoint[i].Y)
                };
                res.Add(temp);
            }
            return res;
        }
        private void Button_mapping_Click(object sender, EventArgs e)
        {
            lock (lock_isClick)
            {
                Is_Click = false;
            }
            isMAPPED = false;
            if (Is_MAPPING) return;
            // 设置Mapping零点
            // 检测
            Bitmap img = null;
            Is_MAPPING = true;
            mapIdX = 0;mapIdY = 0;
            worldDX = 0; worldDY = 0;
            mapResults.Clear();
            mapLEDs.Clear();
            mapPix.Clear();
            lock (is_sleep_symbol)
            {
                Is_Sleep = true;
            }
            lock (Is_process)
            {
                if (Is_process.img_copy != null)
                {
                    img = new Bitmap(Is_process.img_copy);
                }
                if (img != null)
                {
                    Mat temp = OpenCvSharp.Extensions.BitmapConverter.ToMat(img);
                    Cv2.CvtColor(temp, temp, ColorConversionCodes.RGBA2RGB);
                    if (checkBox1.Checked)
                    {
                        Save_Images(temp, @"..\..\MapingPicture\00.jpg");
                    }
                    bool flag = false;
                    //List<DetectOutput> t_res;
                    //lock (lock_MatchImg)
                    //    flag = myyolo.DetectMatch(temp, MatchImg, out t_res);
                    flag = myyolo.Detect(temp,out List<DetectOutput> t_res);
                    // if (t_res!=null) mapResults.AddRange(t_res);
                    int left = 0, right = 659, bottom = 494, top = 0 ;
                    //if (flag)   
                    //{
                    //    Is_process.dcRes = new List<DetectOutput>(t_res.ToArray()); ;
                    //}
                    foreach (DetectOutput output in t_res)
                    {
                        left = 0; //Math.Min(left, output.box.Top);
                        top = 0; //Math.Min(top, output.box.Left);
                        right = 494;
                        bottom = 659;
                    }
                    System.Drawing.Point[] pS;
                    MainForm.myPmac.SendCommand("#1HOMEZ,#2HOMEZ");
                    List<Point2d> worldPoint = new List<Point2d>(); 
                    lock (lock_mapResults)
                    {
                        for(int i=0;i<t_res.Count;i++)
                        {
                            // 像素位置变换，加上移动的余量
                            //t.box.X = 659 - t.box.X;
                            int[] posT = Coordinate_Conversion2(new Point2d(t_res[i].box.Location.X, t_res[i].box.Location.Y), new Point2d(659/2,494/2));
                            worldPoint.Add(new Point2d((double)(posT[1] + worldDX) * Zoom_Factor, (double)(posT[0] + worldDY) * Zoom_Factor));   
                            (t_res[i].box.Y, t_res[i].box.X) = (t_res[i].box.X, t_res[i].box.Y); //由于X、Y相反，因此需要交换
                            t_res[i].box.X = 494 - t_res[i].box.X;
                            t_res[i].box.Y = 659 - t_res[i].box.Y;
                            //t.box.X = 494 - t.box.X;
                            t_res[i].box.X += mapIdX; // 叠加移动的增量
                            t_res[i].box.Y += mapIdY;
                        };
                        mapResults.AddRange(t_res);

                        lock(lock_mapLEDs) mapLEDs.AddRange(DcRes2LedPara(t_res,worldPoint));
                        pS = Norm_Position(mapResults);
                        mapPix = new List<System.Drawing.Point>(pS);
                        Draw_points(pS, 4f);
                        Thread.Sleep(10);
                    }
                    mapDX = right - left;
                    mapDY = Math.Max(mapDY,bottom - top);
                    direct = 1; //向右走
                    // 设置Mapping零点
                    
                }
            }
            lock (is_sleep_symbol)
            {
                Is_Sleep = false;
            }
            Is_MAPPING = false;
            Task.Factory.StartNew(MappingProcess, source1.Token);
            //注册任务取消的事件
            source1.Token.Register(() =>
            {
                Console.WriteLine("MappingProcess任务被取消！");
            });
        }
        /// <summary>
        /// Basler相机采集触发事件委托
        /// </summary>
        /// <param name="bmp"></param>
        private void Camera_CameraImageEvent(Bitmap bmp)
        {
            pictureBox1.Invoke(new MethodInvoker(delegate
            {

                Bitmap old = pictureBox1.Image as Bitmap;  //销毁旧的图
                if (!Is_Sleep && !IS_detect.isMove && Is_Detect_Con)          // 开启了检测多线程
                {
                    lock (Is_process)                          // 保存图像搭配全局变量Is_process.img_copy
                    {
                        if (Is_process.img_copy != null) Is_process.img_copy.Dispose();
                        Is_process.img_copy = new Bitmap(bmp);
                        if (Is_process.dcRes.Count > 0)               // 如果检测有结果，则显示
                        {
                            Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp);
                            myyolo.DrawPred(ref img, img.Size(), Is_process.dcRes, false, true, false);
                            bmp = new Bitmap(img.ToMemoryStream());
                        }
                    }
                }
                pictureBox1.Image = bmp;
                if (old != null)
                    old.Dispose();
            }));
        }//关键代码
    }
    // 是否正在检测
    public class Is_Detect
    {
        public bool isThres = false;
        public bool isMove = false;
    }
    // 保存拍摄到的图像以及检测结果
    public class Is_Process
    {
        public Bitmap img_copy;
        public List<DetectOutput> dcRes = new List<DetectOutput>();
    }
}
