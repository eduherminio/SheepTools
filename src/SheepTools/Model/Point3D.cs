using System;

namespace SheepTools.Model
{
    /// <summary>
    /// 3D Point class, with equality operators overridden
    /// </summary>
    public class Point3D : IEquatable<Point3D>
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public string? Id { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(string id, double x, double y, double z)
            : this(x, y, z)
        {
            Id = id;
        }

        public double DistanceTo(Point3D otherPoint)
        {
            return Math.Sqrt(
                Math.Pow(otherPoint.X - X, 2)
                + Math.Pow(otherPoint.Y - Y, 2)
                + Math.Pow(otherPoint.Z - Z, 2));
        }

        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}]";
        }

        #region Equals override

        public override bool Equals(object? obj)
        {
            if (obj is Point3D other)
            {
                return Equals(other);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Point3D? other)
        {
            if (other is null)
            {
                return false;
            }

            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override int GetHashCode()
        {
#if !NETSTANDARD2_0
            return HashCode.Combine(X, Y, Z, Id);
#else
            unchecked
            {
                var hashCode = -1895077416;
                hashCode = hashCode * -1521134295 + X.GetHashCode();
                hashCode = hashCode * -1521134295 + Y.GetHashCode();
                hashCode = hashCode * -1521134295 + Z.GetHashCode();
                if (!(Id is null))
                {
                    hashCode = hashCode * -1521134295 + Id.GetHashCode();
                }
                return hashCode;
            }
#endif
        }

        public static bool operator ==(Point3D Point3D1, Point3D Point3D2)
        {
            if (Point3D1 is null)
            {
                return Point3D2 is null;
            }

            return Point3D1.Equals(Point3D2);
        }

        public static bool operator !=(Point3D Point3D1, Point3D Point3D2)
        {
            if (Point3D1 is null)
            {
                return Point3D2 is object;
            }

            return !Point3D1.Equals(Point3D2);
        }

        #endregion
    }
}
