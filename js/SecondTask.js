var days = ["Воскресенье", "Понедельник", "Вторник", "Среда", "Четвег", "Пятница", "Суббота"];
var rightYears=[];

for(var i=0,j=2014;j<2050;j++){

    var date=new Date(j,0,1);

    if(days[date.getDay()] == days[0]){
        rightYears[i] = date.getFullYear();
        i++;
    }
}
document.write(rightYears);