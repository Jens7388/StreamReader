using System;
using System.Collections.Generic;
using System.Text;

namespace Opgave2
{
    class Box
    {
        private int height;
        private int length;
        private int width;
        private int volume;
        private int surface;

        public int Height { get { return height; } set { height = value; } }
        public int Length { get { return length; } set { length = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int Volume { get { return volume; } set { volume = value; } }
        public int Surface { get { return surface; } set { surface = value; } }

        public void CalculateVolume()
        {
            volume = Height * Length * Width;
        }
        public void CalculateSurface()
        {
            surface = (Height * Length * 2) + (Height * Width * 2) + (Length * Width * 2);
        }
        public void PrintInfo()
        {

            Console.WriteLine($"Højde:\t\t{Height} cm");
            Console.WriteLine($"Længde:\t\t{Length} cm");
            Console.WriteLine($"Bredde:\t\t{Width} cm");
            Console.WriteLine($"Rumfang:\t{volume} cm3");
            Console.WriteLine($"Samlet overfladeareal: {surface} cm2");
            Console.WriteLine(" ");           
        }
    }
}
