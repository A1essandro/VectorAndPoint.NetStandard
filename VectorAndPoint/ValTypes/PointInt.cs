using System;
using System.Diagnostics;

namespace VectorAndPoint.ValTypes
{
    /// <summary>
    /// Represents an x- and y-coordinates in 2D space.
    /// </summary>
    [DebuggerDisplay("({X}, {Y})")]
    public struct PointInt : I2D<int>, IEquatable<I2D<int>>, IEquatable<PointInt>
    {

        /// <summary>
        /// Creates a new VectorAndPoint.ValTypes.PointInt structure that contains the specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public PointInt(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X-coordinate value of this point
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y-coordinate value of this point
        /// </summary>
        public int Y { get; }

        #region static

        public static double GetRangeBetween(I2D<int> p1, I2D<int> p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static double GetRangeBetween(PointInt p1, PointInt p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static bool IsEquals(I2D<int> p1, I2D<int> p2) => p1.X == p2.X && p1.Y == p2.Y;

        public static bool IsEquals(PointInt p1, PointInt p2) => p1.X == p2.X && p1.Y == p2.Y;

        #endregion

        #region IEquatable

        public bool Equals(I2D<int> other) => IsEquals(this, other);

        public bool Equals(PointInt other) => IsEquals(this, other);

        #endregion

        #region object overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is I2D<int>) return Equals(obj as I2D<int>);
            if (obj is PointInt) return Equals((obj as PointInt?).Value);

            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode() => (X.GetHashCode() * 11) ^ (Y.GetHashCode() * 7);

        public override string ToString() => $"({X}, {Y})";

        #endregion

        #region operators

        public static Point operator +(PointInt v, Vector p) => new Point(p.X + v.X, p.Y + v.Y);

        public static bool operator ==(PointInt p1, PointInt p2) => p1.Equals(p2);

        public static bool operator !=(PointInt p1, PointInt p2) => !p1.Equals(p2);

        #endregion

    }
}
