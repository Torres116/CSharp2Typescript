namespace Parser.Interfaces;

public interface IValidator
{
    Task<bool>Validate(string text);
}