using System;
using System.Drawing;
using System.Windows.Forms;
using Basler.Pylon;
using System.Drawing.Imaging;


namespace BaslerCameras
{
    public class BaslerCamcs
    {
        public int CameraNumber = CameraFinder.Enumerate().Count;//寻找相机个数   
        //委托+事件 = 回调函数，用于传递相机抓取的图像
        public delegate void CameraImage(Bitmap bmp);
        //!!!!
        public event CameraImage CameraImageEvent;
        //放出一个Camera
        Camera camera;
        //basler里用于将相机采集的图像转换成位图
        readonly PixelDataConverter pxConvert = new PixelDataConverter();
        //控制相机采集图像的过程
        bool GrabOver = false;

        //private static readonly Version sfnc2_0_0 = new Version(2, 0, 0);
        private static EnumName regionSelector;
        private static BooleanName autoFunctionAOIROIUseWhiteBalance, autoFunctionAOIROIUseBrightness;
        private static IntegerName regionSelectorWidth, regionSelectorHeight, regionSelectorOffsetX, regionSelectorOffsetY;
        private static string regionSelectorValue1;// regionSelectorValue2;

        public static void Configure(Camera camera)
        {

            regionSelector = PLCamera.AutoFunctionAOISelector;
            regionSelectorOffsetX = PLCamera.AutoFunctionAOIOffsetX;
            regionSelectorOffsetY = PLCamera.AutoFunctionAOIOffsetY;
            regionSelectorWidth = PLCamera.AutoFunctionAOIWidth;
            regionSelectorHeight = PLCamera.AutoFunctionAOIHeight;
            regionSelectorValue1 = PLCamera.AutoFunctionAOISelector.AOI1;
            //regionSelectorValue2 = PLCamera.AutoFunctionAOISelector.AOI2;
            autoFunctionAOIROIUseBrightness = PLCamera.AutoFunctionAOIUsageIntensity;
            autoFunctionAOIROIUseWhiteBalance = PLCamera.AutoFunctionAOIUsageWhiteBalance;

        }


