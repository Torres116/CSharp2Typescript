using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Web.Pages;

namespace Web.Components.TextContainer;

public partial class TextContainer : ComponentBase
{
    
    ElementReference editor;
    
    [Parameter] 
    public required TextContainerConfig Config { get; set; }
    
    const string jsPath = "./Components/TextContainer/TextContainer.razor.js";

    public async Task InitJSInterop<T>(DotNetObjectReference<T> _ref) where T : class
    {
        var module = await JS.InvokeAsync<IJSObjectReference>("import", jsPath);
        await module.InvokeVoidAsync("init",editor, _ref);
    }

    public async Task ChangeTextArea(string text)
    {
        var module = await JS.InvokeAsync<IJSObjectReference>("import", jsPath);
        await module.InvokeVoidAsync("setTextArea",editor,text);
    }
    

}