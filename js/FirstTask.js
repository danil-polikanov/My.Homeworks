var time=new Date();
var test=time.toDateString();
var hour = time.getHours();
var minute = time.getMinutes();
var second = time.getSeconds();

if (minute < 10) {
    minute = "0" + minute;
}

if (second < 10) {
    second = "0" + second;
}

document.write("Local time:  "+hour+":"+minute+":"+second+" "+test);