class Validator{
    isValid(){
        console.log("is not defined");
    }
}
class EmailValidator extends Validator{}
class PhoneValidator extends Validator{}
var tom = new EmailValidator();
tom.isValid();
