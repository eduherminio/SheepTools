using SheepTools.Model;
using System.Numerics;

namespace SheepTools.Extensions;

public static class Vector2Extensions
{
    public static Vector2 Move(this Vector2 vector, char direction, int distance = 1)
    {
        return direction switch
        {
            '>' or 'R' or 'r' => vector with { X = vector.X + distance },
            '<' or 'L' or 'l' => vector with { X = vector.X - distance },
            '^' or 'U' or 'u' => vector with { Y = vector.Y + distance },
            'v' or 'D' or 'd' => vector with { Y = vector.Y - distance },
            _ => throw new ArgumentException("Supported directions: >, R, r; < L, l; ^, U, u; v, D, d")
        };
    }

    public static Vector2 Move(this Vector2 vector, Direction direction, float distance = 1)
    {
        return direction switch
        {
            Direction.Right => vector with { X = vector.X + distance },
            Direction.Left => vector with { X = vector.X - distance },
            Direction.Up => vector with { Y = vector.Y + distance },
            Direction.Down => vector with { Y = vector.Y - distance },
            _ => throw new NotSupportedException($"Direction {direction} isn't supported yet")
        };
    }

    public static double DistanceTo(this Vector2 vector, Vector2 otherVector) => Vector2.Distance(vector, otherVector);

    public static double ManhattanDistance(this Vector2 vector, Vector2 otherVector)
    {
        return Math.Abs(otherVector.X - vector.X) + Math.Abs(otherVector.Y - vector.Y);
    }

    public static double ChebyshevDistance(this Vector2 vector, Vector2 otherVector)
    {
        var xDelta = Math.Abs(vector.X - otherVector.X);
        var yDelta = Math.Abs(vector.Y - otherVector.Y);

        return xDelta >= yDelta
            ? xDelta
            : yDelta;
    }

    public static Point RotateCounterclockwise(this Vector2 vector, Vector2 pivot, double angle, bool isRadians = false)
    {
        if (!isRadians)
        {
            angle = Math.PI * angle / 180;
        }

        var sinAngle = Math.Sin(angle);
        var cosAngle = Math.Cos(angle);

        double deltaX = vector.X - pivot.X;
        double deltaY = vector.Y - pivot.Y;

        return new Point(
            x: pivot.X
                + (cosAngle * deltaX)
                - (sinAngle * deltaY),
            y: pivot.Y
                + (sinAngle * deltaX)
                + (cosAngle * deltaY));
    }

    public static Point RotateClockwise(this Vector2 vector, Vector2 pivot, double angle, bool isRadians = false)
    {
        if (!isRadians)
        {
            angle = Math.PI * angle / 180;
        }

        var sinAngle = Math.Sin(angle);
        var cosAngle = Math.Cos(angle);

        var deltaX = vector.X - pivot.X;
        var deltaY = vector.Y - pivot.Y;

        return new Point(
            x: pivot.X
                + (cosAngle * deltaX)
                + (sinAngle * deltaY),
            y: pivot.Y
                - (sinAngle * deltaX)
                + (cosAngle * deltaY));
    }

    public static string ToPrettyString(this Vector2 vector)
    {
        return $"[{vector.X}, {vector.Y}]";
    }
}
