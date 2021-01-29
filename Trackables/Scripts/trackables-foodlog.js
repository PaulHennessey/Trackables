var foodlog = (function ($) {

    /* Module level state */

    var RefreshServingTableUrl = "/foodlog/refreshfooditemtable";
    var RefreshMealsTableUrl = "/foodlog/refreshmealstable";
    var DeleteUrl = "/foodlog/delete";
    var SaveUrl = "/foodlog/save";
    var SelectFoodUrl = "/foodlog/selectfood";
    var UseMealUrl = "/foodlog/usemeal";
  //  var FavouriteUrl = "/foodlog/favourite";
  //  var UseFavouriteUrl = "/foodlog/usefavourite";
  //  var DeleteFavouriteUrl = "/foodlog/deletefavourite";


    /* On page load functions */

    SetDateOnLoad();
    RefreshServingTable(RefreshServingTableUrl, { date: sessionStorage["currentDate"] });
    RefreshMealsTable(RefreshMealsTableUrl, { date: sessionStorage["currentDate"] });

    /* Date time picker */

    $('#datetimepicker').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false
    });


    $('#datetimepicker').on("dp.change", function (e) {
        RefreshDate(e.target.value);
    });


    $("#datetimepicker").val(sessionStorage["currentDate"]);


    /* Typeahead */

    $('#fetch').on('typeahead:selected', function (event, item) {        
        RefreshServingTable(SelectFoodUrl, { Code: item.Code, date: sessionStorage["currentDate"] });
    });


    $('#fetch').on('typeahead:close', function (event, item) {
        $('.typeahead').typeahead('val', '');
    });


    function RefreshDate(d) {
        sessionStorage["currentDate"] = d;
        RefreshServingTable(RefreshServingTableUrl, { date: sessionStorage["currentDate"] });
    };


    function RefreshServingTable(url, parameters) {

        $.ajax({
            type: "POST",
            url: url,
            dataType: "html",
            data: parameters,
            success: function (response) {

                $("#servingTable").html(response);
                $('.SaveLink').on('click', SaveLinkClick);
                $('.DeleteLink').on('click', DeleteLinkClick);
            }
        });
    };


    function RefreshMealsTable(url, parameters) {

        $.ajax({
            type: "POST",
            url: url,
            dataType: "html",
            data: parameters,
            success: function (response) {
                $("#mealsTable").html(response);
                $('.UseMealLink').on('click', UseMealLinkClick);
            }
        });
    };


    /* Event handlers */

    function SaveLinkClick(e) {

        e.preventDefault();

        var servingId = $(this).data("id");

        // Now get the quantity - the fooditemid is used as the id of the quantity input field        
        var quantity = $("#" + servingId).val();

        RefreshServingTable(SaveUrl, { id: servingId, quantity: quantity, date: sessionStorage["currentDate"] });
    }


    function UseMealLinkClick(e) {

        e.preventDefault();

        var mealId = $(this).data("id");

        RefreshServingTable(UseMealUrl, { id: mealId, date: sessionStorage["currentDate"] });
    }


    function DeleteLinkClick(e) {

        e.preventDefault();

        var servingId = $(this).data("id");

        if (confirm("Delete?")) {
            RefreshServingTable(DeleteUrl, { id: servingId, date: sessionStorage["currentDate"] });
        }
    }

})(jQuery);


    //function FavouriteLinkClick(e) {

    //    e.preventDefault();

    //    // First get the food item id - it is the last bit of the url        
    //    var parsedUrl = this.href.split("/");
    //    var servingId = parsedUrl[parsedUrl.length - 1];

    //    // Now get the quantity - the fooditemid is used as the id of the quantity input field        
    //    var quantity = $("#" + servingId).val();

    //    // Now stick the quantity on the end of the url
    //    var link = this.href + "/" + quantity;

    //    // Go to it...
    //    window.location.href = link;
    //}

    //function DeleteFavouriteLinkClick(e) {

    //    e.preventDefault();

    //    if (confirm("Delete?"))
    //        return window.location.href = this.href;
    //}
