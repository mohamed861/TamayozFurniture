var generalObj={};
var fromCityCheckedVal = null;
var toCityCheckedVal = null;
const checkBoxFromCityElement = document.getElementsByClassName("fromCity");
const checkBoxToCityElement = document.getElementsByClassName('toCity');
const alert = document.getElementById("demo");
const request = document.getElementById("request1");
//btn.addEventListener('click', RequestOrder);
//btn.addEventListener('click', disappearAfterTime);
function RequestOrder(){
    for (var i of checkBoxFromCityElement){
        if (i.selected){
            fromCityCheckedVal = i.value;
        }
    }
    for (var i of checkBoxToCityElement) {
        if (i.selected) {
            toCityCheckedVal = i.value;
        }
    }

    if (fromCityCheckedVal == "") fromCityCheckedVal = null;
    if (toCityCheckedVal == "") toCityCheckedVal = null;

    if (fromCityCheckedVal == null && toCityCheckedVal == null) {
        alert.classList.remove("alert-success");
        alert.innerHTML = "يرجى اختيار المدن من القائمة";
        alert.classList.add("alert-danger");
        disappearAfterTime();
        //showAgain();
        alert.classList.remove("disappear");
    }
    else if (fromCityCheckedVal == null || toCityCheckedVal == null) {
        alert.classList.remove("alert-success");
        alert.innerHTML = "يرجى اختيار المدينة المتبقية من القائمة";
        alert.classList.add("alert-danger");
        disappearAfterTime();
        //showAgain();
        alert.classList.remove("disappear");
    }
    else if (fromCityCheckedVal != null || toCityCheckedVal != null) {
        alert.classList.remove("alert-danger");
        alert.innerHTML = "تم استلام طلبك وسيتم التواصل معك في أقرب وقت";
        alert.classList.add("alert-success");
        disappearAfterTime();
        //showAgain();
        alert.classList.remove("disappear");
        request.innerHTML = "خدمة نقل أثاث من مدينة " + fromCityCheckedVal + " الى مدينة " + toCityCheckedVal;
        request.classList.add("bg-success");
    }
    else {
        alert.innerHTML = "";
        alert.classList.add("alert-danger");
    }


    /*var jsonData = { "cityFromName": fromCityCheckedVal, "cityToName": toCityCheckedVal};
    $.ajax({
        url: 'http://localhost:51039/api/employees/add',
        method: 'post',
        data: JSON.stringify(jsonData),
        contentType: 'Application/Json;charset=utf-8',
        dataType: '',
        success: function (data) {
            alert(JSON.stringify(data));
        },
        error: function (err) {
            alert('eeeeeee');
        }
    });*/
};

//-------------------------
function disappearAfterTime() {
    setTimeout(function () {
        alert.classList.add("disappear");
    }, 2500);
};

function showAgain(){
    setTimeout(function () {
        if(alert.className ==="disappear") {
            alert.classList.remove("disappear");
        }
    }, 3000);
};
    //-------------------------
    //--------click EventListener----
    //-----------------------------------