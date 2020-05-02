using SheepTools.Extensions;
using System.Collections.Generic;
using Xunit;

namespace SheepTools.Test.Extensions
{
    public class IntExtensionsTest
    {
        [Fact]
        public void Factorial()
        {
            var testCases = new Dictionary<int, int>()
            {
                [0] = 1,
                [1] = 1,
                [2] = 2,
                [3] = 6,
                [4] = 24,
                [5] = 120
            };

            foreach (var pair in testCases)
            {
                Assert.Equal(pair.Value, pair.Key.Factorial());
            }
        }

        [Fact]
        public void Clamp()
        {
            const int minValue = -3;
            const int maxValue = +3;

            var testCases = new Dictionary<int, int>()
            {
                [int.MinValue] = minValue,
                [-99999999] = minValue,
                [-4] = minValue,
                [minValue] = minValue,
                [-2] = -2,
                [-1] = -1,
                [0] = 0,
                [+1] = +1,
                [+2] = +2,
                [maxValue] = maxValue,
                [+4] = maxValue,
                [+99999999] = maxValue,
                [int.MaxValue] = maxValue
            };

            foreach (var pair in testCases)
            {
                Assert.Equal(pair.Value, pair.Key.Clamp(minValue, maxValue));
            }
        }
    }
}
