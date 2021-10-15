const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/randomArrCount")
    .build();

hubConnection.start();

function getRandomInRange(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

document.getElementById("sendBtn").addEventListener("click", function (e) {
    let count = document.getElementById("count").value;
    let from = document.getElementById("from").value;
    let to = document.getElementById("to").value;

    const subject = new signalR.Subject();
    hubConnection.send("Send", subject);
    var iteration = 0;

    const intervalHandle = setInterval(() => {
        iteration++;
        subject.next(getRandomInRange(Number(from), Number(to)));
        if (iteration == count) {
            clearInterval(intervalHandle);
            subject.complete();
        }
    }, 10);
});