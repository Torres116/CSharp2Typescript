using Formatter.Configuration;
using TokenGenerator.interfaces;
using TokenGenerator.Validation;

namespace TokenGenerator.Handlers.Type;

internal sealed class DateAsStringConversionHandler(ITokenGenerator generator) : ITokenHandler
{
    public void Verify(IParsedToken token)
    {
        var result = token.Type.ValidateDateFormat();
        token.IsDate = result;
    }

    public void Convert(IParsedToken token)
    {
        if (FormatConfiguration.DatesAsStrings && token.IsDate) 
            token.Type = "string";
    }
}