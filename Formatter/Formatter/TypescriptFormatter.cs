
using System.Text;
using Formatter.interfaces;
using Formatter.Options;

namespace Formatter.Formatter;

public class TypescriptFormatter : IFormatter
{
    private TypescriptFormatOptions TypescriptFormatOptions { get; } = TypescriptFormatOptions.GetInstance;
    private StringBuilder sb = new();
    
    private string GetTypeDeclaration()
    {
        return "";
    }

    private string GetIdent()
    {
        var ident = new string(' ', TypescriptFormatOptions.IdentSize * TypescriptFormatOptions.IdentLevel);
        return ident;
    }

    private string GetTab()
    {
        var tab = new string(' ', TypescriptFormatOptions.TabSize);
        return tab;
    }

    public void FormatTypeDeclaration(string identifier)
    {
        var declaration = $"interface {identifier} " + "{" ;
        sb.Append(declaration);
        sb.AppendLine();
    }
    
    public void FormatLine(string type, string ident)
    {

        sb.Append(GetIdent());
        sb.Append(ident);
        sb.Append(":");
        sb.Append(GetTab());
        sb.Append(type);
        sb.Append(";");
        sb.AppendLine();
    }

    private void EndTypeDeclaration()
    {
        sb.Append("}");
    }
    
    public string GetResult()
    {
        EndTypeDeclaration();
        return sb.ToString();
    }
}