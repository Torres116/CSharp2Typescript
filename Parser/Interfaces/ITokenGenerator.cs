using Parser.Token;

namespace Parser.Context;

public interface ITokenGenerator
{
    public TypescriptToken InterpretToken(Token.Token token);
    public string Convert(string type); 
}   