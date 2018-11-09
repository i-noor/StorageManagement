$(document).ready(function () {    
    var q = Math.round(getRandomArbitary(1, 500));    
    var op = "Продажа";
    if (getRandomArbitary(0, 1)<0.5) op = "Продажа"
    else op = "Поступление";   
    function getRandomArbitary(min, max) {
        return Math.random() * (max - min) + min;
    }

    makeTransaction(q,op);
    function makeTransaction(q,op) {        
        $.ajax({            
            type: 'POST',
            url: '/Home/Buy',
            data: {
                a : 1,
                Operation : op,                             
                Quantity: q                
            },            
            success: function (data) {
                $("#transactions").html(data);                 
            }
        });
    }
})