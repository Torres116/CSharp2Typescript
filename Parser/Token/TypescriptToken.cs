namespace Parser.Token;

public class TypescriptToken
{
    public string Identifier { get; set; }
    public string Type { get; set; }
    public bool Array { get; set; }
    public bool Object { get; set; }
    public bool Nullable { get; set; }
}
