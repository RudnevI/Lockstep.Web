"use strict";


const notifyConnection = new signalR.HubConnectionBuilder()
    .withUrl("/notify")
    .build();

notifyConnection.on("Send", function (data) {

    let elem = document.createElement("p");
    elem.appendChild(document.createTextNode(data));
    let firstElem = document.getElementById("notification").firstChild;
    document.getElementById("notification").insertBefore(elem, firstElem);

});
notifyConnection.start();
window.onload = notifyConnection.invoke("Send", "Notification");


