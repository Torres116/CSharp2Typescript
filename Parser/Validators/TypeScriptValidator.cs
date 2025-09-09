using Parser.Interfaces;

namespace Parser;

public class TypeScriptValidator : IValidator
{
    public Task<bool> Validate(string text)
    {
        return Task.FromResult(false);
    }
}