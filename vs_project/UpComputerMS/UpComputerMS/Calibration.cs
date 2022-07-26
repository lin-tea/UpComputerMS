using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Size = OpenCvSharp.Size;
using OpenCvSharp;

namespace MyCalibration
{
    /// <summary>
    /// 标定类
    /// </summary>
    public class Calibration
    {
        static int BoardSize_Width = 11; //宽度和高度是指内部交叉点的个数，而不是方形格的个数
        static int BoardSize_Height = 8;
        static Size BoardSize = new Size(BoardSize_Width, BoardSize_Height);
        static int SquareSize = 500; //每格的宽度应设置为实际的毫米数
        readonly int winSize = 11;

        Mat newCameraMatrix = new Mat();
        Mat cameraMatrix = new Mat(), distCoeffs = new Mat();
        Mat[] rvecs = new Mat[0];//旋转向量   
        Mat[] tvecs = new Mat[0];//位移向量


        static List<string> imagesList = new List<string>() {
                @"..\..\Resources\标定图片.jpg"
            };

        /// <summary>
        /// 标定主函数入口
        /// </summary>
        public void Calibration_Main()
        {
            List<Point2f[]> imagesPoints = new List<Point2f[]>(); //储存2D点
            cameraMatrix = new Mat(); distCoeffs = new Mat();   //32位dll 像素数据的存储形式 
            //矩阵或图像的载体
            Size imageSize = new Size(); //长和宽的结构体
            bool found; //判断是否找到参数

            Mat[] imagesPointsM = new Mat[imagesList.Count];

            for (int i = 0; i < imagesList.Count; i++)
            {
                Mat view = new Mat(imagesList[i]);

                view = view.Threshold(160, 255, ThresholdTypes.Binary);
                if (!view.Empty())
                {
                    imageSize = view.Size();
                    //Point2f[] pointBuf;//储存2D信息

                    found = Cv2.FindChessboardCorners(view, BoardSize, out Point2f[] pointBuf, ChessboardFlags.AdaptiveThresh | ChessboardFlags.NormalizeImage);
                    //使用自适应阈值（通过平均图像亮度计算得到）将图像转换为黑白图，而不是一个固定的阈值
                    //在利用固定阈值或者自适应的阈值进行二值化之前，先使用cvNormalizeHist来均衡化图像亮度。
                    if (found == true)
                    {
                        Mat viewGray = new Mat();
                        Cv2.CvtColor(view, viewGray, ColorConversionCodes.BGR2GRAY);    //灰度转换
                        Cv2.CornerSubPix(viewGray, pointBuf, new Size(winSize, winSize), new Size(-1, -1), new TermCriteria(CriteriaTypes.Eps | CriteriaTypes.Count, 30, 0.0001));
                        //cornerSubPix()函数在角点检测中精确化角点位置     Size搜索窗口    搜索区域中间的dead region边长的一半，有时用于避免自相关矩阵的奇异性。如果值设为(-1,-1)则表示没有这个区域
                        //角点精准化迭代过程的终止条件。
                        imagesPoints.Add(pointBuf);
                        Mat p = Mat.FromArray<Point2f>(pointBuf);
                        imagesPointsM[i] = p;
                        //棋盘格角点的绘制 
                        Cv2.DrawChessboardCorners(view, BoardSize, pointBuf, found);
                        //Mat temp = view.Clone();//完全拷贝，
                        //Cv2.ImShow("Image View", view);
                        //Cv2.WaitKey(500);
                    }
                }
            }
            rvecs = new Mat[0];//旋转向量   
            tvecs = new Mat[0];//位移向量
            try
            {
                RunCalibration(imagesList.Count, imageSize, out cameraMatrix, out distCoeffs, imagesPointsM, out rvecs, out tvecs, out double totalAvgErr);
                //图片个数  图片尺寸    数组存储    数组存储    图片检测到的角点坐标  内参数 外参数
                Console.WriteLine("Camera Matrix:\n{0}", Cv2.Format(cameraMatrix));
                //内参数矩阵
                Console.WriteLine("Distortion Coefficients:\n{0}", Cv2.Format(distCoeffs));
                //畸变系数
                Console.WriteLine("Total Average Error:\n{0}", totalAvgErr);

                Console.WriteLine("rvecs:\n{0}", Cv2.Format(rvecs[0]));

                Console.WriteLine("tvecs:\n{0}", Cv2.Format(tvecs[0]));
            }
            catch (Exception suan)
            {
                Console.Error.WriteLine("Exception: {0}", suan.Message);
                Console.WriteLine("内参求解异常选择异常！！！，请检查参数输入");
                MessageBox.Show("内参求解异常选择异常！！！，请检查参数输入");
            }
            newCameraMatrix = Cv2.GetOptimalNewCameraMatrix(cameraMatrix, distCoeffs, imageSize, 1, imageSize,out _);
            //内参数矩阵 畸变系数    图片尺寸    缩放比例alpha   新图片尺寸
            //根据自由缩放参数返回新的相机内部矩阵
        }
        /// <summary>
        /// 标定计算
        /// </summary>
        /// <param name="imagesCount"></param>
        /// <param name="imageSize"></param>
        /// <param name="cameraMatrix"></param>
        /// <param name="distCoeffs"></param>
        /// <param name="imagePoints"></param>
        /// <param name="rvecs"></param>
        /// <param name="tvecs"></param>
        /// <param name="totalAvgErr"></param>
        /// <returns></returns>
        static bool RunCalibration(int imagesCount, Size imageSize, out Mat cameraMatrix, out Mat distCoeffs, Mat[] imagePoints, out Mat[] rvecs, out Mat[] tvecs, out double totalAvgErr)
        {
            cameraMatrix = Mat.Eye(new Size(3, 3), MatType.CV_64F);//单位矩阵
            distCoeffs = Mat.Zeros(new Size(8, 1), MatType.CV_64F);

            Mat[] objectPoints = CalcBoardCornerPositions(BoardSize, SquareSize, imagesCount);
            //角点数目矩阵    棋盘格实际宽度  图片个数
            //Find intrinsic and extrinsic camera parameters 找到相机的内参数和外参数
            double _ = Cv2.CalibrateCamera(objectPoints, imagePoints, imageSize, cameraMatrix, distCoeffs, out rvecs, out tvecs, CalibrationFlags.None);
            //世界坐标系中的点  图片检测到的角点坐标  图像的大小   内参数矩阵   畸变矩阵    旋转向量    位移向量    标定是所采用的算法
            //vector<cv::Mat> rvecs因为每个vector<Point3f>会得到一个rvecs。
            bool ok = Cv2.CheckRange(InputArray.Create(cameraMatrix)) && Cv2.CheckRange(InputArray.Create(distCoeffs));
            //创建指定Mat的代理类
            totalAvgErr = ComputeReprojectionErrors(objectPoints, imagePoints, rvecs, tvecs, cameraMatrix, distCoeffs);
            //世界坐标系中的点  图片检测到的角点坐标  旋转向量    位移向量    内参数矩阵   畸变矩阵
            return ok;
        }
        /// <summary>
        /// 根据标定板规格，计算标定板角点实际坐标，第一个点为原点
        /// </summary>
        /// <param name="BoardSize">标定板大小</param>
        /// <param name="SquareSize">实际大小</param>
        /// <param name="imagesCount">用于标定图片的数量</param>
        /// <returns></returns>
        static Mat[] CalcBoardCornerPositions(Size BoardSize, float SquareSize, int imagesCount)
        {
            Mat[] corners = new Mat[imagesCount];
            for (int k = 0; k < imagesCount; k++)
            {
                Point3f[] p = new Point3f[BoardSize.Height * BoardSize.Width];
                //角点数量
                for (int i = 0; i < BoardSize.Height; i++)
                {
                    for (int j = 0; j < BoardSize.Width; j++)
                    {
                        p[i * BoardSize.Width + j] = new Point3f(SquareSize * (BoardSize_Width - 1) - j * SquareSize, SquareSize * (BoardSize_Height - 1) - i * SquareSize, 0);
                        //p[i * BoardSize.Width + j] = new Point3f(j * SquareSize, i * SquareSize, 0);
                        //遍历三维数组里的点  以第一个点为原点，Z方向为0，实际尺寸
                    }
                }
                //corners[k] = new Mat(BoardSize.Width, BoardSize.Height, MatType.CV_64F, p); 
                corners[k] = Mat.FromArray<Point3f>(p);
                //每张图片的点实际坐标记录
            }
            return corners;
        }
        /// <summary>
        /// 计算标定角点预测误差MSE
        /// </summary>
        /// <param name="objectPoints">世界坐标系中的点</param>
        /// <param name="imagePoints">图片检测到的角点坐标</param>
        /// <param name="rvecs">旋转向量</param>
        /// <param name="tvecs">位移向量</param>
        /// <param name="cameraMatrix">内参数矩阵</param>
        /// <param name="distCoeffs">畸变矩阵</param>
        /// <returns>MSE误差</returns>
        static double ComputeReprojectionErrors(Mat[] objectPoints, Mat[] imagePoints, Mat[] rvecs, Mat[] tvecs, Mat cameraMatrix, Mat distCoeffs)
        {
            Mat imagePoints2 = new Mat();//存储重建后的坐标
            int totalPoints = 0;
            double totalErr = 0, err;

            for (int i = 0; i < objectPoints.Length; ++i)
            {
                Cv2.ProjectPoints(objectPoints[i], rvecs[i], tvecs[i], cameraMatrix, distCoeffs, imagePoints2);
                //通过给定的内参数和外参数计算三维点投影到二维图像平面上的坐标。
                err = Cv2.Norm(imagePoints[i], imagePoints2, NormTypes.L2);
                //图片检测到的角点坐标    存储重建后的坐标   计算图像的L2范数 src1-src2的所有元素平方和的开平方
                int n = objectPoints[i].Width * objectPoints[i].Height;
                //perViewErrors[i] = (float)Math.Sqrt(err * err / n);
                totalErr += err * err;//所有检测点与重建坐标差方的和
                totalPoints += n;//世界坐标系中的点 运算完毕的个数
            }
            return Math.Sqrt(totalErr / totalPoints);//均值
        }
        /// <summary>
        /// 像素位置到世界坐标(平面)
        /// </summary>
        /// <param name="imagePointsPre">像素坐标</param>
        /// <param name="rvecs">旋转内参</param>
        /// <param name="tvecs">平移内参</param>
        /// <param name="newCameraMatrix">相机内参数</param>
        public Mat Pix2world(Mat imagePointsPre, Mat rvecs, Mat tvecs, Mat newCameraMatrix)
        {
            Mat neini = new Mat();
            Mat result1, result2, result3;
            // 求逆
            Cv2.Invert(newCameraMatrix, neini, DecompTypes.LU);
            Mat xuan = new Mat();
            Mat xuanni = new Mat();
            Cv2.Rodrigues(rvecs, xuan);
            Cv2.Invert(xuan, xuanni, DecompTypes.LU);

            Mat P = neini * imagePointsPre;
            // 原始世界平面上的三个点
            double[] a = new double[3] { 0, 0, 0 };//P0
            double[] b = new double[3] { 0, 500, 0 };
            double[] c = new double[3] { 500, 0, 0 };
            Mat Point_a = new Mat(3, 1, MatType.CV_64FC1, a);
            Mat Point_b = new Mat(3, 1, MatType.CV_64FC1, b);
            Mat Point_c = new Mat(3, 1, MatType.CV_64FC1, c);
            // 转到相机坐标系
            result1 = xuan * Point_a + tvecs;
            result2 = xuan * Point_b + tvecs;
            result3 = xuan * Point_c + tvecs;
            // 用3个点得到2个非0向量
            Mat result12 = result1 - result2;
            Mat result13 = result1 - result3;
            // 得到法向量
            Mat fa = result12.Cross(result13);
            // 由于：(ZcP0-P)·F = 0, P0为三个点中的一个
            double Zc = result2.Dot(fa) / P.Dot(fa);
            Console.WriteLine("内参数矩阵逆矩阵{0}\n", Cv2.Format(neini));
            Console.WriteLine("旋转矩阵逆矩阵{0}\n", Cv2.Format(xuanni));
            Mat res = xuanni * (P * Zc - tvecs);
            return res;
        }
        /// <summary>
        /// 接口，返回大小参数
        /// </summary>
        /// <returns></returns>
        public int[] Parameter_Process_Return()
        {
            return new int[] { BoardSize_Width, BoardSize_Height, SquareSize };
        }
        /// <summary>
        /// 接口，返回相机各个参数
        /// </summary>
        /// <returns></returns>
        public Mat[] Parameter_Mat_Return()
        {
            try
            {
                if (newCameraMatrix != null)
                    return new Mat[] { newCameraMatrix, cameraMatrix, distCoeffs, rvecs[0], tvecs[0] };

            }
            catch (Exception pic)
            {
                Console.WriteLine("参数输入错误，{0}\n", pic.Message);
            }
            return new Mat[5];
        }
        /// <summary>
        /// 接口，设置标定的参数(棋盘格大小)
        /// </summary>
        /// <param name="Par"></param>
        public void Parameter_Process_Set(int[] Par)
        {
            BoardSize_Width = Par[1];
            BoardSize_Height = Par[0];
            SquareSize = Par[2];
            BoardSize = new Size(BoardSize_Width, BoardSize_Height);
        }
        /// <summary>
        /// 返回用于标定的一些列图片
        /// </summary>
        /// <returns></returns>
        public List<string> Pic_Process_Return()
        {
            return imagesList;
        }
        /// <summary>
        /// 设置用于标定的一系列图片
        /// </summary>
        /// <param name="List"></param>
        public void Pic_Process_Set(List<string> List)
        {
            imagesList = List;
        }
    }
}
