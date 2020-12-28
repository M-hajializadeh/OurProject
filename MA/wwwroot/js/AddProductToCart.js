function AddCart(number) {
    var i = "#productid_" + number;
    var data = new FormData();
    var id = $(i).val();
    data.append('id', id);

    $.ajax({
        type: "Post",
        url: "/Basket/AddCart",
        contentType: false,
        processData: false,
        data: data,

    }).done(function (res) {
        if (res.status === "success") {
            alert(res.message);
        }
        else { alert("در ثبت اطلاعات مشکلی پیش امد."); }
    });
}


