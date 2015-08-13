
(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Catalogo/Equipo/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['CodigoActivoFijo', 'Serie', 'Marca', 'Modelo', 'Planta', '', '', ''],
            colModel: [
                        { name: 'CodigoActivoFijo', index: 'CodigoActivoFijo', align: 'left', width: 90, searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Serie', index: 'Serie', align: 'left', width: 90, searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Marca', index: 'Marca', align: 'left', width: 110, searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Modelo', index: 'Modelo', align: 'left', width: 80, searchoptions: { sopt: ['cn'] }, stype: 'text' },                        
                        { name: 'Planta.NombrePlanta', index: 'Planta.NombrePlanta', align: 'left', width: 80, searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Id', index: 'Id', hidden: true },
                        //{ name: 'Detail', index: 'Detail', align: 'center', width: 50, sortable: false, search: false },
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
            subGrid: true,
            subGridModel: [{
                name: ['Informe Calibración', 'FechaCalibracion', 'Proveedor', 'PDFInforme'],
                width: [100, 100, 100],
                align: ['center', 'center', 'left', 'center']
            }],
            subGridUrl: '/Catalogo/Equipo/Detail',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var btnDetail = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Equipo.Detail('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-note\"></span></div>";
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Equipo.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Equipo.Delete('" + id + "');\" >" +
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
                            {
                                text: "OK", click: function () {
                                    g.Cancelar();
                                    ADS.ReloadGrid("grid");
                                }
                            }
                ]
            });
        };

        g.CreateDialogEdicion = function (dialogId, title, message) {
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
                            {
                                text: "OK", click: function () {
                                    $("#frmEquipo").submit();
                                    g.Cancelar();
                                }
                            }
                ]
            });
        };


        $("#dlg").dialog({
            autoOpen: false,
            width: 450,
            modal: true,
            height: 'auto',
            resizable: false,
            buttons: [
                        {
                            text: "Ok", click: function () {
                                ADS.AjaxPostCall("/Catalogo/Equipo/Delete", "frmEquipo", "dlg");
                                g.Cancelar();
                                //ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNewAjax").click(function () {
            ADS.LoadDialog("/Catalogo/Equipo/Create", "dlg")
        });

        $("#btnNew").click(function () {
            document.location.href = "/Catalogo/Equipo/Create"
        });

        $("#btnCreate").click(function () {
            $.ajax({
                url: '/Catalogo/Equipo/Create',
                type: "POST",
                data: $("#" + 'frmEquipo').serialize(),
                beforeSend: function (xhr) {
                    $(":input").attr("disabled", "disabled");
                }
            }).done(function (data) {
                $(":input").removeAttr("disabled");
                if (data == "Success") {
                    g.CreateDialog("dlgMsj", "Alta Satisfactoria", "El equipo se ha agreagado satisfactoriamente.");
                }
                else if (data == "Error") {
                    $("#frmEquipo").submit();
                    //g.fail();
                    //g.CreateDialog("dlgMsj", "Error", "El equipo no se ha podido crear, favor de verificar la información enviada.");
                }

            })
        });

        //$("#btnCreate").click(function () {
        //    $('form').get(0).setAttribute('action', '/Catalogo/Equipo/Create');
        //    $("#frmEquipo").submit();
        //});

        $("#btnConsulta").click(function () {
            ADS.Filter("grid");
        });

        g.Filter = function () {

        };

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/Equipo/Edit');
            g.CreateDialogEdicion("dlgMsj", "Edición Satisfactoria", "El equipo se ha modificado satisfactoriamente");
            //$("#frmEquipo").submit();
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Catalogo/Equipo/Create", "frmEquipo", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Catalogo/Equipo/";
    }

    g.Detail = function (id) {
        document.location.href = "/Catalogo/Equipo/Detail/" + id;
    }

    g.Edit = function (id) {
        document.location.href = "/Catalogo/Equipo/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Catalogo/Equipo/Delete/" + id, "dlg");
    };

})(ADS.Catalogo.Equipo = {});