using TokenGenerator.interfaces;

namespace TokenGenerator.handlers;

public class PrimitiveConversionHandler : ITokenTypeHandler
{
    private static readonly Dictionary<string, string> Types = new()
    {
        { "string", "string" },
        { "guid", "string" },
        { "bool", "boolean" },
        { "datetime", "Date" },
        { "timespan", "Date" },
        { "int", "number" },
        { "float", "number" },
        { "double", "number" },
        { "long", "number" },
        { "short", "number" },
        { "decimal", "number" },
        { "byte", "number" },
        { "sbyte", "number" },
        { "uint", "number" },
        { "ulong", "number" },
        { "ushort", "number" },
        { "object", "any" },
    };

    public bool CanConvert(string token)
    {
        return !token.Contains('<') && !token.Contains('[') && !token.Contains('?');
    }

    public string Convert(string token)
    {
        return Types.GetValueOrDefault(token.ToLower(), token);
    }
}
