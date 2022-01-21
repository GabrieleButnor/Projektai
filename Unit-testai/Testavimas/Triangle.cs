using System;
using System.ComponentModel;

namespace Testavimas
{
    public class Triangle
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;
        private double _halfPem;

        public Triangle(double a, double b, double c)
        {
            if(a <= 0 || b <= 0 || c <= 0) throw new ArgumentOutOfRangeException();
            if(!IsValid(a, b, c)) throw new ArgumentException();
            _a = a;
            _b = b;
            _c = c;
            _halfPem = (_a + _b + _c) / 2;
        }

        public double GetArea()
        {
            return Math.Sqrt(_halfPem * (_halfPem - _a) * (_halfPem - _b) * (_halfPem - _c));
        }

        public double GetPerimeter()
        {
            return _a + _b + _c;
        }

        public double[] GetAngles()
        {
            double[] angles = new double[3];
            angles[0] = GetAngle(_a, _b, _c);
            angles[1] = GetAngle(_b, _c, _a);
            angles[2] = 180 - angles[0] - angles[1];
            return angles;
        }

        private double GetAngle(double a, double b, double c)
        {
            double cos = (c * c - a * a - b * b) / (-2 * a * b);
            return Math.Acos(cos) * 180 / Math.PI;
        }
        public double GetOuterCircleRadius()
        {
            return (_a * _b * _c) / (4 * GetArea());
        }

        public double GetInnerCircleRadius()
        {
            return GetArea() / _halfPem;
        }

        private bool IsValid(double a, double b, double c)
        {
            if(a >= b && a >= c)
                return b + c >= a;
            if(b >= a && b >= c)
                return a + c >= b;
            return a + b >= c;
        }

        public bool IsSquare()
        {
            if(_a >= _b && _a >= _c)
                return Math.Pow(_b, 2) + Math.Pow(_c, 2) == Math.Pow(_a, 2);
            if(_b >= _a && _b >= _c)
                return Math.Pow(_a, 2) + Math.Pow(_c, 2) == Math.Pow(_b, 2);
            return Math.Pow(_a, 2) + Math.Pow(_b, 2) == Math.Pow(_c, 2);
        }
        

    }
}