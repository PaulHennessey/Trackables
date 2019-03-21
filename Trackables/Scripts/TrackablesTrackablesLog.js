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


    SetDateOnLoad();

    var RefreshUrl = "/trackableslog/refresh";
    var SaveUrl = "/trackableslog/save";


    // When a date is selected I want to 
    $("#dateselection").datepicker({
        onSelect: function (dateText, inst) {

            sessionStorage["currentDate"] = dateText;

            $.ajax({
                type: "POST",
                url: RefreshUrl,
                dataType: "json",
                data: {
                    date: dateText
                },
                success: function (json) {

                    var trackableItemTable = $("#trackableItemTable");
                    trackableItemTable.empty();
                    $(json.TrackableItems).each(function (index, trackableItem) {
                        drawTrackableItemRow(trackableItem);
                    });

                    $('.SaveLink').on('click', SaveLinkClick);
                }
            });

        }
    });



    function SaveLinkClick(e) {

        var id = $(this).data('id');
        var trackableId = $(this).data('trackableid');
        var name = "#" + $(this).data('name');

        // Now get the quantity - the name is used as the id of the quantity input field
        var quantity = $(name).val();

        $.ajax({
            type: "POST",
            url: SaveUrl,
            dataType: "json",
            data: {
                id: id,
                trackableId: trackableId,
                quantity: quantity,
                date: sessionStorage["currentDate"]
            },
            success: function (json) {

                var trackableItemTable = $("#trackableItemTable");
                trackableItemTable.empty();
                $(json.TrackableItems).each(function (index, trackableItem) {
                    drawTrackableItemRow(trackableItem);
                });

                $('.SaveLink').on('click', SaveLinkClick);
            }
        });
    }



    $.ajax({
        type: "POST",
        url: RefreshUrl,
        dataType: "json",
        data: {
            date: sessionStorage["currentDate"]
        },
        success: function (json) {

            var trackableItemTable = $("#trackableItemTable");
            trackableItemTable.empty();
            $(json.TrackableItems).each(function (index, trackableItem) {
                drawTrackableItemRow(trackableItem);
            });

            $(".SaveLink").on("click", SaveLinkClick);
            // Put the focus on the first input field.
            $("#trackableItemTable tr:first").find("input").focus();
        }
    });

    function drawTrackableItemRow(rowData) {
        var row = $("<tr />");
        $("#trackableItemTable").append(row);
        row.append($("<td>" + rowData.Name + "</td>"));
        row.append($("<td><input class='input-quantity' id=" + rowData.Name + " type='text' value=" + isNull(rowData.Quantity) + "></td>"));
        row.append($("<td><a href='#' data-id=" + rowData.Id + " data-trackableid=" + rowData.TrackableId + " data-name=" + rowData.Name + " class= 'SaveLink' onclick = 'SaveLinkClick(this);' > Save</a > "));
    }

    function isNull(str) {
        return !str || 0 === str.length ? "" : str;
    }

    function SetDateOnLoad() {

        var date = sessionStorage["currentDate"];
        if (date == null) {
            date = GetTodaysDate();
            sessionStorage["currentDate"] = date;
        }

        $("#dateselection").val(date);
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


