(function() {
    $.noty.defaults = {
        layout: 'inline',
        theme: 'bootstrap',
        type: 'alert',
        text: '', // can be html or string
        dismissQueue: false, // If you want to use queue feature set this true
        template: '<div class="noty_message"><span class="noty_text lead"></span><div class="noty_close"></div></div>',
        animation: {
            open: { height: 'toggle' },
            close: { height: 'toggle' },
            easing: 'swing',
            speed: 500 // opening & closing animation speed
        },
        timeout: false, // delay for closing event. Set false for sticky notifications
        force: false, // adds notification to the beginning of queue when set to true
        modal: false,
        maxVisible: 5, // you can set max visible notification for dismissQueue true option,
        killer: false, // for close all notifications before show
        closeWith: ['click'], // ['click', 'button', 'hover', 'backdrop'] // backdrop click will close all open notifications
        callback: {
            onShow: function() {},
            afterShow: function() {},
            onClose: function() {},
            afterClose: function() {}
        },
        buttons: false // an array of buttons
    }
}());