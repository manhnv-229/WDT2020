$(document).ready(function () {
    dialog = $('.dialog').dialog({
        autoOpen: false,
        model: true,
    });

    new EmployeeJS();
});

class EmployeeJS extends BaseJS{
    constructor() {
        super();
        this.loadDepart();
        this.loadPosition();
        this.loadDepartDialog();
        this.loadPositionDialog();
        this.filerEmployee();
        this.searchEmployee();
        this.saveEmployee();
        this.delete_updateEmployee();
    }
    setDataUrl() {
        this.getDataUrl = 'http://localhost:51075/api/v1/Employee';
    }

    // get all departmentName and departmentid
    loadDepart() {
        $.ajax({
            url: 'http://localhost:51075/api/v1/EmployeeDepartment',
            method: 'GET',
        }).done(function (res) {
            $.each(res, function (index, obj) {
                var deparName = obj['EmployeeDepartmentName'];
                var deparId = obj['EmployeeDepartmentId'];
                var opt = new Option(deparName, deparId);
                $('#all-department').append($(opt));
            })
        }).fail(function (res) {
            console.log(res);
        })
    }
    loadDepartDialog() {
        $.ajax({
            url: 'http://localhost:51075/api/v1/EmployeeDepartment',
            method: 'GET',
        }).done(function (res) {
            $.each(res, function (index, obj) {
                var deparName = obj['EmployeeDepartmentName'];
                var deparId = obj['EmployeeDepartmentId'];
                var opt = new Option(deparName, deparId);
                $('#all-department-dialog').append($(opt));
            })
        }).fail(function (res) {
            console.log(res);
        })
    }

    //  get all positionName and positionid
    loadPosition() {
        $.ajax({
            url: 'http://localhost:51075/api/v1/EmployeePosition',
            method: 'GET',
        }).done(function (res) {
            $.each(res, function (index, obj) {
                var positionName = obj['EmployeePositionName'];
                var positionId = obj['EmployeePositionId'];
                var opt = new Option(positionName, positionId);
                $('#all-position').append($(opt));
            });
        }).fail(function (res) {
            console.log(res);
        })
    };
    loadPositionDialog() {
        $.ajax({
            url: 'http://localhost:51075/api/v1/EmployeePosition',
            method: 'GET',
        }).done(function (res) {
            $.each(res, function (index, obj) {
                var positionName = obj['EmployeePositionName'];
                var positionId = obj['EmployeePositionId'];
                var opt = new Option(positionName, positionId);
                $('#all-position-dialog').append($(opt));
            });
        }).fail(function (res) {
            console.log(res);
        })
    }

