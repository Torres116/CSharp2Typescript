using System.Text;
using Parser.Context;
using Parser.Interfaces;
using Parser.Token;

namespace Parser.Parsers;

public class TypescriptParser : IParser
{

    public Task<string> Parse(List<Token.Token> tokens)
    {
        var generator = new TypescriptTokenGenerator();
        List<TypescriptToken> tsTokens =
            tokens.Select(token => generator.InterpretToken(token)).ToList();

        var result = Build(tsTokens);
        return Task.FromResult(result);
    }

    string Build(List<TypescriptToken> tokens)
    {
        var sb = new StringBuilder();
        foreach (var token in tokens)
        {
            sb.Append(token.Identifier);
            sb.Append(":");
            sb.Append(token.Type);
            sb.Append(";");
            sb.AppendLine();
        }
        
        return sb.ToString();
    }
       
}