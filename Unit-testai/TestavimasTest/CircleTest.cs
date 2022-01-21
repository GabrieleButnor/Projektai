using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testavimas;


namespace TestavimasTest
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void CircleDiameter_Int()
        {
            double r = 4;
            double expected = 8;
            Circle circle = new Circle();

            double actual = circle.CircleDiameter(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void CircleDiameter_Double()
        {
            double r = 13.55;
            double expected = 27.1;
            Circle circle = new Circle();

            double actual = circle.CircleDiameter(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void CircleDiameter_Negative()
        {
            double r = -10;
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.CircleDiameter(r));
        }

        //---

        [TestMethod]
        public void CirclePerimeter_Int()
        {
            double r = 4;
            double expected = 25.133;
            Circle circle = new Circle();

            double actual = circle.CirclePerimeter(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void CirclePerimeter_Double()
        {
            double r = 13.55;
            double expected = 85.137;
            Circle circle = new Circle();

            double actual = circle.CirclePerimeter(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void CirclePerimeter_Negative()
        {
            double r = -10;
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.CirclePerimeter(r));
        }

        //---

        [TestMethod]
        public void CircleArea_Int()
        {
            double r = 4;
            double expected = 50.265;
            Circle circle = new Circle();

            double actual = circle.CircleArea(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void CircleArea_Double()
        {
            double r = 13.55;
            double expected = 576.804;
            Circle circle = new Circle();

            double actual = circle.CircleArea(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void CircleArea_Negative()
        {
            double r = -10;
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.CircleArea(r));
        }

        //---

        [TestMethod]
        public void NotchAreaLength_Int()
        {
            double r = 4;
            double l = 6;
            double expected = 12;
            Circle circle = new Circle();

            double actual = circle.NotchAreaLength(r, l);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void NotchAreaLength_Double()
        {
            double r = 13.55;
            double l = 6.7;
            double expected = 45.393;
            Circle circle = new Circle();

            double actual = circle.NotchAreaLength(r,l);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void NotchAreaLength_Over()
        {
            double r = 4;
            double l = 30;
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.NotchAreaLength(r, l));
        }


        [TestMethod]
        public void NotchAreaLength_Incorect()
        {
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.NotchAreaLength(-9, 2));
            Assert.ThrowsException<Exception>(() => circle.NotchAreaLength(9, -2));
            Assert.ThrowsException<Exception>(() => circle.NotchAreaLength(-9, -2));
        }

        //---

        [TestMethod]
        public void NotchAreaAngel_Int()
        {
            double r = 14;
            double a = 30;
            double expected = 51.313;
            Circle circle = new Circle();

            double actual = circle.NotchAreaAngel(r, a);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void NotchAreaAngel_Double()
        {
            double r = 13.55;
            double a = 10.15;
            double expected = 16.263;
            Circle circle = new Circle();

            double actual = circle.NotchAreaAngel(r, a);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void NotchAreaAngel_Incorect()
        {
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.NotchAreaAngel(-9, 2));
            Assert.ThrowsException<Exception>(() => circle.NotchAreaAngel(9, -20));
            Assert.ThrowsException<Exception>(() => circle.NotchAreaAngel(-9, -20));
            Assert.ThrowsException<Exception>(() => circle.NotchAreaAngel(9, 450));
        }

        //---

        [TestMethod]
        public void NotchArcLengthAngel_Int()
        {
            double r = 7;
            double a = 30;
            double expected = 3.665;
            Circle circle = new Circle();

            double actual = circle.NotchArcLengthAngel(r, a);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void NotchArcLengthAngel_Double()
        {
            double r = 13.55;
            double a = 10.15;
            double expected = 2.4;
            Circle circle = new Circle();

            double actual = circle.NotchArcLengthAngel(r, a);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void NotchArcLengthAngel_Incorect()
        {
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.NotchArcLengthAngel(-9, 2));
            Assert.ThrowsException<Exception>(() => circle.NotchArcLengthAngel(9, -20));
            Assert.ThrowsException<Exception>(() => circle.NotchArcLengthAngel(-9, -20));
            Assert.ThrowsException<Exception>(() => circle.NotchArcLengthAngel(9, 450));
        }

        //---

        [TestMethod]
        public void CutoutArea_Int()
        {
            double r = 7;
            double a = 30;
            double expected = 37.035;
            Circle circle = new Circle();

            double actual = circle.CutoutArea(r, a);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void CutoutArea_Double()
        {
            double r = 13.55;
            double a = 10.15;
            double expected = 77.155;
            Circle circle = new Circle();

            double actual = circle.CutoutArea(r, a);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void CutoutArea_Incorect()
        {
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.CutoutArea(-9, 2));
            Assert.ThrowsException<Exception>(() => circle.CutoutArea(9, -20));
            Assert.ThrowsException<Exception>(() => circle.CutoutArea(-9, -20));
            Assert.ThrowsException<Exception>(() => circle.CutoutArea(9, 450));
        }

        //---

        [TestMethod]
        public void SphereArea_Int()
        {
            double r = 4;
            double expected = 201.062;
            Circle circle = new Circle();

            double actual = circle.SphereArea(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereArea_Double()
        {
            double r = 3.55;
            double expected = 158.368;
            Circle circle = new Circle();

            double actual = circle.SphereArea(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereArea_Negative()
        {
            double r = -10;
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.SphereArea(r));
        }

        //---

        [TestMethod]
        public void SphereVolume_Int()
        {
            double r = 4;
            double expected = 268.083;
            Circle circle = new Circle();

            double actual = circle.SphereVolume(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereVolume_Double()
        {
            double r = 3.55;
            double expected = 187.402;
            Circle circle = new Circle();

            double actual = circle.SphereVolume(r);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereVolume_Incorect()
        {
            double r = -10;
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.SphereVolume(r));
        }

        //---

        [TestMethod]
        public void SphereCoutoutArea_Int()
        {
            double r = 4;
            double h = 6;
            double expected = 150.796;
            Circle circle = new Circle();

            double actual = circle.SphereCoutoutArea(r, h);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereCoutoutArea_Double()
        {
            double r = 3.55;
            double h = 2.1;
            double expected = 46.841;
            Circle circle = new Circle();

            double actual = circle.SphereCoutoutArea(r, h);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereCoutoutArea_Negative()
        {
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.SphereCoutoutArea(-9, 3));
            Assert.ThrowsException<Exception>(() => circle.SphereCoutoutArea(9, -3));
            Assert.ThrowsException<Exception>(() => circle.SphereCoutoutArea(-9, -3));
            Assert.ThrowsException<Exception>(() => circle.SphereCoutoutArea(9, 30));
        }

        //---

        [TestMethod]
        public void SphereCoutoutVolume_Int()
        {
            double r = 4;
            double h = 6;
            double expected = 226.195;
            Circle circle = new Circle();

            double actual = circle.SphereCoutoutVolume(r, h);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereCoutoutVolume_Double()
        {
            double r = 3.55;
            double h = 2.1;
            double expected = 39.485;
            Circle circle = new Circle();

            double actual = circle.SphereCoutoutVolume(r, h);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereCoutoutVolume_Incorect()
        {
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.SphereCoutoutVolume(-9, 3));
            Assert.ThrowsException<Exception>(() => circle.SphereCoutoutVolume(9, -3));
            Assert.ThrowsException<Exception>(() => circle.SphereCoutoutVolume(-9, -3));
            Assert.ThrowsException<Exception>(() => circle.SphereCoutoutVolume(9, 30));
        }

        //---

        [TestMethod]
        public void SphereNotchArea_Int()
        {
            double r = 4;
            double h = 6;
            double r2 = 2;
            double expected = 175.929;
            Circle circle = new Circle();

            double actual = circle.SphereNotchArea(r, h, r2);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereNotchArea_Double()
        {
            double r = 13.55;
            double h = 2.1;
            double r2 = 4;
            double expected = 349.062;
            Circle circle = new Circle();

            double actual = circle.SphereNotchArea(r, h, r2);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereNotchArea_Incorect()
        {
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.SphereNotchArea(-9, 3, 2));
            Assert.ThrowsException<Exception>(() => circle.SphereNotchArea(-9, -3, 2));
            Assert.ThrowsException<Exception>(() => circle.SphereNotchArea(-9, 3, -2));
            Assert.ThrowsException<Exception>(() => circle.SphereNotchArea(9, -3, -2));
            Assert.ThrowsException<Exception>(() => circle.SphereNotchArea(-9, -3,-2));

            Assert.ThrowsException<Exception>(() => circle.SphereNotchArea(9, 50, 2));
            Assert.ThrowsException<Exception>(() => circle.SphereNotchArea(9, 3, 50));
            Assert.ThrowsException<Exception>(() => circle.SphereNotchArea(9, 50, 50));
        }

        //---

        [TestMethod]
        public void SphereNotchVolume_Int()
        {
            double r = 4;
            double h = 6;
            double expected = 201.062;
            Circle circle = new Circle();

            double actual = circle.SphereNotchVolume(r, h);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereNotchVolume_Double()
        {
            double r = 13.55;
            double h = 2.1;
            double expected = 807.526;
            Circle circle = new Circle();

            double actual = circle.SphereNotchVolume(r, h);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SphereNotchVolume_Incorect()
        {
            Circle circle = new Circle();

            Assert.ThrowsException<Exception>(() => circle.SphereNotchVolume(-9, 3));
            Assert.ThrowsException<Exception>(() => circle.SphereNotchVolume(9, -3));
            Assert.ThrowsException<Exception>(() => circle.SphereNotchVolume(-9, -3));
            Assert.ThrowsException<Exception>(() => circle.SphereNotchVolume(9, 30));
        }
    }
}