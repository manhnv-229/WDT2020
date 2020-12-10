$(document).ready(function () {
    dialog = $(".customer-dialog").dialog({
        autoOpen: false,
        height: 600,
        width: 700,
        modal: true,
    })
    loadData();
    initEvents();

    /**
     * Thực hiện load dữ liệu
    * Author: tkt18
     * */
    function loadData() {
        // gọi service lấy dữ liệu : (http://api.manhnv.net/api/customers)
        $.ajax({
            url: "http://api.manhnv.net/api/customers",
            context: document.body
        }).done(function (response) {
            $('table#table >tbody').empty();
            for (var i = 0; i < response.length; i++) {
                var dob = formatDate(response[i].DateOfBirth);
                var trHtml = ` <tr>
                    <td class="table__id">${response[i].CustomerCode}</td>
                    <td class="table__name">${response[i].FullName}</td>
                    <td class="table__gender">${response[i].GenderName}</td>
                    <td class="table__date">${dob}</td>
                    <td class="table__group">${response[i].CustomerGroupName}</td>
                    <td class="table__phone">${response[i].PhoneNumber}</td>
                    <td class="table__email">${response[i].Email}</td>
                    <td class="table__address">${response[i].Address}</td>
                    <td class="table__debt">${response[i].DebitAmount || ""}</td>
                    <td class="table__card">${response[i].MemberCardCode}</td>
                </tr>`;
                console.log(trHtml);
                $('table#table >tbody').append(trHtml);

            }
        }).fail(function (response) {
            console.log(response);
        });
    }
    /**
     * Thực hiện gán các sự kiện
     * Author: tkt18
     * */
    function initEvents() {
        // Gán các sự kiện dialog
        $('#btnAdd').click(function () {
            dialog.dialog('open')
        });

        $('#btnCancel').click(function () {
            dialog.dialog('close')
        });

        $('#btnSave').click(function () {
            dialog.dialog('close')
        });
        // Upload Image
        $(".avatar").on('click', '#avatar', function () {
            $('#avatarUpload').click()
        });
        // avatar image preview
        $("#avatarUpload").change(function () {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#avatar').replaceWith(`<img id="avatar" class="avatar__image" src="${e.target.result}" alt="Ảnh đại diện">`);
            }
            reader.readAsDataURL(this.files[0]);
        });
    }
    /**
     * Thực hiện định dạng ngày tháng (ngày/tháng/năm)
     * @param {Date} date ngày truyền vào
     * Author: tkt18
     */
    function formatDate(date) {
        var date = new Date(date);
        return `${date.getDate() < 10 ? "0" + date.getDate() : date.getDate()}/${date.getMonth() < 9 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1}/${date.getFullYear()}`;
    }
    // build html và append lên UI



})