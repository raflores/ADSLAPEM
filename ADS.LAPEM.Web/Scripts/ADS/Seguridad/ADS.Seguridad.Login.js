(function (g) {

    g.Init = function () {


        $("#dlg").dialog({
            autoOpen: false,
            width: 450,
            modal: true,
            height: 'auto',
            resizable: false,
            buttons: [
                        {
                            text: "Ok", click: function () {
                                ADS.AjaxPostCall("/Seguridad/Perfil/Delete", "frmPerfil", "dlg");
                                ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnLogin").click(function () {
            $('form').get(0).setAttribute('action', '/Seguridad/Account/Login');
            $("#frmLogin").submit();
        });       

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };
   

    g.Cancelar = function () {
        document.location.href = "/Seguridad/Account/";
    }
    

})(ADS.Seguridad.Login = {});