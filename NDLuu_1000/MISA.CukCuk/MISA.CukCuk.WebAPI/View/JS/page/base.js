var status = "";
class BaseJS {
    constructor() {
        this.getDataUrl = null;
        this.setDataUrl();
        this.loadData();
        this.loadDepartment();
        this.loadPosition();
        this.loadWorkStatus();
        this.initEvens();
        // this.delete();
    }

    setDataUrl() {

    }
    
    // delete(){
    //     $('table tbody').on('click', 'tr', function () {
    //         deleteDialog.dialog('open');
    //     })
    // }

    initEvens() {
        // Gán các sự kiện:
        var me = this;

        //mở dialog
        $('#btnAdd').click(function () {
            status = "add";
            dialog.dialog('open');
            
        })
        //mở dialog delete
        
        //đóng dialog
        $('#btnCancel').click(function () {
            dialog.dialog('close');
            // $('input').val("");
            // $('#txtEmployeeCode').val(" ");
            // $('#txtFullName').val("");
            // $("#dtDateOfBirth").val("");
            // $('#cbGender').val("");
            // $('#txtIdentityNumber').val("");
            // $('#dtIdentityDate').val("");
            // $('#txtIdentityPlace').val("");
            // $('#txtEmail').val("");
            // $('#txtPhoneNumber').val("");
            // $('#cbPosition').val("");
            // $('#cbDepartment').val("");
            // $('#txtTaxCode').val("");
            // $('#txtSalary').val("");
        })

        /**
         * Lưu dữ liệu
         */
        $('#btnSave').click(function () {
            
            var inputValidates = $('input[required], input[type="email"]');
            $.each(inputValidates, function (index, element) {
                $(element).trigger('blur');
            })
            var inputNotValids = $('input[validate="false"]');
            if (inputNotValids && inputNotValids.length > 0) {
                alert("Vui lòng kiểm tra lại dữ liệu");
                inputNotValids[0].focus();
                return;
            }
            if (status == "add") {
                var employee = {
                    employeeCode: $('#txtEmployeeCode').val(),
                    fullName: $('#txtFullName').val(),
                    dateOfBirth: $('#dtDateOfBirth').val() || new Date(),
                    gender: $('#cbGender').val(),
                    identityNumber: $('#txtIdentityNumber').val(),
                    identityDate: $('#dtIdentityDate').val() || new Date(),
                    identityPlace: $('#txtIdentityPlace').val() || "",
                    email: $('#txtEmail').val(),
                    phoneNumber: $('#txtPhoneNumber').val(),
                    positionID: $('#cbPosition').val(),
                    departmentID: $('#cbDepartment').val(),
                    taxCode: $('#txtTaxCode').val() || "",
                    salary: $('#txtSalary').val() || 0,
                    joinDate: $('#txtJoinDate').val() || new Date(),
                    workStatusID: $('#cbWorkStatus').val(),
                }

                $.ajax({
                    url: "http://localhost:60381/api/Employees",
                    method: 'POST',
                    data: JSON.stringify(employee),
                    contentType: 'application/json'
                }).done(function (res) {
                    debugger;
                    alert('Thêm thành công');
                    dialog.dialog('close');
                    me.loadData();
                }).fail(function (res) {
                })
            }

        }.bind(this))

        /**
         * Update Dữ Liệu
         */
        $('#btnSave').click(function () {
            if (status == "update") {
                var rowSelected = $("tr.row-selected");
                var employeeID = rowSelected.data('id');
                var UrlUpdate = "http://localhost:60381/api/Employees/" + employeeID;
                var employee = {
                    employeeCode: $('#txtEmployeeCode').val(),
                    fullName: $('#txtFullName').val(),
                    dateOfBirth: $('#dtDateOfBirth').val(),
                    gender: $('#cbGender').val(),
                    identityNumber: $('#txtIdentityNumber').val(),
                    identityDate: $('#dtIdentityDate').val(),
                    identityPlace: $('#txtIdentityPlace').val(),
                    email: $('#txtEmail').val(),
                    phoneNumber: $('#txtPhoneNumber').val(),
                    positionID: $('#cbPosition').val(),
                    departmentID: $('#cbDepartment').val(),
                    taxCode: $('#txtTaxCode').val(),
                    salary: $('#txtSalary').val(),
                    joinDate: $('#txtJoinDate').val(),
                    workStatusID: $('#cbWorkStatus').val(),
                }

                $.ajax({
                    url: UrlUpdate,
                    method: 'PUT',
                    data: JSON.stringify(employee),
                    contentType: 'application/json'
                }).done(function (res) {
                    alert('Cập nhật thành công');
                    dialog.dialog('close');
                    me.loadData();
                }).fail(function (res) {
                    alert('Cập nhật Thất Bại');
                })
            }

        }.bind(this))
        /**
         * Load lại dữ liệu
         */
        $('#btnRefresh').click(function () {
            this.loadData();
        }.bind(this))

        /**
         * Sự kiện nhấn double click vào 1 bản ghi
         */
        $('table tbody').on('dblclick', 'tr', function () {
            status = "update";
            dialog.dialog('open');
            $(this).addClass("row-selected");
            $(this).siblings().removeClass("row-selected");
            var rowSelected = $("tr.row-selected");
            var employeeID = rowSelected.data('id');
            console.log(employeeID);
            var urlEmployee = "http://localhost:60381/api/Employees/" + employeeID;
            console.log(urlEmployee);
            $.ajax({
                url: urlEmployee,
                method: 'GET',
            }).done(function (response) {
                //lấy dữ liệu và hiển thị lên form
                $('#txtEmployeeCode').val(response["employeeCode"]);
                $('#txtFullName').val(response["fullName"]);
                //ngày sinh
                var dateOfBirth = formatDateInput(response["dateOfBirth"]);
                $("#dtDateOfBirth").val(dateOfBirth);

                $('#cbGender').val(response["gender"]);
                $('#txtIdentityNumber').val(response["identityNumber"]);
                //ngày cấp
                var identityDate = formatDateInput(response["identityDate"]);
                $('#dtIdentityDate').val(identityDate);

                $('#txtIdentityPlace').val(response["identityPlace"]);
                $('#txtEmail').val(response["email"]);
                $('#txtPhoneNumber').val(response["phoneNumber"]);
                $('#cbPosition').val(response["positionID"]);
                $('#cbDepartment').val(response["departmentID"]);
                $('#txtTaxCode').val(response["taxCode"]);
                $('#txtSalary').val(response["salary"]);
                //ngày gia nhập công ty
                var joinDate = formatDateInput(response["joinDate"]);
                $('#txtJoinDate').val(joinDate);
                $('#cbWorkStatus').val(response["workStatusID"]);
            }).fail(function (response) {

            });
        })

        /**
         * Validate dữ liệu
         */
        $('.input-required').blur(function () {
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
            }
            else {
                $(this).removeClass('border-red');
            }
        })
        $('input[type="email"]').blur(function () {
            var value = $(this).val();
            var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
            if (!testEmail.test(value)) {
                $(this).addClass('border-red');
            }
            else {
                $(this).removeClass('border-red');
            }
        })


    }

    /**
     * Thực hiện load dữ liệu
     * 
     * Author: NDL 
     */
    loadData() {
        //alert("Đã load lại trang");
        try {
            var columns = $('table thead th');
            var getDataUrl = this.getDataUrl;
            $.ajax({
                url: getDataUrl,
                method: 'GET',
            }).done(function (response) {
                console.log(response[0]);
                $('table tbody').empty();
                $.each(response, function (index, obj) {

                    var tr = $(`<tr></tr>`);

                    $.each(columns, function (index, th) {
                        var td = $(`<td></td>`);
                        var fieldName = $(th).attr('fieldname');
                        var formatType = $(th).attr('formatType');
                        var value = obj[fieldName];
                        switch (formatType) {
                            case "ddmmyyyy":
                                value = formatDate(value);
                                break;
                            case "MoneyVND":
                                td.addClass("text-align-right");
                                value = formatMoney(value);
                                break;
                            case "Gender":
                                value = setGender(value);
                            default:
                                break;
                        }


                        td.append(value);
                        $(tr).append(td);
                    })
                    tr.data("id", obj['employeeID']);
                    $("table tbody").append(tr);
                })

            }).fail(function (response) {

            });
        } catch (error) {

        }

    }

    /**
     * Load danh sách phòng ban
     */
    loadDepartment() {
        try {
            $.ajax({
                url: "http://localhost:60381/api/Departments",
                method: 'GET',
            }).done(function (response) {
                $('#cbDepartment').empty();
                $.each(response, function (index, element) {
                    var select = $('#cbDepartment');
                    var departmentID = element['departmentID'];
                    var opp = $(`<option value="${departmentID}"></option>`);
                    // var fieldValue = $(element).attr('fieldValue');
                    // console.log(fieldValue);
                    // var value = element[fieldValue];
                    //console.log(element['departmentName'])
                    opp.append(element['departmentName']);
                    $(select).append(opp);
                })

            }).fail(function (response) {

            });
        } catch (error) {

        }
    }

    /**
     * Load chức vụ của nhân viên
     */
    loadPosition() {
        try {
            $.ajax({
                url: "http://localhost:60381/api/Positions",
                method: 'GET',
            }).done(function (response) {
                console.log(response);
                $('#cbPosition').empty();
                $.each(response, function (index, element) {
                    var select = $('#cbPosition');
                    var positionID = element['positionID'];
                    var opp = $(`<option value="${positionID}"></option>`);
                    opp.append(element['positionName']);
                    $(select).append(opp);
                })
            }).fail(function (response) {

            });
        } catch (error) {

        }
    }

    /**
     * Load trạng thái công việc hiện tại
     */
    loadWorkStatus() {
        try {
            $.ajax({
                url: "http://localhost:60381/api/WorkStatus",
                method: 'GET',
            }).done(function (response) {
                console.log(response);
                $('#cbWorkStatus').empty();
                $.each(response, function (index, element) {
                    var select = $('#cbWorkStatus');
                    var WorkStatusID = element['workStatusID'];
                    var opp = $(`<option value="${WorkStatusID}"></option>`);
                    opp.append(element['workStatusName']);
                    $(select).append(opp);
                })
            }).fail(function (response) {

            });
        } catch (error) {

        }
    }
}

/**
 * Format Date
 * @param {} date 
 */
function formatDate(date) {
    var d = new Date(date);
    var day = d.getDate();
    var month = d.getMonth() + 1;
    var year = d.getFullYear();

    return month + "/" + day + "/" + year;
}

/**
 * Định dạng tiền tệ
 * @param {*} money 
 */
function formatMoney(money) {
    if (money) {
        return (money.toFixed(0).replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.") + "VND");
    }

    return "";
}

//load department name
function setGender(gender) {
    if (gender == 0) {
        return "Nữ";
    } else
        if (gender == 1) {
            return "Nam";
        }
    return "Khác";
}

//set date in input date
function formatDateInput(date) {
    var d = new Date(date);
    var day = d.getDate();
    if (day < 10) {
        day = "0" + day;
    }
    var month = d.getMonth() + 1;
    if (month < 10) {
        month = "0" + month;
    }
    var year = d.getFullYear();

    return year + "-" + month + "-" + day;
}
