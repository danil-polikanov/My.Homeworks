var randomNumber=Math.floor(Math.random()*21)+1;
var choice;
while(choice != randomNumber){
    choice = parseInt(prompt());

    if(choice < 1 || choice > 21 || isNaN(choice) == true){
        alert("Неверно введенны данные!!")
    }

    else if(choice != randomNumber && choice > randomNumber){
        alert("Не угадали! Введенное число больше заданного")
    }

    else if(choice != randomNumber && choice < randomNumber){
        alert("Не угадали! Введенное число меньше заданного")
     }
}
alert("Вы угадали!");