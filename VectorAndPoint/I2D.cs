﻿using System;

namespace VectorAndPoint
{
    public interface I2D<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        T X { get; }

        T Y { get; }

    }
}
