using System.Text;
using Formatter.Configuration;
using Formatter.Configuration.utils;
using Formatter.Formatter.handlers;

namespace Formatter.Formatter;

public class TypescriptFormatter : IFormatter
{
    private StringBuilder sb { get; } = new();

    private static string GetTypeDeclaration()
    {
        return FormatConfiguration.TypeDeclaration switch
        {
            TypeDeclaration.Class => "class",
            TypeDeclaration.Interface => "export interface",
            TypeDeclaration.Enum => "enum",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static string GetIdent()
    {
        var ident = new string(' ', FormatConfiguration.IdentSize * FormatConfiguration.IdentLevel);
        return ident;
    }

    private static string GetTab()
    {
        var tab = new string(' ', FormatConfiguration.TabSize);
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

    private static string FormatNamingConvention(string identifier)
    {
        return FormatConfiguration.NamingConvention switch
        {
            NamingConvention.camelCase => NamingConventionHandler.ToCamelCase(identifier),
            NamingConvention.PascalCase => NamingConventionHandler.ToPascalCase(identifier),
            NamingConvention.snake_case => NamingConventionHandler.ToSnakeCase(identifier),
            _ => identifier
        };
    }

    public void FormatLine(string identifier, string type)
    {
        if (FormatConfiguration.TypeDeclaration != TypeDeclaration.Interface)
            return;

        if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(type))
            return;

        identifier = FormatNamingConvention(identifier);

        //TODO: Change this
        sb.Append(GetIdent());
        sb.Append(identifier);
        sb.Append(':');
        sb.Append(GetTab());
        sb.Append(type);
        sb.Append(';');
        sb.AppendLine();
    }

    public void FormatComment(string comment)
    {
        Console.WriteLine("A");
        sb.Append(GetIdent());
        sb.Append("//");
        sb.Append(comment);
        sb.AppendLine();
    }

    public string GetResult()
    {
        EndTypeDeclaration();
        return sb.ToString();
    }
}