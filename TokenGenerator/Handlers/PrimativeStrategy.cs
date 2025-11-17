namespace TokenGenerator.Handlers;

public class PrimitiveTypeMapper
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

    public void Convert(TypescriptToken token)
    {
        var type = token.Type?.Replace("[]", "").Replace("?", "").ToLower();
        var result = Types!.GetValueOrDefault(type,null);
        if (result != null && token.Type.Contains("?"))
        {
            result += "?";
            token.Type = result;
        } else if (result != null)
            token.Type = result;
    }
}