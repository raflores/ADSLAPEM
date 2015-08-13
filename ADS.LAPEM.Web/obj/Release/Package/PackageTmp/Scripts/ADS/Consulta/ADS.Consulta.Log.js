(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Consulta/ConsultaLog/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Nombre', 'Accion', 'Modulo', 'Fecha', ''],
            colModel: [
                        { name: 'Nombre', index: 'Nombre', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Accion', index: 'Accion', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Modulo', index: 'Modulo', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Fecha', index: 'Fecha', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
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
            //gridComplete: function () {
            //    var cell = $("#grid").jqGrid('getDataIDs');
            //    for (var i = 0; i < cell.length; i++) {
            //        var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
            //        var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Color.Edit('" + id + "');\" >" +
            //            "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
            //        var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Color.Delete('" + id + "');\" >" +
            //            "<span class=\"ui-icon ui-icon-trash\"></span></div>";
            //        $("#grid").jqGrid('setRowData', cell[i], { Edit: btnEdit });
            //        $("#grid").jqGrid('setRowData', cell[i], { Delete: btnDelete });
            //    }
            //}
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


})(ADS.Consulta.Log = {});