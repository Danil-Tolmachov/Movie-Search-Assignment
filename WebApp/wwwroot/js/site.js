
$(document).ready(function () {
    let selectedText = '';

    $.extend($.fn.dataTable.ext.type.order, {
        "category-sort-asc": function (aValue, bValue) {
            if (aValue.includes(selectedText) && !bValue.includes(selectedText)) {
                return -1;
            } else if (!aValue.includes(selectedText) && bValue.includes(selectedText)) {
                return 1;
            } else {
                return 0;
            }
        }
    });

    // Init movies table
    let movieTable = $('#movieTable').DataTable({
        "paging": false,
        "searching": false,
        "info": false,
        "ordering": true,
        columnDefs: [
            {
                orderable: false,
                type: "category-sort",
                targets: [2]
            }
        ]
    });

    

    $('#categorySelector').on('change', function () {
        let movieTable = $('#movieTable').DataTable();
        let categoryColumnIndex = 2;

        selectedText = $('#categorySelector').val();

        movieTable.order([categoryColumnIndex, 'asc']).draw();
    });
});
