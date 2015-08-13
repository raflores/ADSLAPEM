(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Catalogo/Especificacion/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Codigo', 'Norma.Nombre', 'NormaEnsayo.Nombre', 'Ensayo.Nombre', 'Minimo', 'Maximo', 'Objetivo', '', '', ''],
            colModel: [
                        { name: 'Codigo', index: 'Codigo', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Norma.Nombre', index: 'Norma.Nombre', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'NormaEnsayo.Nombre', index: 'NormaEnsayo.Nombre', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Ensayo.Nombre', index: 'Ensayo.Nombre', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Minimo', index: 'Minimo', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Maximo', index: 'Minimo', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Objetivo', index: 'Minimo', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Id', index: 'Id', hidden: true },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 25, sortable: false, search: false },
                        { name: 'Delete', index: 'Delete', align: 'center', width: 25, sortable: false, search: false }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'ProductoId',
            sortorder: "asc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Especificacion.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Especificacion.Delete('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-trash\"></span></div>";
                    $("#grid").jqGrid('setRowData', cell[i], { Edit: btnEdit });
                    $("#grid").jqGrid('setRowData', cell[i], { Delete: btnDelete });
                }
            }
        });

        $("#dlg").dialog({
            autoOpen: false,
            width: 450,
            modal: true,
            height: 'auto',
            resizable: false,
            buttons: [
                        {
                            text: "Ok", click: function () {
                                ADS.AjaxPostCall("/Catalogo/Especificacion/Delete", "frmEspecificacion", "dlg");
                                ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNewAjax").click(function () {
            ADS.LoadDialog("/Catalogo/Especificacion/Create", "dlg")
        });

        $("#btnNew").click(function () {
            document.location.href = "/Catalogo/Especificacion/Create"
        });

        $("#btnCreate").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/Especificacion/Create');
            $("#frmEspecificacion").submit();
        });

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/Especificacion/Edit');
            $("#frmEspecificacion").submit();
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });


    };

    g.Create = function () {
        ADS.AjaxPostCall("/Catalogo/Especificacion/Create", "frmEspecificacion", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Catalogo/Especificacion/";
    }

    g.Edit = function (id) {
        document.location.href = "/Catalogo/Especificacion/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Catalogo/Especificacion/Delete/" + id, "dlg");
    };


})(ADS.Catalogo.Especificacion = {});