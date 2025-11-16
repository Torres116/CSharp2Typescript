using Formatter.Options;

namespace TokenGenerator.Handlers;

public class CleanupHandler
{
    public static void Cleanup(Token token)
    {
        token.Type = token.Type.Replace("?", "");
        
        if (!FormatOptions.IncludeOptionals)
            token.Identifier = token.Identifier!.Replace("?","");
    }
}