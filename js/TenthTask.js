function Multiplication(arr){
var objArray=new Array();
objArray=arr;
var max=0;
for(var i=0;i<objArray.length;i++)
    {
    if(max<objArray[i]*objArray[i+1])
        {
        max=objArray[i]*objArray[i+1];
        }
    }
    return max;
}
alert(Multiplication([3, 6, -2, -5, 7, 3]));