namespace TokenGenerator.interfaces;

public interface ITokenHandler
{
    void Verify(TypescriptToken token);
    void Convert(TypescriptToken token);
}