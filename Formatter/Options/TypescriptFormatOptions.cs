using Formatter.Options.Enums;
using Formatter.Options.utils;

namespace Formatter.Options;

public sealed class TypescriptFormatOptions : IFormatOptions
{
    public int TabSize { get; set; } = 4;
    public int IdentSize { get; set; } = 2;
    public int IdentLevel { get; set; } = 1;

    public TypeDeclaration TypeDeclaration { get; set; } = TypeDeclaration.Interface;
    public NamingConvention NamingConvention { get; set; } = NamingConvention.CamelCase;

    private static TypescriptFormatOptions? instance;
    private static readonly object padlock = new();

    public static TypescriptFormatOptions GetInstance
    {
        get
        {
            lock (padlock)
            {
                return instance ??= new TypescriptFormatOptions();
            }
        }
    }
}