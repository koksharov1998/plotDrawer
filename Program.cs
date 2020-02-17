using System;
using System.Drawing;

namespace PlotDrawer 
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = -100;
            var b = 150;
			
            Func<int, int> myFunction = (x) => x / 2;
            // Func<int, int> myFunction = (x) => (int)(100 * Math.Sin(x));

            var bitMap = new Bitmap(400, 400);
            for (var i = 0; i < bitMap.Width; i++)
                for (var j = 0; j < bitMap.Height; j++)
                    bitMap.SetPixel(i, j, Color.White);

            var maxY = int.MinValue;
            var minY = int.MaxValue;
            for (var i = a; i <= b; i++)
            {
                var y = myFunction(i);
                if (y > maxY)
                    maxY = y;
                if (y < minY)
                    minY = y;
            }
            Console.WriteLine(minY.ToString() + " " + maxY.ToString());
            Console.WriteLine();

            for (var xx = 0; xx < bitMap.Width; xx++)
            {
                var x = a + xx * (b - a) / bitMap.Width;
                var y = myFunction(x);
                var yy = (myFunction(x) - minY) * maxY / (maxY - minY);
                Console.WriteLine(x.ToString() + " " + y.ToString());
                if (yy > 0 && yy < bitMap.Height)
                {
                    Console.WriteLine("e");
                    bitMap.SetPixel(xx, yy, Color.Black);
                }
            }
            bitMap.Save("picture.jpg");
        }
    }
}
