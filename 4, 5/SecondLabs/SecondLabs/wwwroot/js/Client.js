const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/randomArrCount")
    .build();

hubConnection.start();

document.getElementById("sendBtn").addEventListener("click", function (e) {
    let count = document.getElementById("count").value;
    let from = document.getElementById("from").value;
    let to = document.getElementById("to").value;

    const subject = new signalR.Subject();
    hubConnection.send("Send", subject);
    const intervalHandle = setInterval(() => {
        subject.next({ "Quantity": parseInt(count), "FromNumber": parseInt(from), "ToNumber": parseInt(to) },);
        clearInterval(intervalHandle);
        subject.complete();
    }, 500);
});