        void AdMain()
        {
            try
            {
                if (camera != null)
                {
                    if (camera.StreamGrabber.IsGrabbing == true)
                    {
                        camera.StreamGrabber.Stop();
                    }
                    if (Is_Open() == true)
                        camera.Close();
                    Console.WriteLine("Using camera {0}.", camera.CameraInfo[CameraInfoKey.ModelName]);
                    // Set the acquisition mode to free running continuous acquisition when the camera is opened.
                    camera.CameraOpened += Configuration.AcquireContinuous;
                    camera.Open();
                    Configure(camera);
                    // Set the pixel format to one from a list of ones compatible with this example
                    string[] pixelFormats = new string[]
                    {
                    PLCamera.PixelFormat.YUV422_YUYV_Packed,
                    PLCamera.PixelFormat.YCbCr422_8,
                    PLCamera.PixelFormat.BayerBG8,
                    PLCamera.PixelFormat.BayerRG8,
                    PLCamera.PixelFormat.BayerGR8,
                    PLCamera.PixelFormat.BayerGB8,
                    PLCamera.PixelFormat.Mono8
                    };//设置像素格式
                    camera.Parameters[PLCamera.PixelFormat].SetValue(pixelFormats);

                    // Disable test image generator if available
                    camera.Parameters[PLCamera.TestImageSelector].TrySetValue(PLCamera.TestImageSelector.Off);
                    camera.Parameters[PLCamera.TestPattern].TrySetValue(PLCamera.TestPattern.Off);

                    // Set the Auto Function ROI for luminance and white balance statistics.
                    // We want to use ROI2 for gathering the statistics.
                    if (camera.Parameters[regionSelector].IsWritable)
                    {
                        camera.Parameters[regionSelector].SetValue(regionSelectorValue1);
                        camera.Parameters[autoFunctionAOIROIUseBrightness].SetValue(true);// ROI 1 is used for brightness control
                        camera.Parameters[autoFunctionAOIROIUseWhiteBalance].SetValue(true);// ROI 1 is used for white balance control
                    }
                    camera.Parameters[regionSelector].SetValue(regionSelectorValue1);
                    camera.Parameters[regionSelectorOffsetX].SetValue(camera.Parameters[PLCamera.OffsetX].GetMinimum());
                    camera.Parameters[regionSelectorOffsetY].SetValue(camera.Parameters[PLCamera.OffsetY].GetMinimum());
                    camera.Parameters[regionSelectorWidth].SetValue(camera.Parameters[PLCamera.Width].GetMaximum());
                    camera.Parameters[regionSelectorHeight].SetValue(camera.Parameters[PLCamera.Height].GetMaximum());


                    camera.Parameters[PLCamera.ProcessedRawEnable].TrySetValue(true);
                    camera.Parameters[PLCamera.GammaEnable].TrySetValue(true);
                    camera.Parameters[PLCamera.GammaSelector].TrySetValue(PLCamera.GammaSelector.sRGB);
                    camera.Parameters[PLCamera.AutoTargetValue].TrySetValue(80);
                    camera.Parameters[PLCamera.AutoFunctionProfile].TrySetValue(PLCamera.AutoFunctionProfile.GainMinimum);
                    camera.Parameters[PLCamera.AutoGainRawLowerLimit].TrySetToMinimum();
                    camera.Parameters[PLCamera.AutoGainRawUpperLimit].TrySetToMaximum();
                    camera.Parameters[PLCamera.AutoExposureTimeAbsLowerLimit].TrySetToMinimum();
                    camera.Parameters[PLCamera.AutoExposureTimeAbsUpperLimit].TrySetToMaximum();


                    // Set all auto functions to once in this example
                    camera.Parameters[PLCamera.GainSelector].TrySetValue(PLCamera.GainSelector.All);
                    camera.Parameters[PLCamera.GainAuto].TrySetValue(PLCamera.GainAuto.Once);
                    camera.Parameters[PLCamera.ExposureAuto].TrySetValue(PLCamera.ExposureAuto.Once);
                    camera.Parameters[PLCamera.BalanceWhiteAuto].TrySetValue(PLCamera.BalanceWhiteAuto.Once);

                    camera.Parameters[PLCamera.LightSourceSelector].TrySetValue(PLCamera.LightSourceSelector.Daylight);



                    // Set the upper limit of the camera's frame rate to 30 fps
                    camera.Parameters[PLCamera.AcquisitionFrameRateEnable].SetValue(true);
                    camera.Parameters[PLCamera.AcquisitionFrameRateAbs].SetValue(50.0);
                    //帧率上限

                    camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
                    //在一个枚举类型中，设置相机捉取的方式，三种参数选项
                    camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
                    //camera.StreamGrabber.Start();
                    //camera.Close();
                }


            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Exception: {0}", e.Message);
                DestroyCamera();
            }
            finally
            {
            }
        }
        public void CameraInit()
        {
            camera = new Camera();
            //自由运行模式
            //The Configuration class is used to configure the camera for software trigger mode
            camera.CameraOpened += Configuration.AcquireContinuous;
            //断开连接事件
            camera.ConnectionLost += Camera_ConnectionLost;
            //抓取开始事件
            camera.StreamGrabber.GrabStarted += StreamGrabber_GrabStarted;
            //抓取图片事件
            camera.StreamGrabber.ImageGrabbed += StreamGrabber_ImageGrabbed;
            //结束抓取事件
            camera.StreamGrabber.GrabStopped += StreamGrabber_GrabStopped;
            //控制缓冲区的数量
            //camera.Parameters[PLCameraInstance.MaxNumBuffer].SetValue(5);
            //if (!camera.Parameters[PLCamera.GainAuto].IsWritable)
            //{
            //    Console.WriteLine( "The camera does not support Gain Auto." );
            //    return;
            //}
            //打开相机
            return;
            //camera.Open();


        }
        private void StreamGrabber_GrabStarted(object sender, EventArgs e)
        {
            GrabOver = true;
        }
        private void StreamGrabber_ImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            IGrabResult grabResult = e.GrabResult;
            if (grabResult.IsValid)
            {
                if (GrabOver)
                    CameraImageEvent(GrabResult2Bmp(grabResult));
            }
        }

