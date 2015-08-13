(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Catalogo/AvisoPrueba/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Identificador', 'Codigo', 'Linea.Nombre', 'Turno.NombreTurno', 'FechaProduccion', 'CantidadProducida', 'Aprobado', ''],
            colModel: [
                        { name: 'Identificador', index: 'Identificador', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Codigo', index: 'Codigo', align: 'left',  searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Linea.Nombre', index: 'Linea.Nombre', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Turno.NombreTurno', index: 'Turno.NombreTurno', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'FechaProduccion', index: 'FechaProduccion', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'CantidadProducida', index: 'CantidadProducida', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Aprobado', index: 'Aprobado', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Id', index: 'Id', hidden: true }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'Identificador',
            multiselect: true,
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            subGrid: true,
            subGridModel: [{
                name: ['Norma.Nombre', 'NormaEnsayo.Nombre', 'ResultadoValor', 'Aprobado'],
                width: [100, 100, 100, 100],
                align: ['center', 'center', 'center', 'center']
            }],
            subGridUrl: '/Catalogo/AvisoPrueba/GetDetail'
        });

        $("#btnNew").click(function () {
            var array = $("#grid").jqGrid('getGridParam', 'selarrrow');
            for (var i = 0; i < array.length; i++) {
                $("#avResultado").append("<input type='hidden' name='Lote["+ i +"].Id' value='" + array[i] + "' />");
            }
            g.CreateDialog("dlgMsj", "Lotes Enviados Satisfactoriamente", "Se enviaron " + array.length + " lotes");
            //$("#dlg").dialog("open");
            $("#FrmAvisoPrueba").submit();            
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

        $("#dlg").dialog({
            autoOpen: false,
            width: 1000,
            modal: true,
            height: 'auto',
            resizable: false,
            buttons: [
                        { text: "Aceptar", click: function () { $(this).dialog("close"); } }
            ]
        });

        g.Cancelar = function () {
            document.location.href = "/Catalogo/AvisoPrueba/";
        }

        g.EnviarAviso = function (id) {
            document.location.href = "/Catalogo/AvisoPrueba/EnviarAviso/" + id;
        };

        //g.EnviarAviso = function (id) {
        //    document.location.href = "/Catalogo/AvisoPrueba/EnviarAviso/" + id;
        //};

        

        
    };

    

})(ADS.Catalogo.AvisoPrueba = {});