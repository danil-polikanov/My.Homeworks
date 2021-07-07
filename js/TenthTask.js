function Multiplication(arr){
objArray = arr;
var max = 0;
var temp;
for(var i = 0;i<objArray.length;i++)
    {
        temp = objArray[i]*objArray[i+1];
    if(max < temp)
        {
        max = temp;
        }
    }
    return max;
}
alert(Multiplication([3, 6, -2, -5, 7, 3]));