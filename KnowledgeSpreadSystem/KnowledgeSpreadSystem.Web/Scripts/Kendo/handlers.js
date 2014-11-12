function onRequestEnd(e) {
    var tmp = e.type;
    if (tmp == "create") {
        var dataSource = this;
        dataSource.read();
    } else if (tmp == "update") {
    }
}