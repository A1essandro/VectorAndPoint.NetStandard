using System;

namespace VectorAndPoint
{
    public interface IVector2D<T> : I2D<T>, ILength
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        /// <summary>
        /// Vectors collinearity check
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        bool IsCollinearWith(IVector2D<T> other);

        /// <summary>
        /// Get the scalar product of this vector and other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        double GetScalarProductWith(IVector2D<T> other);

        /// <summary>
        /// Get the angle between this vector and other in radians
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        double GetAngleWith(IVector2D<T> other);

    }
}
