
(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Catalogo/Calibracion/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['NoInformeCalib', 'CodigoActivoFijo', 'FechaCalibracion', 'FechaVencimiento', 'PDFInforme', '', '', ''],
            colModel: [
                        { name: 'NoInformeCalib', index: 'NoInformeCalib', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'CodigoActivoFijo', index: 'CodigoActivoFijo', width: 200, align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'FechaCalibracion', index: 'FechaCalibracion', width: 150, align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'FechaVencimiento', index: 'FechaVencimiento', width: 150, align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'PDFInforme', index: 'PDFInforme', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Id', index: 'Id', hidden: true },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 25, sortable: false, search: false },
                        { name: 'Delete', index: 'Delete', align: 'center', width: 25, sortable: false, search: false }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'NoInformeCalib',
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Calibracion.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Calibracion.Delete('" + id + "');\" >" +
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
                                    $("#frmCalibracion").submit();
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
                                ADS.AjaxPostCall("/Catalogo/Calibracion/Delete", "frmCalibracion", "dlg");
                                g.Cancelar();
                                ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNewAjax").click(function () {
            ADS.LoadDialog("/Catalogo/Calibracion/Create", "dlg")
        });

        $("#btnNew").click(function () {
            document.location.href = "/Catalogo/Calibracion/Create"
        });

        $("#btnCreate").click(function () {
            $.ajax({
                url: '/Catalogo/Calibracion/Create',
                type: "POST",
                data: $("#" + 'frmCalibracion').serialize(),
                beforeSend: function (xhr) {
                    $(":input").attr("disabled", "disabled");
                }
            }).done(function (data) {
                $(":input").removeAttr("disabled");
                if (data == "Success") {
                    g.CreateDialog("dlgMsj", "Alta Satisfactoria", "La calibración se ha agreagado satisfactoriamente.");
                }
                else if (data == "Error") {
                    $("#frmCalibracion").submit();
                    //g.fail();
                    //g.CreateDialog("dlgMsj", "Error", "La calibración no se ha podido crear, favor de verificar la información enviada.");
                }

            })
        });

        $("#btnConsulta").click(function () {
            ADS.Filter("grid");
        });

        g.Filter = function () {

        };

        //$("#btnCreate").click(function () {
        //    $('form').get(0).setAttribute('action', '/Catalogo/Calibracion/Create');
        //    $("#frmCalibracion").submit();
        //});

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/Calibracion/Edit');
            g.CreateDialogEdicion("dlgMsj", "Calibración", "La calibración se ha actualizado satisfactoriamente");
            //$("#frmCalibracion").submit();
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Catalogo/Calibracion/Create", "frmCalibracion", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Catalogo/Calibracion/";
    }

    g.Edit = function (id) {
        document.location.href = "/Catalogo/Calibracion/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Catalogo/Calibracion/Delete/" + id, "dlg");
    };

})(ADS.Catalogo.Calibracion = {});