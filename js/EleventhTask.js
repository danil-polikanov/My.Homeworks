function removeDuplicates(arr){

var objArray = new Array();
objArray = arr;

var temp=new Set(objArray);
objArray=[...temp];

return objArray
}

alert(removeDuplicates([1, 1, 2, 3, 4, 3, 2]));