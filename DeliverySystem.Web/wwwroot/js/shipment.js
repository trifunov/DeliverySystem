$(document).ready(function () {
    $('.show-shipment-info').click(function () {
        ShowShipmentInfo($(this).data('address'), $(this).data('categoryid'));
    });

    $('.show-shipped').click(function () {
        ShowShipped($(this).data('address'), $(this).data('categoryid'));
    });
});

function ShowShipmentInfo(address, categoryId) {
    $('#shipmentInfoTable').empty();

    $.ajax({
        url: "Shipment/GetByAddressAndCategoryId",
        type: "GET",
        data: {
            'address': address,
            'categoryId': categoryId
        },
        success: function (response) {
            if (response.length > 0) {
                var html = "";
                for (var i = 0; i < response.length; i++) {
                    html += "<thead>";
                    html += "<tr>";
                    html += "<th>" + "OrderId: " + response[i].orderId + "</th>";
                    html += "<th colspan='2'>" + "Address: " + response[i].address + "</th>";
                    html += "<th colspan='2'>" + "First name: " + response[i].firstName + "</th>";
                    html += "<th colspan='2'>" + "Last name: " + response[i].lastName + "</th>";
                    html += "</tr>";
                    html += "<thead>";

                    for (var j = 0; j < response[i].products.length; j++) {
                        html += "<tr>";
                        html += "<td>" + response[i].products[j].name + "</td>" + "<td>" + response[i].products[j].description + "</td>" + "<td>" + response[i].products[j].sku + "</td>" + "<td>" + response[i].products[j].quantity + "</td>" + "<td>" + response[i].products[j].price + "</td>" + "<td>" + response[i].products[j].total + "</td>" + "<td>" + response[i].products[j].categoryName + "</td>";
                        html += "</tr>";
                    }
                }

                $('#shipmentInfoTable').html(html);
            }
        },
        error: function (xhr) {
            alert("An error occured: " + xhr.status + " " + xhr.statusText);
        }
    });
}

function ShowShipped(address, categoryId) {
    $('#requestJson').empty();

    $.ajax({
        url: "Shipment/GetByAddressAndCategoryId",
        type: "GET",
        data: {
            'address': address,
            'categoryId': categoryId
        },
        success: function (response) {
            MakeExternalShippedCall(response);
        },
        error: function (xhr) {
            alert("An error occured: " + xhr.status + " " + xhr.statusText);
        }
    });
}

function MakeExternalShippedCall(responseObject) {
    $.ajax({
        url: "http://localhost/orders",
        type: "POST",
        data: {
            'elements': JSON.stringify(responseObject)
        },
        complete: function () {
            $('#requestJson').html(JSON.stringify(responseObject));
        }
    });
}