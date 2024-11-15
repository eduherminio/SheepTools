﻿using SheepTools.Extensions;
using System.Collections;
using Xunit;

namespace SheepTools.Test;

public class BitArrayComparerTest
{
    [Fact]
    public void BitArrayComparer()
    {
#pragma warning disable CA1861 // Avoid constant arrays as arguments
        var set = new HashSet<BitArray>
            {
                new(new[] { true, false }),
                new(new[] { false, true }),
            };

        var otherSet = new HashSet<BitArray>
            {
                new(new[] { true, false }),
                new(new[] { false, true }),
            };
#pragma warning restore CA1861 // Avoid constant arrays as arguments

        // Without the comparer
        Assert.NotEqual(set, otherSet);
        Assert.False(set == otherSet);

        var aggregatedSet = new HashSet<BitArray>();
        set.ForEach(s => aggregatedSet.Add(s));
        otherSet.ForEach(s => aggregatedSet.Add(s));
        Assert.Equal(4, aggregatedSet.Count);

        // Using the comparer
        Assert.Equal(set, otherSet, new BitArrayComparer());

        var otherAggregatedSet = new HashSet<BitArray>(new BitArrayComparer());
        set.ForEach(s => otherAggregatedSet.Add(s));
        otherSet.ForEach(s => otherAggregatedSet.Add(s));
        Assert.Equal(2, otherAggregatedSet.Count);

        var aggregatedList = new List<BitArray>();
        set.ForEach(s => aggregatedList.Add(s));
        otherSet.ForEach(s => aggregatedList.Add(s));
        Assert.Equal(4, aggregatedList.ToHashSet().Count);
        Assert.Equal(2, aggregatedList.ToHashSet(new BitArrayComparer()).Count);
    }
}
