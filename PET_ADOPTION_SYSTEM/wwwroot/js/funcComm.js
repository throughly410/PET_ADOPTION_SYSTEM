//https://codingdailyblog.wordpress.com/2017/08/20/js-url-searchparams-get-%E6%8A%93%E5%8F%96%E7%B6%B2%E5%9D%80%E4%B8%ADget%E5%8F%83%E6%95%B8/
//取得網址參數
function getUrlParameter(param) {
    var urlString = location.href;
    var url = new URL(urlString);
    return url.searchParams.get(param);
}
//導向首頁
function redirectHomepage() {
    //document.location.href = location.host;
    document.location.href = '/home/index';
}
//上一頁
function previousPage() {
    window.history.back();
    let href = location.href;
    location.href = href.substr(0, href.lastIndexOf('/'));
}

function fetchJsonByPost(uri, data) {
    return fetch(uri, {
        method: 'POST',
        body: JSON.stringify(data),
        header: {
            'content-type': 'application/json',
            //'requestverificationtoken': document.querySelector('input[name="__RequestVerificationToken"]').value
        }  
    })
        .then(resolve => {
            return resolve.json();
        })
}

function fetchJsonByGet(url) {
    return fetch(url, {
        method: 'GET',
    })
        .then(resolve => {
            return resolve.json();
        })
}

