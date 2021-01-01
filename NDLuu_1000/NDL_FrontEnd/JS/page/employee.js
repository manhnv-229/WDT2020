
$(document).ready(function(){
    new Employee();
      
    dialog = $(".m-dialog").dialog({
      autoOpen: false,
      width: 700,
      modal: true,
  });

    
});

class Employee extends BaseJS{
  constructor(){
    super();
  }
  setDataUrl(){
    this.getDataUrl = "http://api.manhnv.net/api/customers";
  }
}


//set gender
function setGender(gender){
  if(gender==0){
    return "Nữ";
  }
  return "Nam";
}