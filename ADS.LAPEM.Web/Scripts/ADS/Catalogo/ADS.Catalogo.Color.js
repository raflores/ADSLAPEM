
(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Catalogo/Color/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Codigo', 'Nombre', 'Tipo Tubo', '', '', ''],
            colModel: [
                        { name: 'Codigo', index: 'Codigo', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Nombre', index: 'Nombre', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Tipo', index: 'Tipo', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Id', index: 'Id', hidden: true },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 25, sortable: false, search: false },
                        { name: 'Delete', index: 'Delete', align: 'center', width: 25, sortable: false, search: false }
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
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Color.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Color.Delete('" + id + "');\" >" +
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
                                    $("#frmColor").submit();
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
                                ADS.AjaxPostCall("/Catalogo/Color/Delete", "frmColor", "dlg");
                                g.Cancelar();
                                //ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNewAjax").click(function () {
            ADS.LoadDialog("/Catalogo/Color/Create", "dlg")
        });

        $("#btnNew").click(function () {
            document.location.href = "/Catalogo/Color/Create"
        });

        $("#btnCreate").click(function () {
            $.ajax({
                url: '/Catalogo/Color/Create',
                type: "POST",
                data: $("#" + 'frmColor').serialize(),
                beforeSend: function (xhr) {
                    $(":input").attr("disabled", "disabled");
                }
            }).done(function (data) {
                $(":input").removeAttr("disabled");
                if (data == "Success") {
                    g.CreateDialog("dlgMsj", "Alta Satisfactoria", "El color se ha agreagado satisfactoriamente.");
                }
                else if (data == "Error") {
                    $("#frmColor").submit();
                    //g.fail();
                    //g.CreateDialog("dlgMsj", "Error", "El color no se ha podido crear, favor de verificar la información enviada.");
                }

            })
        });

        $("#btnConsulta").click(function () {
            ADS.Filter("grid");
        });

        g.Filter = function () {

        };
        

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/Color/Edit');
            g.CreateDialogEdicion("dlgMsj", "Edición Satisfactoria", "El color se ha modificado satisfactoriamente");
            //$("#frmColor").submit();
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Catalogo/Color/Create", "frmColor", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Catalogo/Color/";
    }

    g.Edit = function (id) {
        document.location.href = "/Catalogo/Color/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Catalogo/Color/Delete/" + id, "dlg");
        ADS.ReloadGrid("grid");
    };
    

})(ADS.Catalogo.Color = {});