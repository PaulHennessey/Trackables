var products = (function ($) {

    var DeleteUrl = "/products/delete";


    $(".DeleteLink").on("click", DeleteLinkClick);


    function DeleteLinkClick(e) {

        e.preventDefault();

        if (confirm("Delete?")) {
            RefreshTable(DeleteUrl, { code: $(this).data("code")});
        }
    }


    function RefreshTable(url, parameters) {

        $.ajax({
            type: "POST",
            url: url,
            dataType: "html",
            data: parameters,
            success: function (response) {

                $("#productTable").html(response);
                $('.DeleteLink').on('click', DeleteLinkClick);
            }
        });
    };



})(jQuery);


