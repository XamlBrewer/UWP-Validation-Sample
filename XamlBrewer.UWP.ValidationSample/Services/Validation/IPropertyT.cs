namespace Template10.Interfaces.Validation
{
    public interface IProperty<T> : IProperty
    {
        T OriginalValue { get; set; }

        T Value { get; set; }
    }
}