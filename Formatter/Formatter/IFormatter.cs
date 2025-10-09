namespace Formatter.interfaces;

public interface IFormatter
{
    void FormatLine(string identifier, string type);
    void FormatTypeDeclaration(string identifier);
}