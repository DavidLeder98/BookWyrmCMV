$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "25%" },
            { data: 'author', "width": "25%" },
            { data: 'isbn', "width": "20%" },
            { data: 'price', "width": "5%" },
            { data: 'category.name', "width": "10%" },
            {
                "data": null,
                "width": "15%",
                "render": function (data, type, row) {
                    return `<div class="text-center">
                        <a href="/Admin/Product/Upsert/${row.id}" class="btn btn-success text-white" style="cursor:pointer;">
                            <i class="bi bi-pencil-square"></i>
                        </a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Product/Delete/${row.id}')" class="btn btn-danger text-white" style="cursor:pointer;">
                            <i class="bi bi-trash-fill"></i>
                        </a>
                    </div>`;
                },
                "orderable": false
            }
        ],
        "language": {
            "emptyTable": "No data available"
        },
        "width": "100%"
    });
}