
const incCodeElem = document.getElementById('IncomingCurrencyCode');
const outCodeElem = document.getElementById('OutgoingCurrencyCode');
const incAmountElem = document.getElementById('IncomingAmount');
const outAmountElem = document.getElementById('OutgoingAmount');
var incCodeSelected = false;
var outCodeSelected = false; 

console.log(outAmountElem);
var rates = {
    'GBP': 0.5,
    'USD': 0.8,
    'RBU': 100
};

function updateAmount() {
    if (incCodeSelected && outCodeSelected) {
        outAmountElem.value = incAmountElem.value * rates[outCodeElem.value] / rates[incCodeElem.value];
    }
}

incCodeElem.addEventListener('change', function () {
    incCodeSelected = !(incCodeElem.value == '');
    updateAmount();
});
outCodeElem.addEventListener('change', function () {
    outCodeSelected = !(outCodeElem.value == '');
    updateAmount();
});
incAmountElem.addEventListener('keyup', function () {
    updateAmount();
});
incAmountElem.addEventListener('change', function () {
    updateAmount();
});