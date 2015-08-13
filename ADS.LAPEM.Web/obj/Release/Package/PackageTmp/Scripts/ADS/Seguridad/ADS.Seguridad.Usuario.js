(function (g) {

    g.Init = function () {

                $("#Usuario_Username").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Seguridad/Usuario/AutoCompleteUsername",
                            type: "POST",
                            dataType: "json",
                            data: { term: request.term }                            
                        }).done(function (data) {
                            response($.map(data, function (item) {
                                return { label: item.Username, value: item.Username };
                            }))

                        })
                    }
                });           



        $("#grid").jqGrid({
            url: '/Seguridad/Usuario/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Nombre', 'Username', 'puesto', 'Planta.NombrePlanta', '', '', ''],
            colModel: [
                        { name: 'Nombre', index: 'Nombre', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Username', index: 'Username', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'puesto', index: 'puesto', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Planta.NombrePlanta', index: 'Planta.NombrePlanta', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Id', index: 'Id', hidden: true },
                        { name: 'Edit', index: 'Edit', align: 'center', width: 20, sortable: false, search: false },
                        { name: 'Delete', index: 'Delete', align: 'center',  width: 20, sortable: false, search: false }
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
                    var btnEdit = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Seguridad.Usuario.Edit('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-pencil\"></span></div>";
                    var btnDelete = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Seguridad.Usuario.Delete('" + id + "');\" >" +
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
                                ADS.AjaxPostCall("/Seguridad/Usuario/Delete", "frmUsuario", "dlg");
                                ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#dlgAviso").dialog({
            autoOpen: false,
            width: 450,
            modal: true,
            height: 'auto',
            resizable: false,
            buttons: [                        
                        { text: "Ok", click: function () { $(this).dialog("close"); $("#Usuario_Nombre").focus(); } }
            ]
        });

        $("#btnNew").click(function () {
            document.location.href = "/Seguridad/Usuario/Create"
        });

        $("#btnCreate").click(function () {
            $('form').get(0).setAttribute('action', '/Seguridad/Usuario/Create');
            $("#frmUsuario").submit();
        });

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Seguridad/Usuario/Edit');
            $("#frmUsuario").submit();
        });

        $("#btnCancelar").click(function () {
            g.Cancelar();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Seguridad/Usuario/Create", "frmUsuario", "dlg");
    };

    g.Cancelar = function () {
        document.location.href = "/Seguridad/Usuario/";
    }

    g.Edit = function (id) {
        document.location.href = "/Seguridad/Usuario/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Seguridad/Usuario/Delete/" + id, "dlg");
    };

})(ADS.Seguridad.Usuario = {});