// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function fnAlert(sms) {
    if (sms !== '' && sms === "Successfully") {
        alertify.success("บันทึกผ่าน");
    } else if (sms !== '' && sms === 'Deleted') {
        alertify.success("ลบข้อมูลสำเร็จ");
    } else if (sms !== '' && sms === 'Edited') {
        alertify.success("แก้ไขข้อมูลสำเร็จ");
    } else if (sms !== '' && sms === 'OpenPartsix') {
        alertify.success('บันทึกส่วนที่1-5 ผ่าน โปรดบันทึกมาตรการป้องกันอุบัติเหตุ ส่วนที่ 6 ต่อ');
    }
    else if (sms !== '') {
        alertify.message(sms, 0);
    }
}