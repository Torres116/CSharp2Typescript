using Parser.Token;

namespace Parser.Context;

public interface  ITokenGenerator
{
    public TypescriptToken InterpretToken(Token.Token token);
}   