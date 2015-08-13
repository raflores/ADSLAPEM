﻿(function (g) {

    g.Init = function () {

        //$("#btnNew").click(function () {
        //    document.location.href = "/Reporte/RpteAgrietamiento/GenerarReporte"
        //});
        $("#grid").jqGrid({
            url: '/Reporte/RpteAgrietamiento/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Identificador', 'Codigo', 'Fecha', 'Cantidad','' , ''],
            colModel: [
                        { name: 'Identificador', index: 'Identificador', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Producto.Codigo', index: 'Producto.Codigo', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'FechaProduccion', index: 'FechaProduccion', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'CantidadProducida', index: 'CantidadProducida', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Id', index: 'Id', hidden: true },
                        { name: 'Descargar', index: 'Descargar', align: 'center', width: 20, sortable: false, search: false }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'FechaProduccion',
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var btnGenerar = "<div class=\"ui-state-default ui-corner-all\" onclick=\"ADS.Reporte.Agrietamiento.Generar('" + id + "');\" >" +
                        "<span class=\"ui-icon ui-icon-circle-arrow-s\"></span></div>";
                    $("#grid").jqGrid('setRowData', cell[i], { Descargar: btnGenerar });
                }
            }
        });

        $("#btnNew").click(function () {
            $.ajax({
                url: '/Reporte/RpteAgrietamiento/GenerarReporte',
                type: "POST",
                data: $("#" + 'FrmRpteAgrietamiento').serialize(),
                beforeSend: function (xhr) {
                    $(":input").attr("disabled", "disabled");
                }
            }).done(function (data) {
                $(":input").removeAttr("disabled");
                if (data == "Success") {
                    g.Success();
                }
                else if (data == "Error") {
                    //g.fail();
                    g.CreateDialog("dlgMsj", "No hay resultados disponibles", "No se encontraron datos de su consulta. Favor de intentar nuevamente");
                }
                
            })
            //$('form').get(0).setAttribute('action', '/Seguridad/Account/Login');
            //$("#frmAccount").submit();
        });

        $("#btnGenerar").click(function () {
            $('form').get(0).setAttribute('action', '/Reporte/RpteAgrietamiento/Generar');
            //g.CreateDialogEdicion("dlgMsj", "Edición Satisfactoria", "La línea se ha modificado satisfactoriamente");
            //$("#frmLinea").submit();
        });

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
                            { text: "OK", click: function () { g.Cancelar(); } }
                ]
            });
        };

        g.Cancelar = function () {
            document.location.href = "/Reporte/RpteAgrietamiento/";
        }

        g.Success = function () {
            $('form').get(0).setAttribute('action', '/Reporte/RpteAgrietamiento/GenerarRepo');
            $("#FrmRpteAgrietamiento").submit();
        }

        g.Generar = function (id) {
            document.location.href = "/Reporte/RpteAgrietamiento/Generar/" + id;
        };

        $("#btnConsulta").click(function () {
            ADS.Filter("grid");
        });

        g.Filter = function () {

        };

        //$("#btnNew").click(function () {
        //    $('form').get(0).setAttribute('action', '/Reporte/RpteAgrietamiento/GenerarReporte');
        //    $("#FrmRpteAgrietamiento").submit();
        //});

        //g.Create = function () {
        //    ADS.AjaxPostCall("/Reporte/RpteAgrietamiento/GenerarReporte", "FrmRpteAgrietamiento", "dlg");
        //};

    };

})(ADS.Reporte.Agrietamiento = {});