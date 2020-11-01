using System;
using System.Collections.Generic;
using System.Linq;

namespace SheepTools.Model
{
    /// <summary>
    /// Point class, with equality operators overridden
    /// </summary>
    public class Point : IEquatable<Point>
    {
        public double X { get; set; }

        public double Y { get; set; }

        public string? Id { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(string id, double x, double y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public double ManhattanDistance(Point point)
        {
            return Math.Abs(point.X - X) + Math.Abs(point.Y - Y);
        }

        public double DistanceTo(Point otherPoint)
        {
            return Math.Sqrt(
                Math.Pow(otherPoint.X - X, 2)
                + Math.Pow(otherPoint.Y - Y, 2));
        }

        public Point CalculateClosestManhattanPoint(ICollection<Point> candidatePoints)
        {
            Dictionary<Point, double> pointDistanceDictionary = new Dictionary<Point, double>();

            foreach (Point point in candidatePoints)
            {
                pointDistanceDictionary.Add(point, ManhattanDistance(point));
            }

            return pointDistanceDictionary.OrderBy(pair => pair.Value)
                .First().Key;
        }

        /// <summary>
        /// Returns null if there are multiple points at min Manhattan distance
        /// </summary>
        /// <param name="candidatePoints"></param>
        /// <returns></returns>
        public Point? CalculateClosestManhattanPointNotTied(ICollection<Point> candidatePoints)
        {
            Dictionary<Point, double> pointDistanceDictionary = new Dictionary<Point, double>();

            foreach (Point point in candidatePoints)
            {
                pointDistanceDictionary.Add(point, ManhattanDistance(point));
            }

            var orderedDictionary = pointDistanceDictionary.OrderBy(pair => pair.Value);

            return pointDistanceDictionary.Values.Count(distance => distance == orderedDictionary.First().Value) == 1
                ? orderedDictionary.First().Key
                : null;
        }

        public static IEnumerable<Point> GeneratePointRangeIteratingOverYFirst(IEnumerable<double> xRange, IEnumerable<double> yRange)
        {
            foreach (double x in xRange)
            {
                foreach (double y in yRange)
                {
                    yield return new Point(x, y);
                }
            }
        }

        public static IEnumerable<Point> GeneratePointRangeIteratingOverYFirst(IEnumerable<int> xRange, IEnumerable<int> yRange)
        {
            return GeneratePointRangeIteratingOverYFirst(xRange.Select(x => (double)x), yRange.Select(y => (double)y));
        }

        public static IEnumerable<Point> GeneratePointRangeIteratingOverXFirst(IEnumerable<double> xRange, IEnumerable<double> yRange)
        {
            foreach (double y in yRange)
            {
                foreach (double x in xRange)
                {
                    yield return new Point(x, y);
                }
            }
        }

        public static IEnumerable<Point> GeneratePointRangeIteratingOverXFirst(IEnumerable<int> xRange, IEnumerable<int> yRange)
        {
            return GeneratePointRangeIteratingOverXFirst(xRange.Select(x => (double)x), yRange.Select(y => (double)y));
        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }

        #region Equals override

        public override bool Equals(object? obj)
        {
            if (obj is Point otherPoint)
            {
                return Equals(otherPoint);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Point? other)
        {
            if (other is null)
            {
                return false;
            }

            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
#if !NETSTANDARD2_0
            return HashCode.Combine(X, Y, Id);
#else
            unchecked
            {
                var hashCode = 1166230731;
                hashCode = hashCode * -1521134295 + X.GetHashCode();
                hashCode = hashCode * -1521134295 + Y.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
                return hashCode;
            }
#endif
        }

        public static bool operator ==(Point point1, Point point2)
        {
            if (point1 is null)
            {
                return point2 is null;
            }

            return point1.Equals(point2);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            if (point1 is null)
            {
                return point2 is object;
            }

            return !point1.Equals(point2);
        }
        #endregion
    }
}
