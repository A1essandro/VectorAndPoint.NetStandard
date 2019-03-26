using System;
using System.Diagnostics;

namespace VectorAndPoint.ValTypes
{

    /// <summary>
    /// Represents an x- and y-coordinates in 2D space.
    /// </summary>
    [DebuggerDisplay("({X}, {Y})")]
    public struct Point : I2D<double>, IEquatable<I2D<double>>, IEquatable<Point>
    {

        /// <summary>
        /// Creates a new VectorAndPoint.ValTypes.Point structure that contains the specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X-coordinate value of this point
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Y-coordinate value of this point
        /// </summary>
        public double Y { get; }

        #region static

        public static double GetRangeBetween(I2D<double> p1, I2D<double> p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static double GetRangeBetween(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static bool IsEquals(I2D<double> p1, I2D<double> p2) => p1.X == p2.X && p1.Y == p2.Y;

        public static bool IsEquals(Point p1, Point p2) => p1.X == p2.X && p1.Y == p2.Y;

        [Obsolete("Wrong definition")]
        public static bool IsCollinear(I2D<double> p1, I2D<double> p2) => p1.X / p2.X == p1.Y / p2.Y;

        #endregion

        #region IEquatable

        public bool Equals(I2D<double> other) => IsEquals(this, other);

        public bool Equals(Point other) => IsEquals(this, other);

        #endregion

        #region object overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is I2D<double>) return Equals(obj as I2D<double>);
            if (obj is Point) return Equals((obj as Point?).Value);

            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode() => (X.GetHashCode() * 11) ^ (Y.GetHashCode() * 7);

        public override string ToString() => $"({X}, {Y})";

        #endregion

        #region operators

        public static Point operator +(Point v, Vector p) => new Point(p.X + v.X, p.Y + v.Y);

        #endregion

    }
}
