$(function () {
    var orderProcesing = $.connection.OrderProcessingHub;
    orderProcessing.client.addNotification = function (number) {
        $('#order-notification').text(number);
    }
    orderProcessing.client.aalert()
    {
        alert("SignalR is working!");
    }
    $.connection.hub.start().done( function () {
        alert("Start hub!");
    });
})