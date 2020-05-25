
const incCodeElem = document.getElementById('IncomingCurrencyCode');
const outCodeElem = document.getElementById('OutgoingCurrencyCode');
const incAmountElem = document.getElementById('IncomingAmount');
const outAmountElem = document.getElementById('OutgoingAmount');
var incCodeSelected = false;
var outCodeSelected = false; 

function fieldChange() {
    if (incCodeSelected && outCodeSelected && incAmountElem.value != '' && incAmountElem.value != 0) {
        $.ajax({
            type: 'GET',
            url: 'GetRateByCode',
            data: {
                'incomingCode': incCodeElem.value,
                'outgoingCode': outCodeElem.value
            },
            dataType: 'json', // added data type
            success: function (res) {
                outAmountElem.value = incAmountElem.value * res.BuyRateGEL / res.SellRateGEL;
            }
        });
    } else {
        outAmountElem.value = 0;
    }
};

$(incCodeElem).change(function () {
    incCodeSelected = !(incCodeElem.value == '');
    fieldChange();
});
$(outCodeElem).change(function () {
    outCodeSelected = !(outCodeElem.value == '');
    fieldChange();
});
$(incAmountElem).change(function () {
    fieldChange();
});
$(incAmountElem).keyup(function () {
    fieldChange();
});