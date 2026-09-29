$(document).ready(function () {

    $("#savebtn").click(function () {

        var obj = $("#roleform").serialize();
        $.ajax({
            url: '/Role/AddRole',
            type: 'POST',
            data:obj,
            dataType: 'json',
            success: function (res) {
                alert(res.mess);
                FetchRoles();

            },
            error: function (res) {
                alert('error');
            }

        })

    });

    function FetchRoles() {

        $.ajax({
            url: '/Role/GetRoles',
            type: 'GET',
            dataType: 'json',
            success: function (roles) {
                var obj = '';

                $.each(roles, function (i, r) {
                    obj += "<tr>";
                    obj += "<td>" + r.role_id + "</td>";
                    obj += "<td>" + r.role_name + "</td>";
                    obj += "<td>" + r.description + "</td>";

                    obj += "</tr>";
                });
                $("#rolebody").html(obj);

            },

        })
    };

    $("#deleterole").click(function(){

        $.ajax({
            url: '/Role/DeleteRoles',


        })

    })
});