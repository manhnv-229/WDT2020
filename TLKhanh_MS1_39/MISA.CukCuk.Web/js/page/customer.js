$(document).ready(function () {
    loadData();
    initEvens();
})
/**
 * Thực hiện load dữ liệu
 * Author Tạ Long Khánh (8/12/2020)
 * */
function loadData() {
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
    }).done(function (response) {
        $('tbody').empty();
        for (var customer of response) {
            var trHtml = `
                        <tr class="cell-content" data-id='${customer.CustomerId}'>
                            <td>${customer.CustomerCode}</td>
                            <td>${customer.FullName}</td>
                            <td>${customer.GenderName}</td>
                            <td>${formatDate(customer.DateOfBirth)}</td>
                            <td>${customer.Address}</td>
                            <td>${customer.PhoneNumber}</td>
                            <td>${customer.Email}</td>
                            <td>${customer.CustomerGroupName}</td>
                            <td>${customer.DebitAmount || ''}</td>
                            <td>${customer.CompanyName}</td>
                        </tr>`;
            $('tbody').append(trHtml);
        }
    }).fail(function (response) {

    })
}
/**
 * Thực hiện format ngày sinh
 * Author Tạ Long Khánh (8/12/2020)
 * @param {string} date
 */
function formatDate(date) {
    var date = new Date(date);
    var day = date.getDate() > 10 ? date.getDate() : '0' + date.getDate();
    var month = (date.getMonth() + 1) > 10 ? (date.getMonth() + 1) : '0' + (date.getMonth() + 1);
    var year = date.getFullYear();
    return `${day}/${month}/${year}`
}
/**
 * Thực hiện gán các sự kiện
 * Author Tạ Long Khánh (8/12/2020)
 * */
function initEvens() {
    addCustomerDialogShow();
    infoCustomerDialogShow();
}
/**
 * Hiển thị dialog thêm khách hàng mới
 * Author Tạ Long Khánh (8/12/2020)
 * */
function addCustomerDialogShow() {
    var dialog = $(".add-customer-dialog").dialog({
        autoOpen: false,
        width: 700,
        modal: true,
    });
    $("#btn-AddCustomer").click(function () {
        dialog.dialog("open");
    })
}
/**
 * Hiển thị dialog thông tin khách hàng
 * Author Tạ Long Khánh (8/12/2020)
 * */
function infoCustomerDialogShow(){
    var dialog = $(".info-customer-dialog").dialog({
        autoOpen: false,
        width: 700,
        modal: true,
    });
    $('#tb-lisData').on('dblclick', '.cell-content', function () {
        dialog.dialog("open");
    })
}