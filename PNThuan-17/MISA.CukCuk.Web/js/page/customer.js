$(document).ready(function () {
    dialog = $('.dialog').dialog({
        autoOpen: false,
        width: 800,
        height: 590,
        modal: true
    });
    loadData();
  
    initEvents();
})
/** 
 *
 * 
 */

$('.icon-x').click(function () {
    $('.dialog')[0].style.display = 'none';
});
/*$('.button-add').click(function () {
    dialog.dialog('open');
})*/
/**
 * Load data 
 * */
function loadData() {
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
        data: null,
        contentType: 'application/json',
    }).done(function (res) {
        $('#tbListData tbody').empty();
        for (let i = 0; i < res.length; i++) {
            var item = res[i];

            var customerCode = item['CustomerCode'];
            var fullname = item['FullName'];
            var gennerName = item['GennerName'];
            var dob = item['DateOfBirth'];
            var cusGroup = item['CustomerGroupName'];
            var phone = item['PhoneNumber'];
            var email = item['Email'];
            var address = item['Address'];
            var money = '000';
            var memCode = item['MemberCardCode'];
            $('#tbListData tr:last').after(`<tr>
                                                <td>${customerCode}</td>
                                                <td>${fullname}</td>
                                                <td>${gennerName}</td>
                                                <td>${dob}</td>
                                                <td>${cusGroup}</td>
                                                <td>${phone}</td>
                                                <td>${email}</td>
                                                <td>${address}</td>
                                                <td>${money}</td>
                                                <td>${memCode}</td>
                                            </tr>`)
        }
    }).fail(function (res) {

    })
    //2 : doc du lieu
    //3 : xu ly du lieu
    //4 : day du lieu len
}
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




/** 
 *  Ham dinh dang ngay thang
 *@param {Date} data ngay truyen vao
 *
 */
function fomatDate(date) {
    date = new Date(date);
    day = date.getDate();
    month = date.getMonth() + 1;
    year = date.getFullYear();
    return day + '/' + month + '/' + year;
}
/**
 * Thuc hien gan su kien
 * */
function initEvents() {
    $('.button-add').click(function () {
        dialog.dialog('open');
    })

    $('.btnCancel').click(function () {
        dialog.dialog('close');
    })
    $('#tbListData').on('dblclick', 'tr', function () {
        dialog.dialog('open');
    })
}