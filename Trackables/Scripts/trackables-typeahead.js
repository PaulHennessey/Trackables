var lookup = (function ($) {

    var ProductFetchUrl = "/products/productfetch";

    //http://www.adequatelygood.com/JavaScript-Module-Pattern-In-Depth.html

    var bloodhound = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace("Name"),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        prefetch: ProductFetchUrl
    });

    $('#fetch .typeahead').typeahead(null, {
        name: 'countries',
        displayKey: 'Name',
        source: bloodhound
    });

})(jQuery);