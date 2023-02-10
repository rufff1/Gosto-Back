

$(document).ready(() => {

    $(".searchInput").keyup(function () {
        let inputVal = $(this).val();

        if (inputVal.length <= 0) {
            $(".searchList").html('');
        } else {
            fetch("http://localhost:63147/Blog/Search/?search=" + inputVal)
                .then(response => {
                    if (response.ok) {
                        console.log('Okey');
                        return response.text()
                    }
                })
                .then(data => {
                    $("#searcPar").html(data);
                })
        }





    })


    $(".addtobasket").click(function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url)
            .then(res => {
                return res.text();
            })
            .then(data => {

                $(".header-cart").html(data);
            })
  
    })


    $(document).on("click", ".product-close", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");


        fetch(url)
            .then(res => {
                return res.text();
            })
            .then(data => {

                $(".header-cart").html(data);
            })

    })


    $(".addtobasket").click(function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url)
            .then(res => {
                return res.text();
            })
            .then(data => {

                $(".mobile-cart").html(data);
            })

    })


    $(document).on("click", ".product-close", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");


        fetch(url)
            .then(res => {
                return res.text();
            })
            .then(data => {

                $(".mobile-cart").html(data);
            })

    })
})