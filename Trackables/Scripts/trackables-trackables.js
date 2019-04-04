var trackables = (function ($) {

    $(".DeleteTrackableLink").on("click", DeleteLinkClick);

    function DeleteLinkClick(e) {

        if (confirm("Delete?"))
            return window.location.href = this.href;

        e.preventDefault();
    }

})(jQuery);

