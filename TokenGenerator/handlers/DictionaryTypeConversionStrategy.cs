using TokenGenerator.interfaces;
using TokenGenerator.Validation;

namespace TokenGenerator.handlers;

public class DictionaryTypeConversionStrategy(ITokenGenerator generator) : ITokenTypeHandler
{
    public bool CanConvert(string token)
    {
        return token.ValidateDictionaryFormat();
    }

    public string Convert(string token)
    {
        var types = token.Replace("Dictionary", "").Replace("<", "").Replace(">", "");
        var type1 = types.Split(",")[0].Trim();
        var type2 = types.Split(",")[1].Trim();
        return $"Record<{generator.Convert(type1)},{generator.Convert(type2)}>";
    }
}