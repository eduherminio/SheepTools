#pragma warning disable CA1861 // Avoid constant arrays as arguments

using SheepTools.Model;
using Xunit;

namespace SheepTools.Test.Model;

public class BitMatrixTest
{
    [Theory]
    [MemberData(nameof(FlipUpsideDownData))]
    public void FlipUpsideDown(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.FlipUpsideDown();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    [Theory]
    [MemberData(nameof(FlipLeftRightData))]
    public void FlipLeftRight(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.FlipLeftRight();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    [Theory]
    [MemberData(nameof(RotateClockwiseData))]
    public void RotateClockwise(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.RotateClockwise();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    [Theory]
    [MemberData(nameof(RotateAnticlockwiseData))]
    public void RotateAnticlockwise(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.RotateAnticlockwise();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    [Theory]
    [MemberData(nameof(Rotate180Data))]
    public void Rotate180(BitMatrix original, BitMatrix expectedResult)
    {
        var result = original.Rotate180();

        foreach (var (first, second) in expectedResult.Content.Zip(result.Content))
        {
            Assert.Equal(first, second);
        }
    }

    public static IEnumerable<object[]> FlipUpsideDownData()
    {
        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { true, true, false }),
                    new( new [] { false, false, false }),
                    new( new [] { true, true, true }),
                    new( new [] { false, false, true })
                ]),

                new BitMatrix(
                [
                    new( new [] { false, false, true }),
                    new( new [] { true, true, true }),
                    new( new [] { false, false, false }),
                    new( new [] { true, true, false })
                ])
        };

        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { true, true, false }),
                    new( new [] { false, false, false }),
                    new( new [] { false, false, true })
                ]),

                new BitMatrix(
                [
                    new( new [] { false, false, true }),
                    new( new [] { false, false, false }),
                    new( new [] { true, true, false })
                ])
        };
    }

    public static IEnumerable<object[]> FlipLeftRightData()
    {
        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { true, true, false }),
                    new( new [] { false, false, false }),
                    new( new [] { true, false, true }),
                    new( new [] { true , false, false })
                ]),

                new BitMatrix(
                [
                    new( new [] { false, true, true}),
                    new( new [] { false, false, false }),
                    new( new [] { true, false, true }),
                    new( new [] { false, false, true })
                ])
        };

        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { true, true, false, false }),
                    new( new [] { false, false, true, false }),
                    new( new [] { false, true, true, true })
                ]),

                new BitMatrix(
                [
                    new( new [] { false, false, true, true }),
                    new( new [] { false, true, false, false }),
                    new( new [] { true, true, true, false })
                ])
        };
    }

    public static IEnumerable<object[]> RotateClockwiseData()
    {
        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { true, false, true }),
                    new( new [] { false, false, false }),
                    new( new [] { false, false, true })
                ]),

                new BitMatrix(
                [
                    new( new [] { false, false, true}),
                    new( new [] { false, false, false }),
                    new( new [] { true, false, true })
                ])
        };

        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { true, false, true, false }),
                    new( new [] { false, true, false, true}),
                    new( new [] { false, false, true, true }),
                    new( new [] { true, true, false, true })
                ]),

                new BitMatrix(
                [
                    new( new [] { true, false, false, true }),
                    new( new [] { true, false, true, false }),
                    new( new [] { false, true, false, true }),
                    new( new [] { true, true, true, false })
                ])
        };
    }

    public static IEnumerable<object[]> RotateAnticlockwiseData()
    {
        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { false, false, true}),
                    new( new [] { false, false, false }),
                    new( new [] { true, false, true })
                ]),

                new BitMatrix(
                [
                    new( new [] { true, false, true }),
                    new( new [] { false, false, false }),
                    new( new [] { false, false, true })
                ])
        };

        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { true, false, false, true }),
                    new( new [] { true, false, true, false }),
                    new( new [] { false, true, false, true }),
                    new( new [] { true, true, true, false })
                ]),

                new BitMatrix(
                [
                    new( new [] { true, false, true, false }),
                    new( new [] { false, true, false, true}),
                    new( new [] { false, false, true, true }),
                    new( new [] { true, true, false, true })
                ])
        };
    }

    public static IEnumerable<object[]> Rotate180Data()
    {
        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { false, false, true}),
                    new( new [] { false, false, false }),
                    new( new [] { true, false, true })
                ]),

                new BitMatrix(
                [
                    new( new [] { true, false, true }),
                    new( new [] { false, false, false }),
                    new( new [] { true, false, false })
                ])
        };

        yield return new object[]
        {
                new BitMatrix(
                [
                    new( new [] { true, false, false, false }),
                    new( new [] { true, false, true, false }),
                    new( new [] { false, true, false, true }),
                    new( new [] { true, true, true, false })
                ]),

                new BitMatrix(
                [
                    new( new [] { false, true, true, true}),
                    new( new [] { true, false, true, false}),
                    new( new [] { false, true, false, true }),
                    new( new [] { false, false, false, true })
                ])
        };
    }
}

#pragma warning restore CA1861 // Avoid constant arrays as arguments
