$(document).ready(function () {
    loadData();
    $('#btnAdd').click(btnAddOnclick);
    $('#close').click(btnCancelOnclick);
    $('#btnCancel').click(btnCancelOnclick);

    $('#listCus').on('dblclick', 'tr', DbClick);
})

function btnCancelOnclick() {
    $('.dialog-modal').hide();
    $('.dialog').hide();
}
function btnAddOnclick() {
    $('.dialog-modal').show();
    $('.dialog').show();
}
function DbClick() {
    $('.dialog-modal').show();
    $('.dialog').show();
}



/**
 * Load dữ liệu
 * */
function loadData() {
    // thực hiện load dữ liệu
    // 1.Lấy dữ liệu
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
        data: null,
        dataType: 'json',
        contentType: 'application/json'
    }).done(function (response) {
        $('#listCus tbody').empty();
        for (var i = 0; i < response.length; i++) {
            var item = response[i];

            var customerCode = item['CustomerCode'];
            var fullName = item['FullName'];
            var genderName = item['GenderName'];
            var groupName = item['CustomerGroupName'];
            var dob = formDate(item['DateOfBirth']);
            var mobile = item['PhoneNumber'];
            var email = item['Email'];
            var address = item['Address'];
            var numberCard = item['MemberCardCode'];
            var money = '1.000.000';


            var trHTML = `<tr>
                                <td>${customerCode}</td>
                                <td>${fullName}</td>
                                <td>${genderName}</td>
                                <td>${dob}</td>
                                <td>${groupName}</td>
                                <td>${mobile}</td>
                                <td>${email}</td>
                                <td>${address}</td>
                                <td>${money}</td>
                                <td>${numberCard}</td>
                          </tr>`;
            $('#listCus tr:last').after(trHTML);
        }
    }).fail(function (response) {

    })
    // 2.Đọc dữ liệu

    // 3.Xử lí dữ liệu

    // 4.Đẩy dữ liệu vào HTML
}
/**
* @param
 **/
function formDate(date) {
    var date = new Date(date);
    day = date.getDate();
    month = date.getMonth() + 1;
    year = date.getFullYear();
    console.log(date);
    return day + '/' + month + '/' + year;
}