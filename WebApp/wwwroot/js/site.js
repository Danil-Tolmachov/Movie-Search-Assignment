// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    let categoryColumnIndex = 2;

    let movieTable = $('#movieTable').DataTable({
        "paging": false,
        "searching": false,
        "info": false,
        "ordering": true,
        columnDefs: [
            { orderable: false, targets: [2] } // Disable ordering for the fourth column (index 3)
        ]
    });
});