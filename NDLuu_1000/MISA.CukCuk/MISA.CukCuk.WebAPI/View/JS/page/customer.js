
$(document).ready(function(){
    new Customer();
      
    dialog = $(".m-dialog").dialog({
      autoOpen: false,
      width: 700,
      modal: true,
  });

    
});



class Customer extends BaseJS{
  constructor(){
    super();
  }
  setDataUrl(){
    this.getDataUrl = "http://api.manhnv.net/api/customers";
  }
}



//format Date

//set gender
function setGender(gender){
  if(gender==0){
    return "Nữ";
  }
  return "Nam";
}