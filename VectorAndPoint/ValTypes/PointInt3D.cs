using System;
using System.Diagnostics;

namespace VectorAndPoint.ValTypes
{

    /// <summary>
    /// Represents an x-, y- and z-coordinates in 3D space.
    /// </summary>
    [DebuggerDisplay("({X}, {Y}, {Z})")]
    public struct PointInt3D : I3D<int>, IEquatable<I3D<int>>, IEquatable<PointInt3D>
    {

        /// <summary>
        /// Creates a new VectorAndPoint.ValTypes.PointInt3D structure that contains the specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public PointInt3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// X-coordinate value of this point
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y-coordinate value of this point
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Z-coordinate value of this point
        /// </summary>
        public int Z { get; }

        #region static

        public static double GetRangeBetween(I3D<int> p1, I3D<int> p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        }

        public static double GetRangeBetween(PointInt3D p1, PointInt3D p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        }

        public static bool IsEquals(I3D<int> p1, I3D<int> p2) => p1.X == p2.X && p1.Y == p2.Y;

        public static bool IsEquals(Point p1, Point p2) => p1.X == p2.X && p1.Y == p2.Y;

        [Obsolete("Wrong definition")]
        public static bool IsCollinear(I3D<int> p1, I3D<int> p2) => p1.X / p2.X == p1.Y / p2.Y;

        #endregion

        #region IEquatable

        public bool Equals(I3D<int> other) => IsEquals(this, other);

        public bool Equals(PointInt3D other) => IsEquals(this, other);

        #endregion

        #region object overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is I3D<int>) return Equals(obj as I3D<int>);
            if (obj is PointInt3D) return Equals((obj as PointInt3D?).Value);

            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode() => (X.GetHashCode() * 11) ^ (Y.GetHashCode() * 7) ^ (Z.GetHashCode() * 5);

        public override string ToString() => $"({X}, {Y}, {Z})";

        #endregion

        #region operators

        public static Point3D operator +(PointInt3D v, Vector3D p) => new Point3D(p.X + v.X, p.Y + v.Y, p.Z + v.Z);


        public static bool operator ==(PointInt3D p1, PointInt3D p2) => p1.Equals(p2);

        public static bool operator !=(PointInt3D p1, PointInt3D p2) => !p1.Equals(p2);

        #endregion

    }
}
