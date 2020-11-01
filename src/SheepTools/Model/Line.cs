using System;
using SheepTools.Extensions;

namespace SheepTools.Model
{
    /// <summary>
    /// Straight line class, with equality operators overridden
    /// </summary>
    public class Line : IEquatable<Line>
    {
        public double M { get; set; }

        public double Y0 { get; set; }

        public double X0 { get; set; }

        public string? Id { get; set; }

        public Line(Point a, Point b)
        {
            M = (b.Y - a.Y) / (b.X - a.X);
            X0 = a.X;
            Y0 = a.Y;
        }

        public Line(string id, Point a, Point b) : this(a, b)
        {
            Id = id;
        }

        public double CalculateY(double x)
        {
            return Y0 + (M * (x - X0));
        }

        public override string ToString()
        {
            return $"[y = {Y0} + ({M}) * (X - {X0}]";
        }

        #region Equals override

        public override bool Equals(object? obj)
        {
            if (obj is Line other)
            {
                return Equals(other);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if both have the same m, and then check if other goes through X0 and Y0
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Line? other)
        {
            if (other is null)
            {
                return false;
            }

            return double.IsInfinity(M)
                ? double.IsInfinity(other.M)
                    && X0.DoubleEquals(other.X0)
                : M.DoubleEquals(other.M)
                    && Y0.DoubleEquals(other.CalculateY(X0));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(M, X0, Y0, Id);
        }

        public static bool operator ==(Line line1, Line line2)
        {
            if (line1 is null)
            {
                return line2 is null;
            }

            return line1.Equals(line2);
        }

        public static bool operator !=(Line line1, Line line2)
        {
            if (line1 is null)
            {
                return line2 is object;
            }

            return !line1.Equals(line2);
        }
        #endregion
    }
}
