(function (g) {

    g.Init = function () {
        $("#dtFechaProduccion").prop("disabled", true);
        $('#chkFiltraFecha').change(function () {            
            $("#dtFechaProduccion").prop("disabled", $(this).is(':checked')==false);
            
        });

    };


    
    

})(ADS.Reporte.Reporteador = {});