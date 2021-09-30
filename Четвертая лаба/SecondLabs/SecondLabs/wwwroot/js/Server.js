hubConnection.on("Receive", function changeArray(arr) {
    document.getElementById("response").innerText = arr.join(', ');
});
