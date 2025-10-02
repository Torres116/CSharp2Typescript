using TokenGenerator;

namespace Parser.Interfaces;

public interface IParser
{
    Task<string> Parse(List<Token> tokens);
}