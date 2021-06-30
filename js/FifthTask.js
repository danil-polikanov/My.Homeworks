var text=prompt();
function WorkWithRu(){
    if(text.startsWith("Ру")||text==null){
        return text;
    }
    else{
        return text="Ру"+text;
    }
}
WorkWithRu(text);
alert(text);