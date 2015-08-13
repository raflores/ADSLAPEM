(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Consulta/ConsultaHistorica/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Identificador', 'Codigo', 'Planta', 'Linea', 'Turno', 'FechaProduccion', 'CantidadProducida', 'Estatus', '', ''],
            colModel: [
                        { name: 'Identificador', index: 'Identificador', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Codigo', index: 'Codigo', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Linea.Planta.NombrePlanta', index: 'Linea.Planta.NombrePlanta', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Linea.Nombre', index: 'Linea.Nombre', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Turno.NombreTurno', index: 'Turno.NombreTurno', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'FechaProduccion', index: 'FechaProduccion', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'CantidadProducida', index: 'CantidadProducida', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Aprobado', index: 'Aprobado', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 30, sortable: false, search: false },            
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
            subGrid: true,
            subGridModel: [{
                name: ['Norma.Nombre', 'NormaEnsayo.Nombre', 'ResultadoValor', 'Aprobado'],
                width: [100, 100, 100, 100],
                align: ['center', 'center', 'center', 'center']
            }],
            subGridUrl: '/Consulta/ConsultaHistorica/GetDetail',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                var registro = $("#grid").jqGrid('getRowData');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var regla = registro[i].Aprobado;
                    var btnEdit = "<div align=\"center\">";

                    if (regla == 'Aprobado') {
                        btnEdit += "<span class=\"ui-icon ui-icon-check\"></span>";
                        $("#grid").jqGrid('setCell', cell[i], 'Aprobado', '', { 'background-color': 'green', color: 'white', weightfont: 'bold' });
                    }
                    else
                    {
                        $("#grid").jqGrid('setCell', cell[i], 'Aprobado', '', { 'background-color': 'yellow', color: 'white', weightfont: 'bold' });
                        btnEdit += "<span class=\"ui-icon ui-icon-closethick\"></span>";
                    }
                        

                    btnEdit += "</div>";
                    $("#grid").jqGrid('setRowData', cell[i], { Edit: btnEdit });
                }
            },
            onSelectRow: function (id) {
                if (id != null) {
                    if ($("#gridDetalle").jqGrid('getGridParam', 'records') > 0) {
                        $("#gridDetalle").jqGrid('setGridParam', { url: '/Consulta/ConsultaHistorica/GetDetalle?id=' + id })
                        ADS.ReloadGrid("gridDetalle");
                        $("#dlg").dialog("open");
                    }
                }
            }
        });

        $("#gridDetalle").jqGrid({
            url: '/Consulta/ConsultaHistorica/GetDetalle?id=0',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['LoteId', 'Ensayo', 'NormaUM', 'Minimo', 'Maximo', 'Resultado', 'Aprobado', 'Estatus', '', ''],
            colModel: [
                        { name: 'LoteId', index: 'LoteId', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Ensayo.Nombre', index: 'Ensayo.Nombre', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaUM', index: 'NormaUM', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaVMin', index: 'NormaVMin', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaVMax', index: 'NormaVMax', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'ResultadoValor', index: 'ResultadoValor', align: 'center', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Aprobado', index: 'Aprobado', align: 'center', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 30, sortable: false, search: false },
                        { name: 'NormaEnsayoId', index: 'NormaEnsayoId', hidden: true },
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
                    var lote = registro[i].LoteId;
                    var NeId = registro[i].Edit;
                    var btnEdit = "<div align=\"center\" onclick=\"ADS.Consulta.Historica.Generar('" + lote + "' , '" + NeId + "');\">";

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

        g.Generar = function (id, NeId) {

            if (NeId == '1') {
                document.location.href = "/Reporte/RpteDimensional/Generar/" + id;
            }

            if (NeId == '2') {
                document.location.href = "/Reporte/RpteRigidez/Generar/" + id;
            }

            if (NeId == '3') {
                document.location.href = "/Reporte/RpteAplastamiento/Generar/" + id;
            }


            if (NeId == '4') {
                document.location.href = "/Reporte/RpteImpacto/Generar/" + id;
            }

            if (NeId == '5') {
                document.location.href = "/Reporte/RpteHermeticidad/Generar/" + id;
            }

            if (NeId == '8') {
                document.location.href = "/Reporte/RpteAgrietamiento/Generar/" + id;
            }
        };





    };



})(ADS.Consulta.Historica = {});