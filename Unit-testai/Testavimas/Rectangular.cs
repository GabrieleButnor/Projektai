using System;

namespace Testavimas
{
    public class Rectangular
    {
        private double length;
        private double width;
        private double perimeter;
        private double area;

        public Rectangular(double length, double width, double perimeter, double area)
        {
            this.length = length;
            this.width = width;
            this.perimeter = perimeter;
            this.area = area;
        }

        public double findAreaFromLengthAndWidth(){
            return length * width;
        }
        public double findLengthFromArea(){
            return this.area / this.width;
        }
        public double findWidthFromArea(){
            return this.area / this.length;
        }
        public double findWidthFromPerimeter(){
            return (this.perimeter - this.length * 2) / 2;
        }
        public double findLengthFromPerimeter(){
            return (this.perimeter - this.width * 2) / 2;
        }
        public double findPerimeterFromLengthAndWidth(){
            return (this.length + this.width) * 2;
        }
        public double findPerimeterFromAreaAndWidth(){
            return (this.area / this.width + this.width) * 2;
        }
        public double findPerimeterFromAreaAndLength(){
            return (this.area / this.length + this.length) * 2;
        }
        public double findAreaFromPerimeterAndLength(){
            return (this.perimeter - this.length * 2) / 2 * this.length;
        }

        public double findAreaFromPerimeterAndWidth()
        {
            return (this.perimeter - this.width * 2) / 2 * this.width;
        }
    }
}