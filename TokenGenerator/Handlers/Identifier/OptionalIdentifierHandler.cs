using Formatter.Configuration;
using TokenGenerator.interfaces;

namespace TokenGenerator.Handlers.Identifier;

internal class OptionalIdentifierHandler(ITokenGenerator generator) : ITokenHandler
{
    public void Verify(IParsedToken token)
    {
        var result = token.IsNull;
        token.IsOptional = result;
    }

    public void Convert(IParsedToken token)
    {
        if (!token.IsOptional || !FormatConfiguration.IncludeOptionals)
            return;

        token.Identifier = $"{token.Identifier}?";
    }
}