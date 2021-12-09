// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function startDateChange() {
    //check dates
    let startDate = document.getElementById("startDateInput")
    let endDate = document.getElementById("endDateInput")
    if (Date.parse(startDate.value) > Date.parse(endDate.value)) {
        endDate.value = startDate.value;
    }

    dateChange(startDate, endDate);
}

function endDateChange() {
    //check dates
    let startDate = document.getElementById("startDateInput")
    let endDate = document.getElementById("endDateInput")
    if (Date.parse(startDate.value) > Date.parse(endDate.value)) {
        startDate.value = endDate.value;
    }

    dateChange(startDate, endDate);
}

function dateChange(startDate, endDate) {
    let tableDiv = document.getElementById("tableDiv");
    tableDiv.children[0].remove();

    let newTable = document.createElement("table")
    tableDiv.appendChild(newTable);

    //Creating headers
    let headers = document.createElement("tr");
    for (var i = 0; i < 3; i++) {
        let headerTexts = ["Item ID", "Itemtype name", "Organisation ID"];
        let header = document.createElement("th");
        let headerText = document.createTextNode(headerTexts[i]);
        header.appendChild(headerText);
        headers.appendChild(header);
    }
    newTable.appendChild(headers);

    //filter to show only available items
    let url = 'https://localhost:44309/api/bookings/OnlyFutureInDateRange?organisationId=1&startdatetime=' + startDate.value + '&enddatetime=' + endDate.value
    let overlappingItems = $.getJSON(url, function (data) {})
    console.log(overlappingItems)
    let availableItems = items;
    for (var i = 0; i < overlappingItems.length; i++) {
        availableItems = availableItems.filter(item => {
            return item.id === overlappingItems[i].item.id;
        }) //filter returns the filtered list
    }



    //Creating item rows
    for (var i = 0; i < availableItems.length; i++) {
        let row = document.createElement("tr");
        let data = [items[i].id, items[i].itemTypesId.name, items[i].organisationsId.id];
        for (var j = 0; j < data.length; j++) {
            let cell = document.createElement("td");
            let cellText = document.createTextNode(data[j]);
            cell.appendChild(cellText);
            row.appendChild(cell);
        }
        newTable.appendChild(row);
    }





    
}