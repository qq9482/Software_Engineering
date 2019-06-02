using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gszb
{
    class Class2
    {
        //度分秒转化为十进制
        public double DuZhuanShi(double degree, double minute, double second)
        {
            double shi = second / 3600 + minute / 60 + degree;
            return shi;
        }

        //十进制转化为度分秒
        public void ShiZhuanDu(double shi, ref double degree, ref double minute, ref double second)
        {
            degree = (int)shi;
            minute = (int)((shi - degree) * 60);
            second = ((shi - degree) * 60 - minute) * 60;
        }

        //弧度转化为十进制
        public double HuZhuanShi(double hu)
        {
            double shi = hu / Math.PI * 180;
            return shi;
        }

        //十进制转化为弧度
        public double ShiZhuanHu(double shi)
        {
            double hu = shi * Math.PI / 180;
            return hu;
        }

        //度分秒转化为弧度
        public double DuZhuanHu(double degree, double minute, double second)
        {
            double shi = DuZhuanShi(degree, minute, second);
            double hu = ShiZhuanHu(shi);
            return hu;
        }

        //弧度转化为度分秒
        public void HuZhuanDu(double hu, ref double degree, ref double minute, ref double second)
        {
            double shi = HuZhuanShi(hu);
            ShiZhuanDu(shi, ref degree, ref minute, ref second);
        }
    }
}
