'use strict';

$(document).ready(function () {
    function legendClickCallback(event) {
        event = event || window.event;

        var target = event.target || event.srcElement;
        while (target.nodeName !== 'LI') {
            target = target.parentElement;
        }
        var parent = target.parentElement;
        var chartId = parseInt(parent.classList[0].split("-")[0], 10);
        var chart = Chart.instances[chartId];
        var index = Array.prototype.slice.call(parent.children).indexOf(target);
        var meta = chart.getDatasetMeta(index);
        if (meta.hidden === null) {
            meta.hidden = !chart.data.datasets[index].hidden;
            target.classList.add('hidden-lable');
        } else {
            target.classList.remove('hidden-lable');
            meta.hidden = null;
        }
        chart.update();
    }
    $.ajax({
        url: 'https://localhost:44328/Administrator/statistics',
        method: "GET",
        dataType: "json",
        data: [],
        success: function (response) {
            //  alert("Hello: " + response.Name + " .\nCurrent Date and Time: " + response.DateTime);

            var config = {
                type: 'line',
                data: {
                    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                    datasets: [{
                        label: 'Bookings per Month',
                        fill: true,
                        animation: false,
                        backgroundColor: "rgba(94, 207, 177, 0.2)",
                        borderColor: "#5ECFB1",
                        pointBackgroundColor: "#fff",
                        pointBorderWidth: 1,
                        pointBorderColor: "#5ECFB1",
                        pointHoverBorderWidth: 1,
                        data: response.ReservPerMonth
                    },
                    {
                        label: 'Reviews per Month',
                        fill: true,
                        animation: false,
                        backgroundColor: "rgba(77, 183, 254, 0.2)",
                        borderColor: "#4DB7FE",
                        pointBackgroundColor: "#fff",
                        pointBorderWidth: 1,
                        pointBorderColor: "#4DB7FE",
                        pointBorderWidth: 1,
                        pointHoverBorderWidth: 1,
                        data: response.ReviewsPerMonth
                    }]
                },
                options: {
                    legend: {
                        display: false
                    },
                    hover: {
                        onHover: function (e) {
                            var point = this.getElementAtEvent(e);
                            if (point.length) e.target.style.cursor = 'pointer';
                            else e.target.style.cursor = 'default';
                        }
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                fontColor: "rgba(0,0,0,0.2)",
                                fontStyle: "bold",
                                beginAtZero: true,

                                padding: 20
                            },
                            gridLines: {

                                display: true,
                                zeroLineColor: "transparent"
                            }

                        }],
                        xAxes: [{
                            gridLines: {
                                zeroLineColor: "transparent"
                            },
                            ticks: {
                                padding: 20,
                                fontColor: "rgba(0,0,0,0.5)",
                                fontStyle: "bold"
                            }
                        }],

                    },
                    tooltips: {
                        backgroundColor: "rgba(0,0,0,0.6)",
                        titleMarginBottom: 10,
                        footerMarginTop: 6,
                        xPadding: 22,
                        yPadding: 12
                    }
                }
            };
            var ctx = document.getElementById("canvas-chart");
            var myLegendContainer = document.getElementById("myChartLegend");

            var myChart = new Chart(ctx, config);
            myLegendContainer.innerHTML = myChart.generateLegend();
            var legendItems = myLegendContainer.getElementsByTagName('li');
            for (var i = 0; i < legendItems.length; i += 1) {
                legendItems[i].addEventListener("click", legendClickCallback, false);
            }

            var config1 = {
                type: 'bar',
                data: {
                    labels: ['Overall Rating', 'avg Accuracy', 'avg Checkin', 'avg Cleanliness', 'avg Location', 'avg Value'],
                    datasets: [{
                        label: 'Average Ratings',
                        fill: true,
                        animation: false,
                       // backgroundColor: ["#00cccc", "#66d9ff", "#8080ff", "#739900", "#7FFFD4","#009973"],//"rgba(77, 183, 254, 0.2)",
                        backgroundColor: ["#b3e6ff", "#80d4ff", "#33bbff", "#00aaff", "#0088cc", "#0077b3"],//"rgba(77, 183, 254, 0.2)",
                        borderColor: "#4DB7FE",
                        pointBackgroundColor: "#fff",
                        pointBorderWidth: 1,
                        pointBorderColor: "#4DB7FE",
                        pointBorderWidth: 1,
                        pointHoverBorderWidth: 1,

                        data: [response.OverallRatingPlace, response.avgAccuracy, response.avgCheckin, response.avgCleanliness, response.avgLocation, response.avgValue]
                    }]
                },
                options: {
                    legend: {
                        display: false
                    },
                    hover: {
                        onHover: function (e) {
                            var point = this.getElementAtEvent(e);
                            if (point.length) e.target.style.cursor = 'pointer';
                            else e.target.style.cursor = 'default';
                        }
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                fontColor: "rgba(0,0,0,0.2)",
                                fontStyle: "bold",
                                beginAtZero: true,

                                padding: 20
                            },
                            gridLines: {

                                display: true,
                                zeroLineColor: "transparent"
                            }

                        }],
                        xAxes: [{
                            gridLines: {
                                zeroLineColor: "transparent"
                            },
                            ticks: {
                                padding: 20,
                                fontColor: "rgba(0,0,0,0.5)",
                                fontStyle: "bold"
                            }
                        }],

                    },
                    tooltips: {
                        backgroundColor: "rgba(0,0,0,0.6)",
                        titleMarginBottom: 10,
                        footerMarginTop: 6,
                        xPadding: 22,
                        yPadding: 12
                    }
                }
            };
            var ctx1 = document.getElementById("canvas-chart1");
            var myLegendContainer1 = document.getElementById("myChartLegend1");

            var myChart1 = new Chart(ctx1, config1);
            myLegendContainer1.innerHTML = myChart1.generateLegend();
            var legendItems1 = myLegendContainer1.getElementsByTagName('li');
            for (var i = 0; i < legendItems1.length; i += 1) {
                legendItems1[i].addEventListener("click", legendClickCallback, false);
            }

        },
        failure: function (response) {
            alert("Fail: " + response.responseText);
        },
        error: function (err) {
            var msg = $.parseJSON(err).msg;
            alert(msg);
        }

    });
});