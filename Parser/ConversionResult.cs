using TokenGenerator;
using TokenGenerator.interfaces;

namespace Parser;

public class ConversionResult
{
    public List<IParsedToken> ParsedTokens { get; set; }
    public string Output { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = [];
}