namespace Parser;

internal class Lexer
{
    readonly string[] dataTypes =
    [
        "class",
        "struct",
        "interface",
        "enum"
    ];

    readonly string[] ignoredKeywords =
    [
        "public",
        "private",
        "protected",
        "internal",
        "async"
    ];

    readonly string[] tokenType =
    [
        "class",
        "interface",
        "record",
        "string",
        "bool",
        "int",
        "float",
        "double",
        "char",
        "datetime",
        "timespan"
    ];
    

    public List<Token.Token> Tokenize(string input)
    {
        var result = new List<Token.Token>();
        var separators = new[]{"\n"};
        var formattedInput = input.Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.Replace(";", "").Replace("\n", "").Replace("\t", ""))
            .ToArray();
        
        try
        {
            for (var i = 0; i < formattedInput.Length; i++)
            {
                var token = new Token.Token();
                var current = formattedInput[i].Split([" "], StringSplitOptions.RemoveEmptyEntries)
                    .Where(c => !ignoredKeywords.Contains(c))
                    .Select(c => c.Replace("{","").Replace("}",""))
                    .ToArray();
                
                for (var j = 0; j < current.Length; j++)
                {
                    
                    if (string.IsNullOrWhiteSpace(current[j]) || current[j].StartsWith("//"))
                        break;
                        
                    if (tokenType.Contains(current[j].ToLower()))
                    {
                        token.Type = current[j];
                        continue;
                    } 
                    
                    if (token.Type == null && current.Length - 1 > j )
                        token.Type = current[j];
                    
                    if (dataTypes.Contains(current[j]))
                        continue;

                    if (current[j] == "get" || current[j] == "set")
                        continue;
                    
                    token.Identifier = current[j];
                }
                
                if (token is { Type: not null, Identifier: not null })
                    result.Add(token);
                // Console.WriteLine(token.Identifier + " " + token.Type );
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return result;
    }
    

};

