using System;

namespace P01ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length 
        { 
            get
            {
                return this.length;
            }
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
            }
        }
        public double Width 
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }
        public double Height 
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        public double GetSurfaceArea()
        {
            //2lw + 2lh + 2wh

            return (2 * length * width) + (2 * length * height) + (2 * width * height);
        }

        public double GetLateralSurfafeArea()
        {
            //2lh + 2wh

            return (2 * length * height) + (2 * width * height);
        }

        public double GetVolume()
        {
            return length * width * height;
        }
    }
}