
namespace UpComputerMS
{
    // LED数据结构体
    public class LedParameters
    {
        //public int Led_num;
        public int Led_type;
        public int Pix_X, Pix_Y;
        public int X,Y;
        public double Height,Width;

        public LedParameters() { }
        public LedParameters(int _LedType,int _PixX,int _PixY,int _X,int _Y,double _Height,double _Width)
        {
            //Led_num = _LedNum;
            Led_type = _LedType;
            Pix_X = _PixX;
            Pix_Y = _PixY;
            X = _X;
            Y = _Y;
            Height = _Height;
            Width = _Width;
        }
    }
}
