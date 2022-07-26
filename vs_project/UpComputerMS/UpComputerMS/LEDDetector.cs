using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.Dnn;

/// <summary>
/// yolov5 Detector and Match Detector
/// </summary>
namespace yoloDC
{
    /// <summary>
    /// Output数据结构，即为预测锚框参数
    /// </summary>
    public class DetectOutput
    {
        public int id;//结果类别id
        public float confidence;//结果置信度
        public Rect box;//矩形框
    }
    /// <summary>
    /// yolo类
    ///     - 功能:
    ///        读取yolov5，onnx模型
    ///        进行detect，在图像上画图锚框
    ///        模型要求：锚框参数、置信度、类别onehot，三输出concat成一个向量，对于1类别，为6；对于(640,640)生成25200个预测锚框
    /// </summary>
    public class Yolo
    {
        /// <summary>
        /// 各种属性
        /// </summary>
        private Net net;
        public bool isReadSuccess = false;
        /// <summary>
        /// yolov5网络参数
        /// </summary>
        // 1. anchors 锚框
        //      由于采样的图片长宽比不大，故直接用原始锚框大小
        //      对于3种不同特征图的锚框，对于每一个特征图有3种锚框
        //      小特征图，用大的锚框可以搜索更大的物体，而大特征图用小的锚框可以搜索更小的物体
        readonly float[,] netAnchors = new float[3, 6]{
        { 10.0F, 13.0F, 16.0F, 30.0F, 33.0F, 23.0F }, // 大特征图
        { 30.0F, 61.0F, 62.0F, 45.0F, 59.0F, 119.0F }, //中特征图
        { 116.0F, 90.0F, 156.0F, 198.0F, 373.0F, 326.0F}}; //小特征图
        // 2. stride，锚框的步长
        //      即对应三种特征图在降维时用的步长，根据这个可以得到特征图的box个数
        readonly float[] netStride = new float[3] { 8.0F, 16.0F, 32.0F };
        // 3. 输入图像大小 32倍数
        //    这里为640x640
        readonly float netHeight = 640;
        readonly float netWidth = 640;
        // 4. 各种置信概率(阈值)
        //    可改
        float nmsThreshold = 0.45f;  //nms阈值
        float boxThreshold = 0.5f;  //置信度阈值
        float classThreshold = 0.45f; //类别阈值
        readonly List<string> classname = new List<string> { "chip" };

