var meals = (function ($) {

    var SelectFoodUrl = "/meals/selectfood";
 
    $(".DeleteMealLink").on("click", DeleteLinkClick);
    $(".DeleteIngredientLink").on("click", DeleteLinkClick);
    $(".SaveIngredientLink").on("click", SaveLinkClick);

    $('#fetch .typeahead').on('typeahead:selected', function (event, item) {
        var link = SelectFoodUrl + "?Code=" + item.Code + "&mealId=" + $("#Id").val();
        window.location.href = link;
    });

    function DeleteLinkClick(e) {

        if (confirm("Delete?"))
            return window.location.href = this.href;

        e.preventDefault();
    }

    function SaveLinkClick(e) {

        e.preventDefault();

        // First get the food item id - it is the last bit of the url        
        var parsedUrl = this.href.split("/");
        var ingredientId = parsedUrl[parsedUrl.length - 2];

        // Now get the quantity - the ingredientId is used as the id of the quantity input field
        var quantity = $("#" + ingredientId).val();

        // Now stick the quantity on the end of the url
        var link = this.href + "/" + quantity;

        // Go to it...
        window.location.href = link;
    }

})(jQuery);


