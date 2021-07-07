var MyArray=[];
var number;
alert("Введите число или введите любую букву если хотите закончить")

while(true){
number = parseInt(prompt());

if(isNaN(number) == true)
break;
MyArray.push(number);
}

function OneIsFirstOrLast(MyArray){

if(MyArray[0] == 1 || MyArray[length-1] == 1){
    return true
}

else return false;

}
var result = OneIsFirstOrLast(MyArray);
alert(result);