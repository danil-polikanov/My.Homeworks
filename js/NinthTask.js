function Concat(text,spl){
var result=new Array();
result=text;
result=result.join(spl);
return result;
}
alert(Concat(["Ivanov","Ivan","Ivanovich"],"***"));