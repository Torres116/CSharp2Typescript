using System.Text;
using Parser.Parsers;
using Parser.Token;

namespace Parser;

public class ParseService
{
    Config _config;
    
    public async Task<string> ParseText(string text,Config cfg)
    {
        _config = cfg;
        await Parse(text);
        return "not implemented lol"; 
    }

    async Task<string> Parse(string text)
    {
        try
        {
            var lexer = new Lexer();
            var parser = ParserFactory.GetParser(_config.parser);
            var tokens = lexer.Tokenize(text);
            var result = await parser.Parse(tokens);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return "";
    }

    
}