using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gszb
{
    class Class1
    {
         public double p = 206264.80625;
        public struct Ellipse
        {
            public string Name;//椭球名称
            public double _a;//长轴半径
            public double _b;//短轴半径
            public double _e2;//第2偏心率
            public double _e1;//第1偏心率
            public double _f;//扁率
            public double _c;//极曲率半径
        }

        public struct Point
        {
            public double x;
            public double y;
            public double z;
            public double B;
            public double L;
            public double H;
        }

        //椭球参数设置.......
        public Ellipse SetEllipse(int _izWhat)
        {
            Ellipse _re = new Ellipse();
            switch (_izWhat)
            {
                case 0:
                    {
                        _re.Name = "克拉索夫斯基";
                        _re._a = 6378245.0000;
                        _re._b = 6356863.01877;
                        _re._e2 = 0.00673852541468;
                        _re._e1 = 0.006693421622966;
                        _re._f = 0;
                        _re._c = 6399698.901782;
                        break;
                    }
                case 1:
                    {
                        _re.Name = "Bessel椭球";
                        _re._a = 6377397.155;
                        _re._b = 6356078.963;
                        _re._e2 = 0.0067192188;
                        _re._e1 = 0;
                        _re._f = 0;
                        _re._c = 0;
                        break;
                    }
                case 2:
                    {
                        _re.Name = "西安80/1975年国际椭球";
                        _re._a = 6378140.0000;
                        _re._b = 6356755.288158;
                        _re._e2 = 0.00673950182;
                        _re._e1 = 0;
                        _re._f = 0;
                        _re._c = 0;
                        break;
                    }
                case 3:
                    {
                        _re.Name = "WGS-84椭球";
                        _re._a = 6378137.0000;
                        _re._b = 6356752.3142;
                        _re._e2 = 0;
                        _re._e1 = 0;
                        _re._f = 0;
                        _re._c = 0;
                        break;
                    }
            }
            return _re;
        }

        public double Long(Ellipse _re, double B)
        {
            double e1 = _re._e1;
            double e2 = _re._e2;
            double a = _re._a;
            double b = _re._b;
            double a0 = 1 + 3 / 4 * Math.Pow(e1, 2.0) + 45 / 64 * Math.Pow(e1, 4.0) + 175 / 256 * Math.Pow(e1, 6.0) +
                11025 / 16384 * Math.Pow(e1, 8.0) + 43659 / 65336 * Math.Pow(e1, 10.0) + 693693 / 1048576 * Math.Pow(e1, 12.0)
                + 2760615 / 41944304 * Math.Pow(e1, 14.0) + 703956835 / 1073741824 * Math.Pow(e1, 16.0);
            double a1 = 3 / 4 * Math.Pow(e1, 2.0) + 15 / 16 * Math.Pow(e1, 4.0) + 525 / 512 * Math.Pow(e1, 6.0) +
                2205 / 2048 * Math.Pow(e1, 8.0) + 72765 / 65336 * Math.Pow(e1, 10.0) + 297297 / 262144 * Math.Pow(e1, 12.0)
                + 19324305 / 16777216 * Math.Pow(e1, 14.0);
            double a2 = 15 / 16 * Math.Pow(e1, 4.0) + 105 / 256 * Math.Pow(e1, 6.0) + 2205 / 4096 * Math.Pow(e1, 8.0)
                + 10395 / 16384 * Math.Pow(e1, 10.0) + 1486485 / 2097152 * Math.Pow(e1, 12.0) + 6441435 / 8388608 * Math.Pow(e1, 14.0);
            double a3 = 35 / 512 * Math.Pow(e1, 6.0) + 315 / 2048 * Math.Pow(e1, 8.0) + 31185 / 131072 * Math.Pow(e1, 10.0)
                + 165165 / 524288 * Math.Pow(e1, 12.0) + 6441435 / 16777216 * Math.Pow(e1, 14.0);
            double a4 = 315 / 16348 * Math.Pow(e1, 8.0) + 3465 / 65536 * Math.Pow(e1, 10.0) + 99099 / 1048576 * Math.Pow(e1, 12.0)
                + 585585 / 4194304 * Math.Pow(e1, 14.0);
            double a5 = 693 / 131072 * Math.Pow(e1, 10.0) + 9009 / 524288 * Math.Pow(e1, 12.0) + 585585 / 16777216 * Math.Pow(e1, 14.0);
            double a6 = 3003 / 2097152 * Math.Pow(e1, 12.0) + 45045 / 8388608 * Math.Pow(e1, 14.0);
            double a7 = 6435 / 16777216 * Math.Pow(e1, 14.0);
            double X = a * (1 - Math.Pow(e1, 2.0)) * (a0 * B - 1 / 2 * a1 * Math.Sin(2 * B) + 1 / 4 * a2 * Math.Sin(4 * B)
                - 1 / 6 * a3 * Math.Sin(6 * B) + 1 / 8 * a4 * Math.Sin(8 * B) - 1 / 10 * a5 * Math.Sin(10 * B)
                + 1 / 12 * a6 * Math.Sin(12 * B));
            return X;
        }
       
        public void zbzs(Ellipse _re, double L, double B, double L0, ref double x, ref double y)
        {
            double e1 = _re._e1;
            double e2 = _re._e2;
            double a = _re._a;
            double b = _re._b;            
            double l = L - L0;
            Class2 r = new Class2();
            l = r.ShiZhuanHu(l);
            B = r.ShiZhuanHu(B);
            double N = a / Math.Sqrt(1 - Math.Pow(e1, 2.0) * Math.Pow(Math.Sin(B), 2.0));
            double t = Math.Tan(B);
            double n = e2 * Math.Cos(B);
            double X = Long(_re, B);

            x = X + N / 2 * Math.Sin(B) * Math.Cos(B) * Math.Pow(l, 2.0) + N / 24 * Math.Sin(B) * Math.Pow(Math.Cos(B), 3.0) * (5 - Math.Pow(t, 2.0) + 9 * Math.Pow(n, 2.0)
                + 4 * Math.Pow(n, 4.0)) * Math.Pow(l, 4.0) + N / 720 * Math.Sin(B) * Math.Pow(Math.Cos(B), 5.0) * (61 - 58 * Math.Pow(t, 2.0)
                + Math.Pow(t, 4.0)) * Math.Pow(l, 6.0);
            y = N * Math.Cos(B) * l + N / 6 * Math.Pow(Math.Cos(B), 3.0) * (1 - Math.Pow(t, 2.0) + Math.Pow(n, 2.0)) * Math.Pow(l, 3.0) + N / 120 * Math.Pow(Math.Cos(B), 5.0)
                * (5 - 18 * Math.Pow(t, 2.0) + Math.Pow(t, 4.0) + 14 * Math.Pow(n, 2.0) - 58 * Math.Pow(t, 2.0) * Math.Pow(n, 2.0)) * Math.Pow(l, 5.0);
        }
       
        public void zbfs(Ellipse _re, double x, double y, ref double L, ref double B)
        {
            double e1 = _re._e1;
            double e2 = _re._e2;
            double a = _re._a;
            double b = _re._b;

            double β0 = 1 - 3 * e2 / 4 + 45 * Math.Pow(e2, 2) - 175 * Math.Pow(e2, 3) / 256 + 11025 * Math.Pow(e2, 4) / 16384;
            double C0 = e2 * a * a / b;
            double C1 = 3 * e1 / 8 + 3 * Math.Pow(e1, 2) / 16 + 213 * Math.Pow(e1, 3) / 2048 + 255 * Math.Pow(e1, 4) / 4096;
            double C2 = 21 * Math.Pow(e1, 2) / 256 + 21 * Math.Pow(e1, 3) / 256 + 533 * Math.Pow(e1, 4) / 8192;
            double C3 = 151 * Math.Pow(e1, 3) / 6144 + 151 * Math.Pow(e1, 4) / 4096;
            double C4 = 1097 * Math.Pow(e1, 4) / 131072;
            double B0 = x / C0;
            double Bf = B0 + C1 * Math.Sin(2 * B0) + C2 * Math.Sin(4 * B0) + C3 * Math.Sin(6 * B0) + C4 * Math.Sin(8 * B0);

            //double B0 = x / (6367558.4969) * p;
            //double Bf = (B0 + (50221746 + (293622 + (2350 + 22 * Math.Cos(b) * Math.Cos(b)) * Math.Cos(b) * Math.Cos(b)) *
            //    Math.Cos(b) * Math.Cos(b)) * Math.Sin(b) * Math.Cos(b) * Math.Pow(10, -10) * p) / p;
            double tf = Math.Tan(Bf);
            double w = Math.Sqrt(1 - e1 * Math.Sin(Bf) * Math.Sin(Bf));
            double Nf = a / Math.Sqrt(1 - e1 * w * w);
            double Mf = a * (1 - e1) / Math.Pow(w, 3);
            double nf = Math.Sqrt(e2) * Math.Cos(Bf);//y

            B = Bf - tf * y * y / (2 * Mf * Nf) + (5 + 3 * tf * tf + nf * nf - 9 * nf * nf * tf * tf)  /
                (24 * Mf * Nf * Nf * Nf) + (61 + 90 * tf * tf + 45 * tf * tf * tf * tf * Math.Pow(y, 6)) / (720 * Mf * Math.Pow(Nf, 5));
            L = y / (Nf * Math.Cos(Bf)) - (1 + 2 * tf * tf + nf * nf) * Math.Pow(y, 3) / (6 * Nf * Nf * Nf * Math.Cos(Math.Pow(Bf, 3))) +
                (5 + 28 * tf * tf + 24 * tf * tf * tf * tf + 6 * nf * nf + 8 * nf * nf * tf * tf) * Math.Pow(y, 5) /
                 (120 * Math.Pow(Nf, 5) * Math.Cos(Bf));
        }
      
        public Point ddzkj(Ellipse _re, Point _p)
        {
            Class2 r = new Class2();
            _p.B = r.ShiZhuanHu(_p.B);
            _p.L = r.ShiZhuanHu(_p.L);
            Point _P = new Point();
            double N = _re._a / Math.Sqrt(1 - _re._e1 * Math.Sin(_p.B) * Math.Sin(_p.B));
            _P.x = (N + _p.H) * Math.Cos(_p.B) * Math.Cos(_p.L);
            _P.y = (N + _p.H) * Math.Cos(_p.B) * Math.Sin(_p.L);
            _P.z = (N * (1 - _re._e1) + _p.H) * Math.Sin(_p.B);
            return _P;
        }

       
        public Point kjzdd(Ellipse _re, Point _p)
        {
            Point _P = new Point();
            //L
            _P.L = 180 - Math.Asin(_p.y / Math.Sqrt(_p.x * _p.x + _p.y * _p.y)) / Math.PI * 180;
            //B
            double B = Math.Atan(_p.z / Math.Sqrt(_p.x * _p.x + _p.y * _p.y));
            double B1 = Math.Atan(1 / Math.Sqrt(_p.x * _p.x + _p.y * _p.y) * (_p.z + _re._c * _re._e1 * Math.Tan(B) / Math.Sqrt(1 + _re._e1 + Math.Tan(B) * Math.Tan(B))));
            while (B1 - B == 0)
            {
                B = B1;
                B1 = Math.Atan(1 / Math.Sqrt(_p.x * _p.x + _p.y * _p.y) * (_p.z + _re._c * _re._e1 * Math.Tan(B) / Math.Sqrt(1 + _re._e1 + Math.Tan(B) * Math.Tan(B))));
            }
            _P.B = B1 / Math.PI * 180;
            //H
            double N = _re._a / Math.Sqrt(1 - _re._e1 * Math.Sin(B1) * Math.Sin(B1));
            _P.H = Math.Sqrt(_p.x * _p.x + _p.y * _p.y) / Math.Cos(B1) - N;
            return _P;
        }
    }
}
