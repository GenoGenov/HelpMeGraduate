function handleError(e) {
    console.log(e);
    var $target = $('.notificator-admin');

    if ($target.length) {
        $target.html('');
        $target.show();
        $.each(e.errors, function (propertyName) {
            $target.noty({ text: this.errors, type: "error", theme: 'defaultTheme' });
        });
        
        $target.zIndex(9999);
    }
}

function onRequestEnd(e) {
    var tmp = e.type;
    if (tmp == "create") {
        var dataSource = this;
        dataSource.read();
    } else if (tmp == "update") {
    }
}