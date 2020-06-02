
const incCodeElem = document.getElementById('IncomingCurrencyCode');
const outCodeElem = document.getElementById('OutgoingCurrencyCode');
const changeRateElem = document.getElementById('change_rate');
const incAmountElem = document.getElementById('IncomingAmount');
const outAmountElem = document.getElementById('OutgoingAmount');
var incCodeSelected = false;
var outCodeSelected = false; 
function fieldChange(isChangedIncoming = true) {
    if (incCodeSelected && outCodeSelected) {
        $.ajax({
            type: 'GET',
            url: 'GetRateByCode',
            data: {
                'incomingCode': incCodeElem.value,
                'outgoingCode': outCodeElem.value
            },
            dataType: 'json', // added data type
            success: function (res) {
                changeRateElem.value = res.BuyRateGEL / res.SellRateGEL;
                if (isChangedIncoming && incAmountElem.value != '' && incAmountElem.value != 0) {
                    outAmountElem.value = incAmountElem.value * res.BuyRateGEL / res.SellRateGEL;
                } else if (!isChangedIncoming && outAmountElem.value != '' && outAmountElem.value != 0) {
                    incAmountElem.value = outAmountElem.value / res.BuyRateGEL * res.SellRateGEL;
                } else {
                    outAmountElem.value = 0;
                    incAmountElem.value = 0;
                }
            }
        });
    } else {
        outAmountElem.value = 0;
        incAmountElem.value = 0;
        changeRateElem.value = 0;
    }
};

fieldChange();

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
$(outAmountElem).change(function () {
    fieldChange(false);
});
$(outAmountElem).keyup(function () {
    fieldChange(false);
});