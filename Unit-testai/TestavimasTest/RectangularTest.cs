using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testavimas;

namespace TestavimasTest
{
    [TestClass]
    public class RectangularTest
    {
        [TestMethod]
        public void testFindAreaFromLengthAndWidth(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 2;
            double actual = rectangular.findAreaFromLengthAndWidth();

            Assert.AreEqual(expected, actual, 0.001, "Area calculated not correctly");

            Rectangular rectangular1 = new Rectangular(8, 100, 10, 5);
            expected = 800;
            actual = rectangular1.findAreaFromLengthAndWidth();

            Assert.AreEqual(expected, actual, 0.001, "Area calculated not correctly");

            Rectangular rectangular2 = new Rectangular(2.5, 3.4, 10, 5);
            expected = 8.5;
            actual = rectangular2.findAreaFromLengthAndWidth();

            Assert.AreEqual(expected, actual, 0.001, "Area calculated not correctly");
        }

        [TestMethod]
        public void testFindLengthFromArea(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 2.5;
            double actual = rectangular.findLengthFromArea();

            Assert.AreEqual(expected, actual, 0.001, "Length calculated not correctly");

            Rectangular rectangular1 = new Rectangular(13, 10, 10, 5);
            expected = 0.5;
            actual = rectangular1.findLengthFromArea();

            Assert.AreEqual(expected, actual, 0.001, "Area calculated not correctly");
        }

        [TestMethod]
        public void testFindWidthFromArea(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 5;
            double actual = rectangular.findWidthFromArea();

            Assert.AreEqual(expected, actual, 0.001, "Width calculated not correctly");
        }

        [TestMethod]
        public void testFindWidthFromPerimeter(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 4;
            double actual = rectangular.findWidthFromPerimeter();

            Assert.AreEqual(expected, actual, 0.001, "Width calculated not correctly");
        }

        [TestMethod]
        public void testFindLengthFromPerimeter(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 3;
            double actual = rectangular.findLengthFromPerimeter();

            Assert.AreEqual(expected, actual, 0.001, "Length calculated not correctly");
        }

        [TestMethod]
        public void testFindPerimeterFromLengthAndWidth(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 6;
            double actual = rectangular.findPerimeterFromLengthAndWidth();

            Assert.AreEqual(expected, actual, 0.001, "Perimeter calculated not correctly");
        }

        [TestMethod]
        public void testFindPerimeterFromAreaAndWidth(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 9;
            double actual = rectangular.findPerimeterFromAreaAndWidth();

            Assert.AreEqual(expected, actual, 0.001, "Perimeter calculated not correctly");
        }

        [TestMethod]
        public void testFindPerimeterFromAreaAndLength(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 12;
            double actual = rectangular.findPerimeterFromAreaAndLength();

            Assert.AreEqual(expected, actual, 0.001, "Perimeter calculated not correctly");
        }

        [TestMethod]
        public void testFindAreaFromPerimeterAndLength(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 4;
            double actual = rectangular.findAreaFromPerimeterAndLength();

            Assert.AreEqual(expected, actual, 0.001, "Area calculated not correctly");
        }

        [TestMethod]
        public void testFindAreaFromPerimeterAndWidth(){
            Rectangular rectangular = new Rectangular(1,2,10,5);
            double expected = 6;
            double actual = rectangular.findAreaFromPerimeterAndWidth();

            Assert.AreEqual(expected, actual, 0.001, "Area calculated not correctly");
        }
    }
}