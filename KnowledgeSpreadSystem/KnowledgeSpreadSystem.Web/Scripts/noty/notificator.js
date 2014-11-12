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

$(document).ready(function () {
    var $target = $('.notificator');
    if ($target.length) {
        $target.noty({ text: $target.attr('data-msg'), type: $target.attr('data-type'), theme: 'defaultTheme' });
        $target.removeAttr('data-msg');
        $target.removeAttr('data-type');

    }
});