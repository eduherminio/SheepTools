using SheepTools.Extensions;
using SheepTools.Model;
using System.Numerics;
using Xunit;

namespace SheepTools.Test.Model;

public class Vector2ExtensionsTest
{
    [Fact]
    public void Equal()
    {
        var a = new Vector2(0, 0);
        var b = new Vector2(0, 0);
        var c = new Vector2(0, 1);

        Assert.Equal(a, b);
        Assert.NotEqual(a, c);
        Assert.True(a.Equals(b));
        Assert.True(a == b);
        Assert.True(a != c);

        HashSet<Vector2> set = new() { a };
        Assert.False(set.Add(b));
        Assert.True(set.Add(c));
    }

    [Fact]
    public void ToPrettyString()
    {
        var p = new Vector2(0, 0);

        Assert.Equal($"[{p.X}, {p.Y}]", p.ToPrettyString());
    }

    [Fact]
    public void Distance()
    {
        var a = new Vector2(0, 0);
        var b = new Vector2(1, 1);

        var distance = a.DistanceTo(b);

        Assert.True(distance.DoubleEquals(Math.Sqrt(2)));
    }

    [Fact]
    public void ManhattanDistance()
    {
        var a = new Vector2(0, 0);
        var b = new Vector2(0, 1);
        var c = new Vector2(1, 1);

        var distanceAB = a.ManhattanDistance(b);
        Assert.Equal(1, distanceAB);

        var distanceAC = a.ManhattanDistance(c);
        Assert.Equal(2, distanceAC);
    }

    [Fact]
    public void ChebyshevDistance()
    {
        var a = new Vector2(0, 0);
        var b = new Vector2(0, 1);
        var c = new Vector2(1, 1);
        var d = new Vector2(1, 2);
        var e = new Vector2(2, 2);

        var distanceAB = a.ChebyshevDistance(b);
        Assert.Equal(1, distanceAB);

        var distanceAC = a.ChebyshevDistance(c);
        Assert.Equal(1, distanceAC);

        var distanceAD = a.ChebyshevDistance(d);
        Assert.Equal(2, distanceAD);

        var distanceAE = a.ChebyshevDistance(e);
        Assert.Equal(2, distanceAE);
    }

    [Theory]
    [InlineData('^', 'v', '<', '>')]
    public void MoveChar(char up, char down, char left, char right)
    {
        var startPoint = new Vector2(0, 0);

        var newPoint = startPoint.Move(up, 2);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(0, newPoint.X);
        Assert.Equal(2, newPoint.Y);

        newPoint = startPoint.Move(down);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(0, newPoint.X);
        Assert.Equal(-1, newPoint.Y);

        newPoint = startPoint.Move(left, -2);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(2, newPoint.X);
        Assert.Equal(0, newPoint.Y);

        newPoint = startPoint.Move(right, -3);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(-3, newPoint.X);
        Assert.Equal(0, newPoint.Y);
    }

    [Fact]
    public void MoveDirection()
    {
        var startPoint = new Vector2(0, 0);

        var newPoint = startPoint.Move(Direction.Up);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(0, newPoint.X);
        Assert.Equal(1, newPoint.Y);

        newPoint = startPoint.Move(Direction.Down, -1);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(0, newPoint.X);
        Assert.Equal(1, newPoint.Y);

        newPoint = startPoint.Move(Direction.Left, 2);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(-2, newPoint.X);
        Assert.Equal(0, newPoint.Y);

        newPoint = startPoint.Move(Direction.Right, 3);
        Assert.Equal(0, startPoint.X);
        Assert.Equal(0, startPoint.Y);
        Assert.Equal(3, newPoint.X);
        Assert.Equal(0, newPoint.Y);
    }

    [Theory]
    [InlineData(0, 0, 90, 1, 0, 0, 1)]
    [InlineData(0, 0, 90, 0, 1, -1, 0)]
    [InlineData(0, 0, 90, -1, 0, 0, -1)]
    [InlineData(0, 0, 90, 0, -1, 1, 0)]
    [InlineData(0, 0, 180, 1, 1, -1, -1)]
    [InlineData(0, 0, 180, 1, -1, -1, 1)]
    [InlineData(0, 0, 180, -1, 1, 1, -1)]
    [InlineData(0, 0, 180, -1, -1, 1, 1)]
    public void RotateCounterclockwise(int x0, int y0, int angle, int x1, int y1, int expectedX, int expectedY)
    {
        var pivot = new Vector2(x0, y0);
        var pointToBeRotated = new Vector2(x1, y1);

        var result = pointToBeRotated.RotateCounterclockwise(pivot, angle);

        Assert.Equal(expectedX, result.X, 4);
        Assert.Equal(expectedY, result.Y, 4);
    }

    [Theory]
    [InlineData(0, 0, 90, 1, 0, 0, -1)]
    [InlineData(0, 0, 90, 0, -1, -1, 0)]
    [InlineData(0, 0, 90, -1, 0, 0, 1)]
    [InlineData(0, 0, 90, 0, 1, 1, 0)]
    [InlineData(0, 0, 180, 1, 1, -1, -1)]
    [InlineData(0, 0, 180, 1, -1, -1, 1)]
    [InlineData(0, 0, 180, -1, 1, 1, -1)]
    [InlineData(0, 0, 180, -1, -1, 1, 1)]
    public void RotateClockwise(int x0, int y0, int angle, int x1, int y1, int expectedX, int expectedY)
    {
        var pivot = new Vector2(x0, y0);
        var pointToBeRotated = new Vector2(x1, y1);

        var result = pointToBeRotated.RotateClockwise(pivot, angle);

        Assert.Equal(expectedX, result.X, 4);
        Assert.Equal(expectedY, result.Y, 4);
    }
}
