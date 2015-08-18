(function (g) {

    g.Init = function () {

        $("#btnNew").click(function () {
            $.ajax({
                url: '/Reporte/RpteDimensional/GenerarReporte',
                type: "POST",
                data: $("#" + 'FrmRpteDimensional').serialize(),
                beforeSend: function (xhr) {
                    $(":input").attr("disabled", "disabled");
                }
            }).done(function (data) {
                $(":input").removeAttr("disabled");
                if (data == "Success") {
                    g.Success();
                }
                else if (data == "Error") {
                    //g.fail();
                    g.CreateDialog("dlgMsj", "No hay resultados disponibles", "No se encontraron datos de su consulta. Favor de intentar nuevamente");
                }
            })            
        });

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

        g.Cancelar = function () {
            document.location.href = "/Reporte/RpteDimensional/";
        }

        g.Success = function () {
            $('form').get(0).setAttribute('action', '/Reporte/RpteDimensional/GenerarRepo');
            $("#FrmRpteDimensional").submit();
        }

        

        //$("#btnNew").click(function () {
        //    $('form').get(0).setAttribute('action', '/Reporte/RpteDimensional/GenerarReporte');
        //    $("#FrmRpteDimensional").submit();
        //});

        

    };

})(ADS.Reporte.Dimensional = {});