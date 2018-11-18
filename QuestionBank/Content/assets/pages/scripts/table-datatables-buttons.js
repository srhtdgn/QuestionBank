var TableDatatablesButtons = function () {

    var initList = function () {

        var table = $('#list');

        var table2 = $('.list2');

        var oTable = table.dataTable({

            //"language": {
            //    "sDecimal": ",",
            //    "sEmptyTable": "Tabloda herhangi bir veri mevcut deðil",
            //    "sInfo": "_TOTAL_ kayýttan _START_ - _END_ arasýndaki kayýtlar gösteriliyor",
            //    "sInfoEmpty": "Kayýt yok",
            //    "sInfoFiltered": "(_MAX_ kayýt içerisinden bulunan)",
            //    "sInfoPostFix": "",
            //    "sInfoThousands": ".",
            //    "sLengthMenu": "Sayfada _MENU_ kayýt göster",
            //    "sLoadingRecords": "Yükleniyor...",
            //    "sProcessing": "Ýþleniyor...",
            //    "sSearch": "Ara:",
            //    "sZeroRecords": "Eþleþen kayýt bulunamadý",
            //    "oPaginate": {
            //        "sFirst": "Ýlk",
            //        "sLast": "Son",
            //        "sNext": "Sonraki",
            //        "sPrevious": "Önceki"
            //    },
            //    "oAria": {
            //        "sSortAscending": ": artan sütun sýralamasýný aktifleþtir",
            //        "sSortDescending": ": azalan sütun sýralamasýný aktifleþtir"
            //    }
            //},

            // Or you can use remote translation file
            "language": {
                url: 'https://cdn.datatables.net/plug-ins/1.10.16/i18n/Turkish.json'
            },

            buttons: [
                //{ extend: 'print', className: 'btn default' },
                //{ extend: 'copy', className: 'btn default' },
                //{ extend: 'pdf', className: 'btn default' },
                //{ extend: 'excel', className: 'btn default' },
                //{ extend: 'csv', className: 'btn default' },
                //{
                //    text: 'Reload',
                //    className: 'btn default',
                //    action: function ( e, dt, node, config ) {
                //        //dt.ajax.reload();
                //        alert('Custom Button');
                //    }
                //}
            ],

            "order": [
                [0, 'asc']
            ],

            "lengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "pageLength": 10,

            "dom": "<'row' <'col-md-12'B>><'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r><'table-scrollable't><'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>", // horizobtal scrollable datatable

        });
        var oTable2 = table2.dataTable({

           
            "language": {
                url: 'https://cdn.datatables.net/plug-ins/1.10.16/i18n/Turkish.json'
            },

            buttons: [
                { extend: 'pdf', className: 'btn default' }
            ],

            "order": [
                [0, 'asc']
            ],

            "lengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "pageLength": 10,

            "dom": "<'row' <'col-md-12'B>><'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r><'table-scrollable't><'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>", // horizobtal scrollable datatable

        });
    }

    return {
        init: function () {
            initList();
        }
    };

}();

jQuery(document).ready(function () {
    TableDatatablesButtons.init();
});