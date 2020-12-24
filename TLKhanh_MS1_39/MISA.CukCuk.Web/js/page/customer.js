var dialog = $(".customer-dialog").dialog({
    autoOpen: false,
    width: 700,
    modal: true,
});

$(document).ready(function () {
    loadData();
    initEvens();
    addOrUpdateCustomer();
    deleteCustomer();
    
})
/**
 * Thực hiện load dữ liệu
 * Author Tạ Long Khánh (8/12/2020)
 * */
function loadData() {
    $.ajax({
        url: 'http://localhost:57488/api/v1/Customers',
        method: 'GET',
    }).done(function (response) {
        $('tbody').empty();
        for (var customer of response) {
            var trHtml = `
                        <tr class="cell-content" data-id='${customer.customerId}'>
                            <td>${customer.customerCode}</td>
                            <td>${customer.fullName}</td>
                            <td>${formatGender(customer.gender)}</td>
                            <td>${formatDate(customer.dateOfBirth)}</td>
                            <td>${customer.address}</td>
                            <td>${customer.phoneNumber}</td>
                            <td>${customer.email}</td>
                            <td>${customer.customerGroupName}</td>
                            <td>${customer.companyName || ''}</td>
                        </tr>`;
            $('tbody').append(trHtml);
        }
    }).fail(function (response) {

    });

    $.ajax({
        url: 'http://localhost:57488/api/v1/CustomerGroups',
        method: 'GET',
    }).done(function (response) {
        $('#CustomerGroupId').empty();
        for (var customerGroup of response) {
            var customerGroupOptions = `<option value="${customerGroup.customerGroupId}">
                                            ${customerGroup.customerGroupName}
                                        </option>`;
            $('#CustomerGroupId').append(customerGroupOptions);
        }
    }).fail(function (response) {
        
    });
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
function formatGender(gender) {
    var gender = parseInt(gender);
    var genderName = gender == 0 ? "Nữ" : (gender == 1 ? "Nam" : "Khác");
    return genderName;
}
/**
 * Thực hiện gán các sự kiện
 * Author Tạ Long Khánh (8/12/2020)
 * */
function initEvens() {
    customerDialogShow();
}
/**
 * Hiển thị dialog thêm khách hàng mới
 * Author Tạ Long Khánh (8/12/2020)
 * */

function customerDialogShow() {
    $("#btn-AddCustomer").click(function () {
        var html = `
             <div id="btn-cancel" class="m-btn m-btn-secondary">Hủy</div>
            <div id="btn-save" class="m-btn m-btn-primary">Thêm</div>
        `;
        $('form').attr('data-action', 1);
        $('.dialog-footer').empty();
        $('.dialog-footer').append(html)
        clearInfo();
        dialog.dialog("open");
    });
    $("#tb-listDataCustomer").on('dblclick', '.cell-content', function () {
        var html = `
             <div id="btn-cancel" class="m-btn m-btn-secondary">Hủy</div>
            <div id="btn-del" class="m-btn m-btn-danger">Xóa</div>
            <div id="btn-save" class="m-btn m-btn-primary">Lưu</div>
        `;
        var customerId = $(this).attr('data-id');
        $('form').attr('data-action', 2);
        $('.dialog-footer').empty();
        $('.dialog-footer').append(html)
        $('#btn-save').attr('data-id', customerId);
        $('#btn-del').attr('data-id', customerId);
        dialog.dialog('option', 'title', 'Thông tin khách hàng');
        showCustomerInfo(customerId)
        dialog.dialog("open");
    })
    $('.dialog-footer').on('click', '#btn-cancel', function () {
        dialog.dialog("close");
    });
}
/**
 * Thực hiện logic thêm hoac sua khách hàng
 * Author Tạ Long Khánh (23/12/2020)
 * */
function addOrUpdateCustomer() {
    $('.dialog-footer').on('click', '#btn-save', function () {
        var formDataArray = $('form').serializeArray();

        var customer = formDataArray.reduce(function (customer, obj) {
            customer[obj.name] = obj.value;
            return customer;
        }, {});
        var dataAction = parseInt($('form').attr('data-action'));
        // = 1 => add new, = 2 => update
        if (dataAction == 1) {
            $.ajax({
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                url: "http://localhost:57488/api/v1/Customers/",
                type: "post",
                data: JSON.stringify(customer)
            }).done(function (response) {
                dialog.dialog("close");
                loadData();
                toat({
                    message: "Thêm khách hàng thành công.",
                    type: 'success',
                    duration: 3000
                })
            }).fail(function (xhr, status, error) {
                toat({
                    message: typeof (xhr.responseJSON) == 'string' ? xhr.responseJSON : 'Lỗi!',
                    type: 'danger',
                    duration: 3000
                })
            })
        }
        if (dataAction == 2) {
            var id = $(this).attr('data-id');
            $.ajax({
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                url: `http://localhost:57488/api/v1/Customers/${id}`,
                type: "put",
                data: JSON.stringify(customer)
            }).done(function (response) {
                loadData();
                dialog.dialog("close");
                toat({
                    message: "Cập nhật thông tin khách hàng thành công.",
                    type: 'success',
                    duration: 3000
                })
            }).fail(function (xhr, status, error) {
                toat({
                    message: typeof (xhr.responseJSON) == 'string' ? xhr.responseJSON : 'Lỗi!',
                    type: 'danger',
                    duration: 3000
                })
            })
        }
    })
}

/**
 * Thực hiện logic xoa khách hàng
 * Author Tạ Long Khánh (23/12/2020)
 * */
function deleteCustomer() {
    $('.dialog-footer').on('click', '#btn-del', function () {
        var id = $(this).attr('data-id');
        $.ajax({
            url: `http://localhost:57488/api/v1/Customers/${id}`,
            type: "delete",
        }).done(function (response) {
            loadData();
            dialog.dialog("close");
            toat({
                message: "Xóa khách hàng thành công.",
                type: 'success',
                duration: 3000
            })
        }).fail(function (xhr, status, error) {
            toat({
                message: typeof (xhr.responseJSON) == 'string' ? xhr.responseJSON : 'Lỗi!',
                type: 'danger',
                duration: 3000
            })
        })
    })
}
/**
 * Xóa Input thông tin khách hàng khi thêm mới thành công
 * Author Tạ Long Khánh (23/12/2020)
 * */
function clearInfo() {
    $('#CustomerCode').val('');
    $('#FullName').val('');
    $('#MemberCardCode').val('');
    $('#CustomerGroupId').val('3304dddb-1b72-607f-25c2-579daad24557');
    $('#DateOfBirth').val('');
    $('#male').prop('checked', 'checked');
    $('#Email').val('');
    $('#PhoneNumber').val('');
    $('#CompanyName').val('');
    $('#CompanyTaxCode').val('');
    $('#Address').val('');

}
/**
 * DoubleClick hiển thị thông tin khách hàng
 * Author Tạ Long Khánh (23/12/2020)
 * */
function showCustomerInfo(customerId) {
    $.ajax({
        url: `http://localhost:57488/api/v1/Customers/${customerId}`,
        method: 'GET',
    }).done(function (response) {
        $('#CustomerCode').val(response[0].customerCode);
        $('#FullName').val(response[0].fullName);
        $('#MemberCardCode').val(response[0].memberCardCode);
        $('#CustomerGroupId').val(response[0].customerGroupId);
        var date = (response[0].dateOfBirth).substring(0, 10);
        $('#DateOfBirth').val(date);
        var gender = response[0].gender == 1 ? 'male' : (response[0].gender == 0 ? 'female' : 'another');
        $(`#${gender}`).prop('checked', 'checked');
        $('#Email').val(response[0].email);
        $('#PhoneNumber').val(response[0].phoneNumber);
        $('#CompanyName').val(response[0].companyName);
        $('#CompanyTaxCode').val(response[0].companyTaxCode);
        $('#Address').val(response[0].address);
    }).fail(function (response) {

    });
    
}