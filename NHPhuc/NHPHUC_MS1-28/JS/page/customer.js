$(document).ready(function () {
   
    dialog = $( ".dialog" ).dialog({
        autoOpen: false,
        width: 580,
        height: 600,
        modal: true,
    });
    loadData();
    $('#btnAdd').click(btnAddOnClick)
    $('#btn-cancel').click(btncancelOnClick)
    $('#choose-department').click(btnchooseDepartmentOnClick)
});
function btnAddOnClick() {
    dialog.dialog('open');
}
function btncancelOnClick(){
    dialog.dialog('close');
}
//Thuc hien load du lieu
function loadData() {
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
        data: null,
        dataType: 'json',
        contentType: 'application/json'
    }).done(function (response) {
        $('#table_data tbody').empty();
        for (var i = 0; i < response.length; i++) {
            var iteam = response[i];
            var customerCode = iteam['CustomerCode'];
            var fullName = iteam['FullName'];
            var gender = iteam['Gender'];
            var dob = iteam['DateOfBirth'];
            var groupName = iteam['CustomerGroupName'];
            var mobile = iteam['PhoneNumber'];
            var email = iteam['Email'];
            var address = iteam['Address'];
            var dateString = formatDate(dob);
            var memberCardCode = iteam['MemberCardCode'];
            var debitAmount = iteam['DebitAmount'];
            var trHTML = `<tr>
                            <td>${customerCode}</td>
                            <td>${fullName}</td>
                            <td>${gender}</td>
                            <td>${dateString}</td>
                            <td>${groupName}</td>
                            <td>${mobile}</td>
                            <td>${email}</td>
                            <td>${address}</td>
                            <td>${debitAmount}</td>
                            <td>${memberCardCode}</td >
                         </tr>`;
            $('#table_data tr:last').after(trHTML);
        }
    }).fail(function (response) {

    })
}
/*
 * Hàm định dạng ngày tháng
 */
function formatDate(date) {
    date = new Date(date);
    day = date.getDate();
    month = date.getMonth()+1;
    year = date.getFullYear();
    if (day < 10 ) {
        day = '0' + day;
    }
    if (month < 10) {
        month = '0' + month;
    }
        return day + '/' + month +'/' + year;
}