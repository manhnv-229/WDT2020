$(document).ready(function () {
/* http://api.manhnv.net/api/customers */
    //load du lieu 
    //B1.Goi phuong thuc lay du lieu

    dialog = $(".customer-dialog").dialog({
        autoOpen: false,
        height: 650,
        width: 700,
        modal: true,
       
    });
    initEvens();
})
function initEvens() {
    // Gán các sự kiện:
    $('#btnAdd').click(function () {
        dialog.dialog('open');
    })

    $('#btnCancel').click(function () {
        dialog.dialog('close');
    })

    //$('#tbListData').on('dblclick', 'tr', function () {
    //    alert('á');
    //})

/*    $('#tbListData').on('dblclick', 'tr', function () {
        // load dữ liệu chi tiết:

        // Hiển thị dialog thông tin chi tiết:
        dialog.dialog('open');
    })*/
}
/* $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
        async: false

    }).done(function (response) {
        console.log(response);
        //B3. build html va append len UI

        for (var i = 0; i < response.length(); i++) {
            console.log(response[i]);
            var trHtml = ``;
        }
     
     
       
    }).fail(function (response) {
    });*/

    //B2. xu ly du lieu