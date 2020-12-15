/**
 * Global var
 */
var customerList = []

$(document).ready(function () {

    dialog = $(".m-dialog").dialog({
        autoOpen: false,
        width: 700,
        modal: true,
    });

    loadData();

    initEvens();
  
})

/**
 * Thực hiện load dữ liệu
 * Author: NVMANH (07/12/2020)
 * */
function loadData() {
    // load dữ liệu:
    // 1. Bước 1: gọi service lấy dữ liệu: (api.manhnv.net/api/customes)
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
    }).done(function (response) {
        // 2. Bước 2: xử lý dữ liệu
        customerList = response;
        console.log(customerList);
        // 3. Bước 3: Build html và append lên UI:
        $('#tbListData tbody').empty();
        for (var i = 0; i < customerList.length; i++) {
            console.log(customerList[i]);
            var DOB = formatDate(response[i].DateOfBirth);
            var trHtml = `<tr class="el-table__row first" id=${i}>
                        <td rowspan="1" colspan="1" style="width: 100px;">
                            <div class="cell">${response[i].CustomerCode}</div>
                        </td>
                        <td rowspan="1" colspan="1" style="width: 143px;">
                            <div class="cell">${response[i].FullName}</div>
                        </td>
                        <td rowspan="1" colspan="1" style="width: 58px;"><div class="cell">${response[i].GenderName}</div></td>
                        <td rowspan="1" colspan="1" style="width: 100px;"><div class="cell text-align-center">${DOB}</div></td>
                        <td rowspan="1" colspan="1" style="width: 72px;"><div class="cell">${response[i].CustomerGroupName}</div></td>
                        <td rowspan="1" colspan="1" style="width: 119px;"><div class="cell">${response[i].PhoneNumber}</div></td>
                        <td rowspan="1" colspan="1" style="width: 192px;"><div class="cell">${response[i].Email}</div></td>
                        <td rowspan="1" colspan="1" style="width: 232px;"><div class="cell">${response[i].Address}</div></td>
                        <td rowspan="1" colspan="1" class="text-align-right" style="width: 55px;"><div class="cell">${response[i].DebitAmount || ""}</div></td>
                        <td rowspan="1" colspan="1" style="width: 98px;"><div class="cell">${response[i].MemberCardCode}</div></td>
                        <td rowspan="1" colspan="1" style="width: 32px;"><div class="cell"></div></td>
                    </tr>`;
            $('#tbListData >tbody:last-child').append(trHtml);

            
        }

    }).fail(function (response) {

    })

}

/**
 * Thực hiện gán các sự kiện
 * Author: NVMANH (07/12/2020)
 * */
function initEvens() {
    // Gán các sự kiện:
    $('#btnAdd').click(function () {
        dialog.dialog('open');
    })

    $('#btnCancel').click(function () {
        dialog.dialog('close');
    })

    $('#tbListData').on('dblclick', 'tr', function () {
        dialog.dialog('open');
        customerDetailDialog(customerList[this.id]);
    })
}
/**
 * Thực hiện load dữ liệu detail của khách hàng lên dialog
 * @param {Object} Khách
 */
function customerDetailDialog(obj){
    // Thực hiện load dữ liệu khách hàng từ mảng CustomerList
    // Load dữ liệu vào các input box có ID tương ứng
    $("#txtCustomerCode").val(obj.CustomerCode);
    $("#txtFullName").val(obj.FullName);
    $('#txtMemberCardCode').val(obj.CustomerCode);
    
    $('#dtDateOfBirth').val(
        formatDate(obj.DateOfBirth)
    );
    // Xử lý phần select của Gender:
    $('#Gender').next().remove();
    let paragraphHtml = `<p>${obj.GenderName}</p>`;
    $('#Gender').parent().append(paragraphHtml);

    // Xử lý phần select nhóm khách hàng:
    $('#cbxCustomerGroup').val(obj.CustomerGroupName);
    
    $('#txtEmail').val(obj.Email);
    $('#txtPhoneNumber').val(obj.PhoneNumber);
    $('#CompanyName').val(obj.CompanyName);
    $('#CompanyTaxCode').val(obj.CompanyTaxCode);
    $('#txtAddress').val(obj.Address);
}


/**
 * Hàm thực hiện định dạng ngày tháng (ngày/tháng/năm)
 * @param {Number} date ngày truyền vào
 * Author: NVMANH (07/12/2020)
 */
function formatDate(date) {
    var date = new Date(date);
    // lấy ngày:
    var day = date.getDate();
   
    // lấy tháng:
    var month = date.getMonth() + 1;
   
    // lấy năm:
    var year = date.getFullYear();
    return day + '/' + month + '/' + year;
}