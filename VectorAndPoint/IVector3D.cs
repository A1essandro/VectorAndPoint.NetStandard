using System;

namespace VectorAndPoint
{
    public interface IVector3D<T> : I3D<T>, ILength
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        bool IsCollinearWith(IVector3D<T> vector);

    }
}
