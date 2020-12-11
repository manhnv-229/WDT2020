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
    $("#btnAdd").click(function () {
        dialog.dialog('open');
    })

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
   

})