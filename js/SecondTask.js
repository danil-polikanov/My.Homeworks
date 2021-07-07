var user = {};
user.name = "Tom";
user.age = 26;
user.display = function(){
     
    console.log(user.name);
    console.log(user.age);
};
function checkObj(obj){
    for(var key in obj){
        console.log(key + " : " + user[key]);
    }
}
checkObj(user);