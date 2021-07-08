$(document).ready(function(){
    $('.clc').click(function(){
       $('.myInput').val($('.myInput').val()+$(this).val());
    });
    $('.pow').click(function(){
        var result=$('.myInput').val()*$('.myInput').val();
        $('.myInput').val(result);
    });
    $('.dev').click(function(){
        var result=Math.sqrt($('.myInput').val());
        $('.myInput').val(result);
    });
    $('.reverse').click(function(){
        var result=-$('.myInput').val();
        $('.myInput').val(result);
    });
    $('.clean').click(function(){
        $('.myInput').val(' ');
    });
    $('.final').click(function(){
       $('.myInput').val(eval($('.myInput').val()));
    });
    $('.space').click(function(){
        $('.myInput').val($('.myInput').val().substring(0,$('.myInput').val().length-1));
    });
});