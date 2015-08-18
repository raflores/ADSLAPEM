
(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Catalogo/Planta/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['NombrePlanta', 'Ciudad', 'Estado', 'RFC', '', '', ''],
            colModel: [
                        { name: 'NombrePlanta', index: 'NombrePlanta', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Ciudad', index: 'Ciudad', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Estado', index: 'Estado', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'RFC', index: 'RFC', align: 'left', search: false },
                        { name: 'Id', index: 'Id', hidden: true },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 20, sortable: false, search: false },
                        { name: 'Delete', index: 'Delete', align: 'center', width: 20, sortable: false, search: false }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'NombrePlanta',
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Planta.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Catalogo.Planta.Delete('" + id + "');\" >" +
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
                                    $("#frmPlanta").submit();
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
                                ADS.AjaxPostCall("/Catalogo/Planta/Delete", "frmPlanta", "dlg");
                                g.Cancelar();
                                //ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNewAjax").click(function () {
            ADS.LoadDialog("/Catalogo/Planta/Create", "dlg")
        });

        $("#btnNew").click(function () {
            document.location.href = "/Catalogo/Planta/Create"
        });

        $("#btnCreate").click(function () {
            $.ajax({
                url: '/Catalogo/Planta/Create',
                type: "POST",
                data: $("#" + 'frmPlanta').serialize(),
                beforeSend: function (xhr) {
                    $(":input").attr("disabled", "disabled");
                }
            }).done(function (data) {
                $(":input").removeAttr("disabled");
                if (data == "Success") {
                    g.CreateDialog("dlgMsj", "Alta Satisfactoria", "La Planta se ha agreagado satisfactoriamente.");
                }
                else if (data == "Error") {
                    $("#frmPlanta").submit();
                    //g.fail();
                    //g.CreateDialog("dlgMsj", "Error", "La Planta no se ha podido crear, favor de verificar la información enviada.");
                }

            })
        });

        $("#btnConsulta").click(function () {
            ADS.Filter("grid");
        });

        g.Filter = function () {

        };

        //$("#btnCreate").click(function () {
        //    $('form').get(0).setAttribute('action', '/Catalogo/Planta/Create');
        //    $("#frmPlanta").submit();
        //});

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Catalogo/Planta/Edit');
            g.CreateDialogEdicion("dlgMsj", "Edición Satisfactoria", "La Norma se ha modificado satisfactoriamente");
            $("#frmPlanta").submit();
            ADS.ReloadGrid("grid");
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Catalogo/Planta/Create", "frmPerson", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Catalogo/Planta/";
    }

    g.Edit = function (id) {
        document.location.href = "/Catalogo/Planta/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Catalogo/Planta/Delete/" + id, "dlg");
    };

})(ADS.Catalogo.Planta = {});