        /// <summary>
        /// 初始化函数
        /// </summary>
        public Yolo()
        {
            net = new Net();
        }
        /// <summary>
        /// 各种方法
        /// </summary>
        public double Sigmoid(float x) // sigmoid函数
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
        /// <summary>
        /// 读取onnx模型
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public bool ReadModel(string path)
        {
            try
            {
                net = Net.ReadNet(path);
                isReadSuccess = true;
            }
            catch (Exception)
            {
                net = null;
                isReadSuccess = false;
                return false;
            }
            net.SetPreferableBackend(Backend.DEFAULT);
            net.SetPreferableTarget(Target.CPU);
            return true;
        }
        /// <summary>
        /// 设置阈值
        /// </summary>
        /// <param name="scoreThreshold">锚框置信度阈值</param>
        /// <param name="nmsThreshold">nms阈值</param>
        /// <param name="classThreshold">类别阈值</param>
        public void SetThresholds(float scoreThreshold = 0.5f, float nmsThreshold = 0.45f, float classThreshold = 0.45f)
        {
            this.boxThreshold = scoreThreshold;
            this.nmsThreshold = nmsThreshold;
            this.classThreshold = classThreshold;
        }
        /// <summary>
        /// 检测，预测
        /// </summary>
        /// <param name="ScrImg">输入图像: RGB</param>
        /// <param name="originSizeout">输出原始大小</param>
        /// <param name="Results">输出预测锚框</param>
        /// <returns></returns>
        public bool Detect(Mat ScrImg, out List<DetectOutput> Results)
        {
            // 保存结果，格式如上面定义的结构体output一致
            Results = new List<DetectOutput>();
            // 得到输入图像原本大小，用于后面恢复
            //originSizeout = ScrImg.Size();
            if (isReadSuccess)
            {
                if (ScrImg.Empty()) return false;
                //Cv2.ImShow("test image", ScrImg);
                //Cv2.WaitKey(0);
                // 1) 格式化输入格式，变成 1x3x640x640的tensor，并且归一化
                //       由于输入的RGB故无需转换
                Mat blob = CvDnn.BlobFromImage(ScrImg, 1.0 / 255, new OpenCvSharp.Size(netWidth, netHeight), new Scalar(), false, false);
                // int c = blob.Cols; //debug用
                //MessageBox.Show(blob.Cols);
                // 2) 输入网络
                //DateTime t1 = DateTime.Now;
                net.SetInput(blob);
                // 3) 向前传播 

                Mat netOutput = net.Forward();
                //DateTime t2 = DateTime.Now;
                //TimeSpan dt = t2 - t1;
                //MessageBox.Show(Convert.ToString(dt.Milliseconds));
                // 4) 高、宽的缩放大小倍率
                double ratio_h = ScrImg.Rows / netHeight;  // 输入图像的高 / 640
                double ratio_w = ScrImg.Cols / netWidth;  // 输入图像的宽 / 640
                //int net_width = classname.Count() + 5;  //x,y,h,w,confidence,类别one-hot
                //int num = 0; //debug 查看好的锚框数量
                int r = 0;  // index，第一行
                //float[] pdata; //保存每一个box预测向量 长度为net_width
                List<int> classIds = new List<int>(); //保存好的锚框的分类结果
                List<float> confidences = new List<float>(); //保存好的锚框的置信
                List<Rect> bouduary = new List<Rect>();     //保存好的锚框x,y,h,w
                //MessageBox.Show(netOutput.Count().ToString()); //查看网络输出数量,debug
                // 5) 遍历所有预测锚框参数
                //    注：网络的输出格式已经将3个特征图对应的所有box的预测的3种不同锚框，flatten成 二维矩阵
                //        从大特征图开始的展开；
                //先按特征图大小进行for遍历
                for (int s = 0; s < 3; s++)
                {
                    // 获取box个数
                    int grid_x = (int)(netWidth / netStride[s]);
                    int grid_y = (int)(netHeight / netStride[s]);
                    //MessageBox.Show(grid_x.ToString()); //debug用
                    //MessageBox.Show(grid_y.ToString());
                    // 对每个anchor进行遍历
                    for (int anchor = 0; anchor < 3; anchor++)
                    {
                        // 得到anchor高、宽大小
                        double anchor_w = netAnchors[s, anchor * 2];
                        double anchor_h = netAnchors[s, anchor * 2 + 1];
                        // 对每一个box的预测结果进行遍历
                        for (int j = 0; j < grid_y; j++)
                        {
                            for (int i = 0; i < grid_x; i++)
                            {
                                // 在输出结果中获取对应的box的预测结果 1x6的向量
                                Mat pMat = netOutput.Row(r);
                                // 变成array，更好用
                                pMat.GetArray(out float[] pdata);
                                // 第五个即为置信概率
                                double box_score = Sigmoid(pdata[4]);
                                if (box_score > boxThreshold)
                                {
                                    //++num;
                                    // pdata第六个为类别预测的概率，即第五个之后的向量为one-hot输出结果
                                    // 这里只有一类，故直接取pdata[5]，max其是多余的
                                    //float []ppdata = new float[2] {pdata[5],0};
                                    Mat score = new Mat(1, classname.Count(), MatType.CV_32FC1, pdata[5]); //只有一个类别：芯片
                                    Point classIdpoint = new Point();
                                    // 获取最大值及其对应的index即分类的类别id
                                    Cv2.MinMaxLoc(score, out double min_class_score, out double max_class_score, out Point minclassIdpoint, out classIdpoint);
                                    // sigmoid得到分类的概率
                                    max_class_score = Sigmoid((float)max_class_score);
                                    if (max_class_score > boxThreshold)
                                    {

                                        // 是好的锚框，保存
                                        // 计算公式来自于官方，参考loss
                                        double x = (Sigmoid(pdata[0]) * 2 - 0.5 + i) * netStride[s];
                                        double y = (Sigmoid(pdata[1]) * 2 - 0.5 + j) * netStride[s];
                                        double w = Math.Pow(Sigmoid(pdata[2]) * 2.0, 2.0) * anchor_w;
                                        double h = Math.Pow(Sigmoid(pdata[3]) * 2.0, 2.0) * anchor_h;

                                        if (w >= 48 && h >= 48)
                                        {
                                            int left = (int)((x - 0.5 * w) * ratio_w);
                                            int top = (int)((y - 0.5 * h) * ratio_h);
                                            classIds.Add(classIdpoint.X);
                                            confidences.Add((float)max_class_score);
                                            bouduary.Add(new Rect(left, top, (int)(w * ratio_w), (int)(h * ratio_h)));
                                        }
                                    }
                                }
                                ++r;
                            }
                        }
                    }
                }
                // final_idx 保存最终的最好的锚框id
                // nms，非极大值抑制,有很多预测锚框是重叠的，故用nms可得到其中最好的一个锚框
                CvDnn.NMSBoxes(bouduary, confidences, classThreshold, nmsThreshold, out int[] final_idx);
                // MessageBox.Show(Convert.ToString(final_idx.Length)); //debug,得到最终预测数量
                //MessageBox.Show(num.ToString());
                // 根据最终锚框的idx，保存结果
                for (int i = 0; i < final_idx.Length; i++)
                {
                    int idx = final_idx[i];
                    DetectOutput temp = new DetectOutput
                    {
                        id = classIds[idx],   // 修改地方 应该获取类别而不是index
                        confidence = confidences[idx],
                        box = bouduary[idx]
                    };
                    Results.Add(temp);
                }
            }
            if (Results.Count > 0)
            {
                // 排序
                Results.Sort(delegate (DetectOutput x, DetectOutput y)
                {
                    if (x.box.Y >= y.box.Y)
                    {
                        return 1;
                    }
                    else return -1;
                });
                int row_base_Y = Results[0].box.Y, dy = 20;
                List<DetectOutput> temp = new List<DetectOutput>();
                for (int i = 0; i < Results.Count; i++)
                {
                    List<DetectOutput> temp_row = new List<DetectOutput>();
                    while (i < Results.Count && Math.Abs(row_base_Y - Results[i].box.Y) < dy) temp_row.Add(Results[i++]);
                    temp_row.Sort(delegate (DetectOutput x, DetectOutput y)
                    {
                        if (x.box.X >= y.box.X)
                        {
                            return 1;
                        }
                        else return -1;
                    });
                    for (int j = 0; j < temp_row.Count; j++)
                    {
                        temp.Add(temp_row[j]);
                    }
                    if (i < Results.Count) row_base_Y = Results[i].box.Y;
                    --i;
                }
                Results = temp;
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 检测(模板匹配)
        /// </summary>
        /// <param name="ScrImg">原图</param>
        /// <param name="MatchImg">匹配图像</param>
        /// <param name="Results">结果</param>
        public bool DetectMatch(Mat srcImg, Mat tempImg, out List<DetectOutput> Results)
        {
            Results = new List<DetectOutput>();
            int dstImg_rows = srcImg.Rows - tempImg.Rows + 1;
            int dstImg_cols = srcImg.Cols - tempImg.Cols + 1;
            Mat dstImg = new Mat(dstImg_rows, dstImg_cols, MatType.CV_32F, 1);
            Cv2.MatchTemplate(srcImg, tempImg, dstImg, TemplateMatchModes.CCoeffNormed);
            int w = tempImg.Width;
            int h = tempImg.Height;
            Cv2.Normalize(dstImg, dstImg, 0, 1, NormTypes.MinMax, dstImg.Depth());
            Cv2.MinMaxLoc(dstImg, out _, out _, out _, out _);//查找极值
            //result.Set(matchLoc.Y, matchLoc.X, 0);//改变最大值为最小值  
            //循环查找画框显示
            float threshold = 0.90f;
            for (int i = 1; i < dstImg.Rows - tempImg.Rows; i += tempImg.Rows)//行遍历 
            {
                for (int j = 1; j < dstImg.Cols - tempImg.Cols; j += tempImg.Cols)//列遍历
                {
                    Rect roi = new Rect(j, i, tempImg.Cols, tempImg.Rows);        //建立感兴趣
                    Mat RoiResult = new Mat(dstImg, roi);
                    Cv2.MinMaxLoc(RoiResult, out _, out double maxVul, out _, out _);//查找极值
                    if (maxVul > threshold)
                    {
                        DetectOutput temp = new DetectOutput
                        {
                            id = 1,
                            confidence = (float)maxVul,
                            box = new Rect(i, j, w, h)
                        };
                        //Console.WriteLine(i.ToString(),j.ToString());
                        Results.Add(temp);
                    }

                }
            }
            //Console.WriteLine("xxxx"+Results.Count.ToString());
            if (Results.Count > 0) return true;
            return false;
        }
        /// <summary>
        /// 画出锚框
        /// </summary>
        /// <param name="img">输入图像</param> 
        /// <param name="originSize">图像输出大小</param>
        /// <param name="res">锚框,数据为output结构</param>
        /// <param name="isShow">显示结果图片</param>
        /// <param name="isDrawImgCenter">是否显示图像中心</param>
        /// <param name="isDrawLedCenter">是否显示LED中心</param>
        public void DrawPred(ref Mat img, OpenCvSharp.Size originSize, List<DetectOutput> res, bool isShow = false, bool isDrawLedCenter = false, bool isDrawImgCenter = true)
        {
            if (res != null)
            {
                for (int i = 0; i < res.Count; i++)
                {
                    int left = res[i].box.X, top = res[i].box.Y;
                    Cv2.Rectangle(img, res[i].box, new Scalar(0, 255, 0), thickness: 1, LineTypes.Link8);
                    Cv2.PutText(img, (i + 1).ToString(), new OpenCvSharp.Point(left, top), HersheyFonts.HersheySimplex, fontScale: 0.35, color: new Scalar(0, 0, 255), thickness: 1);
                    if (isDrawLedCenter)
                    {
                        // 绘制十字标
                        int x = res[i].box.X + res[i].box.Width / 2, y = res[i].box.Y + res[i].box.Height / 2;
                        OpenCvSharp.Point py1 = new OpenCvSharp.Point(x, y - 5);
                        OpenCvSharp.Point py2 = new OpenCvSharp.Point(x, y + 5);
                        OpenCvSharp.Point px1 = new OpenCvSharp.Point(x - 5, y);
                        OpenCvSharp.Point px2 = new OpenCvSharp.Point(x + 5, y);
                        Cv2.Line(img, py1, py2, new Scalar(255, 0, 0)); Cv2.Line(img, px1, px2, new Scalar(255, 0, 0));
                    }
                }
                if (isDrawImgCenter)
                {
                    // 绘制十字标
                    int x = img.Width, y = img.Height;
                    OpenCvSharp.Point py1 = new OpenCvSharp.Point(x / 2, 10);
                    OpenCvSharp.Point py2 = new OpenCvSharp.Point(x / 2, y - 10);
                    OpenCvSharp.Point px1 = new OpenCvSharp.Point(10, y / 2);
                    OpenCvSharp.Point px2 = new OpenCvSharp.Point(x - 10, y / 2);
                    Cv2.Line(img, py1, py2, new Scalar(0, 0, 255)); Cv2.Line(img, px1, px2, new Scalar(0, 0, 255));
                }
                Cv2.Resize(img, img, originSize);
            }

            if (isShow)
            {
                Cv2.ImShow("test", img);
                Cv2.WaitKey(0);
            }
        }
        /// <summary>
        ///  根据像素位置得到所在锚框
        /// </summary>
        /// <param name="x">像素坐标x</param>
        /// <param name="y">像素坐标y</param>
        /// <param name="bound">锚框</param>
        /// <returns> index，若为-1表示无
        /// </returns>
        public int FindBox(int x, int y, List<DetectOutput> bound)
        {
            if (bound.Count > 0)
            {
                for (int i = 0; i < bound.Count; i++)
                {
                    if (x >= bound[i].box.X && y >= bound[i].box.Y)
                    {
                        if (x <= bound[i].box.Right && y <= bound[i].box.Bottom)
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }
    }
}