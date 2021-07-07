let obj = {
    name: "John",
    age: 30
  };
function Mapping(obj){
    let map=new Map(Object.entries(obj));
    return map
  }
console.log(Mapping(obj));
