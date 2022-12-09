namespace SheepTools.Model;

/// <summary>
/// Lightweight <see cref="Point"/> record class, based on <see cref="int"/> and with value
/// </summary>
public record IntPointWithValue<T> : IntPoint
{
    public T? Value { get; set; }

    public IntPointWithValue(int x, int y) : base(x, y)
    {
    }

    public IntPointWithValue(T value, int x, int y) : base(x, y)
    {
        Value = value;
    }

#pragma warning disable RCS1132 // Remove redundant overriding member - not redundant, https://github.com/JosefPihrt/Roslynator/issues/744
    public override string ToString() => base.ToString();
#pragma warning restore RCS1132 // Remove redundant overriding member.
}
