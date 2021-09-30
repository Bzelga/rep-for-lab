const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/randomArrCount")
    .build();

document.getElementById("sendBtn").addEventListener("click", function (e) {
    let count = document.getElementById("count").value;
    let from = document.getElementById("from").value;
    let to = document.getElementById("to").value;

    hubConnection.invoke("Send", { "Quantity": parseInt(count), "FromNumber": parseInt(from), "ToNumber": parseInt(to)});
});

hubConnection.start();