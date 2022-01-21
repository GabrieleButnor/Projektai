using System;


namespace Testavimas
{
    public class Circle
    {
        public Circle()
        {

        }

        public double CircleDiameter(double r)
        {
            if(r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            double d = 2 * r;
            d = Math.Round(d, 3);
            return d;
        }

        public double CirclePerimeter(double r)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            double C = 2 * r * Math.PI;
            C = Math.Round(C, 3);
            return C;
        }

        public double CircleArea(double r)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            double S = Math.PI * r * r;
            S = Math.Round(S, 3);
            return S;
        }

        public double NotchAreaLength(double r, double notchLeght)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            if(notchLeght < 0)
            {
                throw new Exception("Netinkamas išpjovos ilgis.");
            }
            double C = CirclePerimeter(r);
            if(notchLeght >  C)
            {
                throw new Exception("Išpjovos ilgis viršyje skritulio ilgį.");
            }
            else
            {
                double NotchS = r * notchLeght / 2;
                NotchS = Math.Round(NotchS, 3);
                return NotchS;
            }
        }

        public double NotchAreaAngel(double r, double a)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            if (a < 0 || a > 360)
            {
                throw new Exception("Netinkamas kampas.");
            }
            double NotchS = (Math.PI * r * r * a) / 360; 
            NotchS = Math.Round(NotchS, 3);
            return NotchS;
        }

        public double NotchArcLengthAngel(double r, double a)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            if (a < 0 || a > 360)
            {
                throw new Exception("Netinkamas kampas.");
            }
            double NotchArc = (Math.PI * r / 180) * a;
            NotchArc = Math.Round(NotchArc, 3);
            return NotchArc;
        }


        public double CutoutArea(double r, double a)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            if (a < 0 || a > 360)
            {
                throw new Exception("Netinkamas kampas.");
            }
            double CutoutS = ((r * r) / 2) * ((Math.PI * a / 180) - Math.Sin(a));
            CutoutS = Math.Round(CutoutS, 3);
            return CutoutS;
        }

        public double SphereArea(double r)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            double S = 4 * Math.PI * r * r;
            S = Math.Round(S, 3);
            return S;
        }

        public double SphereVolume(double r)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            double V = Math.PI * r * r * r * 4 / 3;
            V = Math.Round(V, 3);
            return V;
        }


        public double SphereCoutoutArea(double r, double cutOutH)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            if(cutOutH < 0 || cutOutH > (2 * r))
            {
                throw new Exception("Netinkamos nuopjovos aukštis.");
            }
            double S = 2 * Math.PI * r * cutOutH;
            S = Math.Round(S, 3);
            return S;
        }

        public double SphereCoutoutVolume(double r, double cutOutH)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            if (cutOutH < 0 || cutOutH > (2 * r))
            {
                throw new Exception("Netinkamos nuopjovos aukštis.");
            }
            double V = Math.PI * cutOutH * cutOutH * (r - (cutOutH / 3));
            V = Math.Round(V, 3);
            return V;
        }


        public double SphereNotchArea(double r, double cutOutH, double rNotch)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            if (cutOutH < 0 || cutOutH > (2 * r))
            {
                throw new Exception("Netinkamos nuopjovos aukštis.");
            }
            if (rNotch < 0 || rNotch > r)
            {
                throw new Exception("Netinkamos išpjovos spindulys.");
            }
            double S = Math.PI * r * (2 * cutOutH + rNotch);
            S = Math.Round(S, 3);
            return S;
        }

        public double SphereNotchVolume(double r, double cutOutH)
        {
            if (r < 0)
            {
                throw new Exception("Netinkamas spindulys.");
            }
            if (cutOutH < 0 || cutOutH > (2 * r))
            {
                throw new Exception("Netinkamos nuopjovos aukštis.");
            }
            double V = Math.PI * r * r * cutOutH * 2 / 3;
            V = Math.Round(V, 3);
            return V;
        }
    }

}
