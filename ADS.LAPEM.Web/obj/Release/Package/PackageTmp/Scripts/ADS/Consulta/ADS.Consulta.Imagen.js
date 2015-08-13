(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Consulta/ConsultaAviso/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Num Aviso', 'Lote Identificador', 'Producto', 'Familia', 'Pedido', 'Cantidad', 'Costo', 'Moneda', ''],
            colModel: [
                        { name: 'NumAviso', index: 'NumAviso', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Identificador', index: 'Identificador', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Lote.Producto.Codigo', index: 'Lote.Producto.Codigo', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'FamiliaId', index: 'FamiliaId', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Pedido', index: 'Pedido', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Cantidad', index: 'Cantidad', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Costo', index: 'Costo', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Moneda', index: 'Moneda', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Id', index: 'Id', hidden: true }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'Id',
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true
            //height: '100%',
            //subGrid: true,
            //subGridModel: [{
            //    name: ['Norma.Nombre', 'NormaEnsayo.Nombre', 'ResultadoValor', 'Aprobado'],
            //    width: [100, 100, 100, 100],
            //    align: ['center', 'center', 'center', 'center']
            //}],
            //subGridUrl: '/Consulta/ConsultaAviso/GetDetail',
            //gridComplete: function () {
            //    var cell = $("#grid").jqGrid('getDataIDs');
            //    for (var i = 0; i < cell.length; i++) {
            //        var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
            //    }
            //}
        });

        $("#gridDetalle").jqGrid({
            url: '/Consulta/ConsultaHistorica/GetDetalle?id=0',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['LoteId', 'Ensayo', 'NormaUM', 'Resultado', 'Aprobado', ''],
            colModel: [
                        { name: 'LoteId', index: 'LoteId', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Ensayo.Nombre', index: 'Ensayo.Nombre', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaUM', index: 'NormaUM', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'ResultadoValor', index: 'ResultadoValor', align: 'center', searchoptions: { sopt: ['cn'] }, stype: 'text' },
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

        $("#btnConsulta").click(function () {
            ADS.Filter("grid");
        });

        g.Filter = function () {

        };

    };



})(ADS.Consulta.Imagen = {});