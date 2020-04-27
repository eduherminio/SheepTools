using SheepTools.Model;
using Xunit;

namespace SheepTools.Test
{
    public class LinearInterpolationTest
    {
        [Fact]
        public void Interpolate()
        {
            const double x0 = 0, x1 = 10;
            const double y0 = 0, y1 = 10;

            const double x = 5;

            var y = LinearInterpolation.InterpolateLinearly(x, x0, x1, y0, y1);

            Assert.Equal(x, y);
        }

        [Fact]
        public void InterpolateVertical()
        {
            const double x0 = 5, x1 = 5;
            const double y0 = 0, y1 = 10;

            const double x = 20;

            var y = LinearInterpolation.InterpolateLinearly(x, x0, x1, y0, y1);

            Assert.Equal(0.5 * (y0 + y1), y);
        }

        [Fact]
        public void InterpolatePoint()
        {
            var p1 = new Point(1, 0);
            var p2 = new Point(11, 10);

            const double x = 8;

            var p3 = LinearInterpolation.InterpolateLinearly(x, p1, p2);

            Assert.Equal(x, p3.X);
            Assert.Equal(x - 1, p3.Y);
        }
    }
}
