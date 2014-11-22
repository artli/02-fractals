using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Julia {
    public class Generator {
        const int MaxIterations = 200;

        static int TestPoint(Complex c, Func<Complex, Complex, Complex> f, double infinity) {
            var z = c;
            for (int i = 0; i < MaxIterations; i++) {
                z = f(z, c);
                if (z.Length() > infinity)
                    return i + 1;
            }
            return 0;
        }

        public static int[][] Generate(double minx, double maxx, double miny, double maxy, int width, int height, Func<Complex, Complex, Complex> f, double infinity) {
            var result = new int[width][];
            for (int i = 0; i < width; i++)
                result[i] = new int[height];

            double stepX = (maxx - minx) / width;
            double stepY = (maxy - miny) / height;

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    result[i][j] = TestPoint(new Complex(minx + i * stepX, miny + j * stepY), f, infinity);

            return result;
        }
    }

    static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
