(function (g) {

    g.Init = function () {


        $("#btnLogin").click(function () {
            $.ajax({
                url: '/Seguridad/Account/Login',
                type: "POST",
                data: $("#" + 'frmAccount').serialize(),
                beforeSend: function (xhr) {
                    $(":input").attr("disabled", "disabled");
                }
            }).done(function (data) {
                $(":input").removeAttr("disabled");
                if (data == "Success") {
                    g.Succes();
                }
                else if (data == "Error") {
                    //g.fail();
                    g.CreateDialog("dlgMsj", "Error de Autenticación", "Sus datos son incorrectos. Favor de intentar nuevamente");
                }
                
            })
            //$('form').get(0).setAttribute('action', '/Seguridad/Account/Login');
            //$("#frmAccount").submit();
        });        

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.CreateDialog = function (dialogId, title, message) {
        var NewDialog = $('<div id="mensajeDialog" title="' + title + '">\<p>' + message + '</p>\</div>');
        NewDialog.dialog({
            modal: false,
            autoOpen: true,
            width: 450,
            height: 'auto',
            resizable: false,
            //show: "blind",
            //hide: "explode",
            buttons: [
                        { text: "OK", click: function () { g.Cancelar(); } }
            ]
        });
    };
    
    $("#dlgValidacion").dialog({
        autoOpen: false,
        width: 450,
        modal: true,
        height: 'auto',
        resizable: false,
        buttons: [
                    { text: "Ok", click: function () { $(this).dialog("close"); } }
        ]
    });

    g.Cancelar = function () {
        document.location.href = "/Seguridad/Account/";
    }

    g.Succes = function () {
        document.location.href = "/Seguridad/Account/LoginSuccess/";
    }

    g.fail = function () {
        g.LoadDialog("/Seguridad/Account/LoginFail/", "dlgValidacion");
    };
    

})(ADS.Seguridad.Account = {});