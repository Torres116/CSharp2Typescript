
let textarea;

export async function init(Config,ref){
    textarea = document.querySelector(".content");
    textarea.value = ""
    
    textarea.addEventListener("input", async e => {
        await onTextChange(ref);
    })
}

export async function onTextChange(ref){
    if(!textarea)
        return;
    
    try {
        
        const text = textarea.value
        await ref.invokeMethodAsync("OnInputTextChangedJS",text)
        
    } catch (error) {
        console.error(error);
    }
    
}