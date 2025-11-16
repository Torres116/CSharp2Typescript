using Formatter.Options;
using TokenGenerator.interfaces;
using TokenGenerator.Validation;

namespace TokenGenerator.Handlers.Type;

public class DateAsStringConversionHandler(ITokenGenerator generator) : ITokenHandler
{
    public void Verify(TypescriptToken token)
    {
        var result = token.Type.ValidateDateFormat();
        token.IsDate = result;
    }

    public void Convert(TypescriptToken token)
    {
        if (FormatOptions.DatesAsStrings && token.IsDate) 
            token.Type = "string";
    }
}