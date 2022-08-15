var SiteController = function () {
    this.initialize = function () {
        registerEvents();
        loadCart();
    }
}
function loadCart() {
    const languageId = $('hiddenCulture').val();
    $.ajax({
        type: "GET",
        url: "/" + languageId + '/Cart/GetListItems',
        success: function (res) {
            $('#lbl_number_items_header').text(res.length);
        },
        error: function (res) {
            console.log(res)
        }
    });
}
function registerEvents() {
    $('body').on('click', '.btn-add-cart', function (e) {
        e.preventDefault();

        const languageId = $('#hiddenCulture').val();
        const id = $(this).data('id');

        //alert(id);

        $.ajax({
            type: "POST",
            url: "/" + languageId + '/Cart/AddToCart',
            data: {
                languageId: languageId,
                id: id
            },
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
            },
            error: function (res) {
                console.log(res)
            }
        });
    });
}


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}


