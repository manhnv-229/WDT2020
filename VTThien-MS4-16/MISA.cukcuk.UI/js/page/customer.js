$(document).ready(function () {

    $("#btn-add").on("click", function () {
        dialog.dialog("open");
    });

    dialog = $(".customer-dialog").dialog({
        autoOpen: false,
        height: 520,
        width: 630,
        modal: true
    });
    //load du lieu:
    //b1: goi service lay du lieu

    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
    }).done(function (response) {
        console.log(response);

    //b2 xu ly du lieu
    //b3 build html va append len UI    
        $('#tblistdata tbody').empty();
        for (var i = 0; i < response.length; i++) {
            console.log(response[i]);
            var dob = formatDate(response[i].DateOfBirth);
            var trHtml = `<tr class="firstline">
                        <td>${response[i].CustomerCode}</td>
                        <td>${response[i].FullName}</td>
                        <td>${response[i].GenderName}</td>
                        <td>${dob}</td>
                        <td>${response[i].CustomerGroupName}</td>
                        <td>${response[i].PhoneNumber}</td>
                        <td>${response[i].Email}</td>
                        <td>${response[i].Address}</td>
                        <td>${response[i].MemberCardCode}</td>
                    </tr>`;
            $('#tblistdata > tbody:last-child').append(trHtml);
        }
    }).fail(function (response){
    })

    function formatDate(date) {
        var date = new Date(date);

        var day = date.getDate();
        if (day < 10) day = '0' + day;
        var month = date.getMonth() + 1;
        if (month < 10) month = '0' + month;
        var year = date.getFullYear();
        return day + '/' + month + '/' + year;
    }

})