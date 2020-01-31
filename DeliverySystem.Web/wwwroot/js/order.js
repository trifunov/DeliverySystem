$(document).ready(function () {
    $('#ordersTable tbody tr').click(function () {
        $(this).toggleClass('selected');

        if ($(this).hasClass('selected')) {
            $(this).find('.add-order').hide();
            $(this).find('.remove-order').show();
            $(this).find('.remove-order').removeClass('hidden');
        }
        else {
            $(this).find('.add-order').show();
            $(this).find('.remove-order').hide();
        }
    });

    $('.show-order-info').click(function (e) {
        ShowOrderInfo($(this).data('orderid'));
        e.stopPropagation();
    });

    $('.order-fulfill').click(function (e) {
        OrderFulfill();
    });
});

function ShowOrderInfo(orderId) {
    $('#orderInfoTable').empty();
    $('#orderInfo').modal();

    $.ajax({
        url: "Order/GetProductsByOrderId",
        type: "GET",
        data: {
            'orderId': orderId
        },
        success: function (response) {
            var html = "";
            for (var i = 0; i < response.length; i++) {
                html += "<tr>";
                html += "<td>" + response[i].name + "</td>";
                html += "<td>" + response[i].description + "</td>";
                html += "<td>" + response[i].sku + "</td>";
                html += "<td>" + response[i].categoryName + "</td>";
                html += "<td>" + response[i].price + "</td>";
                html += "<td>" + response[i].quantity + "</td>";
                html += "<td>" + response[i].total + "</td>";
                html += "</tr>";
            }

            $('#orderInfoTable').html(html);
        },
        error: function (xhr) {
            alert("An error occured: " + xhr.status + " " + xhr.statusText);
        }
    });
}

function OrderFulfill() {
    $('#requestJson').empty();
    var selectedRows = [];

    $('#ordersTable tbody tr.selected').each(function () {
        selectedRows.push($(this).data('orderid'));
    });

    if (selectedRows.length > 0) {
        $.ajax({
            url: "Shipment/GetBySelectedOrderIds",
            type: "GET",
            data: {
                'orderIds': selectedRows.join(',')
            },
            success: function (response) {
                $('#requestJson').html(JSON.stringify(response));
                MakeExternalShippedCall(response);
            },
            error: function (xhr) {
                alert("An error occured: " + xhr.status + " " + xhr.statusText);
            }
        });
    }
    else {
        $('#requestJson').html('Please select orders to ship');
    }
}

function MakeExternalShippedCall(responseObject) {
    $.ajax({
        url: "http://localhost/orders",
        type: "POST",
        data: {
            'elements': JSON.stringify(responseObject)
        },
        complete: function () {
            //$('#requestJson').html(JSON.stringify(responseObject));
        }
    });
}
