var text=prompt()
function getVowels(){
    var m = text.match(/[aeiou]/gi);
    return m.length;
}
alert(getVowels());