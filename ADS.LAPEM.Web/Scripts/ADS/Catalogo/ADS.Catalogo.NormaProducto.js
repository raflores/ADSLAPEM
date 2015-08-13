
(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Catalogo/NormaProducto/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Nombre', '', '', ''],
            colModel: [
                        { name: 'Nombre', index: 'Nombre', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Id', index: 'Id', hidden: true },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 20, sortable: false, search: false },
                        { name: 'Delete', index: 'Delete', align: 'center', width: 20, sortable: false, search: false }
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
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.NormaProducto.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.NormaProducto.Delete('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-trash\"></span></div>";                    
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
                                ADS.AjaxPostCall("/Catalogo/NormaProducto/Delete", "frmNormaProducto", "dlg");
                                ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNewAjax").click(function () {
            ADS.LoadDialog("/Catalogo/NormaProducto/Create", "dlg")
        });

        $("#btnNew").click(function () {
            document.location.href = "/Catalogo/NormaProducto/Create"
        });

        $("#btnCreate").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/NormaProducto/Create');
            $("#frmNormaProducto").submit();
        });

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/NormaProducto/Edit');
            $("#frmNormaProducto").submit();
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Catalogo/NormaProducto/Create", "frmNormaProducto", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Catalogo/NormaProducto/";
    }

    g.Edit = function (id) {
        document.location.href = "/Catalogo/NormaProducto/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Catalogo/NormaProducto/Delete/" + id, "dlg");
    };

})(ADS.Catalogo.NormaProducto = {});