using TokenGenerator.handlers;
using TokenGenerator.interfaces;

namespace TokenGenerator;

public class TypescriptTokenGenerator : ITokenGenerator
{
    private List<ITokenTypeHandler>? _typeHandlers;

    public TypescriptTokenGenerator()
    {
        InitTypeHandlers();
    }

    private void InitTypeHandlers()
    {
        _typeHandlers = new List<ITokenTypeHandler>
        {
            new PrimitiveConversionHandler(),
            new NullableTypeConversionHandler(this),
            new DictionaryTypeConversionHandler(this),
            new ListTypeConversionHandler(this)
        };
    }

    public TypescriptToken InterpretToken(Token token)
    {
        var convertedType = Convert(token.Type ?? string.Empty);

        var _t = new TypescriptToken
        {
            Type = convertedType,
            Identifier = token.Identifier
        };

        return _t;
    }

    public string Convert(string type)
    {
        foreach (var _strategy in _typeHandlers ?? [])
        {
            if (_strategy.CanConvert(type))
               type = _strategy.Convert(type);
        }

        return type;
    }
    
}