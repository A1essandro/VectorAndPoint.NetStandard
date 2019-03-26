using System;
using VectorAndPoint.ValTypes;
using Xunit;

namespace Tests
{
    public class Vector3DTest
    {

        [Fact]
        public void EqualsTest()
        {
            var v1 = new Vector3D(1, 1, 1);
            var v2 = new Vector3D(1, 1, 1);
            var v3 = new Vector3D(1, 2, 3);

            Assert.Equal(v1, v2);
            Assert.NotEqual(v1, v3);
            Assert.NotEqual(v2, v3);
        }

        [Fact]
        public void LengthTest()
        {
            var v1 = new Vector3D(1, 1, 1);

            var res = Math.Sqrt(1 + 1 + 1);

            Assert.Equal(res, v1.Length);
        }

        [Fact]
        public void CollinearTest()
        {
            var v1 = new Vector3D(1, 4, 8);
            var v2 = new Vector3D(-2, -8, -16);
            var v3 = new Vector3D(4, 10, 20);
            var v4 = new Vector3D(1, 0, 0);
            var v5 = new Vector3D(1, 1, 0);
            var v6 = new Vector3D(-1, 0, 0);
            var v7 = new Vector3D(2, 0, 0);

            Assert.True(v1.IsCollinearWith(v2));
            Assert.False(v1.IsCollinearWith(v3));
            Assert.False(v2.IsCollinearWith(v3));
            Assert.False(v4.IsCollinearWith(v5));
            Assert.True(v4.IsCollinearWith(v6));
            Assert.True(v4.IsCollinearWith(v7));
        }

        [Fact]
        public void SumTest()
        {
            var v1 = new Vector3D(0, 1, 1);
            var v2 = new Vector3D(1, 0, 1);

            var res = new Vector3D(1, 1, 2);

            Assert.Equal(res, v1 + v2);
        }

        [Fact]
        public void ScalarMultipleTest()
        {
            var v1 = new Vector3D(1, 1, 0);
            var v2 = new Vector3D(1, 0, 1);

            Assert.Equal(1, v1.GetScalarProductWith(v2));
        }

        [Fact]
        public void AngleTest()
        {
            var v1 = new Vector3D(1, 1, 0);
            var v2 = new Vector3D(0, 0, 1);

            Assert.Equal(Math.PI / 2, v1.GetAngleWith(v2));
        }

    }
}
