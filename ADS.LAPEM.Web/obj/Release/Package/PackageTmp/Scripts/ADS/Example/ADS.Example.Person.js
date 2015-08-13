
(function (g) {

    g.Init = function () {

        $("#grid").jqGrid({
            url: '/Example/Person/GetList',
            datatype: 'json',
            mtype: 'GET',
            colNames: ['Firstname', 'Lastname', 'Email', 'Telephone', 'Created Date', '', '', ''],
            colModel: [
                        { name: 'Firstname', index: 'Firstname', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Lastname', index: 'Lastname', align: 'left', searchoptions: { sopt: ['eq', 'ne', 'cn'] } },
                        { name: 'Email', index: 'Email', align: 'left', searchoptions: { sopt: ['cn'] }, stype: 'text' },
                        { name: 'Telephone', index: 'Telephone', align: 'left', search: false },
                        { name: 'CreatedDate', index: 'CreatedDate', align: 'left', search: false },
                        { name: 'Id', index: 'Id', hidden: true },
                        { name: 'Edit', index: 'Edit', align: 'center', sortable: false, search: false },
                        { name: 'Delete', index: 'Delete', align: 'center', sortable: false, search: false }
            ],
            pager: '#pager',
            rowNum: 10,
            rowList: [5, 10, 20, 50],
            sortname: 'Firstname',
            sortorder: "desc",
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            height: '100%',
            gridComplete: function () {
                var cell = $("#grid").jqGrid('getDataIDs');
                for (var i = 0; i < cell.length; i++) {
                    var id = $('#grid').jqGrid('getCell', cell[i], 'Id');
                    var btnEdit = "<div onclick=\"ADS.Example.Person.Edit('" + id + "');\" >Edit</div>";
                    var btnDelete = "<div onclick=\"ADS.Example.Person.Delete('" + id + "');\" >Delete</div>";
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
                                ADS.AjaxPostCall("/Example/Person/Delete", "frmPerson", "dlg");
                                ADS.ReloadGrid("grid");
                            }
                        },
                        { text: "Cancel", click: function () { $(this).dialog("close"); } }
            ]
        });

        $("#btnNewAjax").click(function () {
            ADS.LoadDialog("/Example/Person/Create", "dlg")
        });

        $("#btnNew").click(function () {
            document.location.href = "/Example/Person/Create"
        });

        $("#btnCreate").click(function () {
            $('form').get(0).setAttribute('action', '/Example/Person/Create');
            $("#frmPerson").submit();
        });

        $("#btnEdit").click(function () {
            $('form').get(0).setAttribute('action', '/Example/Person/Edit');
            $("#frmPerson").submit();
        });
    };

    g.Create = function () {
        ADS.AjaxPostCall("/Example/Person/Create", "frmPerson", "dlg");
    };

    g.Edit = function (id) {
        document.location.href = "/Example/Person/Edit/" + id;
    };

    g.Delete = function (id) {
        ADS.LoadDialog("/Example/Person/Delete/" + id, "dlg");
    };

})(ADS.Example.Person = {});