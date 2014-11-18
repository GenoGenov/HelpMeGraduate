var chat = $.connection.chatHub;
var $chat = $('#chat-body');

chat.client.connected = function (id, date) {
    $("#results").append("connected: " + id + " : " + date + "</br>");
};

chat.client.disconnected = function (id, date) {
    $("#results").append(("connected: " + id + " : " + date + "</br>"));
};

chat.client.populateUsers=function(data) {
    $(data).each(function(index, element) {
        $chat.append($('<li/>').text(element));
    });
}

chat.client.userJoined=function(user) {
    $chat.append($('<li/>').text(user));
}

$.connection.hub.start().done(function () {
    
});
