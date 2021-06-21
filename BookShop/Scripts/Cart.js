var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtAmount');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    amount: $(item).val(),
                    Book: {
                        Id: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        $('#btnDelete').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/Delete',
                data: { id: $(this).data('id') },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
    }
}
cart.init();