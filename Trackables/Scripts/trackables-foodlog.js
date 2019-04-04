var home = (function ($) {

    $('#datetimepicker').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false
    });

    $('#datetimepicker').on("dp.change", function (e) {
        example(e.target.value);
    });

    var example = function exampleFunction(d) {

        sessionStorage["currentDate"] = d;

        $.ajax({
            type: "POST",
            url: RefreshUrl,
            dataType: "json",
            data: {
                date: d
            },
            success: function (json) {

                $("#foodItemTableBody").empty();
                $(json.FoodItems).each(function (index, foodItem) {
                    drawFoodItemRow1(foodItem);
                });

                $('.SaveLink').on('click', SaveLinkClick);
            }
        });
    };

    //$("#datetimepicker").on("dp.change", function (e) {

    //    sessionStorage["currentDate"] = e.date;

    //    $.ajax({
    //        type: "POST",
    //        url: RefreshUrl,
    //        dataType: "json",
    //        data: {
    //            date: e.date
    //        },
    //        success: function (json) {

    //            var foodItemTable = $("#foodItemTable");

    //            $(json.FoodItems).each(function (index, foodItem) {
    //                drawFoodItemRow1(foodItem);
    //            });


    //            //foodItemTable.empty();
    //            //$(json.FoodItems).each(function (index, foodItem) {
    //            //    drawFoodItemRow(foodItem);
    //            //});

    //            //drawTotalCaloriesRow(json.TotalCalories);

    //            //$('.DeleteLink').on('click', DeleteLinkClick);
    //            //$('.SaveLink').on('click', SaveLinkClick);
    //            //$('.FavouriteLink').on('click', FavouriteLinkClick);
    //            //$('.DeleteFavouriteLink').on('click', DeleteFavouriteLinkClick);
    //        }
    //    });

    //});

    SetDateOnLoad();

    var RefreshUrl = "/foodlog/refresh";
    var DeleteUrl = "/foodlog/delete";
    var SaveUrl = "/foodlog/save";
    var FavouriteUrl = "/foodlog/favourite";
    var UseFavouriteUrl = "/foodlog/usefavourite";
    var SelectFoodUrl = "/foodlog/selectfood";
    var DeleteFavouriteUrl = "/foodlog/deletefavourite";
    var UseMealUrl = "/foodlog/usemeal";
    

    $('#fetch .typeahead').on('typeahead:selected', function (event, item) {
        var link = SelectFoodUrl + "?Code=" + item.Code + "&date=" + ConvertDateToISO8601(sessionStorage["currentDate"]);
        window.location.href = link;  
    });




    //// When a date is selected I want to 
    //$("#datetimepicker").datetimepicker({
    //    onSelect: function (dateText, inst) {

    //        sessionStorage["currentDate"] = dateText;

    //        $.ajax({
    //            type: "POST",
    //            url: RefreshUrl,
    //            dataType: "json",
    //            data: {
    //                date: dateText
    //            },
    //            success: function (json) {

    //                var foodItemTable = $("#foodItemTable");

    //                $(json.FoodItems).each(function (index, foodItem) {
    //                    drawFoodItemRow1(foodItem);
    //                });


    //                //foodItemTable.empty();
    //                //$(json.FoodItems).each(function (index, foodItem) {
    //                //    drawFoodItemRow(foodItem);
    //                //});

    //                //drawTotalCaloriesRow(json.TotalCalories);

    //                //$('.DeleteLink').on('click', DeleteLinkClick);
    //                //$('.SaveLink').on('click', SaveLinkClick);
    //                //$('.FavouriteLink').on('click', FavouriteLinkClick);
    //                //$('.DeleteFavouriteLink').on('click', DeleteFavouriteLinkClick);
    //            }
    //        });

    //    }
    //});


    $.ajax({
        type: "POST",
        url: RefreshUrl,
        dataType: "json",
        data: {
            date: sessionStorage["currentDate"]
        },
        success: function (json) {

            var foodItemTable = $("#foodItemTable");

         //   https://stackoverflow.com/questions/8302166/dynamic-creation-of-table-with-dom
            //https://stackoverflow.com/questions/18333427/how-to-insert-row-in-html-table-body-in-javascripts


            $(json.FoodItems).each(function (index, foodItem) {
                drawFoodItemRow1(foodItem);
            });

            $('.SaveLink').on('click', SaveLinkClick);

            //tablearea.appendChild(table);

            //foodItemTable.empty();
            //$(json.FoodItems).each(function (index, foodItem) {
            //    drawFoodItemRow(foodItem);
            //});

            //drawTotalCaloriesRow(json.TotalCalories);

            //var favouriteTable = $("#favouriteTable");
            //favouriteTable.empty();
            //$(json.Favourites).each(function (index, favourite) {
            //    drawFavouriteRow(favourite);
            //});

            //var mealsTable = $("#mealsTable");
            //mealsTable.empty();
            //$(json.Meals).each(function (index, meal) {
            //    drawMealRow(meal);
            //});

            //$('.DeleteLink').on('click', DeleteLinkClick);
            //$(".SaveLink").on("click", SaveLinkClick);
            //$('.FavouriteLink').on('click', FavouriteLinkClick);
            //$('.DeleteFavouriteLink').on('click', DeleteFavouriteLinkClick);
            //// Put the focus on the first input field.
            //$("#foodItemTable tr:first").find("input").focus();
        }
    });




    //for (var i = 1; i < 4; i++) {
    //    var tr = document.createElement('tr');

    //    tr.appendChild(document.createElement('td'));


    //    tr.cells[0].appendChild(document.createTextNode('Text1'));


    //    body.appendChild(tr);
    //}

    function drawFoodItemRow1(rowData) {

        var foodItemTableBody = document.getElementById('foodItemTableBody');
        var row = document.createElement('tr');

        var nameCell = document.createElement('td');
        nameCell.append(document.createTextNode(rowData.Name));
        row.append(nameCell);

        var quantityCell = document.createElement('td');
        var div = document.createElement("div");
        var input = document.createElement("input");
        input.setAttribute("type", "text");
        input.setAttribute("class", "form-control input-sm");
        input.setAttribute("id", rowData.Id);
        input.value = rowData.Quantity;
        div.appendChild(input);
        quantityCell.appendChild(div);
        row.append(quantityCell);

        var linkCell = document.createElement('td');

        var saveLink = document.createElement("a");        
        saveLink.setAttribute("class", "SaveLink");
        saveLink.setAttribute("href", "/foodlog/save/" + rowData.Id);
        saveLink.innerHTML = "Save";
        linkCell.appendChild(saveLink);

        var deleteLink = document.createElement("a");
        deleteLink.setAttribute("class", "DeleteLink");
        deleteLink.setAttribute("href", "/foodlog/delete/" + rowData.Id);
        deleteLink.innerHTML = "Delete";
        linkCell.appendChild(deleteLink);

        row.append(linkCell);

        foodItemTableBody.append(row);
    }
    

    function drawFoodItemRow(rowData) {
        var row = $("<tr />");
        $("#foodItemTable").append(row);
        row.append($("<td>" + rowData.Name + "</td>"));
        row.append($("<td><input class='input-quantity' id=" + rowData.Id + " name=" + rowData.Quantity + " type='text' value=" + rowData.Quantity + "></td>"));
        row.append($("<td>" + rowData.Calories + "</td>"));
        row.append($("<td><a class='SaveLink' href=" + SaveUrl + "/" + rowData.Id + ">Save</a>" +
            "<a class='DeleteLink' href=" + DeleteUrl + "/" + rowData.Id + ">Delete</a>" +
            "<a class='FavouriteLink' href=" + FavouriteUrl + "/" + rowData.Id + ">Favourite</a></td>"));
    }

    function drawTotalCaloriesRow(totalCalories) {
        var row = $("<tr />");
        $("#foodItemTable").append(row);
        row.append($("<td>" + "Total calories" + "</td>"));
        row.append($("<td></td>"));
        row.append($("<td>" + totalCalories + "</td>"));
    }

    function drawFavouriteRow(rowData) {
        var row = $("<tr />");
        $("#favouritesTable").append(row);
        row.append($("<td><a class='UseFavouriteLink' href=" + UseFavouriteUrl + "/" + rowData.Code +
            "/" + ConvertDateToISO8601(sessionStorage["currentDate"]) +
            ">" + rowData.Name + "</td>"));
        row.append($("<td><a class='DeleteFavouriteLink' href=" + DeleteFavouriteUrl + "/" + rowData.Code + ">Delete</a></td>"));
    }

    function drawMealRow(rowData) {
        var row = $("<tr />");
        $("#mealsTable").append(row);

        row.append($("<td><a class='UseMealLink' href=" + UseMealUrl + "/" + rowData.Id +
            "/" + ConvertDateToISO8601(sessionStorage["currentDate"]) +
            ">" + rowData.Name + "</td>"));
    }

    function SetDateOnLoad() {

        var date = sessionStorage["currentDate"];
        if (date == null) {
            date = GetTodaysDate();
            sessionStorage["currentDate"] = date;
        }

        $("#datetimepicker").val(date);
    }


    function DeleteLinkClick(e) {

        e.preventDefault();

        if (confirm("Delete?"))
            return window.location.href = this.href;
    }



    function SaveLinkClick(e) {

        e.preventDefault();

        // First get the food item id - it is the last bit of the url        
        var parsedUrl = this.href.split("/");
        var foodItemId = parsedUrl[parsedUrl.length - 1];

        // Now get the quantity - the fooditemid is used as the id of the quantity input field        
        var quantity = $("#" + foodItemId).val();

        // Now stick the quantity on the end of the url
        var link = this.href + "/" + quantity;

        // Go to it...
        window.location.href = link;
    }


    function FavouriteLinkClick(e) {

        e.preventDefault();

        // First get the food item id - it is the last bit of the url        
        var parsedUrl = this.href.split("/");
        var foodItemId = parsedUrl[parsedUrl.length - 1];

        // Now get the quantity - the fooditemid is used as the id of the quantity input field        
        var quantity = $("#" + foodItemId).val();

        // Now stick the quantity on the end of the url
        var link = this.href + "/" + quantity;

        // Go to it...
        window.location.href = link;
    }


    function DeleteFavouriteLinkClick(e) {

        e.preventDefault();

        if (confirm("Delete?"))
            return window.location.href = this.href;
    }

    function GetTodaysDate() {

        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }

        return dd + "/" + mm + "/" + yyyy;
    }

    function ConvertDateToISO8601(date) {

        var splitDate = date.split("/");
        return splitDate[2] + "-" + splitDate[1] + "-" + splitDate[0];
    }
})(jQuery);