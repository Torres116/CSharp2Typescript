using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Web.Components.InputContainer;
using Web.Pages;

namespace Web.Components.TextContainer;

public partial class TextContainer : ComponentBase
{
    
    private ElementReference editor;
    
    [Parameter] 
    public required TextContainerConfig Config { get; set; }
    
    IJSObjectReference? module;
    
    const string jsPath = "./Components/TextContainer/TextContainer.razor.js";

    public async Task InitJSInterop<T>(DotNetObjectReference<T> _ref) where T : class
    {
        try
        {
            if (JS != null)
            {
                module = await JS.InvokeAsync<IJSObjectReference>("import", jsPath);
                await module.InvokeVoidAsync("init", Config, _ref);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    

}