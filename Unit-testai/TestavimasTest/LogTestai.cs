using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Testavimas;

namespace TestavimasTest
{
    [TestClass]
    public class LogTestai
    {
        [TestMethod]
        public void Lygu()
        {
            double pagrindas = 2;
            double x = 5;
            double expected = Math.Log(x, pagrindas);
            Logaritmas loga = new Logaritmas(pagrindas, x);

            double actual = loga.Lygu();

            Assert.AreEqual(expected, actual, 0.001);

        }
        [TestMethod]
        public void BlogasSukurimas()
        {

            Assert.ThrowsException<Exception>(() => new Logaritmas(-2, -5));
            Assert.ThrowsException<Exception>(() => new Logaritmas(-2, 5));
            Assert.ThrowsException<Exception>(() => new Logaritmas(2, -5));
            Assert.ThrowsException<Exception>(() => new Logaritmas(1, 4));

        }
        [TestMethod]
        public void NaujasLogSuma()
        {
            double pagrindas = 2;
            double x = 5;
            double y = 7;
            Logaritmas loga = new Logaritmas(pagrindas, x);
            Logaritmas expected = new Logaritmas(2, 35);

            Logaritmas actual = loga.NaujasLogaritmuSuma(pagrindas, y);

            Assert.ThrowsException<Exception>(() => loga.NaujasLogaritmuSuma(6, 4));
            Assert.AreEqual(expected.Lygu(), actual.Lygu());

        }
        [TestMethod]
        public void LogSkirtumasTeisinga2()
        {
            double pagrindas = 2;
            double x = 16;
            double y = 8;
            Logaritmas log1 = new Logaritmas(pagrindas, x);
            Logaritmas log2 = new Logaritmas(pagrindas, y);
            double expected = 1;

            double actual = log1.LogaritmuSkirtumas(log2);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NaujasLogSumaBlogas()
        {
            double pagrindas = 2;
            double pagrindas2 = 3;
            double x = 16;
            double y = 8;
            Logaritmas log1 = new Logaritmas(pagrindas, x);
            Logaritmas log2 = new Logaritmas(pagrindas2, y);
            Logaritmas log3 = new Logaritmas(2, 4);
            Assert.AreEqual(log1.NaujasLogaritmuSuma(log3).X, log1.NaujasLogaritmuSuma(new Logaritmas(2, 4)).X);
            Assert.ThrowsException<Exception>(() => log1.NaujasLogaritmuSuma(log2));
        }
        [TestMethod]
        public void LogaritmuSuma()
        {
            double pagrindas = 2;
            double x = 16;
            double y = 8;
            Logaritmas log1 = new Logaritmas(pagrindas, x);
            Logaritmas log2 = new Logaritmas(pagrindas, y);
            double expected = 7;

            double actual = log1.LogaritmuSuma(log2);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LogaritmuSuma2()
        {
            double pagrindas = 2;
            double x = 16;
            double y = 8;
            Logaritmas log1 = new Logaritmas(pagrindas, x);
            double expected = 7;

            double actual = log1.LogaritmuSuma(2, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PagrindoLaipsnisBlogas()
        {
            Logaritmas loga = new Logaritmas(2, 5);
            Logaritmas loga1 = new Logaritmas(2, 5);
            Assert.AreEqual(loga.PagrindoLaipsnis(2), 0.5 * Math.Log(5, 2));
            Assert.AreEqual(loga.NaujasPagrindoLaipsnis(2).Pagrindas, loga.NaujasPagrindoLaipsnis(2).Pagrindas);
            Assert.ThrowsException<Exception>(() => loga.PagrindoLaipsnis(0));
            Assert.ThrowsException<Exception>(() => loga.NaujasPagrindoLaipsnis(0));
        }
        [TestMethod]
        public void NaujasLogaritmoLaipsnis()
        {
            Logaritmas loga = new Logaritmas(2, 8);
            double n = 2;
            Logaritmas expected = new Logaritmas(2, 64);
            Logaritmas actual = loga.NaujasLogaritmoLaipsnis(n);

            Assert.AreEqual(expected.Lygu(), actual.Lygu());
        }
        [TestMethod]
        public void LogaritmoLaipsnis()
        {
            Logaritmas loga = new Logaritmas(2, 8);
            double n = 2;
            double expected = 6;
            double actual = loga.LogaritmoLaipsnis(n);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LogaritmuSkirtumas()
        {
            Logaritmas loga = new Logaritmas(2, 8);
            double expected = 0;
            double actual = loga.LogaritmuSkirtumas(2, 8);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void NaujasLogaritmuSkirtumas()
        {
            Logaritmas loga = new Logaritmas(2, 8);
            Logaritmas expected = new Logaritmas(2, 4);
            Logaritmas actual = loga.NaujasLogaritmuSkirtumas(2, 2);

            Assert.AreEqual(expected.Pagrindas, actual.Pagrindas);
            Assert.ThrowsException<Exception>(() => loga.NaujasLogaritmuSkirtumas(5, 4));
        }


        [TestMethod]
        public void NaujasLogaritmuSkirtumas1Exception()
        {
            Logaritmas loga5 = new Logaritmas(2, 8);
            Logaritmas loga2 = new Logaritmas(2, 4);
            Logaritmas expected2 = new Logaritmas(5, 1);
            Assert.ThrowsException<Exception>(() => loga5.NaujasLogaritmuSkirtumas(expected2));
            Assert.AreEqual(loga5.NaujasLogaritmuSkirtumas(loga2).X, 2);
        }

        [TestMethod]
        public void ToStringPalyginimas()
        {
            Logaritmas loga = new Logaritmas(2, 8);
            string loga1 = "Pagrindas = 2, skaicius = 8";

            Assert.AreEqual(loga1, loga.ToString());
        }

    }
}
