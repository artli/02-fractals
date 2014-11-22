using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Julia {
    public class Complex : IEquatable<Complex> {
        public double X, Y;

        public Complex(double x, double y) {
            X = x;
            Y = y;
        }

        public static Complex ByAngle(double angle, double length) {
            return new Complex(Math.Cos(angle) * length, Math.Sin(angle) * length);
        }

        public double Length() {
            return Math.Sqrt(X * X + Y * Y);
        }

        public double Angle() {
            var angle = Math.Acos(X / Length());
            if (Y < 0)
                angle = -angle;
            return angle;
        }

        public static Complex operator +(Complex a, Complex b) {
            return new Complex(a.X + b.X, a.Y + b.Y);
        }

        public static Complex operator -(Complex a, Complex b) {
            return new Complex(a.X - b.X, a.Y - b.Y);
        }

        public static Complex operator *(Complex a, int k) {
            return new Complex(a.X * k, a.Y * k);
        }

        public static Complex operator *(Complex a, Complex b) {
            return new Complex(a.X * b.X - a.Y * b.Y, a.X * b.Y + a.Y * b.X);
        }

        public override string ToString() {
            return "(" + X.ToString() + ", " + Y.ToString() + ")";
        }

        public static bool DoublesEqual(double d1, double d2) {
            return Math.Abs(d1 - d2) < 1e-6;
        }

        public bool Equals(Complex that) {
            return DoublesEqual(X, that.X) && DoublesEqual(Y, that.Y);
        }
    }
}
