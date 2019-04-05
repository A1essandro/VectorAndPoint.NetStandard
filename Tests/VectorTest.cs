using System;
using VectorAndPoint.ValTypes;
using Xunit;

namespace Tests
{
    public class VectorTest
    {

        [Fact]
        public void EqualsTest()
        {
            var v1 = new Vector(1, 1);
            var v2 = new Vector(1, 1);
            var v3 = new Vector(1, 2);

            Assert.Equal(v1, v2);
            Assert.NotEqual(v1, v3);
            Assert.NotEqual(v2, v3);
            Assert.True(v1 == v2);
            Assert.False(v1 != v2);
        }

        [Fact]
        public void LengthTest()
        {
            var v1 = new Vector(1, 1);

            var res = Math.Sqrt(1 + 1);

            Assert.Equal(res, v1.Length);
        }

        [Fact]
        public void CollinearTest()
        {
            var v1 = new Vector(1, 8);
            var v2 = new Vector(2, 16);
            var v3 = new Vector(4, 10);
            var v4 = new Vector(1, 0);
            var v5 = new Vector(-2, 0);
            var v6 = new Vector(3, 0);

            Assert.True(v1.IsCollinearWith(v2));
            Assert.False(v1.IsCollinearWith(v3));
            Assert.False(v2.IsCollinearWith(v3));
            Assert.True(v4.IsCollinearWith(v5));
            Assert.True(v4.IsCollinearWith(v6));
        }

        [Fact]
        public void SumTest()
        {
            var v1 = new Vector(0, 1);
            var v2 = new Vector(1, 0);

            var res = new Vector(1, 1);

            Assert.Equal(res, v1 + v2);
        }

        [Fact]
        public void ScalarMultipleTest()
        {
            var v1 = new Vector(1, 1);
            var v2 = new Vector(1, 0);

            Assert.Equal(1, v1.GetScalarProductWith(v2));
        }

        [Fact]
        public void AngleTest()
        {
            var v1 = new Vector(0, 1);
            var v2 = new Vector(1, 0);

            Assert.Equal(Math.PI / 2, v1.GetAngleWith(v2));
        }

    }
}
