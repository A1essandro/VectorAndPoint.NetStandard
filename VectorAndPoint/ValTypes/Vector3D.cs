using System;

namespace VectorAndPoint.ValTypes
{

    /// <summary>
    /// Represents a displacement in 3D space
    /// </summary>
    public struct Vector3D : IVector3D<double>, IEquatable<IVector3D<double>>, IEquatable<Vector3D>
    {

        /// <summary>
        /// Initializes a new instance of VectorAndPoint.ValTypes.Vector3D
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
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
        /// Z component of this vector
        /// </summary>
        public double Z { get; }

        /// <summary>
        /// Gets the length of this vector
        /// </summary>
        public double Length => Point3D.GetRangeBetween(new Point3D(X, Y, Z), new Point3D(0, 0, 0));

        /// <summary>
        /// Vectors collinearity check
        /// </summary>
        /// <remarks>
        /// If structures of type Vector3D are used - better way is call a static method IsCollinear
        /// </remarks>
        /// <param name="vector"></param>
        /// <returns></returns>
        public bool IsCollinearWith(IVector3D<double> vector) => IsCollinear(this, vector);

        /// <summary>
        /// Get the scalar product of this vector and other
        /// </summary>
        /// <remarks>
        /// If structures of type Vector3D are used - better way is call a static method GetScalarProduct
        /// </remarks>
        /// <param name="other"></param>
        /// <returns></returns>
        public double GetScalarProductWith(IVector3D<double> other) => GetScalarProduct(this, other);

        /// <summary>
        /// Get the angle between this vector and other in radians
        /// </summary>
        /// <remarks>
        /// If structures of type Vector3D are used - better way is call a static method GetAngleBetween
        /// </remarks>
        /// <param name="other"></param>
        /// <returns></returns>
        public double GetAngleWith(IVector3D<double> other) => GetAngleBetween(this, other);

        #region static

        public static bool IsEquals(IVector3D<double> v1, IVector3D<double> v2) => v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;

        public static bool IsEquals(Vector3D v1, Vector3D v2) => v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z; //without boxing

        /// <summary>
        /// Vectors collinearity check
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool IsCollinear(IVector3D<double> v1, IVector3D<double> v2) => v1.X / v2.X == v1.Y / v2.Y && v1.Y / v2.Y == v1.Z / v2.Z;

        /// <summary>
        /// Vectors collinearity check
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool IsCollinear(Vector3D v1, Vector3D v2) => v1.X / v2.X == v1.Y / v2.Y && v1.Y / v2.Y == v1.Z / v2.Z; //without boxing

        /// <summary>
        /// Get the scalar product of vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetScalarProduct(IVector3D<double> v1, IVector3D<double> v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

        /// <summary>
        /// Get the scalar product of vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetScalarProduct(Vector3D v1, Vector3D v2) => v1.X * v2.X + v1.Y * v2.Y * v2.Y + v1.Z * v2.Z; //without boxing

        /// <summary>
        /// Get the angle between vectors in radians
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetAngleBetween(IVector3D<double> v1, IVector3D<double> v2)
        {
            return Math.Acos(GetScalarProduct(v1, v2) / (v1.Length * v2.Length));
        }

        /// <summary>
        /// Get the angle between vectors in radians
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double GetAngleBetween(Vector3D v1, Vector3D v2) //without boxing
        {
            return Math.Acos(GetScalarProduct(v1, v2) / (v1.Length * v2.Length));
        }

        #endregion

        #region IEquatable

        public bool Equals(IVector3D<double> other) => IsEquals(this, other);

        public bool Equals(Vector3D other) => IsEquals(this, other);

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

        public override int GetHashCode() => (X.GetHashCode() * 11) ^ (Y.GetHashCode() * 7) ^ (Z.GetHashCode() * 5);

        public override string ToString() => $"({X}, {Y}, {Z})";

        #endregion

        #region operators

        public static Point3D operator +(Vector3D p, Point3D v) => new Point3D(p.X + v.X, p.Y + v.Y, p.Z + v.Z);

        public static Vector3D operator +(Vector3D v1, Vector3D v2) => new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        public static Vector3D operator *(double s, Vector3D v) => new Vector3D(s * v.X, s * v.Y, s * v.Z);

        public static Vector3D operator *(int s, Vector3D v) => new Vector3D(s * v.X, s * v.Y, s * v.Z);

        public static Vector3D operator *(float s, Vector3D v) => new Vector3D(s * v.X, s * v.Y, s * v.Z);

        public static Vector3D operator *(Vector3D v, double s) => new Vector3D(s * v.X, s * v.Y, s * v.Z);

        public static Vector3D operator *(Vector3D v, int s) => new Vector3D(s * v.X, s * v.Y, s * v.Z);

        public static Vector3D operator *(Vector3D v, float s) => new Vector3D(s * v.X, s * v.Y, s * v.Z);

        #endregion

    }

}
