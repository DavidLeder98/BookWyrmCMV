$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "25%" },
            { data: 'author', "width": "17%" },
            { data: 'isbn', "width": "18%" },
            { data: 'price', "width": "5%" },
            { data: 'category.name', "width": "10%" },
            {
                "data": 'id',
                "width": "25%",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-warning text-white" style="cursor:pointer;">
                            <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        &nbsp;
                        <a href="/Admin/Product/Delete/${data}" class="btn btn-danger text-white" style="cursor:pointer;">
                            <i class="bi bi-trash-fill"></i> Delete
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