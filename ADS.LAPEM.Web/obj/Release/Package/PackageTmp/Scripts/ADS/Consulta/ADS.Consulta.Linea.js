(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Consulta/ConsultaEnLinea/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Identificador', 'Codigo', 'Planta', 'Linea', 'Turno.NombreTurno', 'FechaProduccion', 'CantidadProducida', 'Aprobado', ''],
            colModel: [
                        { name: 'Identificador', index: 'Identificador', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Codigo', index: 'Codigo', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Linea.Planta.NombrePlanta', index: 'Linea.Planta.NombrePlanta', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
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
            sortname: 'FechaProduccion',
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            height: '100%',
            subGrid: true,
            subGridModel: [{
                name: ['Norma.Nombre', 'NormaEnsayo.Nombre', 'ResultadoValor', 'Aprobado2'],
                width: [100, 100, 100, 100],
                align: ['center', 'center', 'center', 'center']
            }],
            subGridUrl: '/Consulta/ConsultaEnLinea/GetDetail',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                var registro = $("#grid").jqGrid('getRowData');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var regla = registro[i].Aprobado;

                    if (regla == 'Aprobado') {                        
                        $("#grid").jqGrid('setCell', cell[i], 'Aprobado', '', { 'background-color': 'green', color: 'white', weightfont: 'bold' });
                    }
                    else {
                        $("#grid").jqGrid('setCell', cell[i], 'Aprobado', '', { 'background-color': 'red', color: 'white', weightfont: 'bold' });                       
                    }
                }
            },
            onSelectRow: function (id) {
                if (id != null) {
                    if ($("#gridDetalle").jqGrid('getGridParam', 'records') > 0) {
                        $("#gridDetalle").jqGrid('setGridParam', { url: '/Consulta/ConsultaEnLinea/GetDetalle?id=' + id })
                        ADS.ReloadGrid("gridDetalle");
                        $("#dlg").dialog("open");
                    }
                }
            }
        });

        $("#gridDetalle").jqGrid({
            url: '/Consulta/ConsultaEnLinea/GetDetalle?id=0',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['LoteId', 'Ensayo', 'NormaUM', 'Minimo', 'Maximo', 'Resultado', 'Estatus2', 'Estatus', ''],
            colModel: [
                        { name: 'LoteId', index: 'LoteId', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Ensayo.Nombre', index: 'Ensayo.Nombre', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaUM', index: 'NormaUM', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaVMin', index: 'NormaVMin', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaVMax', index: 'NormaVMax', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'ResultadoValor', index: 'ResultadoValor', align: 'center', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Aprobado', index: 'Aprobado', align: 'center', hidden: true, searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 30, sortable: false, search: false },
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
                var cell = $("#gridDetalle").jqGrid('getDataIDs');
                var registro = $("#gridDetalle").jqGrid('getRowData'); //obtiene todos los registros con todos los datos
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#gridDetalle').jqGrid('getCell', cell[i], 'Id');
                    var regla = registro[i].Aprobado;
                    var btnEdit = "<div align=\"center\">";

                    if (regla == 'Aprobado') {
                        btnEdit += "<span class=\"ui-icon ui-icon-check\"></span>";
                        $("#gridDetalle").jqGrid('setCell', cell[i], 'ResultadoValor', '', { 'background-color': 'green', color: 'white', weightfont: 'bold' });
                    }
                    else {
                        btnEdit += "<span class=\"ui-icon ui-icon-closethick\"></span>";
                        $("#gridDetalle").jqGrid('setCell', cell[i], 'ResultadoValor', '', { 'background-color': 'red', color: 'white', weightfont: 'bold' });
                    }

                    btnEdit += "</div>";
                    $("#gridDetalle").jqGrid('setRowData', cell[i], { Edit: btnEdit });

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



})(ADS.Consulta.Linea = {});