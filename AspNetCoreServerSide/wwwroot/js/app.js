"use strict";

$(() => {
    if ($('#fingers10').length !== 0) {

        $('#fingers10 thead tr:last th').each(function () {
            var label = $('#fingers10 thead tr:first th:eq(' + $(this).index() + ')').html();
            $(this)
                .addClass('p-0')
                .html('<span class="sr-only">' + label + '</span><input type="search" class="form-control form-control-sm" aria-label="' + label + '" />');
        });

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
            dom: '<tr>',
            ajax: {
                type: "POST",
                url: '/Home/LoadTable/',
                contentType: "application/json; charset=utf-8",
                async: true,
                data: function (data) {
                    data.StringValue1 = "Additional Parameters 1";
                    data.StringValue2 = "Additional Parameters 2";
                    return JSON.stringify(data);
                }
            },
            columns: [
                {
                    title: "Name",
                    data: "Name",
                    name: "co"
                },
                {
                    title: "Position",
                    data: "Position",
                    name: "co"
                },
                {
                    title: "Office",
                    data: "Office",
                    name: "eq"
                },
                {
                    title: "Extn",
                    data: "Extn",
                    name: "eq"
                },
                {
                    title: "Start Date",
                    data: "StartDate",
                    render: function (data, type, row) {
                        return window.moment(row.StartDate).format("DD/MM/YYYY");
                    },
                    name: "eq"
                },
                {
                    title: "Salary",
                    data: "Salary",
                    name: "eq"
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
