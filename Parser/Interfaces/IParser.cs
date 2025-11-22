using TokenGenerator;
using TokenGenerator.interfaces;

namespace Parser.Interfaces;

internal interface IParser
{
    ConversionResult Parse(List<IToken> rawTokens);
}