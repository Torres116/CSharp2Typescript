namespace TokenGenerator.interfaces;

public interface ITokenGenerator
{
    public TypescriptToken InterpretToken(Token token);
    public string Convert(string type); 
}   