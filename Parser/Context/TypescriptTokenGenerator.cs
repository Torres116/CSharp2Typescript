using Parser.Token;

namespace Parser.Context;

public class TypescriptTokenGenerator : ParserTokenGenerator
{
    private readonly Dictionary<string, string> types = new()
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
        { "object", "any" }
    };
        
    public TypescriptToken InterpretToken(Token.Token token)
    {
        
        var _t = new TypescriptToken
        {
            Nullable = IsNullable(token),
            Array = IsArray(token),
            Identifier = token.Identifier!,
            Type = GetType(token)
        };

        if (_t.Array)
           _t.Type = FormatIfArray(_t.Type);
        
        return _t;
    }

    private string GetType(Token.Token token)
    {
        var tokenType = token.Type!;
        tokenType = tokenType.Replace("[]", "");
        return types.GetValueOrDefault(tokenType.ToLower(), tokenType);
    }

    private static bool IsNullable(Token.Token token)
    {
        return token.Type!.Contains('?');
    }

    private static bool IsArray(Token.Token token)
    {
        if (token.Type!.Contains("[]"))
            return true;

        if (token.Type!.Contains("List"))
            return true;

        return false;
    }

    string FormatIfArray(string token)
    {
        token = token.Replace("List", "").Replace("<", "").Replace(">", "").Replace("[]","");
        token += "[]";
        return token;
    }
    
}