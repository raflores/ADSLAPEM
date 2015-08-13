(function (g) {

    g.Init = function () {

        $("#btnNew").click(function () {
            document.location.href = "/Reporte/Test/GeneraReporte"
        });

        g.Create = function () {
            ADS.AjaxPostCall("/Reporte/Test/GeneraReporte", "FrmTestReporte", "dlg");
        };

    };

    })(ADS.Reporte.Test = {});