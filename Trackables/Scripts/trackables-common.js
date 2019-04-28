function SetDateOnLoad() {

    var date = sessionStorage["currentDate"];
    if (date == null) {
        date = GetTodaysDate();
        sessionStorage["currentDate"] = date;
    }
}

function GetTodaysDate() {

    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    return dd + "/" + mm + "/" + yyyy;
}

function ConvertDateToISO8601(date) {

    var splitDate = date.split("/");
    return splitDate[2] + "-" + splitDate[1] + "-" + splitDate[0];
}