var charts = (function ($) {

    var refreshBarChartUrl = "/trackableschart/refreshbarchart/";
    var refreshLineChartUrl = "/trackableschart/refreshlinechart/";

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
            refreshChart("bar");
        }
        else {
            refreshChart("line");
        }

    });



    function refreshChart(chartType) {

        $.ajax({
            type: "POST",
            url: refreshLineChartUrl,
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
                            text: yAxis
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


})(jQuery);


