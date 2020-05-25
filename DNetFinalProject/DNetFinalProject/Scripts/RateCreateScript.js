
const currencyCodeElem = document.getElementById('CurrencyCode');
const buyRateElem = document.getElementById('BuyRateGEL');
const sellRateElem = document.getElementById('SellRateGEL');

$(currencyCodeElem).change(function () {
    if (currencyCodeElem.value != '') {
        $.ajax({
            type: 'GET',
            url: 'GetCurrencyRate',
            data: { 'currencyCode': currencyCodeElem.value },
            dataType: 'json', // added data type
            success: function (res) {
                buyRateElem.value = res.BuyRateGEL;
                sellRateElem.value = res.SellRateGEL;
            }
        });
    } else {
        buyRateElem.value = '';
        sellRateElem.value = '';
    }
});
