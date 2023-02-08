
$(document).ready(function () {


    $("#deleteImage").click(function (e) {
        e.preventDefault();
        let url = $(this).attr("href");

        fetch(url).then(data => data.text())
            .then(res => {
                $(".proImg").html(res);
            })
    });
})