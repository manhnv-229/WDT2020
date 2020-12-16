$(document).ready(function(){
    //load du lieu
    //Buoc1: goi service lay du lieu :(http://api.manhnv.net/api/customers)
    
    $.ajax({
        url:'http://api.manhnv.net/api/customers',
        method:'GET',
    }).done(function(response){
        console.log(response);  
    }).fail(function(response){

    })
    //Bước 2: Xử lý dữ liệu
    
    //Bước 3: Build html và append lên UI
    
    for (var i=0; i<10; i++){
        var trHTML=`<tr class="customer__row">
            <td>KH0441943</td>
            <td>Bùi Khánh Loan</td>
            <td>Nữ</td>
            <td>15/03/1965</td>
            <td>Null</td>
            <td>094413864334</td>
            <td>huonghoan@misa.vn</td>
            <td>Hà Nội</td>
        </tr>`;
    }
    $('#table_data > tbody:last-child').append(trHTML);
})