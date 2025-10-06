namespace Web.Components.buttons;

public sealed class DropdownOption(string value, int index) 
{
    public string Value { get; } = value;
    public int Index { get; } = index;
}