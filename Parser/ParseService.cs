using Exceptions;
using Parser.Parsers;

namespace Parser;

public sealed class ParseService
{
    private Config _config;

    public async Task<string> ParseText(string text, Config cfg)
    {
        _config = cfg;
        return await Parse(text);
    }

    private async Task<string> Parse(string text)
    {
        var syntaxErrors = SyntaxHelper.GetSyntaxErrors(text);
        if (syntaxErrors.Count > 0)
        {
            var errors = syntaxErrors.Aggregate("", (current, error) => current + error + "\n");
            throw new SyntaxErrorException(errors);
        }

        var lexer = new Lexer();
        var parser = ParserFactory.GetParser(_config.parser);

        var rawTokens = lexer.Tokenize(text);
        var conversionResult = await parser.Parse(rawTokens);
        return conversionResult.Output;
    }
}