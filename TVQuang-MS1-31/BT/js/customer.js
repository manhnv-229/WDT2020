$(document).ready(function () {
    $("#dialog-customer").dialog({
        autoOpen: false,
        width: '650px',
        buttons: [
            {
                text: "Hủy",
                addClass: 'cancel',
                open: function () {

                },
                click: function () {
                    $(this).dialog("close");
                }
            },
            {
                text: "Lưu",
                icons: { primary: "ui-icon-disk"},
                addClass: 'save',
                open: function () {

                }
            }
            ,
            {
                text: "Lưu và thêm mới",
                addClass: 'saveA',
                click: function () {

                }
            }
        ]
    });
    $(".ui-dialog-buttonpane").attr('style', 'background-color: #E5E5E5;');

    $(".cancel").attr('style', 'background-color: #E5E5E5; border: 0px; height: 40px;');

    $(".save").attr('style', ' height: 40px; background-color: #019160; color: #ffffff; background-size: contain; background-position: center; background-repeat: no-repeat;');

    //$('.ui-dialog-buttonpane').find('button:contains("Lưu")').prepend('<span style="float:left;" class="ui-icon ui-icon-trash"></span>');


    $(".saveA").attr('style', 'background-color: #019160; height: 40px; color: #ffffff');
   
    //load data:
    //1. Goi services lay du lieu: (api.manhnv.net/api/customer)
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
        async: false
    }).done(function (response) {
        $('#tabl tbody').empty();
        for (var i = 0; i < response.length; i++) {
            var DOB = response[i].DateOfBirth;
            DOB = formatDate(DOB);
            var trHtml = `<tr>
                        <td style="max-width: 5px;">${response[i].CustomerCode}</td>
                        <td>${response[i].FullName}</td>
                        <td>${response[i].GenderName}</td>
                        <td>${DOB}</td>
                        <td>${response[i].CustomerGroupId}</td>
                        <td>${response[i].PhoneNumber}</td>
                        <td>${response[i].Email}</td>
                        <td style="max-width: 5px;">${response[i].Address}</td>
                    </tr>`;
            $('#tabl > tbody:last-child').append(trHtml);
        }
    }).fail(function (response) {

    })
    //2. Xu ly du lieu

    //3. build file html va append len UI

    events();
})

function formatDate(date) {
    var date = new Date(date);
    var day = date.getDay() + 1;
    var month = date.getMonth() + 1;
    var year = date.getFullYear();
    if (day < 10) {
        day = '0' + day;
    }
    if (month < 10) {
        month = '0' + month;
    }

    return day + '/' + month + '/' + year;
}

function events() {
    $(".btn__add__customer").click(function () {
        $("#dialog-customer").dialog('open');
    });
}

