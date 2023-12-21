var App = ( function () {

    var settings = {
        apiUrl: "https://localhost:7003/api/fruits",
    }

    function init() {
        clearError();
        attachEventHandlers();
        fetchData(null);
    }

    function attachEventHandlers() {
        $("#btnFilter").on("click", function (e) {
            filterData();
        });
    }

    function fetchData(datePicked) {
        var url = settings.apiUrl;
        if (datePicked) {
            url += "?datepicked=" + datePicked;
        }

        $.ajax({
            url: url,
            type: "GET",
            dataType: "json",
            success: function (data) {
                populateGrid(data);
            },
            error: function (result) {
                displayError("An error has occurred while displaying the data. Please call customer support.");
                console.log(result);
            }
        });
    }

    function displayError(message) {
        $("div.alert.alert-danger").remove();
        var alertBox = $('<div class="alert alert-danger" role="alert">' + message + '</div>');
        $("#messagePlaceholder").append(alertBox);
    }

    function isValidDate(dateString)
    {
        if(!/^\d{4}-\d{1,2}-\d{1,2}$/.test(dateString))
            return false;

        var parts = dateString.split("-");
        var year = parseInt(parts[0], 10);
        var month = parseInt(parts[1], 10);
        var day = parseInt(parts[2], 10);

        if(year < 1000 || year > 3000 || month == 0 || month > 12)
            return false;

        var monthLength = [ 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ];

        if(year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
            monthLength[1] = 29;

        return day > 0 && day <= monthLength[month - 1];
    };

    function filterData() {
        var date = $("#datePicked").val();
        var valid = isValidDate(date);

        if(valid || date === "") {
            clearError();
            fetchData(date);
        } else {
            displayError("Invalid date");
        }
    }

    function clearError() {
        $("div.alert.alert-danger").remove();
    }

    function populateGrid(data) {
        $("table.fruit-list tr").not(':first').remove();
        for (var i = 0; i< data.length; i++) {
            addRow(data[i]);
        }
    }

    function addRow(record) {
        var newRow = $("<tr>");
        var cols = "";

        cols += '<td>' + record.name + '</td>';
        cols += '<td>' + record.color + '</td>';
        cols += '<td>' + formatBoolean(record.hasSeeds) + '</td>';
        cols += '<td>' + record.price + '</td>';
        cols += '<td>' + record.weight + '</td>';
        cols += '<td>' + formatDate(record.datePicked) + '</td>';
        
        newRow.append(cols);
        
        $("table.fruit-list").append(newRow);
    }

    function formatBoolean(val) {
        return val ? "Yes" : "No";
    }

    function formatDate(val) {
        if(val) {
            var date = new Date(val);
            return (date.getMonth()+1) + "/" + date.getDate() + "/" + date.getFullYear();
        }

        return ""; 
    }

    return {
        init: init
    }

})();

App.init();
