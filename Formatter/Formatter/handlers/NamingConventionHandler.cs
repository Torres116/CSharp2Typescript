namespace Formatter.Formatter.handlers;

public static class NamingConventionHandler
{
    public static string ToCamelCase(string str)
    {
        str = str.Replace("_", "");
        var strArray = str.ToCharArray();
        strArray[0] = char.ToLower(strArray[0]);
        return new string(strArray);
    }

    public static string ToPascalCase(string str)
    {
        str = str.Replace("_", "");
        var strArray = str.ToCharArray();
        strArray[0] = char.ToUpper(strArray[0]);
        return new string(strArray);
    }

    public static string ToSnakeCase(string str)
    {
        string result = "";
        for (var i = 0; i < str.Length; i++)
        {
            var c = str[i];
            if (char.IsUpper(c) && i > 0)
            {
                c = char.ToLower(c);
                if (i + 1 < str.Length)
                {
                    result += "_" + c;
                    continue;
                }
                result += c;
            }
            
            result += c.ToString().ToLower();
        }
        
        return result;
    }
}