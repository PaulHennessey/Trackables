var trackables = (function ($) {

    var DeleteTrackableUrl = "/trackables/delete";

    $(".DeleteTrackableLink").on("click", DeleteLinkClick);


    function DeleteLinkClick(e) {

        e.preventDefault();

        if (confirm("Delete?")) {
            RefreshTrackablesTable(DeleteTrackableUrl, { id: $(this).data("trackableid") });
        }
    }

    function RefreshTrackablesTable(url, parameters) {

        $.ajax({
            type: "POST",
            url: url,
            dataType: "html",
            data: parameters,
            success: function (response) {

                $("#trackablesTable").html(response);
                $('.DeleteTrackableLink').on('click', DeleteLinkClick);
            }
        });
    };

})(jQuery);

