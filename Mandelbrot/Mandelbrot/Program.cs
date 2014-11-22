using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Mandelbrot {
    static class Generator {
        const int MaxIterations = 200;

        static bool TestPoint(Complex c) {
            Complex z = c;
            for (int i = 0; i < MaxIterations; i++) {
                z = z*z + c;
                if (z.Length() > 2)
                    return true;
            }
            return false;
        }
        
        public static bool[][] Generate(double minx, double maxx, double miny, double maxy, int width, int height) {
            var result = new bool[width][];
            foreach (var i in Enumerable.Range(0, width)) {
                result[i] = new bool[height];
            }

            var stepX = (maxx - minx) / width;
            var stepY = (maxy - miny) / height;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    result[i][j] = TestPoint(new Complex(minx + i*stepX, miny + j*stepY));

            return result;
        }
    }

    class Program {
        static void Main(string[] args) {
            double minx = 0;
            double maxx = 2;
            double miny = -1;
            double maxy = 1;
            int width = 200;
            int height = 200;

            var lines = new List<string>();
            var result = Generator.Generate(minx, maxx, miny, maxy, width, height);
            for (int j = height - 1; j >= 0; j--) {
                var line = new List<char>();
                for (int i = 0; i < width; i++) {
                    if (result[i][j])
                        line.Add('.');
                    else
                        line.Add('@');
                }
                lines.Add(string.Join("", line));
            }

            File.WriteAllLines("output.txt", lines);
        }
    }
}
