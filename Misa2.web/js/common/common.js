/**
 * format date in form dd/mm/yyyy
 * Author: Manh Tien(14/12/2020)**/
function formatDate(date) {
    var date = new Date(date);
    var year = ("0000" + date.getFullYear()).slice(-4);
    var day = ("0" + date.getDate()).slice(-2);
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    return day + '/' + month + '/' + year;
}

/**
 * format date in form: yyyy-mm-dd
 * @param {any} date
 */
function formatDate2(date) {
    var date = new Date(date);
    var day = ("0" + date.getDate()).slice(-2);
    var month = ("0" + (date.getMonth() + 1)).slice(-2);
    var year = ("0000" + date.getFullYear()).slice(-4);
    return year + '-' + month + '-' + day;
}
/**
 * format monen
 * CreatedBy: Manh Tien(28/12/2020)
 * @param {any} money
 */
function formatMoney(money) {
    if(money){
        var num = parseFloat(money);
        return new Intl.NumberFormat().format(num);
    }
    return "";
}

/**
 * format giới tính
 * CreatedBy: Manh Tien(28/12/2020)
 * @param {any} gender
 */
function formatGender(gender) {
    switch (gender) {
        case 0:
            return "Nữ";
        case 1:
            return "Nam";
        case 2:
            return "Khác";
    }
}

/**
 * format trạng thái công việc
 * @param {any} state
 */
function formatState(state) {
    switch (state) {
        case 0:
            return "Làm việc";
        case 1:
            return "Nghỉ việc";
        case 2:
            return "Thử việc";
        case 3:
            return "Nghỉ hưu";
    }
}

/**
 * tải dữ liệu có phân trang
 * createdBy: Mạnh Tiến(30/12/2020)
 * @param {any} url
 * @param {any} page
 * @param {any} limmit
 */
function loadDataPaging(url, page, limmit) {
    try {
        var column = $('table thead th');
        var fileName = [];
        var dataUrl = url + '/' + page + '/' + limmit;
        $.ajax({
            url: dataUrl,
            method: 'GET',
        }).done(function (response) {
            $('table tbody').empty();
            $.each(response, function (index, obj) {
                var tr = $(`<tr></tr>`);
                $.each(column, function (index, th) {
                    var td = $(`<td><div><span></span></div></td>`);
                    var fieldName = $(th).attr('fieldName');
                    var value = obj[fieldName];
                    var format = $(th).attr('formatType');
                    switch (format) {
                        case "gender":
                            value = formatGender(value);
                            break;
                        case "ddmmyyyy":
                            td.addClass("text-align-center");
                            value = formatDate(value);
                            break;
                        case "money":
                            td.addClass("text-align-right");
                            value = formatMoney(value);
                            break;
                        case "state":
                            value = formatState(value);
                            break;
                        default:
                            break;
                    }
                    td.append(value);
                    $(tr).append(td);
                })
                $('table tbody').append(tr);
            });
        }).fail(function (response) {
            console.log(response);
        });
    } catch (e) {
        console.log(e);
    }
}

function pageIndex() {
    var totalPageRounded = this.totalRow / this.limmit
    this.totalPage = Math.ceil(totalPageRounded);
    var total = this.totalRow;
    var offSet = this.page * this.limmit;
    var res = total - offSet;
    if (res < this.limmit) {
        offSet = total;
    }
    $('#total').text(total);
    $('#offSet').text(offSet);
}

function loadPageIndex() {
    $.ajax({
        url: this.getDataUrl + '/' + 'numberEntity',
        method: 'GET',
    }).done((res) => {
        this.totalRow = res;
        var totalPageRounded = this.totalRow / this.limmit
        this.totalPage = Math.ceil(totalPageRounded);
        var total = this.totalRow;
        var offSet = this.page * this.limmit;
        $('#total').text(total);
        $('#offSet').text(offSet);
    }).fail(function (res) {
        console.log(res);
    })
}
/**
 * set empty file after save employee or update*/
function setEmptyText() {
    $('#txtEmployeeCode').val("");
    $('#txtFullName').val("");
    $('#txtDOB').val("");
    $('#txtIdCardNumber').val("");
    $('#txtIssueDate').val("");
    $('#txtIssuePlace').val("");
    $('#txteEmail').val("");
    $('#txtPhonenumber').val("");
    $('#txtEmployeeTaxCode').val("");
    $('#txtSalary').val("");
    $('#txtDOJ').val("");
}

/**
 * vaidate email
 * @param {any} email
 */
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

/**
 * validate required field
 * @param {any} employeeCode
 * @param {any} employeeName
 * @param {any} employeeIDCard
 * @param {any} email
 * @param {any} phoneNumber
 */
function validate(employeeCode, employeeName, employeeIDCard, email, phoneNumber) {
    if (!employeeCode) {
        alert("Không được trống mã nhân viên");
        return false;
    }
    if (!employeeName) {
        alert("Không được trống tên nhân viên");
        return false;
    }
    if (!employeeIDCard) {
        alert("Không được trống số CMTND/thẻ căn cước nhân viên");
        return false;
    }
    if (!email) {
        alert("Không được trống email");
        return false;
    } else {
        if (!isEmail(email)) {
            alert("Không đúng định dạng email.");
            return false;
        }
    }
    if (!phoneNumber) {
        alert("Không được trống số điện thoại");
        return false;
    }
    return true;
}

function resetPageIndexColor() {
    $('#page-number-1').css("background-color", "#f4f4f4");
    $('#page-number-2').css("background-color", "#f4f4f4");
    $('#page-number-3').css("background-color", "#f4f4f4");
    $('#page-number-4').css("background-color", "#f4f4f4");
}