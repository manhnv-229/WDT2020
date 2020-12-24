function toat({
    message = '',
    type = 'info',
    duration = 2000
}) {
    var main = document.getElementById('toat');
    if (main) {
        var toat = document.createElement('div');
        
        var icon = {
            info: 'fas fa-info-circle',
            success: 'fas fa-check-circle',
            warning: 'fas fa-exclamation-circle',
            danger: 'fas fa-exclamation-triangle',
        }
        var delay = (duration / 1000).toFixed(2);
        toat.classList.add('toat', `toat--${type}`);
        toat.style.animation = `topDown ease 0.3s, fadeOut linear 1s ${delay}s forwards`;
        toat.innerHTML = `
            <div class="toat__icon"><i class="${icon[type]}"></i></div>
            <div class="toat__body">${message}</div>
            <div class="toat__close"><i class="fas fa-times"></i></div>
        `;
    }
    main.appendChild(toat);
    // automatic remove toat
    var timeOutId = setTimeout(function () {
        main.removeChild(toat);
    }, duration + 1000);
    // click remove toat
    toat.onclick = function (e) {
        if (e.target.closest('.toat__close')) {
            main.removeChild(toat);
            clearTimeout(timeOutId);
        }
    }
    
}

function showSucessToat() {
    toat({
        message: "thanhcong",
        type: 'success',
        duration: 2000
    })
}
function showWarningToat() {
    toat({
        message: "warning",
        type: 'warning',
        duration: 2000
    })
}
function showInfoToat() {
    toat({
        message: "info",
        type: 'info',
        duration: 4000
    })
}
function showDangerToat() {
    toat({
        message: "danger",
        type: 'danger',
        duration: 3000
    })
}