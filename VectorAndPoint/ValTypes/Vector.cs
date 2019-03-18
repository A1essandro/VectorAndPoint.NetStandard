using System;

namespace VectorAndPoint.ValTypes
{

    /// <summary>
    /// Represents a displacement in 2D space
    /// </summary>
    public struct Vector : IVector2D<double>, IEquatable<IVector2D<double>>, IEquatable<Vector>
    {

        /// <summary>
        /// Initializes a new instance of VectorAndPoint.ValTypes.Vector
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X component of this vector
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Y component of this vector
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Gets the length of this vector
        /// </summary>
        public double Length => Point.GetRangeBetween(new Point(X, Y), new Point(0, 0));

        public bool IsCollinearWith(IVector2D<double> vector) => X / vector.X == Y / vector.Y;

        #region static

        public static bool IsEquals(IVector2D<double> v1, IVector2D<double> v2) => v1.X == v2.X && v1.Y == v2.Y;

        public static bool IsEquals(Vector v1, Vector v2) => v1.X == v2.X && v1.Y == v2.Y;

        public static bool IsCollinear(IVector2D<double> v1, IVector2D<double> v2) => v1.X / v2.X == v1.Y / v2.Y;

        #endregion

        #region IEquatable

        public bool Equals(IVector2D<double> other) => IsEquals(this, other);

        public bool Equals(Vector other) => IsEquals(this, other);

        #endregion

        #region object overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is IVector2D<double>) return Equals(obj as IVector2D<double>);
            if (obj is Vector) return Equals((obj as Vector?).Value); //hint

            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode() => (X.GetHashCode() * 11) ^ (Y.GetHashCode() * 7);

        public override string ToString() => $"({X}, {Y})";

        #endregion

        #region operators

        public static Point operator +(Vector p, Point v) => new Point(p.X + v.X, p.Y + v.Y);

        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);

        public static Vector operator *(double s, Vector v) => new Vector(s * v.X, s * v.Y);

        public static Vector operator *(int s, Vector v) => new Vector(s * v.X, s * v.Y);

        public static Vector operator *(float s, Vector v) => new Vector(s * v.X, s * v.Y);

        public static Vector operator *(Vector v, double s) => new Vector(s * v.X, s * v.Y);

        public static Vector operator *(Vector v, int s) => new Vector(s * v.X, s * v.Y);

        public static Vector operator *(Vector v, float s) => new Vector(s * v.X, s * v.Y);

        #endregion

    }

}
