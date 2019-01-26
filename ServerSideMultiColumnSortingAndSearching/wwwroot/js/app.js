"use strict";

$(() => {
    if ($('#fingers10').length !== 0) {

        $('#fingers10 thead tr:last th').each(function() {
            $(this).html('<input type="search" disabled="disabled" />');
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
                data: function(data) {
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
                    title: "Birth Date",
                    data: "BirthDate",
                    render: function(data, type, row) {
                        return window.moment(row.BirthDate).format("MM/D/yyyy");
                    },
                    name: "eq"
                },
                {
                    title: "Bank Balance",
                    data: "BankBalance",
                    name: "eq"
                }
            ]
        });

        table.columns().every(function(index) {
            $('#fingers10_wrapper .dataTables_scrollHeadInner table thead tr:last th:eq(' + index + ') input')
                .on('keyup',
                    function(e) {
                        if (e.keyCode === 13) {
                            table.column($(this).parent().index() + ':visible').search(this.value).draw();
                        }
                    });
        });
    }
});
