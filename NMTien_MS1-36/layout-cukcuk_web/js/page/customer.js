$(document).ready(function () {
/* http://api.manhnv.net/api/customers */
    //load du lieu 
    //B1.Goi phuong thuc lay du lieu

    dialog = $(".customer-dialog").dialog({
        autoOpen: false,
        height: 400,
        width: 350,
        modal: true,
       
    });
    $("#btnAdd").click(function () {
        dialog.dialog('open');
    })

    $.ajax({
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
      
      
        debugger;
    }).fail(function (response) {
    });
    debugger;
    //B2. xu ly du lieu
   

})