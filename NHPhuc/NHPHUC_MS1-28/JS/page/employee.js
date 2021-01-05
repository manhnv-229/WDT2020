$(document).ready(function () {
   
    dialog = $( ".dialog" ).dialog({
        autoOpen: false,
        width: 580,
        height: 600,
        modal: true,
    });
    loadData();
    $('#btnAdd').click(btnAddOnClick);
    $('#btn-cancel').click(btncancelOnClick);
    $('#table_data').on('dblclick','tr',trOnClick);
    $('#btn-save').on('click',btnSaveOnClick);
});
function btnAddOnClick() {
    dialog.dialog('open');
}
function btncancelOnClick(){
    dialog.dialog('close');
}
function trOnClick(){
    dialog.dialog('open');
}
function btnSaveOnClick(){
    var employeeCode = $('#txtCode').val();
    var employeeName = $('#txtName').val();
    var employeeDoB = $('#txtDoB').val();
    var employeeGender = $('#txtGender').val();
    var employeeCMND = $('#txtCMND').val();
    var employeeDateRange = $('#txtDateRange').val();
    var employeeEmail = $('#txtEmail').val();
    var employeePhoneNumber = $('#txtPhoneNumber').val();
    var employeePosition = $('#txtPosition').val();
    var employeeDepartment = $('#txtDepartment').val();
    var employeeTaxCode = $('#txtTaxCode').val();
    var employeeSalary = $('#txtSalary').val();
    var employeeDateJoin = $('#txtDateJoin').val();
    var employeeJobStatus = $('#txtJobStatus').val();
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if(!employeeCode){
        alert('Vui lòng không để trống mã khách hàng');
        return;
    }
    if(!employeeName){
        alert('Vui lòng không để trống họ và tên');
        return;
    }
    if(!employeeCMND){
        alert('Vui lòng nhập CMND/CCCD');
        return;
    }
    if(!employeeEmail){
        alert('Vui lòng nhập Email');
        return;
    }
    else if(filter.test(employeeEmail)==false){
        alert('Email không phù hợp');
        return;
    }
    if(!employeePhoneNumber){
        alert('Vui lòng nhập số điện thoại');
        return;
    }
    
    var employee = {
    "EmployeeCode": employeeCode,
    "EmployeeName": employeeName,
    "DateofBirth": employeeDoB,
    "Gender": employeeGender,
    "CitizenIdentification": employeeCMND,
    "DateRange": employeeDateRange,
    "Email": employeeEmail,
    "PhoneNumber": employeePhoneNumber,
    "PersonnalTax": employeeTaxCode,
    "BasicSalary": employeeSalary,
    "JoiningDate": employeeDateJoin,
    "Department": employeeDepartment,
    "Status": employeeJobStatus,
    "JobPosition": employeePosition}
    
    $.ajax({
        url: 'http://localhost:60766/api/v2/Employees',
        method: 'POST',
        data: JSON.stringify(employee),
        dataType: 'json',
        contentType: 'application/json'
    }).done(function(res){
        alert('Them thanh cong!')
    }).fail(function(res){
        alert('Them khong thanh cong!')
    })
    dialog.dialog('close');
};
//Thuc hien load du lieu
function loadData() {
    $.ajax({
        url: 'http://localhost:60766/api/v2/Employees',
        method: 'GET',
        data: null,
        dataType: 'json',
        contentType: 'application/json'
    }).done(function (response) {
        $('#table_data tbody').empty();
        for (var i = 0; i < 10; i++) {
            var iteam = response[i];
            var employeeCode = iteam['EmployeeCode'];
            var fullName = iteam['EmployeeName'];
            var gender = iteam['Gender'];
            var dob = iteam['DateofBirth'];
            var citizenIdentification = iteam['CitizenIdentification'];
            var dateRange = iteam['DateRange'];
            var email = iteam['Email'];
            var phoneNumber = iteam['PhoneNumber'];
            var personnalTax = iteam['PersonnalTax'];
            var basicSalary = iteam['BasicSalary'];
            var joiningDate = iteam['JoiningDate'];
            var jobStatusID = iteam['Status'];
            var departmentID = iteam['Department'];
            var jobPositionID = iteam['JobPosition'];
            var dateString = formatDate(dob);
            var dateString1 = formatDate(dateRange);
            var dateString2 = formatDate(joiningDate);
            
            var trHTML = `<tr>
                            <td>${employeeCode}</td>
                            <td>${fullName}</td>
                            <td>${gender}</td>
                            <td>${dateString}</td>
                            <td>${phoneNumber}</td>
                            <td>${email}</td>
                            <td>${jobPositionID}</td>
                            <td>${departmentID}</td>
                            <td>${basicSalary}</td>
                            <td>${jobStatusID}</td>
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
function getData(){
    var a = document.querySelector('#all').value;
    var b = document.querySelector('#dp-ps').value;
    console.log(a);
}
getData();