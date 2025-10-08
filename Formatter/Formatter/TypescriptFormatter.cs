using System.Text;
using Formatter.Formatter.handlers;
using Formatter.interfaces;
using Formatter.Options;
using Formatter.Options.Enums;
using Formatter.Options.utils;

namespace Formatter.Formatter;

public class TypescriptFormatter : IFormatter
{
    private IFormatOptions _formatOptions { get; } = TypescriptFormatOptions.GetInstance;
    private StringBuilder sb { get; } = new();

    private string GetTypeDeclaration()
    {
        return _formatOptions.TypeDeclaration switch
        {
            TypeDeclaration.Class => "class",
            TypeDeclaration.Interface => "interface",
            TypeDeclaration.Enum => "enum",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string GetIdent()
    {
        var ident = new string(' ', _formatOptions.IdentSize * _formatOptions.IdentLevel);
        return ident;
    }

    private string GetTab()
    {
        var tab = new string(' ', _formatOptions.TabSize);
        return tab;
    }

    public void FormatTypeDeclaration(string identifier)
    {
        var declaration = $"{GetTypeDeclaration()} {identifier} " + "{";
        sb.Append(declaration);
        sb.AppendLine();
    }

    private void EndTypeDeclaration()
    {
        sb.Append("}");
    }

    private string FormatNamingConvention(string identifier)
    {
        return _formatOptions.NamingConvention switch
        {
            NamingConvention.CamelCase => NamingConventionHandler.ToCamelCase(identifier),
            NamingConvention.PascalCase => NamingConventionHandler.ToPascalCase(identifier),
            NamingConvention.SnakeCase => NamingConventionHandler.ToSnakeCase(identifier),
            _ => identifier
        };
    }

    public void FormatLine(string identifier, string type)
    {
        if (_formatOptions.TypeDeclaration != TypeDeclaration.Interface)
            return;

        if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(type))
            return;

        identifier = FormatNamingConvention(identifier);

        //TODO: Change this
        sb.Append(GetIdent());
        sb.Append(identifier);
        sb.Append(":");
        sb.Append(GetTab());
        sb.Append(type);
        sb.Append(";");
        sb.AppendLine();
    }

    public string GetResult()
    {
        EndTypeDeclaration();
        return sb.ToString();
    }
}