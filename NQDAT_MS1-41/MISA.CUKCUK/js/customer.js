$(document).ready(function () {
    loadData();
})

function loadData() {
    //1. Gọi service lấy dữ liệu: (api.manhnv.net/apt/customers)
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET'
    }).done(function (res) {
        var data = res;
        console.log(data);
        //2. Xử lí dữ liệu
        for (i = 0; i < data.length; i++) {
            var DateOfBirth = dateFormat(data[i].DateOfBirth);
            var Gender = "Nam";
            if (data[i].Gender == 0)
                Gender = "Nữ";
            var trHTML = `<tr>
                            <td>${data[i].CustomerCode}</td>
                            <td>${data[i].FullName}</td>
                            <td>${Gender}</td>
                            <td>${DateOfBirth}</td>
                            <td>${data[i].CustomerGroupName}</td>
                            <td>${data[i].PhoneNumber}</td>
                            <td>${data[i].Email}</td>
                            <td>${data[i].Address}</td>
                            <td>${data[i].DebitAmount || ""}</td>
                            <td>${data[i].CustomerGroupName}</td>
                           </tr>`
            $('table > tbody:last-child').append(trHTML);
        }
        var recordInfo = "<span>Hiển thị 1 - " + data.length + "/" + data.length + " khách hàng</span>";
        var recordOption = "<span>" + data.length + " khách hàng/Trang";
        $('.content-footer .record-info').append(recordInfo);
        $('.content-footer .record-option').append(recordOption);
    }).fail(function (data) {

    })
}

function dateFormat(date) {
    var a = new Date(date);
    // lấy ngày:
    var day = a.getDate();

    // lấy tháng:
    var month = a.getMonth() + 1;

    // lấy năm:
    var year = a.getFullYear();

    if (day < 10)
        day = '0' + day;
    if (month < 10)
        month = '0' + month;

    return day + '/' + month + '/' + year;
}