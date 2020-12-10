$(document).ready(function () {
	// load dữ liệu:
	// 1. b1: gọi server lấy dữ liệu (api.manhnv.net/api/customers)
	// call api ajax
	//debugger;// khi gap lenh se coi nhu breakpoint

	var dialog = $(".customer-dialog").dialog({
		autoOpen: false,
		height: 500,
		width: 750,
		modal: true,
	});

	// load data
	loadData();

	// Gán sự kiện
/**
* Hàm thực hiện gán các sự kiện
* Author: LQNGAN (07/12/2020)
* */
	function initEvents() {
		$('.add__customer').click(function () {
			dialog.dialog('open');
		})

		$('#cancel').click(function () {
			dialog.dialog('close');
		})
		$('#save').click(function () {
			dialog.dialog('close');
		})
		$('#add_save').click(function () {
			dialog.dialog('close');
		})
	}
	initEvents();

})
/**
 * Hàm thực hiện load dữ liệu
 * Author: LQNGAN (07/12/2020)
 * */
function loadData() {
	$.ajax({
		url: 'http://api.manhnv.net/api/customers', // địa chỉ
		method: 'GET', // lấy dữ liệu
		async: false
	}).done(function (response) {
		$('#tblist tbody').empty();
		for (var i = 0; i < response.length; i++) {
			console.log(response[i]);
			var DOB = formatDate(response[i].DateOfBirth);
			var trHtml = `<tr>
                    <td>${response[i].CustomerCode}</td>
                    <td>${response[i].FullName}</td>
                    <td>${response[i].GenderName}</td>
                    <td>${DOB}</td>
                    <td>${response[i].CustomerGroupName}</td>
                    <td>${response[i].PhoneNumber}</td>
                    <td>${response[i].Email}</td>
                    <td>${response[i].Address}</td>
                    <td>${response[i].DebitAmount || ""}</td>
                    <td>${response[i].MemberCardCode}</td>
                </tr>`;
			$('#tblist > tbody:last-child').append(trHtml);
		}

	}).fail(function (response) {

	})
}

/**
 * Hàm thực hiện gán các sự kiện
 * Author: LQNGAN (07/12/2020)
 * */


/**	
 * Hàm thực hiện định dạng ngày tháng năm (ngày/tháng/năm)
 * @param {any} date ngày truyền vào
 * Author: LQNGAN (07/12/2020)
 */
function formatDate(date) {
	var date = new Date(date);
	// get day
	var day = date.getDate();
	if (day < 10) {
		day = '0' + day;
    }
	// get month
	var month = date.getMonth() + 1;
	if (month < 10) {
		month = '0' + month;
    }
	// get full year

	var year = date.getFullYear();

	return day + '/' + month + '/' + year;

}