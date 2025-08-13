namespace EventModular.Shared.Dtos.Course.ValueObjects;
[ComplexType] // برای EF Core
public sealed record IndexValue
{
    public int Value { get; private init; }

    // Constructor اصلی برای ساخت امن
    public IndexValue(int value)
    {
        if (value < 0)
            throw new ArgumentException("Index must be greater than or equal to 0.", nameof(value));

        Value = value;
    }

    // EF Core needs a private constructor
    private IndexValue() { }

    // Implicit conversions
    public static implicit operator int(IndexValue i) => i.Value;
    public static implicit operator IndexValue(int v) => new IndexValue(v);

    public override string ToString() => Value.ToString();
}
