using TokenGenerator.interfaces;
using TokenGenerator.Validation;

namespace TokenGenerator.handlers;

public class ListTypeConversionHandler(ITokenGenerator generator) : ITokenTypeHandler
{
    public bool CanConvert(string token)
    {
        return token.Contains("[]")
            ? token.ValidateArrayFormat()
            : token.ValidateListFormat();
    }

    public string Convert(string token)
    {
        var type = token.Replace("List", "").Replace("<", "").Replace(">", "").Replace("[]","");
        return $"{generator.Convert(type)}[]";
    }
}