using Parser.Token;

namespace Parser.Context;

public class TypescriptTokenGenerator : ITokenGenerator
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

        FormatIfArray(_t);
        FormatIfNullable(_t);

        return _t;
    }

    private string GetType(Token.Token token)
    {
        var tokenType = token.Type!;
        tokenType = tokenType.Replace("[]", "").Replace("?","");
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

    private static void FormatIfNullable(TypescriptToken token)
    {
        if (token is { Nullable: false })
            return;
        
        token.Type = token.Type.Replace("?", "");
        token.Identifier += "?";
    }

    private static void FormatIfArray(TypescriptToken token)
    {
        token.Type = token.Type.Replace("List", "").Replace("<", "").Replace(">", "").Replace("[]","");
        token.Type += "[]";
    }
    
}