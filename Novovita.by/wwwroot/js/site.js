function getProducts(idForUpdate, categoryId) {
    $.ajax({
        type: "GET",
        url: "/Home/Filtered?categoryId=" + categoryId,
        success: function (response) {
            console.log('get products response', response);
            $(idForUpdate).html(response);
        },
        error: function (response) {
            $(idForUpdate).html(response.responseText);
            console.error(response);
        }
    });
}