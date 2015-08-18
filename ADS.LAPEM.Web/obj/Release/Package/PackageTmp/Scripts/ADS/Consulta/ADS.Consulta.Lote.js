(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Consulta/ConsultaPorLote/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Lote Identificador', 'FechaProduccion', 'Nombre', 'Diametro(In)', 'NombrePlanta', ''],
            colModel: [
                        { name: 'Identificador', index: 'Identificador', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Fecha', index: 'Fecha', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },                        
                        { name: 'Nombre', index: 'Nombre', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'ValorIn', index: 'ValorIn', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NombrePlanta', index: 'NombrePlanta', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },                        
                        { name: 'Id', index: 'Id', hidden: true }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'Identificador',
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
            subGridUrl: '/Consulta/ConsultaPorLote/GetDetail',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                }
            },
            onSelectRow: function(id) {
                if (id != null) {
                    if ($("#gridDetalle").jqGrid('getGridParam', 'records') > 0) {                        
                        $("#gridDetalle").jqGrid('setGridParam', { url: '/Consulta/ConsultaPorLote/GetDetalle?id=' + id })
                        ADS.ReloadGrid("gridDetalle");
                        $("#dlg").dialog("open");
                    }
                }
            }
        });

        $("#gridDetalle").jqGrid({
            url: '/Consulta/ConsultaPorLote/GetDetalle?id=0',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['LoteId', 'Norma', 'Prueba', 'Producto', 'MuestraNum', 'NormaUM', 'Resultado', 'Aprobado', ''],
            colModel: [
                        { name: 'LoteId', index: 'LoteId', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Norma', index: 'Norma', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'PruebaDesc', index: 'PruebaDesc', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'ProductoDesc', index: 'ProductoDesc', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'MuestraNum', index: 'MuestraNum', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaUM', index: 'NormaUM', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaRev', index: 'NormaRev', align: 'center', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Aprobado', index: 'Aprobado', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Id', index: 'Id', hidden: true }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'LoteId',
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                var registro = $("#grid").jqGrid('getRowData'); //obtiene todos los registros con todos los datos
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');                    

                }
            }
        });
        

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
        

        //$("#btnConsulta").click(function () {
        //    $('form').get(0).setAttribute('action', '/Consulta/ConsultaPorLote/Buscar');
        //    $("#FrmConsultaLote").submit();
        //});

        $("#btnConsulta").click(function () {
            ADS.Filter("grid"); 
        });

        g.Filter = function () {

        };

        //g.Consulta = function (id) {
        //    document.location.href = "/Consulta/ConsultaPorLote/Buscar/" + id;
        //};

    };

})(ADS.Consulta.Lote = {});