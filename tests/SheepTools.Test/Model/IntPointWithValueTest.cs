using SheepTools.Model;
using Xunit;

namespace SheepTools.Test.Model;

public class IntPointWithValueTest
{
    [Fact]
    public void Equal()
    {
        var a = new IntPointWithValue<string>(0, 0);
        var b = new IntPointWithValue<string>(0, 0);
        var c = new IntPointWithValue<string>(0, 1);

        Assert.Equal(a, b);
        Assert.NotEqual(a, c);
        Assert.True(a.Equals(b));
        Assert.True(a == b);
        Assert.True(a != c);

        HashSet<IntPointWithValue<string>> set = new() { a };
        Assert.False(set.Add(b));
        Assert.True(set.Add(c));
    }

    [Fact]
    public void ToStringTest()
    {
        var p = new IntPointWithValue<string>("Value", 0, 1);

        Assert.Equal($"[{p.X}, {p.Y}]", p.ToString());
        Assert.Equal("Value", p.Value);
    }
}
