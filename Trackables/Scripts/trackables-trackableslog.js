var trackableslog = (function ($) {

    /* Module level state */

    var RefreshUrl = "/trackableslog/refresh";
    var SaveUrl = "/trackableslog/save";

    /* On page load functions */

    SetDateOnLoad();
    RefreshTable(RefreshUrl, { date: sessionStorage["currentDate"] });

    /* Date time picker */

    $('#datetimepicker').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false
    });


    $('#datetimepicker').on("dp.change", function (e) {
        RefreshDate(e.target.value);
    });


    $("#datetimepicker").val(sessionStorage["currentDate"]);


    function RefreshDate(d) {
        sessionStorage["currentDate"] = d;
        RefreshTable(RefreshUrl, { date: sessionStorage["currentDate"] });
    };


    function RefreshTable(url, parameters) {

        $.ajax({
            type: "POST",
            url: url,
            dataType: "html",
            data: parameters,
            success: function (response) {
                var v = 1;
                $("#trackableItemTable").html(response);
                $('.SaveLink').on('click', SaveLinkClick);
            }
        });
    };


    /* Event handlers */


    function SaveLinkClick(e) {

        e.preventDefault();

        var id = $(this).data('id');
        var trackableId = $(this).data('trackableid');

        // Now get the quantity - the trackableId is used as the id of the quantity input field
        var quantity = $("#" + trackableId).val();

        RefreshTable(SaveUrl, { id: id, trackableId: trackableId, quantity: quantity, date: sessionStorage["currentDate"] });
    }


})(jQuery);


