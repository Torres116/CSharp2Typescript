using Formatter.Formatter;
using Formatter.options.Typescript;

namespace Formatter.Options;

public sealed class TypescriptFormatOptions : IFormatOptions
{
    public int TabSize { get; set; } = 4;
    public int IdentSize { get; set; } = 2;
    public int IdentLevel { get; set; } = 1;
    
    public TypeDeclaration TypeDeclaration { get; set; } = TypeDeclaration.Interface;

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