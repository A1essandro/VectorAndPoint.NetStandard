using System;
using System.Diagnostics;

namespace VectorAndPoint.ValTypes
{

    /// <summary>
    /// Represents a displacement in 2D space
    /// </summary>
    [DebuggerDisplay("({X}, {Y})")]
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

        /// <summary>
        /// Vectors collinearity check
        /// </summary>
        /// <remarks>
        /// If structures of type Vector are used - better way is call a static method IsCollinear
        /// </remarks>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool IsCollinearWith(IVector2D<double> other) => IsCollinear(this, other);

        /// <summary>
        /// Get the scalar product of this vector and other
        /// </summary>
        /// <remarks>
        /// If structures of type Vector are used - better way is call a static method GetScalarProduct
        /// </remarks>
        /// <param name="other"></param>
        /// <returns></returns>
        public double GetScalarProductWith(IVector2D<double> other) => GetScalarProduct(this, other);

        /// <summary>
        /// Get the angle between this vector and other in radians
        /// </summary>
        /// <remarks>
        /// If structures of type Vector are used - better way is call a static method GetAngleBetween
        /// </remarks>
        /// <param name="other"></param>
        /// <returns></returns>
        public double GetAngleWith(IVector2D<double> other) => GetAngleBetween(this, other);

        #region static

        public static bool IsEquals(IVector2D<double> v1, IVector2D<double> v2) => v1.X == v2.X && v1.Y == v2.Y;

        public static bool IsEquals(Vector v1, Vector v2) => v1.X == v2.X && v1.Y == v2.Y; //without boxing

        /// <summary>
        /// Vectors collinearity check
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool IsCollinear(IVector2D<double> v1, IVector2D<double> v2)
        {
            if ((v1.X == 0 && v2.X == 0) || (v1.Y == 0 && v2.Y == 0))
                return true;
            return v1.X / v2.X == v1.Y / v2.Y;
        }

        /// <summary>
        /// Vectors collinearity check
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool IsCollinear(Vector v1, Vector v2) //without boxing
        {
            if ((v1.X == 0 && v2.X == 0) || (v1.Y == 0 && v2.Y == 0))
                return true;
            return v1.X / v2.X == v1.Y / v2.Y;
        }

        /// <summary>
        /// Get the scalar product of vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetScalarProduct(IVector2D<double> v1, IVector2D<double> v2) => v1.X * v2.X + v1.Y * v2.Y;

        /// <summary>
        /// Get the scalar product of vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetScalarProduct(Vector v1, Vector v2) => v1.X * v2.X + v1.Y * v2.Y; //without boxing

        /// <summary>
        /// Get the angle between vectors in radians
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetAngleBetween(IVector2D<double> v1, IVector2D<double> v2)
        {
            return Math.Acos(GetScalarProduct(v1, v2) / (v1.Length * v2.Length));
        }

        /// <summary>
        /// Get the angle between vectors in radians
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetAngleBetween(Vector v1, Vector v2) //without boxing
        {
            return Math.Acos(GetScalarProduct(v1, v2) / (v1.Length * v2.Length));
        }

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
            if (obj is Vector) return Equals((obj as Vector?).Value);

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
