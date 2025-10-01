using Parser.Context;
using Parser.Interfaces;
using Parser.Token;
using Parser.TokenGenerator.strategies;
using Parser.utils;

namespace Parser.TokenGenerator;

public class TypescriptTokenGenerator : ITokenGenerator
{
    private List<ITokenTypeGeneratorStrategy> _strategies;

    public TypescriptToken InterpretToken(Token.Token token)
    {

        _strategies = new List<ITokenTypeGeneratorStrategy>
        {
            new PrimitiveConversionStrategy(),
            new NullableTypeConversionStrategy(this),
            new DictionaryTypeConversionStrategy(this),
            new ListTypeConversionStrategy(this)
        };
        
        var convertedType = Convert(token.Type);
        
        var _t = new TypescriptToken
        {
            Type = convertedType,
            Identifier = token.Identifier,
            IsNullable = token.Type.Contains('?'),
            IsArray = token.Type.Contains("[]") || token.Type.Contains("List<"),
            IsDictionary = token.Type.Contains("Dictionary<")
        };

        return _t;
    }

    public string Convert(string type)
    {
        foreach (var _strategy in _strategies)
        {
            if (_strategy.CanConvert(type))
               type = _strategy.Convert(type);
        }

        return type;
    }
    
    
}