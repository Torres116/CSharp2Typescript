namespace Parser.Token;

internal class Lexer
{

    public List<Token> Tokenize(string input)
    {
        var result = new List<Token>();
        var separators = new[]{";","\n"," "};
        var newInput = input.Split(separators,StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var item in newInput)
        {
            if (int.TryParse(item, out _))
            {
                result.Add(new Token
                {
                    Identifier = item,
                    Type = TokenType.Number,
                    index = result.Count + 1
                });
            }
            else if(item.StartsWith("\"") && item.EndsWith("\""))
            {
                result.Add(new()
                {
                    Identifier = item.Substring(1, item.Length - 2),
                    Type = TokenType.String,
                    index = result.Count + 1
                });
                
            }
            else if (item is "{" or "}")
            {
                result.Add(new()
                {
                    Identifier = item,
                    Type = item == "{" ? TokenType.BraceOpen : TokenType.BraceClose,
                    index = 0
                });
            }
            else
            {
                result.Add(new()
                {
                    Identifier = item,
                    Type = TokenType.Identifier,
                    index = result.Count + 1
                });
            }
            
            // Console.WriteLine(item);

        }
        
        return result;
    }
    

};

