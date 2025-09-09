using System.Text;
using Parser.Context;
using Parser.Interfaces;
using Parser.Token;

namespace Parser.Parsers;

public class TypescriptParser : IParser
{

    TokenType[] ignoredTokens =
    {
        TokenType.BraceOpen,
        TokenType.BraceClose,
        TokenType.Unknown
    };

    private Dictionary<TokenType,string> syntax = new()
    {
        { TokenType.Number ,"number"},
        { TokenType.String ,"string"},
        { TokenType.Boolean ,"boolean"},
        { TokenType.Identifier, ""},
    };
    
    
    public async Task<string> Parse(List<Token.Token> tokens)
    {
        var sb = new StringBuilder();
        var skip = 0;
        var context = new ParserContext();
        
        for(int i = 0; i < tokens.Count; i++)
        {
            var token = tokens[i];
            
            if (ignoredTokens.Contains(token.Type)) continue;

            if (token is
                {
                    Type: TokenType.Identifier,
                    Identifier: "get" or "set"
                }) continue;

            if ( token is { Type: TokenType.Identifier,Identifier: "public" or "private" or "protected" })
            {
                var nextToken = tokens[i++];
                if (nextToken is { Identifier: "async", Type: TokenType.Identifier })
                {
                    
                }
            }

            // if(syntax.ContainsKey(token.Type))
            //     sb.Append(syntax[token.Type]);
            
            Console.WriteLine(token.Type);
            
        }

        return sb.ToString();
    }
    
       
}