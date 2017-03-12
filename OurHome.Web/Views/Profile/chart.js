$(document).ready(function() {
    ctx = $('#chart');
    var resourceChart;

    drawChart(1);
    


    $('.chart_period').click(function () {
        var _this = $(this);

        //Снимаем выделение
        $.each($('#period-selector').children(), function(key, value) {
            $(value).removeClass('active');
        });

        //Добавляем выделение
        _this.parent().addClass('active');

        var period = Number(_this.data('period'));
        drawChart(period);
    });

    /*
   
    */


    function drawChart(month_count) {
        var max = 10;
        var min = 3;
        var sum = 0;

        data = [];
        labels = [];

        //Просто отступаем от текущей даты сколько надо
        var now = moment();
        var date = moment();
        date.add(-month_count, 'month');

        var daysCount = now.diff(date, 'days');
        var labelEvery = Math.round(daysCount / 15);        //Надпись каждые x дней

        var i = 0;
        while (date < now) {
            var perDay = Math.floor(Math.random() * (max - min + 1)) + min;
            data.push(perDay);
            sum += perDay;

            if (i % labelEvery==0)
                labels.push(date.format('DD.MM.YYYY'));
            else
                labels.push('');

            i++;
            date.add(1, 'day');
        }

        if (resourceChart != undefined) {
            resourceChart.destroy();
        }

        resourceChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Потребление, '+unit,
                    data: data,
                    backgroundColor: 'rgba(54, 162, 235, 0.2)',
                    borderColor: 'rgba(54, 162, 235, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        stacked: true
                    }],
                    xAxes: [{
                        barPercentage: 1,
                        categoryPercentage: 1
                    }]
                }
            }
        });

        //Обновлени стоимости и общего кол-ва
        $('#resources').html(sum);
        $('#money').html(sum*1.5);
    }

});