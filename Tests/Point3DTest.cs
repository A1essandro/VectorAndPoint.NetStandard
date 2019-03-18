using VectorAndPoint.ValTypes;
using Xunit;

namespace Tests
{
    public class Point3DTest
    {

        [Fact]
        public void EqualsTest()
        {
            var p1 = new Point3D(0, 1, 2);
            var p2 = new Point3D(0, 1, 2);
            var p3 = new Point3D(1, 2, 3);

            Assert.Equal(p1, p2);
            Assert.NotEqual(p1, p3);
            Assert.NotEqual(p2, p3);
        }
    }
}
