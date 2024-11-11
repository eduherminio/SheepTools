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

    public override string ToString() => base.ToString();
}
