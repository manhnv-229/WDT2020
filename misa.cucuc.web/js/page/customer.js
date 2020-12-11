
$(document).ready(function () {
    dialog = $(".customer-dialog").dialog({
        autoOpen: true,
       width:700,
        modal: true,
    })
    loadData();

    initEvens();
   

  
})
/**
 * laod dl
 * author: nhhung
 * */
function loadData() {
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
    }).done(function (response) {
        console.log(response);
        $('#customer tbody').empty();
        for (var i = 0; i < response.length; i++) {
            console.log(response[i]);
            var DOB = formatDate(response[i].DateOfBirth);
            var trHtml = `<tr>
            <td>${response[i].CustomerCode}</td>
            <td>${response[i].FullName}</td>
            <td>${response[i].GenderName}</td>
            <td>${DOB}</td>
            <td>${response[i].CustomerGroupName}</td>
            <td>${response[i].PhoneNumber}</td>
            <td>${response[i].Email}</td>
            <td>${response[i].Address}</td>
            <td>${response[i].DebitAmount || ""}</td>
            <td>${response[i].MemberCardCode}</td>
        </tr>`;
            $('#customer > tbody:last-child').append(trHtml);
        }
    }).fail(function (response) {

    }) 
}
/**
 * gan su kien
 * author: nhhung
 * */
function initEvens() {
    $('.function').click(function () {
        dialog.dialog('open');
    })


    $('#customer').on('dblclick', 'tr', function () {
        dialog.dialog('open');
    })
}
/**
 * Dinh dang ngay thang
 * @param {any} date ngay truyen
 * author: nhhung
 */
function formatDate(date) {
    var date = new Date(date);
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();
    return day + '/' + month + '/' + year;
}