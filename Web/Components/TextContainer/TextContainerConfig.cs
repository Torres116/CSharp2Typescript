namespace Web.Components.InputContainer;

public sealed class TextContainerConfig(
    bool isReadOnly,
    string title)
{
    public bool IsReadOnly { get; } = isReadOnly;
    public string Title { get; } = title;
}

