var MyArray=[];
var number;
alert("Введите число или введите любую букву если хотите закончить")
while(true){
number=parseInt(prompt());
if(isNaN(number)==true)
break;
MyArray.push(number);
}

alert("Введите число последних элементов");
var last=parseInt(prompt());
function Last(){
var deleted=MyArray.splice(length-last);
return deleted
}
var result=Last(MyArray,last);
alert(result);