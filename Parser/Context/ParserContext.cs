namespace Parser.Context;

internal sealed class ParserContext
{
    int _iterator = 0;
    Dictionary<int,string> methods = new(); // index - methodName
    Dictionary<int,string> variables = new(); // index - variableName

    public void AddMethod(string methodName,
        string methodType,
        bool asyncMethod,
        Action<string> callback)
    {
        
    }
    
    
    // string str;
    // var mtdParams = "";
    //     
    // str = methodName + "()" + ":";
    // str += str.PadRight(4) + methodType.ToLower() + ";";
    // Console.WriteLine(str);
    //
    // _iterator++;
    // methods.Add(_iterator, str);
}   