$(document).ready(function(){
    $.ajax({
        url: 'http://api.manhnv.net/api/customers' ,
        method:'GET',
    }).done(function(response){
      console.log(response);
      loadData(response);
      
      
    }).fail(function (response){

    });
    
    
});
/**
 * Thực hiện gán dữ liệu
 * 
 * Author: NDL 
 * */
function loadData(response){
  $('#myTable tbody').empty();
  for (var index = 0; index < response.length; index++) {
    console.log(response[index]);
    var x = response[index].DateOfBirth;
    var DOB = formatDate(x);
    var gender = setGender(response[index].Gender)
    var trHTML = `<tr>
                  <td>${response[index].CustomerCode}</td>
                  <td>${response[index].FullName}</td>
                  <td>${gender}</td>
                  <td>${DOB}</td>
                  <td>${response[index].CustomerGroupName}</td>
                  <td>${response[index].PhoneNumber}</td>
                  <td>${response[index].Email}</td>
                  <td>${response[index].Address}</td>
                  </tr>`;
    $('#myTable >tbody:last-child').append(trHTML);
  }
}
//format Date
function formatDate(date){
  var d = new Date(date);
  var day = d.getDate();
  var month = d.getMonth();
  var year = d.getFullYear();

  return day + "/" +month +"/"+year;
}
//set gender
function setGender(gender){
  if(gender==0){
    return "Nữ";
  }
  return "Nam";
}