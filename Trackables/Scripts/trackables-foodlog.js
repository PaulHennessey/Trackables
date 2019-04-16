var home = (function ($) {


    var RefreshUrl = "/foodlog/refresh";
    var DeleteUrl = "/foodlog/delete";
    var SaveUrl = "/foodlog/save";
    var FavouriteUrl = "/foodlog/favourite";
    var UseFavouriteUrl = "/foodlog/usefavourite";
    var SelectFoodUrl = "/foodlog/selectfood";
    var DeleteFavouriteUrl = "/foodlog/deletefavourite";
    var UseMealUrl = "/foodlog/usemeal";


    SetDateOnLoad();
    RefreshTable();


    $('#datetimepicker').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false
    });


    $('#datetimepicker').on("dp.change", function (e) {
        RefreshDate(e.target.value);
    });


    $('#fetch').on('typeahead:selected', function (event, item) {

        $.ajax({
            type: "POST",
            url: SelectFoodUrl,
            dataType: "html",
            data: {
                Code: item.Code,
                date: sessionStorage["currentDate"]
            },
            success: function (response) {

                $("#foodItemTable").html(response);
                $('.SaveLink').on('click', SaveLinkClick);
                $('.DeleteLink').on('click', DeleteLinkClick);
            }
        });
    });


    $('#fetch').on('typeahead:close', function (event, item) {
        $('.typeahead').typeahead('val', '');
    });


    function SaveLinkClick(e) {

        e.preventDefault();

        // First get the food item id - it is the last bit of the url        
        var parsedUrl = this.href.split("/");
        var foodItemId = parsedUrl[parsedUrl.length - 1];

        // Now get the quantity - the fooditemid is used as the id of the quantity input field        
        var quantity = $("#" + foodItemId).val();

        $.ajax({
            type: "POST",
            url: SaveUrl,
            dataType: "html",
            data: {
                id: foodItemId,
                quantity: quantity,
                date: sessionStorage["currentDate"]
            },
            success: function (response) {
                $("#foodItemTable").html(response);
                $('.SaveLink').on('click', SaveLinkClick);
                $('.DeleteLink').on('click', DeleteLinkClick);
            }
        });
    }

    function RefreshDate(d) {

        sessionStorage["currentDate"] = d;
        RefreshTable();
    };


    function RefreshTable() {

        $.ajax({
            type: "POST",
            url: RefreshUrl,
            dataType: "html",
            data: {
                date: sessionStorage["currentDate"]
            },
            success: function (response) {

                $("#foodItemTable").html(response);
                $('.SaveLink').on('click', SaveLinkClick);
                $('.DeleteLink').on('click', DeleteLinkClick);
            }
        });
    };




    function SetDateOnLoad() {

        var date = sessionStorage["currentDate"];
        if (date == null) {
            date = GetTodaysDate();
            sessionStorage["currentDate"] = date;
        }

        $("#datetimepicker").val(date);
    }


    function DeleteLinkClick(e) {

        e.preventDefault();

        // First get the food item id - it is the last bit of the url        
        var parsedUrl = this.href.split("/");
        var foodItemId = parsedUrl[parsedUrl.length - 1];

        if (confirm("Delete?")) {
            $.ajax({
                type: "POST",
                url: DeleteUrl,
                dataType: "html",
                data: {
                    id: foodItemId,
                    date: sessionStorage["currentDate"]
                },
                success: function (response) {
                    $("#foodItemTable").html(response);
                    $('.SaveLink').on('click', SaveLinkClick);
                    $('.DeleteLink').on('click', DeleteLinkClick);
                }
            });
        }
    }


    function FavouriteLinkClick(e) {

        e.preventDefault();

        // First get the food item id - it is the last bit of the url        
        var parsedUrl = this.href.split("/");
        var foodItemId = parsedUrl[parsedUrl.length - 1];

        // Now get the quantity - the fooditemid is used as the id of the quantity input field        
        var quantity = $("#" + foodItemId).val();

        // Now stick the quantity on the end of the url
        var link = this.href + "/" + quantity;

        // Go to it...
        window.location.href = link;
    }
    
    function DeleteFavouriteLinkClick(e) {

        e.preventDefault();

        if (confirm("Delete?"))
            return window.location.href = this.href;
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
})(jQuery);