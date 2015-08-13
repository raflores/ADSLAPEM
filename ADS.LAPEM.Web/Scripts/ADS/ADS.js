var ADS = {};

(function (g) {

    g.Init = function () {
        $(".ReadOnly").attr("readonly", true)
    };

    g.LoadDialog = function (url, dlgId) {
        $("#" + dlgId).load(url, function (response, status, jqxhr) {
            $("#" + dlgId).dialog("open");
        });
    };

    g.LoadDialogWithData = function (url, data, dlgId) {
        $("#" + dlgId).load(url, data, function (response, status, jqxhr) {
            $("#" + dlgId).dialog("open");
        });
    };

    g.AjaxPostCall = function (postUrl, formId, dlgId) {
        $.ajax({
            url: postUrl,
            type: "POST",
            data: $("#" + formId).serialize(),
            beforeSend: function (xhr) {
                $(":input").attr("disabled", "disabled");
            }
        }).done(function (data) {
            $(":input").removeAttr("disabled");
            if (data == "Success") {
                $("#" + dlgId).dialog("close");
            }
            else if (data == "Error") {
                g.CreateDialog("dlgMsj", "Error", data);
            }
            else {
                $("#" + dlgId).empty();
                $("#" + dlgId).html(data);
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            $(":input").removeAttr("disabled");
            g.AjaxErrors(jqXHR);
        });
    };

    g.ReloadGrid = function (grid) {
        $("#" + grid).setGridParam({ datatype: 'json' });
        $('#' + grid).trigger('reloadGrid');
    }

    g.Filter = function (grid) {

        var filters = {
            groupOp: "AND",
            rules: [],
            groups: []
        };

        $(':input[data-search="True"]').each(function () {
            if ($.trim($(this).val()) != "") {
                filters.rules.push({
                    field: $(this).attr("data-rules-field"),
                    op: $(this).attr("data-rules-op"),
                    data: $(this).val()
                    //type: $(this).attr("data-search-type")
                });
            }
        });

        $("#" + grid)[0].p.search = filters.rules.length > 0;
        $.extend($("#" + grid)[0].p.postData, { filters: JSON.stringify(filters) });
        g.ReloadGrid(grid);
    };


    g.AjaxErrors = function (xhr) {
        switch (xhr.status) {
            case 2627: g.CreateDialog("error2627", "Error en Base de Datos", "Duplicado en Base de Datos"); break;
            case 547: g.CreateDialog("error547", "Error en Base de Datos", "Está siendo utilizado por otro Registro"); break;
            default: g.CreateDialog("error500", "Internal Server Error", "Internal Server Error"); break;
        }
    };


    g.CreateDialog = function (dialogId, title, message) {
        var NewDialog = $('<div id="mensajeDialog" title="' + title + '">\<p>' + message + '</p>\</div>');
        NewDialog.dialog({
            modal: false,
            autoOpen: true,
            //show: "blind",
            //hide: "explode",
            buttons: [
                        { text: "OK", click: function () { $(this).dialog("close"); } },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });
    };

    g.CreateDialogWithFn = function (dialogId, title, message, fnName) {
        var NewDialog = $('<div id="mensajeDialog" title="' + title + '">\<p>' + message + '</p>\</div>');
        NewDialog.dialog({
            modal: false,
            autoOpen: true,
            //show: "blind",
            //hide: "explode",
            buttons: [
                        { text: "OK", click: function () { fnName.apply(); $(this).dialog("close"); } },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });
    };

})(ADS = {});