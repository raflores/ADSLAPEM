
(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Catalogo/TipoPrueba/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Nombre', 'Descripción', '', '', ''],
            colModel: [
                        { name: 'Nombre', index: 'Nombre', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Descripcion', index: 'Descripcion', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
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
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.TipoPrueba.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.TipoPrueba.Delete('" + id + "');\" >" +
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
                                    $("#frmTipoPrueba").submit();
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
                                ADS.AjaxPostCall("/Catalogo/TipoPrueba/Delete", "frmTipoPrueba", "dlg");
                                ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNewAjax").click(function () {
            ADS.LoadDialog("/Catalogo/TipoPrueba/Create", "dlg")
        });

        $("#btnNew").click(function () {
            document.location.href = "/Catalogo/TipoPrueba/Create"
        });

        $("#btnCreate").click(function () {
            $.ajax({
                url: '/Catalogo/TipoPrueba/Create',
                type: "POST",
                data: $("#" + 'frmTipoPrueba').serialize(),
                beforeSend: function (xhr) {
                    $(":input").attr("disabled", "disabled");
                }
            }).done(function (data) {
                $(":input").removeAttr("disabled");
                if (data == "Success") {
                    g.CreateDialog("dlgMsj", "Alta Satisfactoria", "El Tipo de Prueba se ha agreagado satisfactoriamente.");
                }
                else if (data == "Error") {
                    //g.fail();
                    g.CreateDialog("dlgMsj", "Error", "El El Tipo de Prueba no se ha podido crear, favor de verificar la información enviada.");
                }

            })
        });

        $("#btnConsulta").click(function () {
            ADS.Filter("grid");
        });

        g.Filter = function () {

        };

        //$("#btnCreate").click(function () {
        //    $('form').get(0).setAttribute('action', '/Catalogo/TipoPrueba/Create');
        //    $("#frmTipoPrueba").submit();
        //});

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/TipoPrueba/Edit');
            g.CreateDialogEdicion("dlgMsj", "Edición Satisfactoria", "El Tipo de Prueba se ha modificado satisfactoriamente");
            $("#frmTipoPrueba").submit();
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Catalogo/TipoPrueba/Create", "frmTipoPrueba", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Catalogo/TipoPrueba/";
    }

    g.Edit = function (id) {
        document.location.href = "/Catalogo/TipoPrueba/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Catalogo/TipoPrueba/Delete/" + id, "dlg");
    };

})(ADS.Catalogo.TipoPrueba = {});