$(document).ready(function () {
    new MPlugin();
    (function ($) {
        $.fn.extend({
            // Lấy value với các element xác định là combobox:
            getValue: function (options) {
                var controlType = this.attr("control-type");
                switch (controlType) {
                    case "combobox":
                        var data = $(this).data('selected');
                        if (data && data.value) {
                            return data.value;
                        } else {
                            return null;
                        }
                        break;
                    default:
                        return null;
                }
            },
            getText: function (options) {
                var controlType = this.attr("control-type");
                switch (controlType) {
                    case "combobox":
                        var data = $(this).data('selected');
                        if (data && data.text) {
                            return data.text;
                        } else {
                            return null;
                        }
                        break;
                    default:
                        return null;
                }
            },
            getData: function (options) {
                var controlType = this.attr("control-type");
                switch (controlType) {
                    case "combobox":
                        return $(this).data('data');
                        break;
                    default:
                        return null;
                }
            }
        });
    })(jQuery);
})

class MPlugin {
    constructor() {
        this.init();
        this.initEvents();
    }
    init() {
        this.buildElements();
    }

    initEvents() {
        var me = this;
        $(document).on('keyup', 'input[date-picker].hasDatepicker', function () {
            var value = this.value;
            if (value && (value.length == 2 || value.length == 5)) {
                value = value + '/';
            }
            $(this).val(value);
        })


        $(document).on('keydown', '[control-type="combobox"] input.m-combobox-input', function (e) {
            var keyCode = e.keyCode;
            switch (keyCode) {
                case 40:
                    me.setFocusComboboxItem(this.parentElement, true);
                    break;
                case 38:
                    me.setFocusComboboxItem(this.parentElement, false);
                    break;
                default:
            }

        })

        /* -----------------------------------------------------
         * Thực hiện auto complete - nhập liệu thì thực hiện tìm kiếm dữ liệu
         * Author: NVMANH (07/12/2020)
         */
        $(document).on('input', '[control-type="combobox"] input.m-combobox-input', function () {
            var inputValue = this.value;
            var combobox = $(this).parent();
            var data = combobox.data('data');
            var entity = combobox.data('entity');
            var dataFilter = $.grep(data, function (item) {
                return item[entity.FieldText].toLowerCase().includes(inputValue.toLowerCase()) == true;
            })
            me.buildHTMLComboboxData(combobox, dataFilter, entity.FieldText, entity.FieldValue);
            combobox.data('areFiltering', true);
            combobox.data('selected', null);
            $(this).siblings('.m-combobox-data').show();
        })

        //TODO: Chọn item trong combobox:
        $(document).on('click', '.m-combobox button.m-combobox-trigger', function () {
            var comboboxData = $(this).siblings('.m-combobox-data');
            var combobox = comboboxData.parent();

            // Build lại dữ liệu cho combobox:
            var data = combobox.data('data');
            var areFiltering = combobox.data('areFiltering');

            // Nếu đang có việc filter dữ liệu thì load lại data, không thì thôi:
            if (data && areFiltering) {
                combobox.data('areFiltering', false);
                var entity = combobox.data('entity');
                me.buildHTMLComboboxData(combobox, data, entity.FieldText, entity.FieldValue);
            }

            // Hiển thị màu sắc item được chọn có trong danh sách:
            var itemSelected = $(combobox).data('selected');
            comboboxData.children().removeClass('mCombobox__item--selected');
            if (itemSelected && itemSelected.value) {
                var value = itemSelected.value;
                comboboxData.children("[value='" + value + "']").addClass('mCombobox__item--selected');
            }
            comboboxData.toggle();
        })

        //TODO: xây dựng combobox động
        $(document).on('click', '.m-combobox .m-combobox-item', function () {
            var comboboxData = this.parentElement;
            var input = $(comboboxData).siblings('input');
            var value = this.getAttribute('value'),
                text = this.firstElementChild.textContent;
            input.val(text);
            $(input.parent()).data("selected", { text: text, value: value });
            input.parent.data = { text: text, value: value };
            $(comboboxData).toggle();
        })
    }

    buildElements() {
        this.buildCombobox();
        this.buildDatePicker();
    }

    //TODO: build html cho combobox
    buildCombobox(inputs) {
        var me = this;
        if (!inputs) {
            inputs = $('mcombobox');
        }
        $.each(inputs, function (index, combobox) {
            var apiGetUrl = $(this).attr('apiGetUrl');
            if (apiGetUrl) {
                $.ajax({
                    method: 'GET',
                    url: apiGetUrl,
                }).done(function (res) {
                    me.buildHTMLCombobox(combobox, res);
                }).fail(function () {
                    me.buildHTMLCombobox(combobox, null);
                })
            } else {
                me.buildHTMLCombobox(combobox, null);
            }
        })
    }

