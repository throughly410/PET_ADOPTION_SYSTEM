(function () {
    document.querySelector('.blockUI').style.display = 'none';
    document.querySelector('.login').style.display = 'none';
})()

function openLoginDialog() {
    toggleBlockUI();
    openDialog('.login');
}

function toggleBlockUI() {
    var blockUI = document.querySelector('.blockUI');
    if (blockUI.style.display == 'none') {
        blockUI.style.display = 'block';
    }
    else {
        blockUI.style.display = 'none';
    }
}
function openDialog(prefix) {
    var objUI = document.querySelector(prefix);
    if (objUI.style.display == 'none') {
        objUI.style.display = 'block';
    }
    else {
        objUI.style.display = 'none';
    }
}