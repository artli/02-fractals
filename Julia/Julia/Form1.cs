using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Julia {
    public partial class Form1 : Form {
        private Dictionary<int, Pen> dict = new Dictionary<int, Pen> {
            {1, new Pen(Brushes.Red)},
            {2, new Pen(Brushes.Bisque)},
            {3, new Pen(Brushes.BlueViolet)},
            {4, new Pen(Brushes.DarkGreen)},
            {0, new Pen(Brushes.Gray)}
        };
        public Form1() {
            InitializeComponent();
            Width = 300;
            Height = 300;
        }

        protected override void OnPaint(PaintEventArgs e) {
            var gen = Generator.Generate(-2, 2, -2, 2, Width, Height, Mond, 2);
            var graphics = e.Graphics;
            var black = new Pen(Brushes.Black);
            for (var x = 0; x < Width; x++)
                for (var y = 0; y < Height; y++) {
                    var color = gen[x][Height - y - 1];
                    var pen = black;
                    if (color > 0)
                        pen = dict[color % 5];
                    graphics.DrawRectangle(pen, x, y, 1, 1);
                }
        }

        protected override void OnResize(EventArgs e) {
            Invalidate();
        }

        public Complex Cool(Complex z, Complex c) {
            return z * z * z * z + new Complex(0.5, 0.5);
        }
        public Complex Mond(Complex z, Complex c) {
            return z * z + c;
        }
    }
}
