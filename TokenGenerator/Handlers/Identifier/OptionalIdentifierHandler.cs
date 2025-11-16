using Formatter.Options;
using TokenGenerator.interfaces;
using TokenGenerator.Validation;

namespace TokenGenerator.Handlers.Identifier;

public class OptionalIdentifierHandler(ITokenGenerator generator) : ITokenHandler
{
    public void Verify(TypescriptToken token)
    {
        var result = FormatOptions.IncludeOptionals && token.ValidateOptionalFormat();
        token.IsOptional = result;
    }

    public void Convert(TypescriptToken token)
    {
        if (!token.IsOptional)
        {
            return;
        }
        
        var identifier = token.Identifier.Trim();
        identifier += "?";
        
        token.Identifier = identifier;
    }
}