    //filter emplopyee by position and department
    filerEmployee() {
        $('#all-department').click(() => {
            //var that = this;
            var deparId = $('#all-department').find(":selected").val();
            var posiId = $('#all-position').find(":selected").val();
            if ((deparId == "") && (posiId == "")) {
                this.getDataUrl = 'http://localhost:51075/api/v1/Employee';
                var urlForCount = 'http://localhost:51075/api/v1/Employee/numberEntity';
                $.ajax({
                    url: urlForCount,
                    method: 'GET',
                }).done((res) => {
                    this.page = 1;
                    this.totalRow = res;
                    var totalPageRounded = this.totalRow / this.limmit
                    this.totalPage = Math.ceil(totalPageRounded);
                    var total = this.totalRow;
                    var offSet = this.page * this.limmit;
                    var lowOffSet = (this.page - 1) * this.limmit;
                    $('#lowOffSet').text(lowOffSet);
                    $('#total').text(total);
                    $('#offSet').text(offSet);
                }).fail(function (res) {
                    console.log(res);
                })
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            }
            else if ((deparId != "") && (posiId == "")) {
                this.getDataUrl = 'http://localhost:51075/api/v1/Employee/department' + '/' + deparId;
                var urlForCount = 'http://localhost:51075/api/v1/Employee/countEmployeeByDeparId/' + deparId;
                $.ajax({
                    url: urlForCount,
                    method: 'GET',
                }).done((res) => {
                    this.page = 1;
                    this.totalRow = res;
                    var totalPageRounded = this.totalRow / this.limmit
                    this.totalPage = Math.ceil(totalPageRounded);
                    var total = this.totalRow;
                    var offSet = this.page * this.limmit;
                    var lowOffSet = (this.page - 1) * this.limmit;
                    $('#lowOffSet').text(lowOffSet);
                    $('#total').text(total);
                    $('#offSet').text(offSet);
                }).fail(function (res) {
                    console.log(res);
                })
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            }
            else if ((deparId == "") && (posiId != "")) {
                this.getDataUrl = 'http://localhost:51075/api/v1/Employee/position' + '/' + posiId;
                var urlForCount = 'http://localhost:51075/api/v1/Employee/countEmployeeByPosiId/' + posiId;
                $.ajax({
                    url: urlForCount,
                    method: 'GET',
                }).done((res) => {
                    this.page = 1;
                    this.totalRow = res;
                    var totalPageRounded = this.totalRow / this.limmit
                    this.totalPage = Math.ceil(totalPageRounded);
                    var total = this.totalRow;
                    var offSet = this.page * this.limmit;
                    var lowOffSet = (this.page - 1) * this.limmit;
                    $('#lowOffSet').text(lowOffSet);
                    $('#total').text(total);
                    $('#offSet').text(offSet);
                }).fail(function (res) {
                    console.log(res);
                })
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            }
            else {
                this.getDataUrl= 'http://localhost:51075/api/v1/Employee' + '/' + posiId + '/' + deparId;
                var urlForCount = 'http://localhost:51075/api/v1/Employee/countEmployeeByPosiIdAndDeparId'
                                    + '/'+ posiId + '/' + deparId;
                $.ajax({
                    url: urlForCount,
                    method: 'GET',
                }).done((res) => {
                    this.page = 1;
                    this.totalRow = res;
                    var totalPageRounded = this.totalRow / this.limmit
                    this.totalPage = Math.ceil(totalPageRounded);
                    var total = this.totalRow;
                    var offSet = this.page * this.limmit;
                    var lowOffSet = (this.page - 1) * this.limmit;
                    $('#lowOffSet').text(lowOffSet);
                    $('#total').text(total);
                    $('#offSet').text(offSet);
                }).fail(function (res) {
                    console.log(res);
                })
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            }
        })

        $('#all-position').click(() => {
            var deparId = $('#all-department').find(":selected").val();
            var posiId = $('#all-position').find(":selected").val();
            if ((deparId == "") && (posiId == "")) {
                var urlForCount = 'http://localhost:51075/api/v1/Employee/numberEntity';
                this.getDataUrl= 'http://localhost:51075/api/v1/Employee';
                $.ajax({
                    url: urlForCount,
                    method: 'GET',
                }).done((res) => {
                    this.page = 1;
                    this.totalRow = res;
                    var totalPageRounded = this.totalRow / this.limmit
                    this.totalPage = Math.ceil(totalPageRounded);
                    var total = this.totalRow;
                    var offSet = this.page * this.limmit;
                    var lowOffSet = (this.page - 1) * this.limmit;
                    $('#lowOffSet').text(lowOffSet);
                    $('#total').text(total);
                    $('#offSet').text(offSet);
                }).fail(function (res) {
                    console.log(res);
                })
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            }
            else if ((deparId != "") && (posiId == "")) {
                this.getDataUrl = 'http://localhost:51075/api/v1/Employee/department' + '/' + deparId;
                var urlForCount = 'http://localhost:51075/api/v1/Employee/countEmployeeByDeparId/' + deparId;
                $.ajax({
                    url: urlForCount,
                    method: 'GET',
                }).done((res) => {
                    this.page = 1;
                    this.totalRow = res;
                    var totalPageRounded = this.totalRow / this.limmit
                    this.totalPage = Math.ceil(totalPageRounded);
                    var total = this.totalRow;
                    var offSet = this.page * this.limmit;
                    var lowOffSet = (this.page - 1) * this.limmit;
                    $('#lowOffSet').text(lowOffSet);
                    $('#total').text(total);
                    $('#offSet').text(offSet);
                }).fail(function (res) {
                    console.log(res);
                })
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            }
            else if ((deparId == "") && (posiId != "")) {
                this.getDataUrl = 'http://localhost:51075/api/v1/Employee/position' + '/' + posiId;
                var urlForCount = 'http://localhost:51075/api/v1/Employee/countEmployeeByPosiId/' + posiId;
                $.ajax({
                    url: urlForCount,
                    method: 'GET',
                }).done((res) => {
                    this.page = 1;
                    this.totalRow = res;
                    var totalPageRounded = this.totalRow / this.limmit
                    this.totalPage = Math.ceil(totalPageRounded);
                    var total = this.totalRow;
                    var offSet = this.page * this.limmit;
                    var lowOffSet = (this.page - 1) * this.limmit;
                    $('#lowOffSet').text(lowOffSet);
                    $('#total').text(total);
                    $('#offSet').text(offSet);
                }).fail(function (res) {
                    console.log(res);
                })
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            }
            else {
                this.getDataUrl = 'http://localhost:51075/api/v1/Employee' + '/' + posiId + '/' + deparId;
                var urlForCount = 'http://localhost:51075/api/v1/Employee/countEmployeeByPosiIdAndDeparId'
                    + '/' + posiId + '/' + deparId;
                $.ajax({
                    url: urlForCount,
                    method: 'GET',
                }).done((res) => {
                    this.page = 1;
                    this.totalRow = res;
                    var totalPageRounded = this.totalRow / this.limmit
                    this.totalPage = Math.ceil(totalPageRounded);
                    var total = this.totalRow;
                    var offSet = this.page * this.limmit;
                    var lowOffSet = (this.page - 1) * this.limmit;
                    $('#lowOffSet').text(lowOffSet);
                    $('#total').text(total);
                    $('#offSet').text(offSet);
                }).fail(function (res) {
                    console.log(res);
                })
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            }
        })
    }

