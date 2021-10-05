"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/hub").build();

connection.on("recievemessage", function (message) {
    var div = document.createElement("div");
    div.innerHTML = "hoooray" + message.CommentContent;
    document.getElementById("messages").appendChild(div);
    var random = "@Html.Raw(Json.Encode(Model.MediaID))";
    console.log(random);


});

connection.start().catch(function (err) {
    console.log(err.toString());
});
document.getElementById("sendbutton").addEventListener("click", function (event) {
    var message = document.getElementById("message").value;
    connection.invoke("SendMessage", message).catch(function (err) {
        console.log(err.toString());
    });
    e.preventDefault();
});