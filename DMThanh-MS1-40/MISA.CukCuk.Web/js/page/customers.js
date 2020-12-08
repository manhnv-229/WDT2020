$(document).ready(function () {
    //load du lieu


    //1. 
    $.ajax({
        url: 'http://api.manhnv.net/api/customers',
        method: 'GET',
    }).done(function (response){
        console.log(response);
    }).fail(function (response) {

    })
    //2.

    //3. 

    for (var i = 0; i < 10; i++) {
        var trHtml = `<tr class="line1">
                        <td>KH000001</td>
                        <td>Đặng Minh Thành</td>
                        <td>Nam</td>
                        <td>06/12/1997</td>
                        <td>Cá nhân</td>
                        <td>0123456789</td>
                        <td>minhthhanh@gmail.com</td>
                        <td style="max-width:100px"><span style="width:100px">Thôn Chùa, Xã Thuận Lộc, THị Xã Hồng Lĩnh, Hà Tĩnh</span></td>
                    </tr>`;
        $(# > tbody: 'last-Child').append(trHtml);

    }

})