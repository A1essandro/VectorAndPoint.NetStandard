# VectorAndPoint.NetStandard

Vector, Vector3D, Point and Point3D for netstandard1.3

## Points

There are several types (structs) of points available:

**Point** - point with coordinates of type `double`

```cs
using VectorAndPoint.ValTypes;
//...........................
var point = new Point(0.5, 10.3);
```

**PointInt** - point with coordinates of type `int`

```cs
using VectorAndPoint.ValTypes;
//...........................
var point = new PointInt(1, 2);
```

**Point3D** - point with coordinates of type `double` in three-dimensional space

```cs
using VectorAndPoint.ValTypes;
//...........................
var point = new Point3D(1, 2, 3);
```

## Vectors

There are two types (structs) of vectors available:

**Vector** - vector with coordinates of type `double`

```cs
using VectorAndPoint.ValTypes;
//...........................
var vector = new Vector(0.5, 10.3);
```

**Vector3D** - vector with coordinates of type `double` in three-dimensional space

```cs
using VectorAndPoint.ValTypes;
//...........................
var vector = new Vector3D(1, 2, 3);
```

## Usage

### Common

All types overrides method `ToString()` for representating value as `(X, Y)` for two-dimensional and `(X, Y, Z)` for three-dimensional structure.

Comparison via `Equals()` has compare each coordinate or component of both structure.

#### Addition of a point and a vector

```cs
var point = new Point(0.5, 3.14);
var vector = new Vector(1, 2);
var resultVector1 = point + vector; //result is point with coordinates (1.5, 5.14)
var resultVector2 = vector + point; //result is point with coordinates (1.5, 5.14)
```

### Points behaviors

`Point` has static method `GetRangeBetween()` for calculation of range between two points.

### Vectors behaviors

Scalar product of two vectors:

```cs
var vector1 = new Vector(1, 0);
var vector2 = new Vector(2, 2);
double result = vector1.GetScalarProductWith(vector2); // 2
//or static
double result = Vector.GetScalarProduct(vector1, vector2); // 2
```

Checking vectors collinearity:

```cs
var vector1 = new Vector(1, 0);
var vector2 = new Vector(2, 2);
bool result = vector1.IsCollinearWith(vector2); // false
//or static
bool result = Vector.IsCollinear(vector1, vector2); // false
```