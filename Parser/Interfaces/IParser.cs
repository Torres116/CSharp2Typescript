namespace Parser.Interfaces;

public interface IParser
{
    Task<string> Parse(List<Token.Token> tokens);
}