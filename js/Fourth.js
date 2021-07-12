class Validator{
    isValid(){
        console.log("is not defined");
    }
}
class EmailValidator extends Validator{
    isValid(email)
    {
    var regex = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/;
    return regex.test(String(email).toLowerCase());
    }
}
class PhoneValidator extends Validator{
    isValid(phone)
    {
    let regex = /^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$/;
    return regex.test(phone);
    }
}
var tom = new EmailValidator();
if(tom.isValid("danil.polikanov@gmail.com")){
    console.log("емейл валидный")
}
else{
    console.log("емейл невалидный")
}
var jax = new PhoneValidator();
if(jax.isValid("+380-95-052-40-16")){
    console.log("номер валидный")
}
else{
    console.log("номер невалидный")
}