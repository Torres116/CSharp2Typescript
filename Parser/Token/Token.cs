namespace Parser.Token;

public class Token
{
    public string Identifier;
    public TokenType Type;
    public int index;
}

public enum TokenType
{
    Identifier,
    String,
    Number,
    Boolean,
    BraceOpen,
    BraceClose,
    Semicolon,
    Unknown
}