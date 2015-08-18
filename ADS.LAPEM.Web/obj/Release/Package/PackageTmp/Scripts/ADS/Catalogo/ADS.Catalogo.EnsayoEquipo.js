
(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Catalogo/EnsayoEquipo/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Serie', 'Marca', 'Modelo', 'Descripcion', '', '', ''],
            colModel: [
                        { name: 'Serie', index: 'Serie', align: 'left', width: 90, searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Marca', index: 'Marca', align: 'left', width: 110, searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Modelo', index: 'Modelo', align: 'left', width: 80, searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Descripcion', index: 'Descripcion', align: 'left', search: false },
                        { name: 'Id', index: 'Id', hidden: true },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 25, sortable: false, search: false },
                        { name: 'Delete', index: 'Delete', align: 'center', width: 25, sortable: false, search: false }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'Serie',
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var btnDetail = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.EnsayoEquipo.Detail('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-note\"></span></div>";
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.EnsayoEquipo.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.EnsayoEquipo.Delete('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-trash\"></span></div>";
                    $("#grid").jqGrid('setRowData', cell[i], { Detail: btnDetail });
                    $("#grid").jqGrid('setRowData', cell[i], { Edit: btnEdit });
                    $("#grid").jqGrid('setRowData', cell[i], { Delete: btnDelete });
                }
            }
        });

        //$("#grid").jqGrid('filterToolbar', { searchOperators: true });

        //$("#grid").jqGrid('navGrid', '#pager', { view: false, edit: false, add: false, del: false },
        //    {}, //settings for edit
        //    {}, //settings for add
        //    {}, //delete
        //    {closeOnEscape: true, multipleSearch: false, closeAfterSearch: true},
        //    {});


        $("#dlg").dialog({
            autoOpen: false,
            width: 450,
            modal: true,
            height: 'auto',
            resizable: false,
            buttons: [
                        {
                            text: "Ok", click: function () {
                                ADS.AjaxPostCall("/Catalogo/EnsayoEquipo/Delete", "frmEnsayoEquipo", "dlg");
                                ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNewAjax").click(function () {
            ADS.LoadDialog("/Catalogo/EnsayoEquipo/Create", "dlg")
        });

        $("#btnNew").click(function () {
            document.location.href = "/Catalogo/EnsayoEquipo/Create"
        });

        $("#btnCreate").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/EnsayoEquipo/Create');
            $("#frmEnsayoEquipo").submit();
        });

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/EnsayoEquipo/Edit');
            $("#frmEnsayoEquipo").submit();
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Catalogo/EnsayoEquipo/Create", "frmEnsayoEquipo", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Catalogo/EnsayoEquipo/";
    }

    g.Detail = function (id) {
        document.location.href = "/Catalogo/EnsayoEquipo/Detail/" + id;
    }

    g.Edit = function (id) {
        document.location.href = "/Catalogo/EnsayoEquipo/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Catalogo/EnsayoEquipo/Delete/" + id, "dlg");
    };

})(ADS.Catalogo.EnsayoEquipo = {});