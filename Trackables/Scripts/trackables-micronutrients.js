﻿var charts = (function ($) {

    var refreshBarChartUrl = "/micronutrients/refreshbarchart/";
    var refreshLineChartUrl = "/micronutrients/refreshlinechart/";

    /* On page load functions */

    SetDateOnLoad();

    $('.date').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false
    });

    $("#fromdate").val(sessionStorage["currentDate"]);
    $("#todate").val(sessionStorage["currentDate"]);


    $('#GenerateChartButton').click(function (e) {
        e.preventDefault();

        var from = $("#fromdate").val();
        var to = $("#todate").val();

        if (from === to) {
            refreshBarChart();
        }
        else {
            refreshLineChart("Grams");
        }
    });

    function refreshBarChart() {

        $.ajax({
            type: "POST",
            url: refreshBarChartUrl,
            dataType: "json",
            data: {
                start: $("#fromdate").val(),
                end: $("#todate").val(),
                nutrient: $('#SelectedNutrientId :selected').text()
            },
            success: function (json) {

                var options = {
                    chart: { renderTo: "foodChart", type: "bar" },
                    title: { text: "" },
                    yAxis: { title: { text: "" } },
                    xAxis: { categories: json.BarNames },
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


    function refreshLineChart(nutrient, yAxis) {

        $.ajax({
            type: "POST",
            url: refreshLineChartUrl,
            dataType: "json",
            data: {
                start: $("#fromdate").val(),
                end: $("#todate").val(),
                nutrient: $('#SelectedNutrientId :selected').text()
            },
            success: function (json) {

                var options = {
                    chart: { renderTo: "foodChart", type: "line" },
                    title: { text: "" },
                    yAxis: { title: { text: "" } },
                    xAxis: { categories: json.BarNames },
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
})(jQuery);


