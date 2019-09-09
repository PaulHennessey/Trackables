var charts = (function ($) {

    var refreshBarChartUrl = "/trackableschart/refreshbarchart/";
    var refreshLineChartUrl = "/trackableschart/refreshlinechart/";
    var refreshTrackableItemsListUrl = "/trackableschart/refreshTrackableItemsList/";
    var refreshMacronutrientsListUrl = "/trackableschart/refreshMacronutrientsList/";

    /* On page load functions */

    SetDateOnLoad();
    RefreshTrackableItemsList(refreshTrackableItemsListUrl);
    RefreshMacronutrientsList(refreshMacronutrientsListUrl);

    $('.date').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false
    });

    $("#fromdate").val(sessionStorage["currentDate"]);
    $("#todate").val(sessionStorage["currentDate"]);

    function RefreshTrackableItemsList(url) {

        $.ajax({
            type: "POST",
            url: url,
            dataType: "html",
            success: function (response) {
                $("#trackablesList").html(response);
            }
        });
    };

    function RefreshMacronutrientsList(url) {

        $.ajax({
            type: "POST",
            url: url,
            dataType: "html",
            success: function (response) {
                $("#macronutrientsList").html(response);
            }
        });
    };

    $('#GenerateChartButton').click(function (e) {
        e.preventDefault();

        var from = $("#fromdate").val();
        var to = $("#todate").val();

        if (from === to) {
            refreshChart(refreshBarChartUrl, "bar");
        }
        else {
            refreshChart(refreshLineChartUrl, "line");
        }

    });



    function refreshChart(url, chartType) {

        $.ajax({
            type: "POST",
            url: url,
            data: {
                start: $("#fromdate").val(),
                end: $("#todate").val(),
                selectedIds: checkedBoxes()
            },
            success: function (json) {

                var options = {
                    chart: {
                        renderTo: 'trackablesChart',
                        type: chartType
                    },
                    title: {
                        text: json.Title
                    },
                    xAxis: {
                        categories: json.BarNames
                    },
                    yAxis: {
                        title: {
                            text: ""
                        }
                    },
                    series: []

                };

                for (i = 0; i < json.BarData.length; i++) {
                    options.series.push({
                        name: json.ChartTitle[i],
                        data: json.BarData[i]
                    });
                }

                var chart = new Highcharts.Chart(options);
            }
        });
    }


    function checkedBoxes() {

        var selectedIdentifiers = {};
        selectedIdentifiers.trackables = [];
        selectedIdentifiers.macronutrients = [];

        var t = $("input[name='trackables']:checked");
        var f = $("input[name='macronutrients']:checked");

        t.each(function () {
            selectedIdentifiers.trackables.push($(this).attr("id"));
        });

        f.each(function () {
            selectedIdentifiers.macronutrients.push($(this).attr("id"));
        });

        return selectedIdentifiers;
    }

})(jQuery);


