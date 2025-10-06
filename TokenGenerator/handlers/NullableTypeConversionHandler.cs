using TokenGenerator.interfaces;
using TokenGenerator.Validation;

namespace TokenGenerator.handlers;

public class NullableTypeConversionHandler(ITokenGenerator generator) : ITokenTypeHandler
{
    public bool CanConvert(string token)
    {
        return token.ValidateNullableFormat();
    }

    public string Convert(string token)
    {
        var baseType = token.TrimEnd('?');
        return generator.Convert(baseType) + " | null";
    }
}