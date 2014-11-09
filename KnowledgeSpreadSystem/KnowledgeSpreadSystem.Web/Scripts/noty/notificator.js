$(document).ready(function() {
    var $target = $('.notificator');
    if ($target.length) {
        $target.noty({ text: $target.attr('data-msg'), type: $target.attr('data-type'), theme: 'defaultTheme' });
        $target.removeAttr('data-msg');
        $target.removeAttr('data-type');
    }
});