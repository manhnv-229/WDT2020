
$(document).ready(function(){
    new Employee();
      
    dialog = $(".m-dialog").dialog({
      autoOpen: false,
      width: 700,
      modal: true,
    });

    deleteDialog = $(".delete-dialog").dialog({
      autoOpen: false,
      width: 400,
      modal: true,
    });
    
});

class Employee extends BaseJS{
  constructor(){
    super();
  }
  setDataUrl(){
    this.getDataUrl = "http://localhost:60381/api/Employees";
  }
}