    buildHTMLCombobox(combobox, data) {
        var label = $(combobox).attr('label'),
            id = $(combobox).attr('id'),
            labelCls = $(combobox).attr('label-cls'),
            controlCls = $(combobox).attr('input-cls'),
            dataIndex = $(combobox).attr('dataIndex'),
            fieldValue = $(combobox).attr('fieldValue'),
            fieldText = $(combobox).attr('fieldText');
        var controlHtml = $(`<div id="` + id + `" class="m-combobox" control-type="combobox">
                                    <div class="m-label `+ labelCls + `">` + label + `</div>
                                    <input class="m-combobox-input `+ controlCls + `" type="text" autocomplete="off" />
                                    <button class="m-combobox-trigger"><i class="fas fa-chevron-down"></i></button>
                                    <div class="m-combobox-data">
                                    </div>
                                </div>`);
        if (data) {
            this.buildHTMLComboboxData(controlHtml, data, fieldText, fieldValue);
            //$.each(data, function (index, item) {
            //    var text = item[fieldText],
            //        value = item[fieldValue];
            //    var itemHTML = `<div class="m-combobox-item" value="` + value + `"><span>` + text + `</span></div>`;
            //    controlHtml.find('.m-combobox-data').append(itemHTML);
            //})
        }

        // Lưu trữ dữ liệu của combobox
        $(controlHtml).data('data', data);

        // Lưu trữ thông tin entity sẽ bindding của Object:
        $(controlHtml).data('entity', {
            DataIndex: dataIndex,
            FieldText: fieldText,
            FieldValue: fieldValue
        });
        $(combobox).replaceWith(controlHtml);
    }

    /** ---------------------------------------------------------------
     * Thực hiện buil các item html cho element chứa dữ liệu cho combobox
     * @param {HTMLElement} comboboxHTML HTML của combobox
     * @param {Array} data mảng dữ liệu truyền vào
     * CreatedBy: NVMANH (03/12/2020)
     */
    buildHTMLComboboxData(comboboxHTML, data, fieldText, fieldValue) {
        var comboboxDataEl = comboboxHTML.find('.m-combobox-data');
        // clear toàn bộ dữ liệu cũ:
        $(comboboxDataEl).empty();
        $.each(data, function (index, item) {
            var text = item[fieldText],
                value = item[fieldValue];
            var itemHTML = `<a class="m-combobox-item" value="` + value + `"><span>` + text + `</span></a>`;
            comboboxDataEl.append(itemHTML);
        })
    }

    setFocusComboboxItem(combobox, isNext) {
        var comboboxData = $(combobox).children('.m-combobox-data');
        var childrenFirst = comboboxData.children().first();
        var childrenLast = comboboxData.children().last();
        var itemFocusCurrent = comboboxData.children('.mCombobox__item--focus').first();
        var comboboxDataNotShow = (comboboxData.css('display') == 'none');
       
        comboboxData.show();
        // Hiển thị các item lựa chọn:
        if (comboboxDataNotShow && isNext || (isNext && !comboboxDataNotShow && itemFocusCurrent.length == 0)) {
            childrenFirst.addClass('mCombobox__item--focus');
        } else if (comboboxDataNotShow && !isNext || (!isNext && !comboboxDataNotShow && itemFocusCurrent.length == 0)) {
            childrenLast.addClass('mCombobox__item--focus');
        } else {
            itemFocusCurrent.removeClass('mCombobox__item--focus');
            /* - Chưa có item nào được focus thì focus luôn thằng đầu tiên
               - Có thằng focus rồi thì thực hiện focus thằng tiếp theo: */
            if (isNext) {
                debugger
                if (itemFocusCurrent.next().length > 0) {
                    itemFocusCurrent.next().addClass('mCombobox__item--focus');
                } else {
                    childrenFirst.addClass('mCombobox__item--focus');
                }
                
            } else {
                if (itemFocusCurrent.prev().length > 0) {
                    itemFocusCurrent.prev().addClass('mCombobox__item--focus');
                } else {
                    childrenLast.addClass('mCombobox__item--focus');
                }
            }
        }
    }

    //TODO: build html date picker:
    buildDatePicker() {
        var inputs = $('m-date-picker');
        $.each(inputs, function (index, input) {
            var label = $(input).attr('label'),
                id = $(input).attr('id'),
                labelCls = $(input).attr('label-cls'),
                controlCls = $(input).attr('input-cls'),
                format = $(input).attr('format'),
                fieldName = $(input).attr('fieldName');
            var controlHtml = $(`<div class="m-date-picker">
                                     <div class="` + (labelCls ? labelCls : '') + `">` + (label ? label : '') + `</div>
                                     <div class="` + (controlCls ? controlCls : '') + `">
                                        <div class="dateInput">
                                            <input id="` + (id ? id : '') + `" date-picker format="` + (format ? format : '') + `" fieldName="` + (fieldName ? fieldName : '') + `" type="text" placeholder="_ _/ _ _/ _ _ _ _" autocomplete="off"/>
                                            <div class="dateInput-icon-box"></div>
                                        </div>
                                    </div>
                                </div>`);
            $(this).replaceWith(controlHtml);
            $("#" + id + "").datepicker({
                showOn: "button",
                buttonImage: "/content/icon/date-picker.svg",
                buttonImageOnly: true,
                buttonText: "Chọn ngày",
                dateFormat: "dd/mm/yy"
            });
        })
    }
}