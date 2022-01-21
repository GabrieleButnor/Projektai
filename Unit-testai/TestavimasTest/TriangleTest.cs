using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testavimas;

namespace TestavimasTest
{
    [TestClass]
    public class TriangleTest
    {
        private Triangle triangle = new Triangle(4, 3, 5);

        [TestMethod]
        public void PerimeterRetrunsCorrectValue()
        {
            Assert.AreEqual(4 + 3 + 5, triangle.GetPerimeter(), 0.0001);
        }

        [TestMethod]
        public void AreaReturnsCorrectValue()
        {
            var area = 3 * 4 / 2;
            Assert.AreEqual(area, triangle.GetArea(), 0.0001);
        }

        [TestMethod]
        public void GetAnglesReturnsCorrectValue()
        {
            double[] angles = new double[]{90, 53.13, 36.87};
            double[] gotAngles = triangle.GetAngles();
            Assert.AreEqual(angles[0], gotAngles[0], 0.001);
            Assert.AreEqual(angles[1], gotAngles[1], 0.001);
            Assert.AreEqual(angles[2], gotAngles[2], 0.001);
        }

        [TestMethod]
        public void GetOuterCircleReturnsCorrectValue()
        {
            Assert.AreEqual(2.5, triangle.GetOuterCircleRadius(), 0.0001);
        }

        [TestMethod]
        public void GetInnerCircleReturnsCorrectValue()
        {
            Assert.AreEqual(1, triangle.GetInnerCircleRadius(), 0.0001);
        }

        [TestMethod]
        public void TriangleSidesCannotBeNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(0, 1, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(1, 0, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(1, 1, 0));
        }

        [TestMethod]
        public void TriangleMustBeValid()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 5, 1));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(5, 1, 1));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 1, 50));
        }

        [TestMethod]
        public void TriangleIsSquareReturnsCorrectValue()
        {
            Assert.AreEqual(true, triangle.IsSquare());
            Assert.AreEqual(false, new Triangle(5, 6, 2).IsSquare());
            Assert.AreEqual(false, new Triangle(6, 5, 2).IsSquare());
        }
    }
}
