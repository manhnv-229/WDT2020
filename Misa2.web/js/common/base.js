class BaseJS {
    constructor() {
        this.page = 1;
        this.limmit = 5;
        this.totalRow = null;
        this.totalPage = null;
        this.getDataUrl = null;
        this.setDataUrl();
        this.loadData();
        this.initEvent();
        //this.loadPageIndex();
        //this.initEvent().bind(this);
    }

    setDataUrl() {

    }
    /**
    * Load data from api
    * Ahtor: Manh Tien(14/12/2020)**/
    loadData() {
        try {
            var column = $('table thead th');
            $.ajax({
                url: this.getDataUrl + '/' + this.page + '/' + this.limmit,
                method: 'GET',
            }).done(function (response) {
                $('table tbody').empty();
                $.each(response, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    $.each(column, function (index, th) {
                        var td = $(`<td><div><span></span></div></td>`);
                        var fieldName = $(th).attr('fieldName');
                        var value = obj[fieldName];
                        var format = $(th).attr('formatType');
                        switch (format) {
                            case "gender":
                                value = formatGender(value);
                                break;
                            case "ddmmyyyy":
                                td.addClass("text-align-center");
                                value = formatDate(value);
                                break;
                            case "money":
                                td.addClass("text-align-right");
                                value = formatMoney(value);
                                break;
                            case "state":
                                value = formatState(value);
                                break;
                            default:
                                break;
                        }
                        td.append(value);
                        $(tr).append(td);
                    })
                    $('table tbody').append(tr);
                });
            }).fail(function (respone) {
                console.log(respone);
            });

            $.ajax({
                url: this.getDataUrl + '/' + 'numberEntity',
                method: 'GET',
            }).done( (res) => {
                this.totalRow = res;
                var totalPageRounded = this.totalRow / this.limmit
                this.totalPage = Math.ceil(totalPageRounded);
                var total = this.totalRow;
                var offSet = this.page * this.limmit;
                var lowOffSet = (this.page - 1) * this.limmit;
                $('#lowOffSet').text(lowOffSet);
                $('#total').text(total);
                $('#offSet').text(offSet);
            }).fail(function (res) {
                console.log(res);
            })
        } catch (e) {
            console.log(e);
        }
        
    }

    /**
     * init event
     * Author: Manh Tien(14/12/2020)
     * */
    initEvent() {
        $('#btnAdd').click(function () {
            $.ajax({
                url: 'http://localhost:51075/api/v1/Employee/employeeCodeMax',
                method: 'GET',
                async: false,
            }).done(function (res) {
                var employeeCodeString = res;
                var emploeeCodeNumberPart = employeeCodeString.slice(2);
                emploeeCodeNumberPart = parseInt(emploeeCodeNumberPart) + 1;
                employeeCodeString = 'NV' + emploeeCodeNumberPart;
                $('#txtEmployeeCode').val(employeeCodeString);
            }).fail(function (res) {
                console.log(res);
            })
            dialog.dialog('open');
        });

        $('#btnClose').click(function () {
            dialog.dialog('close');
        });

        $('#cancel').click(function () {
            dialog.dialog('close');
            setEmptyText();
        });

        $('#cancel-pup-up').click(function () {
            $('#pup-up').hide();
        });
        
        $('#oke').click(function () {
            $('#notice').hide();
            //dialog.dialog('open');
        });

        $('#page-number-1').click(() => {
            resetPageIndexColor();
            $('#page-number-1').css("background-color", "#019160");
            this.page = 1;
            var totalPageRounded = this.totalRow / this.limmit
            this.totalPage = Math.ceil(totalPageRounded);
            var total = this.totalRow;
            var offSet = this.page * this.limmit;
            var lowOffSet = (this.page - 1) * this.limmit;
            $('#lowOffSet').text(lowOffSet);
            var res = total - offSet;
            if (res < this.limmit) {
                offSet = total;
            }
            $('#total').text(total);
            $('#offSet').text(offSet);
            loadDataPaging(this.getDataUrl, this.page, this.limmit);
        })
        $('#page-number-2').click(() => {
            resetPageIndexColor();
            $('#page-number-2').css("background-color", "#019160");
            this.page = 2;
            var totalPageRounded = this.totalRow / this.limmit
            this.totalPage = Math.ceil(totalPageRounded);
            var total = this.totalRow;
            var offSet = this.page * this.limmit;
            var lowOffSet = (this.page - 1) * this.limmit;
            $('#lowOffSet').text(lowOffSet);
            var res = total - offSet;
            if (res < this.limmit) {
                offSet = total;
            }
            $('#total').text(total);
            $('#offSet').text(offSet);
            loadDataPaging(this.getDataUrl, this.page, this.limmit);
        })
        $('#page-number-3').click(() => {
            resetPageIndexColor();
            $('#page-number-3').css("background-color", "#019160");
            this.page = 3;
            var totalPageRounded = this.totalRow / this.limmit
            this.totalPage = Math.ceil(totalPageRounded);
            var total = this.totalRow;
            var offSet = this.page * this.limmit;
            var lowOffSet = (this.page - 1) * this.limmit;
            $('#lowOffSet').text(lowOffSet);
            var res = total - offSet;
            if (res < this.limmit) {
                offSet = total;
            }
            $('#total').text(total);
            $('#offSet').text(offSet);
            loadDataPaging(this.getDataUrl, this.page, this.limmit);
        })
        $('#page-number-4').click(() => {
            resetPageIndexColor();
            $('#page-number-4').css("background-color", "#019160");
            this.page = 4;
            var totalPageRounded = this.totalRow / this.limmit
            this.totalPage = Math.ceil(totalPageRounded);
            var total = this.totalRow;
            var offSet = this.page * this.limmit;
            var lowOffSet = (this.page - 1) * this.limmit;
            $('#lowOffSet').text(lowOffSet);
            var res = total - offSet;
            if (res < this.limmit) {
                offSet = total;
            }
            $('#total').text(total);
            $('#offSet').text(offSet);
            loadDataPaging(this.getDataUrl, this.page, this.limmit);
        })
        $('#first-page').click(() => {
            resetPageIndexColor();
            $('#page-number-1').css("background-color", "#019160");
            this.page = 1;
            var totalPageRounded = this.totalRow / this.limmit
            this.totalPage = Math.ceil(totalPageRounded);
            var total = this.totalRow;
            var offSet = this.page * this.limmit;
            var lowOffSet = (this.page - 1) * this.limmit;
            $('#lowOffSet').text(lowOffSet);
            var res = total - offSet;
            if (res < this.limmit) {
                offSet = total;
            }
            $('#total').text(total);
            $('#offSet').text(offSet);
            loadDataPaging(this.getDataUrl, this.page, this.limmit);
        })
        $('#prev-page').click(() => {
            resetPageIndexColor();
            if (this.page > 1) {
                this.page -= 1;
                var totalPageRounded = this.totalRow / this.limmit
                this.totalPage = Math.ceil(totalPageRounded);
                var total = this.totalRow;
                var offSet = this.page * this.limmit;
                var lowOffSet = (this.page - 1) * this.limmit;
                $('#lowOffSet').text(lowOffSet);
                var res = total - offSet;
                if (res < this.limmit) {
                    offSet = total;
                }
                $('#total').text(total);
                $('#offSet').text(offSet);
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            } else {
                $('#prev-page').prop("disabled", true);
            }
            
        })
        $('#next-page').click(() => {
            if (this.page < this.totalPage) {
                resetPageIndexColor();
                this.page += 1;
                var totalPageRounded = this.totalRow / this.limmit
                this.totalPage = Math.ceil(totalPageRounded);
                var total = this.totalRow;
                var offSet = this.page * this.limmit;
                var lowOffSet = (this.page - 1) * this.limmit;
                $('#lowOffSet').text(lowOffSet);
                var res = total - offSet;
                if (res < this.limmit) {
                    offSet = total;
                }
                $('#total').text(total);
                $('#offSet').text(offSet);
                loadDataPaging(this.getDataUrl, this.page, this.limmit);
            } else {
                $('#next-page').prop("disabled", true);
            }
        })
        $('#last-page').click(() => {
            resetPageIndexColor();
            this.page = this.totalPage;
            var totalPageRounded = this.totalRow / this.limmit
            this.totalPage = Math.ceil(totalPageRounded);
            var total = this.totalRow;
            var offSet = total;
            var lowOffSet = (this.page - 1) * this.limmit;
            $('#lowOffSet').text(lowOffSet);
            $('#total').text(total);
            $('#offSet').text(offSet);
            loadDataPaging(this.getDataUrl, this.page, this.limmit);
        })
        $('#option-page').click(() => {
            this.limmit = $('#option-page').find(":selected").val();
            var totalPageRounded = this.totalRow / this.limmit
            this.totalPage = Math.ceil(totalPageRounded);
            var total = this.totalRow;
            var offSet = this.page * this.limmit;
            var lowOffSet = (this.page - 1) * this.limmit;
            $('#lowOffSet').text(lowOffSet);
            $('#total').text(total);
            $('#offSet').text(offSet);
            loadDataPaging(this.getDataUrl, this.page, this.limmit);
        })
        $('#fresh-data').click(() => {
            resetPageIndexColor();
            $('#page-number-1').css("background-color", "#019160");
            this.page = 1;
            this.limmit = 5;
            this.getDataUrl = 'http://localhost:51075/api/v1/Employee';
            this.loadData();
        })
    }
}