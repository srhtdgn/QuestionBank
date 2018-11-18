var TableDatatablesButtons = function () {

    var initList = function () {

        var table = $('#list');

        var table2 = $('.list2');

        var oTable = table.dataTable({

            //"language": {
            //    "sDecimal": ",",
            //    "sEmptyTable": "Tabloda herhangi bir veri mevcut de�il",
            //    "sInfo": "_TOTAL_ kay�ttan _START_ - _END_ aras�ndaki kay�tlar g�steriliyor",
            //    "sInfoEmpty": "Kay�t yok",
            //    "sInfoFiltered": "(_MAX_ kay�t i�erisinden bulunan)",
            //    "sInfoPostFix": "",
            //    "sInfoThousands": ".",
            //    "sLengthMenu": "Sayfada _MENU_ kay�t g�ster",
            //    "sLoadingRecords": "Y�kleniyor...",
            //    "sProcessing": "��leniyor...",
            //    "sSearch": "Ara:",
            //    "sZeroRecords": "E�le�en kay�t bulunamad�",
            //    "oPaginate": {
            //        "sFirst": "�lk",
            //        "sLast": "Son",
            //        "sNext": "Sonraki",
            //        "sPrevious": "�nceki"
            //    },
            //    "oAria": {
            //        "sSortAscending": ": artan s�tun s�ralamas�n� aktifle�tir",
            //        "sSortDescending": ": azalan s�tun s�ralamas�n� aktifle�tir"
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