var charts = (function ($) {

    var refreshBarChartUrl = "/macronutrients/refreshbarchart/";
    var refreshLineChartUrl = "/macronutrients/refreshlinechart/";

    /* On page load functions */

    SetDateOnLoad();

    $('.date').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false
    });

    $("#fromdate").val(sessionStorage["currentDate"]);
    $("#todate").val(sessionStorage["currentDate"]);


    /* Event handlers */

    $('#GenerateChartButton').click(function (e) {
        e.preventDefault();

        var from = $("#fromdate").val();
        var to = $("#todate").val();

        if (from === to) {
            refreshBarChart();
        }
        else {
            refreshLineChart();
        }
    });


    /* Functions */

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


    function refreshLineChart() {

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
    
})(jQuery);


