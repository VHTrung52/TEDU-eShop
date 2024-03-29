﻿
var CartController = function () {
    this.initialize = function () {
        loadData();

        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-plus', function (e) {
            e.preventDefault();

            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) + 1;
            //alert(id);

            updateCart(id, quantity);
        });

        $('body').on('click', '.btn-minus', function (e) {
            e.preventDefault();

            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) - 1;
            updateCart(id, quantity);
        });

        $('body').on('click', '.btn-remove', function (e) {
            e.preventDefault();

            const id = $(this).data('id');
            //alert(id);

            updateCart(id, 0);
        });
    }

    function updateCart(id, quantity) {
        const languageId = $('#hiddenCulture').val();

        $.ajax({
            type: "POST",
            url: "/" + languageId + '/Cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                /*$('#txt_quantity_' + id).val(quantity);*/
                $('#lbl_number_items_header').text(res.length);
                loadData();
            },
            error: function (res) {
                console.log(res)
            }
        });
    }


    function loadData() {
        const languageId = $('hiddenCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + languageId + '/Cart/GetListItems',
            success: function (res) {
                if (res.length == 0) {
                    $('#tbl_cart').hide();
                }

                var html = '';
                var total = 0;

                $.each(res, function (i, item) {
                    var itemTotal = item.price * item.quantity
                    html +=
                        "<tr>"
                        + "<td> <img width=\"125\" src=\"" + item.imagePath + "\" alt=\"\" /></td>"
                        + "<td>" + item.description + "</td>"
                        + "<td>"
                    + "<div class=\"input-append\">"
                    + "<input class=\"span1\" style = \"max-width: 34px\" placeholder = \"1\" id=\"txt_quantity_" + item.productId + "\" size = \"16\" type = \"text\" value=\"" + item.quantity + "\">"
                    + "<button class=\"btn btn-plus\" data-id=\"" + item.productId + "\" type=\"button\"> <i class=\"icon-plus\"></i> </button>"
                    + "<button class=\"btn btn-minus\" data-id=\"" + item.productId + "\" type=\"button\"> <i class=\"icon-minus\"></i> </button > "
                    + "<button class=\"btn btn-danger btn-remove\" type=\"button\" data-id=\"" + item.productId + "\"> <i class=\"icon-remove icon-white\"></i></button>"
                        + "</div >"
                        + "</td>"
                    + "<td>" + numberWithCommas(item.price) + "</td>"
                    + "<td>" + numberWithCommas(0) + "</td>"
                        + "<td>" + numberWithCommas(itemTotal) + "</td>"
                        + "</tr>";
                    total += itemTotal;
                });
                $('#cart_body').html(html);
                $('#lbl_number_of_items').text(res.length);
                $('#lbl_total').text(numberWithCommas(total));
            },
            error: function (res) {
                console.log(res)
            }
        });
    }


}