(function (g) {

    g.Init = function () {
        $("#grid").jqGrid({
            url: '/Seguridad/Perfil/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Nombre', 'Descripcion', '', '', ''],
            colModel: [
                        { name: 'Nombre', index: 'Nombre', align: 'left', width:125, searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Descripcion', index: 'Descripcion', align: 'left', width:250, searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Id', index: 'Id', hidden: true, width:15 },
                        { name: 'Edit', index: 'Edit', align: 'center', width:15, sortable: false, search: false },
                        { name: 'Delete', index: 'Delete', align: 'center', width:15, sortable: false, search: false }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'Nombre',
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            width: 420,
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Seguridad.Perfil.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Seguridad.Perfil.Delete('" + id + "');\" >" +
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
                                ADS.AjaxPostCall("/Seguridad/Perfil/Delete", "frmPerfil", "dlg");
                                ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNew").click(function () {
            document.location.href = "/Seguridad/Perfil/Create"
        });

        $("#btnCreate").click(function () {
            $('form').get(0).setAttribute('action', '/Seguridad/Perfil/Create');
            $("#frmPerfil").submit();
        });

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Seguridad/Perfil/Edit');
            $("#frmPerfil").submit();
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Seguridad/Perfil/Create", "frmPerson", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Seguridad/Perfil/";
    }

    g.Edit = function (id) {
        document.location.href = "/Seguridad/Perfil/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Seguridad/Perfil/Delete/" + id, "dlg");
    };

})(ADS.Seguridad.Perfil = {});