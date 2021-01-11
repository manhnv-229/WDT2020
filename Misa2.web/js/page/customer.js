
$(document).ready(function () {
    dialog = $('.dialog').dialog({
        autoOpen: false,
        model: true,
    });

    new CustomerJS();
});

class CustomerJS extends BaseJS {
    constructor() {
        super();
    }
    setDataUrl() {
        this.getDataUrl = ' http://api.manhnv.net/api/customers';
    }

}
