
var dialog = $(".customer-dialog").dialog({
    autoOpen: false,
    width: 700,
    modal: true,
});

var currentPage = 1;
var totalPages;
var limit = 10;

$(document).ready(function () {
    loadData();
    initEvens();
    addOrUpdateCustomer();
    deleteCustomer();
    loadPaginate();
    
})


/**
 * Thực hiện load dữ liệu
 * Author Tạ Long Khánh (8/12/2020)
 * */
function loadData(first) {
    $.ajax({
        url: 'http://localhost:57488/api/v1/Customers',
        method: 'GET',
    }).done(function (response) {
        
        if (first) {
            response = response.slice(0, limit);
        } else {
            response = response.slice((currentPage - 1) * limit, currentPage * limit);
        }
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
 * Thực hiện load Phân trang
 * Author Tạ Long Khánh (24/12/2020)
 * */
function loadPaginate() {
    $.ajax({
        url: 'http://localhost:57488/api/v1/Customers',
        method: 'GET',
    }).done(function (response) {
        // paginate
        totalRows = response.length;
        $('.paginate').empty();

        totalPages = Math.ceil(totalRows / limit);

        var start = 1;
        var page = currentPage;
        var end = totalPages;
        if (page > 2) {
            start = page - 2;
        }
        if (page > 0 && page < totalPages - 2) {
            end = page + 2;
        }
        if (totalPages < 2) {
            $('.content__paginate-bar').remove();
            $('.table').height(540);
        }
        if (totalPages > 2) {
            var paginateHtml = `
                         <div onclick="firstPageClick()" class="page-control first-page"></div>
                         <div onclick="prevPageClick()" class="page-control prev-page"></div>
                        `;
        }
        else {
            var paginateHtml = '';
        }

        for (var i = start; i <= end; i++) {
            if (i == currentPage) {
                paginateHtml += `
                    <div onclick="pageClick(${i})" class="page page-active">${i}</div>
                    `;
            }
            else {
                paginateHtml += `
                    <div onclick="pageClick(${i})" class="page">${i}</div>
                    `;
            }

        }
        if (totalPages > 2) {
            paginateHtml += `
                        <div onclick="nextPageClick()" class="page-control next-page"></div>
                        <div onclick="lastPageClick()" class="page-control last-page"></div>
                        `;
        }
        
        $('.paginate').append(paginateHtml)

        // count
        $('.count-customer').empty();
        var start = (currentPage - 1) * limit;
        var end = currentPage * limit;
        if (end > response.length) {
            end = response.length;
        }
        var html = `Hiển thị ${start}-${end}/${response.length} Khách hàng`;
        $('.count-customer').append(html);
        // total
        $('.total-page').empty();
        var html = `${limit} Khách hàng/Trang`;
        $('.total-page').append(html);
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
/**
 * Thực hiện format gioi tinh
 * Author Tạ Long Khánh (23/12/2020)
 * @param {int} gender
 */
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
                loadData(true);
                loadPaginate();
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
            loadData(true);
            loadPaginate();
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

/**
 * Thay đổi nội dung khách hàng theo trang
 * Author Tạ Long Khánh (24/12/2020)
 * @param {int} page
 */
function pageClick(page) {
    if (page == currentPage) {
        return;
    }
    else {
        loadPaginate();
        currentPage = page;
        $('.paginate').on('click', '.page', function () {
            var pages = $('.page');
            pages.removeClass('page-active');
            $(this).addClass('page-active')
        })

        $.ajax({
            url: 'http://localhost:57488/api/v1/Customers',
            method: 'GET',
        }).done(function (response) {
            $('tbody').empty();
            response = response.slice((currentPage - 1) * limit, limit * currentPage);

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
    }
    
}
/**
 * Xử lý logic khi nút next click
 * Author Tạ Long Khánh (24/12/2020)
 * */
function nextPageClick() {
    var page = currentPage + 1;
    if (page > totalPages) {
        page = totalPages;
    }
    if (currentPage == totalPages) {
        return;
    }
    else {
        $('.paginate').one('click', '.next-page', function () {
            var next = $('.page-active').next();
            var pages = $('.page');
            pages.removeClass('page-active');
            next.addClass('page-active');
        })
        pageClick(page);
    }
}
/**
 * Xử lý logic khi nút last click
 * Author Tạ Long Khánh (24/12/2020)
 * */
function lastPageClick() {
    pageClick(totalPages);
    var pages = $('.page');
    pages.removeClass('page-active');
    $('.page').last().addClass('page-active')

}
/**
 * Xử lý logic khi nút prev click
 * Author Tạ Long Khánh (24/12/2020)
 * */
function prevPageClick() {
    var page = currentPage - 1;
    if (page < 1) {
        page = 1;
    }
    if (currentPage == 1) {
        return;
    }
    else {
        $('.paginate').one('click', '.prev-page', function () {
            var prev = $('.page-active').prev();
            var pages = $('.page');
            pages.removeClass('page-active');
            prev.addClass('page-active');
        })
        pageClick(page);
    }
}
/**
 * Xử lý logic khi nút first click
 * Author Tạ Long Khánh (24/12/2020)
 * */
function firstPageClick() {
    pageClick(1);
    var pages = $('.page');
    pages.removeClass('page-active');
    $('.page').first().addClass('page-active')

}