        private void StreamGrabber_GrabStopped(object sender, GrabStopEventArgs e)
        {
            GrabOver = false;
        }

        private void Camera_ConnectionLost(object sender, EventArgs e)
        {
            camera.StreamGrabber.Stop();
            DestroyCamera();
        }

        public bool Is_Open()
        {
            return camera.IsOpen;
        }

        public bool Is_Grab()
        {
            return camera.StreamGrabber.IsGrabbing;
        }

        public void Stop()
        {
            try
            {
                if (camera != null)
                {
                    //StreamGrabber 流控制
                    if (camera.StreamGrabber.IsGrabbing == true)
                    {
                        camera.StreamGrabber.Stop();
                    }
                    else
                    {
                        MessageBox.Show("相机已关闭");
                    }

                }
            }
            catch
            {
                DestroyCamera();
                Console.WriteLine("camera close has error!!");
            }
            finally
            {

            }

        }

        public void Start()
        {
            try
            {
                if (camera != null)
                {
                    //StreamGrabber 流控制
                    if (Is_Open() != true)
                        camera.Open();
                    if (camera.StreamGrabber.IsGrabbing)
                    {
                        MessageBox.Show("相机正在捕捉");
                    }
                    else
                    {
                        double d = camera.Parameters[PLCamera.ExposureTimeAbs].GetValue();
                        Console.WriteLine("{0}", d);
                        //camera.Parameters[PLCamera.ExposureTimeMode].SetValue(PLCamera.ExposureTimeMode.Timed);
                        camera.Parameters[PLCamera.ExposureAuto].SetValue(PLCamera.ExposureAuto.Off);

                        //camera.Parameters[PLCamera.ExposureAuto].TrySetValue(PLCamera.ExposureAuto.Once);
                        camera.Parameters[PLCamera.ExposureTimeAbs].SetValue(9000.0);


                        camera.Parameters[PLCamera.GainAuto].SetValue(PLCamera.GainAuto.Off);
                        camera.Parameters[PLCamera.GainRaw].SetValue(300);

                        camera.Parameters[PLCamera.AcquisitionFrameRateEnable].SetValue(true);
                        camera.Parameters[PLCamera.AcquisitionFrameRateAbs].SetValue(80.0);
                        //帧率
                        camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
                        //在一个枚举类型中，设置相机捉取的方式，三种参数选项
                        camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
                    }

                }
            }
            catch
            {
                Console.WriteLine("camera start has error！");
                DestroyCamera();
            }
            finally
            {

            }

        }

        public void Auto_Ad()
        {
            AdMain();
        }
        public void Daoru(string filename)
        {
            camera.Parameters.Load(filename, ParameterPath.CameraDevice);//导入配置文件
            Start();
        }
        public void Daochu()
        {
            SaveFileDialog saveImageDialog = new SaveFileDialog
            {
                Title = "图片保存",
                Filter = @"pfs|*.pfs",
                FileName = "camera",
                DefaultExt = "pfs"
            };
            if (saveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveImageDialog.FileName.ToString();
                if (fileName != "" && fileName != null)
                {
                    //string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToString();
                    Console.WriteLine(fileName);
                    MessageBox.Show("保存路径：" + fileName, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    camera.Parameters.Save(fileName, ParameterPath.CameraDevice);//导出配置文件
                }
            }
        }
        //将相机抓取到的图像转换成Bitmap位图
        Bitmap GrabResult2Bmp(IGrabResult grabResult)
        {
            Bitmap b = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
            BitmapData bmpData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, b.PixelFormat);
            pxConvert.OutputPixelFormat = PixelType.BGRA8packed;
            IntPtr bmpIntpr = bmpData.Scan0;
            pxConvert.Convert(bmpIntpr, bmpData.Stride * b.Height, grabResult);
            b.UnlockBits(bmpData);
            return b;
        }
        //释放相机
        public void DestroyCamera()
        {
            if (camera != null)
            {
                camera.Close();
                camera.Dispose();
                camera = null;
            }
        }
    }
}
