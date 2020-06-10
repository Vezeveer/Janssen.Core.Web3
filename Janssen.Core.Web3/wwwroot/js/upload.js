var CLOUDINARY_URL = 'https://api.cloudinary.com/v1_1/sajcti/image/upload';
var CLOUDINARY_UPLOAD_PRESET = 'qp0czmjt';

const imgPreviewConfig = "upload/w_300,q_auto:low/";

for (let i = 1; i < 5; i++){
    document.getElementById(`file-upload${i}`).onchange = handleEvent(`#img-loader${i}`, `img-preview${i}`,
        document.getElementById(`myBar${i}`), `url-psa-img${i}`);
};

function handleEvent(imgLoaderID, imgPreviewID, elem, urlImgID) {
    return function (event) {
        uploadFile(event, imgLoaderID, imgPreviewID, elem, urlImgID);
    };
}

function uploadFile(event, imgLoaderID, imgPreviewID, elem, urlImgID) {
    // Show the loading image.
    $(imgLoaderID).show();
    console.log("Loader shows...");
    // When main image loads:
    $("#"+imgPreviewID).on('load', function () {
        console.log("fades....");
        // Fade out and hide the loading image.
        $(imgLoaderID).fadeOut(100); // Time in milliseconds.
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
            document.getElementById(imgPreviewID).src = ImgUrl.replace(/upload\//g, imgPreviewConfig);

            document.getElementById(urlImgID).value = ImgUrl;
            elem.innerHTML = "Success";

        }).catch(function (err) {
            console.error(err);
            document.getElementById(imgPreviewID).src = "imgs/error-upload.jpg";

            document.getElementById(urlImgID).value = "";
            elem.style.width = "10%";
            elem.style.backgroundColor = "red";
            elem.innerHTML = "Failed";
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

function CheckOtherGuardians(val) {
    var element = document.getElementById('guardians');
    if (val == 'others')
        element.style.display = 'block';
    else
        element.style.display = 'none';
}

function HowTheyFindUs(val) {
    var element = document.getElementById('HowTheyFindUs');
    if (val == 'others')
        element.style.display = 'block';
    else
        element.style.display = 'none';
}

$('#student-enroll-form').submit(function () {
    $('#loader-wrapper').show();

    return true; // return false to cancel form action
});

    //beforeSubmit = function () {
    //    console.log("submitted...");
    //                    $('.loader-wrapper').show();

    //                    setTimeout(() => {
    //    $("#formid").submit();
    //                        console.log("we waited 204586560000 ms to run this code, oh boy wowwoowee!");
    //                    }, 5000);

    //}
