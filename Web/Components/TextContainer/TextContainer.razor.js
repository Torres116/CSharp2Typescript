
export async function init(element,ref){
    element.addEventListener("input", async e => {
        try {
            await ref.invokeMethodAsync("OnInputTextChangedJS", element.value);
        } catch (error) {
            console.error(error);
        }
    });
}

export async function setTextArea(element,text)
{
   if(element)
       element.value = text;
}