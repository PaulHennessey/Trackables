var products = (function ($) {

    $(".DeleteProductLink").on("click", DeleteLinkClick);

    function DeleteLinkClick(e) {

        if (confirm("Delete?"))
            return window.location.href = this.href;

        e.preventDefault();
    }

})(jQuery);