    // search employee by keyWord
    searchEmployee() {
        $('#searching').keypress((e) => {
            var keyEnter = e.which;
            if (keyEnter == 13) {
                var keyWord = $('#searching').val();
                if (keyWord != "") {
                    this.getDataUrl = 'http://localhost:51075/api/v1/Employee/filter' + '/' + keyWord;
                    this.page = 1;
                    this.limmit = 5;
                    $.ajax({
                        url: 'http://localhost:51075/api/v1/Employee/numberEmployeeSearchByName/' + keyWord,
                        method: 'GET',
                    }).done((res) => {
                        this.page = 1;
                        this.totalRow = res;
                        var totalPageRounded = this.totalRow / this.limmit
                        this.totalPage = Math.ceil(totalPageRounded);
                        var total = this.totalRow;
                        var offSet = this.page * this.limmit;
                        var lowOffSet = (this.page - 1) * this.limmit;
                        $('#lowOffSet').text(lowOffSet);
                        $('#total').text(total);
                        $('#offSet').text(offSet);
                    })
                    loadDataPaging(this.getDataUrl, this.page, this.limmit);
                }
                else {
                    alert("Ô tìm kiếm không được để trống !");
                }
            }
        });
    }
    saveEmployee() {
        $('#saveEmployee').click(function () {
            var employeeId = $('#txtId').val();
            var employeeCode = $('#txtEmployeeCode').val();
            var employeeName = $('#txtFullName').val();
            var dateOfBirth = $('#txtDOB').val();
            if (dateOfBirth == "") {
                dateOfBirth = null;
            }
            var gender = $('#gender').find(':selected').val();
            var employeeIDCard = $('#txtIdCardNumber').val();
            var dateOfIssueIDCard = $('#txtIssueDate').val();
            if (dateOfIssueIDCard == "") {
                dateOfIssueIDCard = null;
            }
            var issueBy = $('#txtIssuePlace').val();
            var email = $('#txteEmail').val();
            var phoneNumber = $('#txtPhonenumber').val();
            var employeePositionId = $('#all-position-dialog').find(':selected').val();
            var employeeDepartmentId = $('#all-department-dialog').find(':selected').val();
            var employeeSalary = $('#txtSalary').val();
            var employeeTaxCode = $('#txtEmployeeTaxCode').val();
            var dateOfJoiningCompany = $('#txtDOJ').val();
            if (dateOfJoiningCompany == "") {
                dateOfJoiningCompany = null;
            }
            var employeeSate = $('#stateWoring').find(':selected').val();
            if (!validate(employeeCode, employeeName, employeeIDCard, email, phoneNumber)) {
                return;
            }
            var employee = {
                "employeeCode": employeeCode,
                "employeeName": employeeName,
                "dateOfBirth": dateOfBirth,
                "gender": gender,
                "employeeIDCard": employeeIDCard,
                "dateOfIssueIDCard": dateOfIssueIDCard,
                "issueBy": issueBy,
                "email": email,
                "phoneNumber": phoneNumber,
                "employeePositionId": employeePositionId,
                "employeeDepartmentId": employeeDepartmentId,
                "employeeSalary": employeeSalary,
                "employeeTaxCode": employeeTaxCode,
                "dateOfJoiningCompany": dateOfJoiningCompany,
                "employeeSate": employeeSate
            }
            if (employeeId == "") {
                $.ajax({
                    url: 'http://localhost:51075/api/v1/Employee',
                    method: 'POST',
                    data: JSON.stringify(employee),
                    contentType: "application/json"
                }).done(function (res) {
                    if (res.MisaCode == 200) {
                        setEmptyText();
                        dialog.dialog('close');
                        $('#notice').show();
                        $('#txtHeadNotice').text(res.Messenger);
                        $('#txtBodyNotice').text("Đã thêm thành công nhân viên với mã: " + employeeCode);
                     }
                    else {
                        dialog.dialog('close');
                        $('#notice').show();
                        $('#txtHeadNotice').text("Cảnh báo");
                        $('#txtBodyNotice').text(res.Messenger);
                        
                    }
                }).fail(function (res) {
                    console.log(res);
                })
            }else {
                $.ajax({
                    url: 'http://localhost:51075/api/v1/Employee/' + employeeId,
                    method: 'PUT',
                    data: JSON.stringify(employee),
                    contentType: "application/json"
                }).done(function (res) {
                    if (res.MisaCode == 200) {
                        setEmptyText();
                        dialog.dialog('close');
                        $('#notice').show();
                        $('#txtHeadNotice').text(res.Messenger);
                        $('#txtBodyNotice').text("Đã cập nhật thành công nhân viên với mã: " + employeeCode);
                    }
                    else {
                        dialog.dialog('close');
                        $('#notice').show();
                        $('#txtHeadNotice').text("Cảnh báo");
                        $('#txtBodyNotice').text(res.Messenger);
                    }
                }).fail(function (res) {
                    console.log(res);
                })
            }

        })

    }
    //click - show update dialog, dblclick - show delete dialog
    delete_updateEmployee() {
        var timer = 0;
        var delay = 200;
        var prevent = false;

        $('#tbListData').on('click', 'tr', function () {
            timer = setTimeout( () => {
                if (!prevent) {
                    var currentRow = $(this).closest('tr');
                    var employeeCode = currentRow.find("td:eq(0)").text();
                    $.ajax({
                        url: 'http://localhost:51075/api/v1/Employee' + '/employeeCode/' + employeeCode,
                        method: 'GET',
                        async: true
                    }).done(function (res) {
                        dialog.dialog("open");
                        //binding data
                        var employeeId = res.EmployeeId;
                        $('#txtId').val(res.EmployeeId);
                        $('#txtEmployeeCode').val(res.EmployeeCode);
                        $('#txtFullName').val(res.EmployeeName);
                        if (res.DateOfBirth == null) {
                            res.DateOfBirth = "";
                        }
                        else {
                            res.DateOfBirth = formatDate2(res.DateOfBirth);
                        }
                        $('#txtDOB').val(res.DateOfBirth);
                        $('#gender').val(res.Gender);
                        $('#txtIdCardNumber').val(res.EmployeeIDCard);
                        if (res.DateOfIssueIDCard == null) {
                            res.DateOfIssueIDCard = "";
                        } else {
                            res.DateOfIssueIDCard = formatDate2(res.DateOfIssueIDCard);
                        }
                        $('#txtIssueDate').val(res.DateOfIssueIDCard);
                        $('#txtIssuePlace').val(res.IssueBy);
                        $('#txteEmail').val(res.Email);
                        $('#txtPhonenumber').val(res.PhoneNumber);
                        $('#all-position-dialog').val(res.EmployeePositionId);
                        $('#all-department-dialog').val(res.EmployeeDepartmentId);
                        $('#txtEmployeeTaxCode').val(res.EmployeeTaxCode);
                        $('#txtSalary').val(res.EmployeeSalary);
                        if (res.DateOfJoiningCompany == null) {
                            res.DateOfJoiningCompany = "";
                        } else {
                            res.DateOfJoiningCompany = formatDate2(res.DateOfJoiningCompany);
                        }
                        $('#txtDOJ').val(res.DateOfJoiningCompany);
                        $('#stateWoring').val(res.EmployeeSate);
                    }).fail(function (res) {
                        console.log(res);
                    })
                }
                prevent = false;
            }, delay);
            }).on('dblclick', 'tr', function () {
                clearTimeout(timer);
                prevent = true;

                var currentRow = $(this).closest('tr');
                var employeeCode = currentRow.find("td:eq(0)").text();
                $('#pup-up').show();
                $('#txtContnetHead').text("Cảnh báo xóa !");
                $('#txtContentBody').text("Bạn có muốn xóa nhân viên với mã: " + employeeCode);
                $('#deleteEmployee').click(function () {
                    $.ajax({
                        url: 'http://localhost:51075/api/v1/Employee' + '/employeeCode/' + employeeCode,
                        method: 'DELETE',
                    }).done(function (res) {
                        $('#pup-up').hide();
                        alert(res.Messenger);
                    }).fail(function (res) {
                        $('#pup-up').show();
                        $('#txtContnetHead').text("Cảnh báo xóa !");
                        $('#txtContentBody').text("Không được xóa nhân viên với mã: " + employeeCode);
                    })
                });
            })
            
    }

   
}