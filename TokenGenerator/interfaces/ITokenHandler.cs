namespace TokenGenerator.interfaces;

internal interface ITokenHandler
{
    void Verify(IParsedToken token);
    void Convert(IParsedToken token);
}