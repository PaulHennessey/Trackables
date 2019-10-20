var charts = (function ($) {

    var refreshChartUrl = "/trackableschart/refreshchart/";
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

    /* Event handlers */

    $('#GenerateChartButton').click(function (e) {
        e.preventDefault();

        var chartType = $('#ChartTypeId :selected').text().toLowerCase();
        refreshChart(chartType);
    });

    /* Functions */

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


    function refreshChart(chartType) {

        $.ajax({
            type: "POST",
            url: refreshChartUrl,
            data: {
                start: $("#fromdate").val(),
                end: $("#todate").val(),
                selectedIds: checkedBoxes()
            },
            success: function (json) {

                var options = {
                    chart: { renderTo: 'trackablesChart', type: chartType },
                    title: { text: "" },
                    xAxis: { categories: json.Categories },
                    series: []
                };

                for (i = 0; i < json.Series.length; i++) {
                    options.series.push({
                        name: json.Series[i].Name,
                        data: json.Series[i].Data
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


