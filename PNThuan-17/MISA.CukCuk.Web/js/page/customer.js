$('.radio-check').click(function () {
    $(this).prop('checked', true);
    var arr = $('.radio-check');
    for (let i = 0; i < arr.length; i++) {
        if (this != arr[i]) {
            $(arr[i]).prop("checked", false);
            break;
        }
    }
})