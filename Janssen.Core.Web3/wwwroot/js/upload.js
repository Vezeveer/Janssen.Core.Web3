var CLOUDINARY_URL = 'https://api.cloudinary.com/v1_1/sajcti/image/upload';
var CLOUDINARY_UPLOAD_PRESET = 'qp0czmjt';

const imgPreviewConfig = "upload/w_300,q_auto:low/";

var imgPreview = document.getElementById('img-preview');
var fileUpload = document.getElementById('file-upload');
var elem = document.getElementById("myBar");

var imgPreview2 = document.getElementById('img-preview2');
var fileUpload2 = document.getElementById('file-upload2');
var elem2 = document.getElementById("myBar2");

var imgPreview3 = document.getElementById('img-preview3');
var fileUpload3 = document.getElementById('file-upload3');
var elem3 = document.getElementById("myBar3");

document.getElementById("file-upload").onchange = function (event) {
    // Show the loading image.
    $('#img-loader').show();

    // When main image loads:
    $('#img-preview').on('load', function () {
        // Fade out and hide the loading image.
        $('#img-loader').fadeOut(100); // Time in milliseconds.
    });
    elem.style.backgroundColor = "#4caf50";
    if (event.target.files[0].size > 2097152) { //2097152 equals 2mb
        var size = +(event.target.files[0].size / 1000000).toFixed(2);
        alert("You tried to upload a " + size + "mb sized file which is too large. Please upload a file less than 2mb");
        event.target.value = "";
    } else {
        var file = event.target.files[0];
        var formData = new FormData();
        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);

        axios({
            url: CLOUDINARY_URL,
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            data: formData,
            onUploadProgress: function (progressEvent) {
                var percentCompleted = Math.round((progressEvent.loaded * 100) / progressEvent.total);
                elem.style.width = percentCompleted + "%";
                elem.innerHTML = percentCompleted + "%";
                console.log("Progress:-" + percentCompleted);
            }
        }).then(function (res) {
            var ImgUrl = res.data.secure_url;
            imgPreview.src = ImgUrl.replace(/upload\//g, imgPreviewConfig);

            document.getElementById('url-psa-img').value = ImgUrl;
            elem.innerHTML = "Success";

        }).catch(function (err) {
            console.error(err);
            imgPreview.src = "imgs/error-upload.jpg";

            document.getElementById('url-psa-img').value = "";
            elem.style.width = "10%";
            elem.style.backgroundColor = "red";
            elem.innerHTML = "Failed";
        });
    };
};

document.getElementById("file-upload2").onchange = function (event) {
    // Show the loading image.
    $('#img-loader2').show();

    // When main image loads:
    $('#img-preview2').on('load', function () {
        // Fade out and hide the loading image.
        $('#img-loader2').fadeOut(100); // Time in milliseconds.
    });
    elem2.style.backgroundColor = "#4caf50";
    if (event.target.files[0].size > 2097152) { //2097152 equals 2mb
        var size = +(event.target.files[0].size / 1000000).toFixed(2);
        alert("You tried to upload a " + size + "File size is too large. ");
        event.target.value = "";
    } else {
        var file = event.target.files[0];
        var formData = new FormData();
        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);

        axios({
            url: CLOUDINARY_URL,
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            data: formData,
            onUploadProgress: function (progressEvent) {
                var percentCompleted = Math.round((progressEvent.loaded * 100) / progressEvent.total);
                elem2.style.width = percentCompleted + "%";
                elem2.innerHTML = percentCompleted + "%";
                console.log("Progress:-" + percentCompleted);
            }
        }).then(function (res) {
            console.log(res);
            var ImgUrl = res.data.secure_url;
            imgPreview2.src = ImgUrl.replace(/upload\//g, imgPreviewConfig);

            document.getElementById('url-psa-img2').value = ImgUrl;
            elem2.innerHTML = "Success";

        }).catch(function (err) {
            console.error(err);
            imgPreview2.src = "imgs/error-upload.jpg";

            elem2.style.width = 10 + "%";
            elem2.style.backgroundColor = "red";
            elem2.innerHTML = "Failed";
        });
    };
};

document.getElementById("file-upload3").onchange = function (event) {
    // Show the loading image.
    $('#img-loader3').show();

    // When main image loads:
    $('#img-preview3').on('load', function () {
        // Fade out and hide the loading image.
        $('#img-loader3').fadeOut(100); // Time in milliseconds.
    });
    elem3.style.backgroundColor = "#4caf50";
    if (event.target.files[0].size > 2097152) { //2097152 equals 2mb
        var size = +(event.target.files[0].size / 1000000).toFixed(2);
        alert("You tried to upload a " + size + "File size is too large. ");
        event.target.value = "";
    } else {
        var file = event.target.files[0];
        var formData = new FormData();
        formData.append('file', file);
        formData.append('upload_preset', CLOUDINARY_UPLOAD_PRESET);

        axios({
            url: CLOUDINARY_URL,
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            data: formData,
            onUploadProgress: function (progressEvent) {
                var percentCompleted = Math.round((progressEvent.loaded * 100) / progressEvent.total);
                elem3.style.width = percentCompleted + "%";
                elem3.innerHTML = percentCompleted + "%";
            }
        }).then(function (res) {
            var ImgUrl = res.data.secure_url;
            imgPreview3.src = ImgUrl.replace(/upload\//g, imgPreviewConfig);

            document.getElementById('url-psa-img2').value = ImgUrl;
            elem3.innerHTML = "Success";

        }).catch(function (err) {
            console.error(err);
            imgPreview3.src = "imgs/error-upload.jpg";

            elem3.style.width = 10 + "%";
            elem3.style.backgroundColor = "red";
            elem3.innerHTML = "Failed";
        });
    };
};

var originalAlert = window.alert;

window.alert = function (args) {
    document.querySelector("html").classList.add("darkenPage");
    setTimeout(function () {
        originalAlert(args);
        document.querySelector("html").classList.remove("darkenPage");
    });
}

