$(() => {
     //if ($('#fingers10').length !== 0) {
         
     //    $('#fingers10 thead tr:last th').each(function () {
     //           var label = $('#fingers10 thead tr:first th:eq(' + $(this).index() + ')').html();
     //           $(this).html('<span class="sr-only">' + label + '</span><input type="search" disabled="disabled" aria-label="' + label + '" />');
     //       });
         
     //   var table = $('#fingers10').DataTable({
     //           scrollX: true,
     //           scrollY: '80vh',
     //           scrollCollapse: true,
     //           language: {
     //               processing: "Loading Claims...",
     //               zeroRecords: "No matching records found"
     //           },
     //           processing: true,
     //           serverSide: true,
     //           orderCellsTop: true,
     //           autoWidth: true,
     //           deferRender: true,
     //           dom: '<tr>',
     //           ajax: {
     //               type: "POST",
     //               url: '/Home/LoadTable/',
     //               contentType: "application/json; charset=utf-8",
     //               //headers: {
     //               //    "XSRF-TOKEN": $('#_AjaxAntiForgeryTokenForm input[name="__RequestVerificationToken"]').val()
     //               //},
     //               //global: false,
     //               async: true,
     //               data: function (data) {
     //                   //data.StringValue1 = $('#').val();
     //                   //data.StringValue2 = $('#').val();
     //                   //claimsExportModel = data;
     //                   return JSON.stringify(data);
     //               }
     //           },
     //           columns: [
     //               {
     //                   title: "",
     //                   data: "",
     //                   visible: false,
     //                   searchable: false,
     //                   orderable: false
     //               },
     //               {
     //                   title: "",
     //                   data: "",
     //                   name: "eq"
     //               },
     //               {
     //                   title: "",
     //                   data: "",
     //                   name: "co"
     //               },
     //               {
     //                   title: "",
     //                   data: "",
     //                   render: function (data, type, row) {
     //                       return window.moment(row.fieldname).format(dateFormat);
     //                   },
     //                   name: "eq"
     //               },
     //               {
     //                   title: "",
     //                   data: "",
     //                   name: "co"
     //               }
     //           ]
     //   }); 
         
     //    table.columns().every(function (index) {
     //           $('#fingers10_wrapper .dataTables_scrollHeadInner table thead tr:last th:eq(' + index + ') input').on('keyup', function (e) {
     //               if (e.keyCode === 13) {
     //                   table.column($(this).parent().index() + ':visible').search(this.value).draw();
     //               }
     //           });
     //       });
     //}
})
