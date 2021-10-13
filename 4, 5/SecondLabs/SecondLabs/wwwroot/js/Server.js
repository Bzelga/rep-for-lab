hubConnection.on("Receive", function(e) {
    
    hubConnection.stream("ReceiveHub",e, 10)
        .subscribe({
            next: (item) => {
                document.getElementById("response").append(' ' + item);
            },
            error: (err) => {
                document.getElementById("response").textContent = err;
            },
        });
});