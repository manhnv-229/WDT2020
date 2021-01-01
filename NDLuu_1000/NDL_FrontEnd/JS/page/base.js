class BaseJS{
    constructor(){
        this.getDataUrl = null;
        this.setDataUrl();
        this.loadData();
        this.loadDepartment();
        this.initEvens();
    }

    setDataUrl(){

    }

    initEvens() {
        // Gán các sự kiện:
        $('#btnAdd').click(function () {
            dialog.dialog('open');
        })
      
        $('#btnCancel').click(function () {
            dialog.dialog('close');
        })
      
        $('#btnRefresh').click(function () {
            this.loadData();
        }.bind(this))
      
        $('table tbody').on('dblclick', 'tr', function () {
            dialog.dialog('open');
        })

        //validate dữ liệu
        $('.input-required').blur(function(){
            var value = $(this).val();
            if(!value){
                $(this).addClass('border-red');
            }
            else{
                $(this).removeClass('border-red');
            }
        })
        $('input[type="email"]').blur(function(){
            var value = $(this).val();
            var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
            if (!testEmail.test(value)){
                $(this).addClass('border-red');
            }
            else{
                $(this).removeClass('border-red');
            }
        })

        
      }

    /**
     * Thực hiện load dữ liệu
     * 
     * Author: NDL 
     */
    loadData(){
        //alert("Đã load lại trang");
        try {
            var columns = $('table thead th');
            var getDataUrl = this.getDataUrl;
            $.ajax({
                url: getDataUrl ,
                method:'GET',
            }).done(function(response){
                console.log(response[0]);
                $('table tbody').empty();
                $.each(response, function(index, obj){
                
                    var tr = $(`<tr></tr>`);
                    
                    $.each(columns, function(index, th){
                        var td = $(`<td><div><span></span></div></td>`);
                        var fieldName = $(th).attr('fieldname');
                        var formatType = $(th).attr('formatType');
                        var value = obj[fieldName];
                        switch (formatType) {
                            case "ddmmyyyy":
                                value = formatDate(value);
                                break;
                            case "MoneyVND":
                                td.addClass("text-align-right");
                                value = formatMoney(value);
                                break;
                            default:
                                break;
                        }

                        
                        td.append(value);
                        $(tr).append(td);
                    })
                $("table tbody").append(tr);
            })
            
            }).fail(function (response){
        
            });
        } catch (error) {
            
        }
        
    }
    loadDepartment(){
        try {
            $.ajax({
                url: "http://localhost:60381/api/Departments" ,
                method:'GET',
            }).done(function(response){
                console.log(response);
               // $('.department').empty();
               $.each(response, function(index, element){
                    var select = $('#department');
                    var departmentID = element['departmentID'];
                    var opp = $(`<option value="${departmentID}"></option>`);
                    // var fieldValue = $(element).attr('fieldValue');
                    // console.log(fieldValue);
                    // var value = element[fieldValue];
                    //console.log(element['departmentName'])
                    opp.append(element['departmentName']);
                    $(select).append(opp);
               })
                
            }).fail(function (response){
        
            });
        } catch (error) {
            
        }
    }
}

/**
 * Format Date
 * @param {} date 
 */
function formatDate(date){
    var d = new Date(date);
    var day = d.getDate();
    var month = d.getMonth();
    var year = d.getFullYear();
  
    return day + "/" +month +"/"+year;
  }

  /**
   * Định dạng tiền tệ
   * @param {*} money 
   */
  function formatMoney(money){
      if(money){
          return money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, '.')+" đ";
      }
      
    return "";
  }

  //load department name
  