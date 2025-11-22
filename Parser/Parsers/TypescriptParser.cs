using Formatter.Formatter;
using Parser.Interfaces;
using TokenGenerator;
using TokenGenerator.interfaces;

namespace Parser.Parsers;

internal sealed class TypescriptParser : IParser
{
    private readonly TypescriptTokenGenerator _generator = new();
    ConversionResult _conversionResult = new();

    public ConversionResult Parse(List<IToken> rawTokens)
    {
        _conversionResult.Output = Build(rawTokens);
        return _conversionResult;
    }

    string Build(List<IToken> tokens)
    {
        var parsed = new List<IParsedToken>();
        foreach (var token in tokens)
        {
            var newToken = _generator.ConvertToken(token);
            if (newToken != null)
                parsed.Add(newToken);
            else
                // _conversionResult.Errors.Add($"Error parsing token: {token.Identifier}");
                Console.WriteLine($"Error parsing token: {token.Identifier ?? "null"}");
        }

        var ft = new TypescriptFormatter();
        ft.Format(parsed
            .Select(token => (token.Identifier, token.Type, token.IsComment, token.Comment, token.IsDeclaration,
                token.IsCustomType, token.CustomTypes))
            .ToList());

        return ft.GetResult();
    }
}