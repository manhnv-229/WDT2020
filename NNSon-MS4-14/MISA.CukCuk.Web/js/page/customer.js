$(document).ready(function () {

    dialog = $(".customer-dialog").dialog({
        autoOpen: false,
        width: 700,
        modal: true,
    });

    // load dữ liệu:
    // 1. Bước 1: Gọi service lấy dữ liệu: (api.manhnv.net/api/customers)
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
    }).done(function (response) {
        console.log(response);
        // 2. Bước 2: xử lý dữ liệu

        // 3. Bước 3: Build html và append lên UI
        $('#tbListData tbody').empty();
        for (var i = 0; i < response.length; i++) {
            console.log(response[i]);
            var DOB = formatDate(response[i].DateOfBirth);
            var trHtml = `<tr>
                            <td rowspan="1" colspan="1" style="width: 120px;">
                                <div class="cell">${response[i].CustomerCode}</div>
                            </td>
                            <td rowspan="1" colspan="1" style="width: 143px;">
                                <div class="cell">${response[i].FullName}</div>
                            </td>
                            <td rowspan="1" colspan="1" style="width: 58px;">
                                <div class="cell">${response[i].GenderName}</div>
                            </td>
                            <td rowspan="1" colspan="1" style="width: 100px;">
                                <div class="cell">${DOB}</div>
                            </td>
                            <td rowspan="1" colspan="1" style="width: 130px;">
                                <div class="cell">${response[i].CustomerGroupName}</div>
                            </td>
                            <td rowspan="1" colspan="1" style="width: 72px;">
                                <div class="cell">${response[i].PhoneNumber}</div>
                            </td>
                            <td rowspan="1" colspan="1" style="width: 197px;">
                                <div class="cell">${response[i].Email}</div>
                            </td>
                            <td rowspan="1" colspan="1" style="width: 232px;">
                                <div class="cell">${response[i].Address}</div>
                            </td>
                            <td rowspan="1" colspan="1" style="width: 70px;">
                                <div class="cell">${response[i].DebitAmount||""}</div>
                            </td>
                            <td rowspan="1" colspan="1" style="width: 140px;">
                                <div class="cell">${response[i].MemberCardCode}</div>
                            </td>
                        </tr>`
            $('#tbListData > tbody:last-child').append(trHtml);
        }
    }).fail(function (response) {

    })

    // Gán các sự kiện:
    $('#btn-add').click(function () {
        dialog.dialog('open');
    })

    $('#btn-cancel').click(function () {
        dialog.dialog('close');
    })

    $('#btn-submit').click(function () {
        dialog.dialog('close');
    })

    $('#tbListData').on('dblclick', 'tr', function () {
        dialog.dialog('open');
    })
})

function formatDate(date) {
    var date = new Date(date);

    var day = date.getDate();
    var month = date.getMonth();
    var year = date.getFullYear();
    return day + '/' + month + '/' + year;
}