window.onload = function GetAttr() {
    $.ajax({
        type: "Get",
        url: "/Attributions/GetAttrs",
        data: "",
        success: function (msg) {
            var select = $("#Attrs");
            for (var i = 0; i < msg.length; i++) {
                select.append("<option value='" + msg[i].id + "'>" + msg[i].classDescription + "</option>");
            }

        }
    });
} 

