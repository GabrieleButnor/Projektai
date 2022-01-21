using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testavimas
{
    public class Logaritmas
    {
        public double Pagrindas;
        public double X;
        public Logaritmas(double pagrindas, double x)
        {
            if (x <= 0)
            {
                throw new Exception("Blogas skaicius (per mazas)");
            }
            if (pagrindas <= 0)
            {
                throw new Exception("Blogas pagrindas (per mazas)");
            }
            if (pagrindas == 1)
            {
                throw new Exception("Blogas pagrindas (lygu 1)");
            }
            this.Pagrindas = pagrindas;
            this.X = x;
        }
        public double Lygu()
        {
            return Math.Log(X, Pagrindas);
        }
        public string ToString()
        {
            return string.Format("Pagrindas = {0}, skaicius = {1}", this.Pagrindas, this.X);
        }

        public double LogaritmuSuma(double pagrindas, double x)
        {
            Logaritmas kitas = new Logaritmas(pagrindas, x);
            return this.Lygu() + kitas.Lygu();
        }
        public Logaritmas NaujasLogaritmuSuma(double pagrindas, double x)
        {
            Logaritmas kitas = new Logaritmas(pagrindas, x);
            if (kitas.Pagrindas == this.Pagrindas)
            {
                
                return new Logaritmas(pagrindas, this.X * kitas.X);
            }
            else
            {
                throw new Exception("Siam metodui pagrindai turi buti vienodi");
            }
        }
        public double LogaritmuSuma(Logaritmas kitas)
        {
            return this.Lygu() + kitas.Lygu();
        }
        public Logaritmas NaujasLogaritmuSuma(Logaritmas kitas)
        {
            if (kitas.Pagrindas == this.Pagrindas)
            {
                return new Logaritmas(this.Pagrindas, this.X * kitas.X);
            }
            else
            {
                throw new Exception("Siam metodui pagrindai turi buti vienodi");
            }
        }
        public double LogaritmuSkirtumas(double pagrindas, double x)
        {
            Logaritmas kitas = new Logaritmas(pagrindas, x);
            return this.Lygu() - kitas.Lygu();
        }
        public Logaritmas NaujasLogaritmuSkirtumas(double pagrindas, double x)
        {
            Logaritmas kitas = new Logaritmas(pagrindas, x);
            if (kitas.Pagrindas == this.Pagrindas)
            {
                return new Logaritmas(pagrindas, this.X / kitas.X);
            }
            else
            {
                throw new Exception("Siam metodui pagrindai turi buti vienodi");
            }
        }
        public double LogaritmuSkirtumas(Logaritmas kitas)
        {
            return this.Lygu() - kitas.Lygu();
        }
        public Logaritmas NaujasLogaritmuSkirtumas(Logaritmas kitas)
        {
            if (kitas.Pagrindas == this.Pagrindas)
            {
                return new Logaritmas(this.Pagrindas, this.X / kitas.X);
            }
            else
            {
                throw new Exception("Siam metodui pagrindai turi buti vienodi");
            }
        }
        public double LogaritmoLaipsnis(double n)
        {
            return n * this.Lygu();
        }
        public Logaritmas NaujasLogaritmoLaipsnis(double n)
        {
            return new Logaritmas(this.Pagrindas, Math.Pow(this.X, n));
        }
        public double PagrindoLaipsnis(double n)
        {
            if (n == 0)
            {
                throw new Exception("n negali buti lygu 0");
            }
            return 1 / n * this.Lygu();
        }
        public Logaritmas NaujasPagrindoLaipsnis(double n)
        {
            if (n == 0)
            {
                throw new Exception("n negali buti lygu 0");
            }
            return new Logaritmas(Math.Pow(this.Pagrindas, n), this.X);
        }
    }
}
