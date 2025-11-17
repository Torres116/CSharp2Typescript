namespace Web.Components.buttons;

public sealed class DropdownOption<T>(T value, int key)  
{
    public T Value { get; } = value;
    public int Key { get; } = key;
}