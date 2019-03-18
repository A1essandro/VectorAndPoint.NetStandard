using System;

namespace VectorAndPoint
{
    public interface I3D<T> : I2D<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        T Z { get; }

    }
}
