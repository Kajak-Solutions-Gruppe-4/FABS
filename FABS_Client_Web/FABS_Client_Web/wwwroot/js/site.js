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

    dateChange(startDate.value, endDate.value);
}

function endDateChange() {
    //check dates
    let startDate = document.getElementById("startDateInput")
    let endDate = document.getElementById("endDateInput")
    if (Date.parse(startDate.value) > Date.parse(endDate.value)) {
        startDate.value = endDate.value;
    }

    dateChange(startDate.value, endDate.value);
}

async function dateChange(startDate, endDate) {
    console.log(startDate)
    console.log(endDate)

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
    let overlappingItems = await findOverlappingBookings(startDate, endDate)
    let availableItems = items;
    for (var i = 0; i < overlappingItems.length; i++) {
        availableItems = availableItems.filter(item => {
            return item.id != overlappingItems[i].item.id;
        }) //filter returns the filtered list
    }

    //Creating item rows
    for (var i = 0; i < availableItems.length; i++) {
        let row = document.createElement("tr");
        row.className = "notSelectedItem";
        row.onclick = function () { onItemClick(row) };
        let data = [availableItems[i].id, availableItems[i].itemTypesId.name, availableItems[i].organisationsId.id];
        for (var j = 0; j < data.length; j++) {
            let cell = document.createElement("td");
            let cellText = document.createTextNode(data[j]);
            cell.appendChild(cellText);
            row.appendChild(cell);
        }
        newTable.appendChild(row);
    }
}

function onItemClick(clickedElement) {
    if (clickedElement.className === "notSelectedItem") {
        clickedElement.className = "selectedItem"
    } else {
        clickedElement.className = "notSelectedItem"
    }
}

function onSubmit() {
    console.log("Submit begin")
    let itemElements = document.getElementsByClassName("selectedItem");
    let itemIds = [];
    for (var i = 0; i < itemElements.length; i++) {
        itemIds.push(itemElements[i].children[0].innerText);
    }

    let bookingLines = createBookingLines(itemIds);
    console.log(bookingLines)
    let booking = createBooking(bookingLines);
    postBooking(booking);
}

function createBookingLines(itemsIds) {
    console.log("Creating booking lines")
    console.log(itemsIds)
    let bookingLines = []
    for (var i = 0; i < itemsIds.length; i++) {
        let bookingLine = {
            "bookingId": 0,
            "itemId": itemsIds[i]
        }
        bookingLines.push(bookingLine)
    }
    return bookingLines
}

function createBooking(bookingLines) {
    console.log("Creating booking")
    let booking = {
        "startDateTime": document.getElementById("startDateInput").value,
        "endDateTime": document.getElementById("endDateInput").value,
        "personId": document.getElementById("personIdInput").value,
        "bookingLines": bookingLines
    }
    console.log(bookingLines)
    return booking;
}



async function postBooking(booking) {
    console.log("Posting booking")
    console.log(JSON.stringify(booking))
    $.ajax({
        url: 'https://localhost:44309/api/bookings?organisationId=1',
        type: 'POST',
        data: JSON.stringify(booking),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response, textStatus, jqXHR) {
            console.log(response);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }
    })
}











async function findOverlappingBookings(startDate, endDate) {
    let url = 'https://localhost:44309/api/bookings/OnlyFutureInDateRange?organisationId=1&startdatetime=' + startDate + '&enddatetime=' + endDate
    return await $.getJSON(url).then(function (data) {
        return data
    })
}