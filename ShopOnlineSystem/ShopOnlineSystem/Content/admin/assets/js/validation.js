var password = document.getElementById("inputPassword");
var confirm_password = document.getElementById("inputPassword2");

function validatePassword() {
    if (password.value != confirm_password.value) {
        confirm_password.setCustomValidity("Mật khẩu không trùng khớp!");
    } else {
        confirm_password.setCustomValidity('');
    }
}

password.onchange = validatePassword;
confirm_password.onkeyup = validatePassword;