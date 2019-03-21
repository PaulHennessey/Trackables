var products = (function ($) {

    var SelectFoodUrl = "/meals/selectfood";

    $(".DeleteMealLink").on("click", DeleteLinkClick);
    $(".DeleteIngredientLink").on("click", DeleteLinkClick);
    $(".SaveIngredientLink").on("click", SaveLinkClick);

    function DeleteLinkClick(e) {

        if (confirm("Delete?"))
            return window.location.href = this.href;

        e.preventDefault();
    }


    var substringMatcher = function (strs) {
        return function findMatches(q, cb) {
            var matches, substringRegex;

            // an array that will be populated with substring matches
            matches = [];

            // regex used to determine if a string contains the substring `q`
            substrRegex = new RegExp(q, 'i');

            // iterate through the pool of strings and for any string that
            // contains the substring `q`, add it to the `matches` array
            $.each(strs, function (i, str) {
                if (substrRegex.test(str)) {
                    matches.push(str);
                }
            });

            cb(matches);
        };
    };

    var states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California',
        'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii',
        'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana',
        'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota',
        'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire',
        'New Jersey', 'New Mexico', 'New York', 'North Carolina', 'North Dakota',
        'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island',
        'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont',
        'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'
    ];

    $('#the-basics .typeahead').typeahead({
        hint: true,
        highlight: true,
        minLength: 1
    },
        {
            name: 'states',
            source: substringMatcher(states)
        });



    $('.typeahead').on('typeahead:selected', function (e, item) {
        var link = SelectFoodUrl + "?Code=" + item.code + "&mealId=" + ConvertDateToISO8601(sessionStorage["currentDate"]);
        window.location.href = link;                                                           // Go to it...
    });


    $("#Search").typeahead({
        source: function (query, process) {
            var countries = [];
            map = {};

            // This is going to make an HTTP post request to the controller
            return $.post('/Meals/CountryLookup', { query: query }, function (data) {

                // Loop through and push to the array
                $.each(data, function (i, country) {
                    map[country.Name] = country;
                    countries.push(country.Name);
                });

                // Process the details
                process(countries);
            });
        },
        updater: function (item) {
            var selectedShortCode = map[item].ShortCode;

            // Set the text to our selected id
            $("#details").text("Selected : " + selectedShortCode);
            return item;
        }
    });

    //// This deals with the autocomplete.
    //// This rather dense code is explained here: http://blogs.msdn.com/b/stuartleeks/archive/2012/04/23/asp-net-mvc-amp-jquery-ui-autocomplete.aspx
    //$('*[data-autocomplete-url]')
    //    .each(function () {
    //        $(this).autocomplete({
    //            minLength: 3,
    //            source: $(this).data("autocomplete-url"),
    //            select: function (event, ui) {

    //                var actionlink = $(this).data("selectfood-url");


    //                actionlink = actionlink.replace("replace", ui.item.value);                              // Insert the parameter (on the client)

    //                actionlink = actionlink.replace("replace-date", ConvertDateToISO8601(sessionStorage["currentDate"]));             // Insert the parameter (on the client)
    //                window.location.href = actionlink;                                                           // Go to it...
    //            }
    //        });
    //    });

    function ConvertDateToISO8601(date) {

        var splitDate = date.split("/");
        return splitDate[2] + "-" + splitDate[1] + "-" + splitDate[0];
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


