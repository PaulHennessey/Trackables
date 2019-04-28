var meals = (function ($) {

    var SelectFoodUrl = "/meals/selectfood";
    var DeleteMealUrl = "/meals/deletemeal";
    var DeleteIngredientUrl = "/meals/deleteingredient";
    var SaveIngredientUrl = "/meals/saveingredient";

    $(".DeleteMealLink").on("click", DeleteMealLinkClick);
    $(".DeleteIngredientLink").on("click", DeleteIngredientLinkClick);
    $(".SaveIngredientLink").on("click", SaveIngredientLinkClick);

    /* Typeahead */

    $('#fetch').on('typeahead:selected', function (event, item) {
        RefreshIngredientsTable(SelectFoodUrl, { code: item.Code, mealId: $("#fetch").data("mealid") });
    });

    $('#fetch').on('typeahead:close', function (event, item) {
        $('.typeahead').typeahead('val', '');
    });

    function DeleteMealLinkClick(e) {

        e.preventDefault();

        if (confirm("Delete?")) {
            RefreshMealsTable(DeleteMealUrl, { mealId: $(this).data("mealid") });
        }
    }

    function DeleteIngredientLinkClick(e) {

        e.preventDefault();

        if (confirm("Delete?")) {
            RefreshIngredientsTable(DeleteIngredientUrl, { ingredientId: $(this).data("ingredientid"), mealId: $(this).data("mealid") });
        }
    }

    function RefreshIngredientsTable(url, parameters) {

        $.ajax({
            type: "POST",
            url: url,
            dataType: "html",
            data: parameters,
            success: function (response) {

                $("#ingredientsTable").html(response);
                $('.SaveIngredientLink').on('click', SaveIngredientLinkClick);
                $('.DeleteIngredientLink').on('click', DeleteIngredientLinkClick);
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
                $('.DeleteMealLink').on('click', DeleteMealLinkClick);
            }
        });
    };

    function SaveIngredientLinkClick(e) {

        e.preventDefault();

        var ingredientId = $(this).data("ingredientid");
        var mealId = $(this).data("mealid");

        // Now get the quantity - the ingredientId is used as the id of the quantity input field
        var quantity = $("#" + ingredientId).val();

        RefreshIngredientsTable(SaveIngredientUrl, { ingredientId: ingredientId, mealId: mealId, quantity: quantity });
    }

})(jQuery);


