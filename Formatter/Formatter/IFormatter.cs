namespace Formatter.interfaces;

public interface IFormatter
{
    void FormatLine(string type, string ident);
    void FormatTypeDeclaration(string identifier);
}