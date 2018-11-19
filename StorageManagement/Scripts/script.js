$(document).ready(function () {    
    var q = 1;
    var trade = false;
    var op = "Продажа";
    var timerId;
    function getRandomArbitary(min, max) {
        return Math.random() * (max - min) + min;
    }
    if ($("#tradeButton").text() == "Остановить торговлю") {
        timerId = setInterval(makeTransaction, 1000);
        trade = true;
    }
    $("#tradeButton").click(function () {
        if (trade == false) {
            timerId = setInterval(makeTransaction, 1000);
            trade = true;
            $("#tradeButton").text("Остановить торговлю");
        } else {
            clearInterval(timerId);
            trade = false;
            $("#tradeButton").text("Начать торговлю");
        }
    });
    $('#spButton').click(function () {
        $('#sp').modal('hide');
        $.ajax({
            type: 'POST',
            url: '/Home/Transactions',
            data: {
                a: 1,
                Operation: op,
                Quantity: q
            },
            success: function (data) {
                $("#transactions").html(data);
                trade = true;
                $("#status").text() == "Online";
                console.log(data);
            }
        });
    });
    function makeTransaction() {        
        if ($("#status").text() == "Online") {
        //    q = Math.round(getRandomArbitary(1, 10));
        //    var rand = getRandomArbitary(0, 1);
        //    if (rand < 0.8) {
        //        op = "Продажа";
        //    }
        //    else if (rand < 0.9) {
        //        op = "Поступление";
        //        q = Math.round(getRandomArbitary(40, 50));
        //    } else if (rand < 0.95){
        //        trade = false;
        //        op = "Списание";
        //        q = Math.round(getRandomArbitary(10, 30));
        //        //$(".modal-body").text("Обнаружены просроченные продукты.");
        //        $('#sp').modal('show');                
        //        return 0;
        //    } else {
        //        trade = false;
        //        op = "Списание";
        //        q = Math.round(getRandomArbitary(10, 30));
        //        //$(".modal-body").text("Пропажа продуктов");
        //        $('#sp').modal('show');
        //        return 0;
        //    }
            $.ajax({
                type: 'POST',
                url: '/Home/Transactions',
                data: {
                    //a: 1,
                    //Operation: op,
                    //Quantity: q
                },
                success: function (data) {
                    $("#transactions").html(data);
                    console.log(data);
                }
            });
        }
    }
})