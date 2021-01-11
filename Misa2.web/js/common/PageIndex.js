var pageIndex = {
    pageIndexShow: function () {
        var totalPageRounded = this.totalRow / this.limmit
        this.totalPage = Math.ceil(totalPageRounded);
        var total = this.totalRow;
        var offSet = this.page * this.limmit;
        var res = total - offSet;
        if (res < this.limmit) {
            offSet = total;
        }
        $('#total').text(total);
        $('#offSet').text(offSet);
    }
}