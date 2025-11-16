using TokenGenerator.interfaces;
using TokenGenerator.Validation;

namespace TokenGenerator.Handlers.Type;

public class ListConversionHandler(ITokenGenerator generator) : ITokenHandler
{
    public void Verify(TypescriptToken token)
    {
        var result = token.Type.ValidateArrayFormat() || token.Type.ValidateListFormat();
        token.IsArray = result;
    }

    public void Convert(TypescriptToken token)
    {
        if (!token.IsArray)
            return;
        
        token.Type = token.Type.Replace("List", "").Replace("<", "").Replace(">", "").Replace("[]","").Replace("?","");
        token.Type = $"{token.Type}[]";
    }
}