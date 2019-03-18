using System;

namespace VectorAndPoint
{
    public interface IVector2D<T> : I2D<T>, ILength
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        bool IsCollinearWith(IVector2D<T> vector);

    }
}
