using VectorAndPoint.ValTypes;
using Xunit;

namespace Tests
{
    public class PointTest
    {

        [Fact]
        public void EqualsTest()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(1, 1);
            var p3 = new Point(1, 2);

            Assert.Equal(p1, p2);
            Assert.NotEqual(p1, p3);
            Assert.NotEqual(p2, p3);
            Assert.True(p1 == p2);
            Assert.False(p1 != p2);
        }
    }
}
