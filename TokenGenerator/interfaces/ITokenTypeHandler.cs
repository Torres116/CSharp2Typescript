namespace TokenGenerator.interfaces;

public interface ITokenTypeHandler
{
    bool CanConvert(string token);
    string Convert(string token);
}