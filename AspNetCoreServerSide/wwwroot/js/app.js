"use strict";

$(() => {
    if ($('#fingers10').length !== 0) {

        //var table = $('#fingers10').DataTable({
        //    language: {
        //        processing: "Loading Data...",
        //        zeroRecords: "No matching records found"
        //    },
        //    processing: true,
        //    serverSide: true,
        //    orderCellsTop: true,
        //    autoWidth: true,
        //    deferRender: true,
        //    lengthMenu: [5, 10, 15, 20],
        //    dom: '<"row"<"col-sm-12 col-md-6"B><"col-sm-12 col-md-6 text-right"l>><"row"<"col-sm-12"tr>><"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>',
        //    buttons: [
        //        {
        //            text: 'Export to Excel',
        //            className: 'btn btn-sm btn-dark',
        //            action: function (e, dt, node, config) {
        //                var data = table.ajax.params();
        //                var x = JSON.stringify(data, null, 4);
        //                window.location.href = "/Home/GetExcel?" + $.param(data);
        //            },
        //            init: function (api, node, config) {
        //                $(node).removeClass('dt-button');
        //            }
        //        }
        //    ],
        //    ajax: {
        //        url: '/Home/LoadTable/',
        //        data: function (data) {
        //            return $.extend({}, data, {
        //                "additionalValues[0]": "Additional Parameters 1",
        //                "additionalValues[1]": "Additional Parameters 2"
        //            });
        //        }
        //    },
        //    columns: [
        //        {
        //            data: "Id",
        //            name: "eq",
        //            visible: false,
        //            searchable: false
        //        },
        //        {
        //            data: "Name",
        //            name: "eq"
        //        },
        //        {
        //            data: "Position",
        //            name: "co"
        //        },
        //        {
        //            data: "Office",
        //            name: "eq"
        //        },
        //        {
        //            data: "Experience",
        //            name: "eq"
        //        },
        //        {
        //            data: "Extn",
        //            name: "eq"
        //        },
        //        {
        //            data: "StartDate",
        //            render: function (data, type, row) {
        //                return window.moment(data).format("DD/MM/YYYY");
        //            },
        //            name: "gt"
        //        },
        //        {
        //            data: "Salary",
        //            name: "lte"
        //        }
        //    ]
        //});

        var table = $('#fingers10').DataTable({
            language: {
                processing: "Loading Data...",
                zeroRecords: "No matching records found"
            },
            processing: true,
            serverSide: true,
            orderCellsTop: true,
            autoWidth: true,
            deferRender: true,
            lengthMenu: [5, 10, 15, 20],
            dom: '<"row"<"col-sm-12 col-md-6"B><"col-sm-12 col-md-6 text-right"l>><"row"<"col-sm-12"tr>><"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>',
            buttons: [
                {
                    text: 'Export to Excel',
                    className: 'btn btn-sm btn-dark',
                    action: function (e, dt, node, config) {
                        window.location.href = "/Home/GetExcel?exportAllData=false";
                    },
                    init: function (api, node, config) {
                        $(node).removeClass('dt-button');
                    }
                },
				{
                    text: 'Export to Excel All Data',
                    className: 'btn btn-sm btn-dark',
                    action: function (e, dt, node, config) {
                        window.location.href = "/Home/GetExcel?exportAllData=true";
                    },
                    init: function (api, node, config) {
                        $(node).removeClass('dt-button');
                    }
                }
            ],
            ajax: {
                type: "POST",
                url: '/Home/LoadTable/',
                contentType: "application/json; charset=utf-8",
                async: true,
                headers: {
                    "XSRF-TOKEN": document.querySelector('[name="__RequestVerificationToken"]').value
                },
                data: function (data) {
                    let additionalValues = [];
                    additionalValues[0] = "Additional Parameters 1";
                    additionalValues[1] = "Additional Parameters 2";
                    data.AdditionalValues = additionalValues;

                    return JSON.stringify(data);
                }
            },
            columns: [
                {
                    data: "Id",
                    name: "eq",
                    visible: false,
                    searchable: false
                },
                {
                    data: "Name",
                    name: "co"
                },
                {
                    data: "Position",
                    name: "co"
                },
                {
                    data: "Office",
                    name: "eq"
                },
                {
                    data: "Experience",
                    name: "eq"
                },
                {
                    data: "Extn",
                    name: "eq"
                },
                {
                    data: "StartDate",
                    render: function (data, type, row) {
                        if (data)
                            return window.moment(data).format("DD/MM/YYYY");
                        else
                            return null;
                    },
                    name: "gt"
                },
                {
                    data: "Salary",
                    name: "lte"
                }
            ]
        });

        table.columns().every(function (index) {
            $('#fingers10 thead tr:last th:eq(' + index + ') input')
                .on('keyup',
                    function (e) {
                        if (e.keyCode === 13) {
                            table.column($(this).parent().index() + ':visible').search(this.value).draw();
                        }
                    });
        });
    }
});
