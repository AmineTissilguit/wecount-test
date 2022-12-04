
let currentCandidatureId;

function GetCandidatures() {
    $('#myTable').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/candidature/list",
            "type": "POST",
            "datatype": "json",
        },
        "columns": [
            { "data": "id" },
            { "data": "nomComplet", "orderable": false },
            { "data": "tele", "orderable": false },
            { "data": "dateEnvoi", "orderable": false },
            {
                "data": "id",
                "render": function (data) {
                    return `<button type="button" class="btn btn-primary me-3" data-bs-toggle="modal" 
                            onclick="return getSelectedCandidatureId('${data}')" data-bs-target="#deleteModal">Delete</button>` + 
                        `<button type="button" class="btn btn-secondary" data-bs-toggle="modal" 
                            data-bs-target="#pdfModal">CV</button>`;
                },
                "orderable": false
            }
        ],
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "language": {
            "lengthMenu": "Afficher _MENU_ enregistrements par page",
            "zeroRecords": "Rien n'a été trouvé - pardon",
            "info": "Afficher la page _PAGE_ sur _PAGES_",
            "infoEmpty": "Aucun enregistrement disponible",
            "loadingRecords": "Chargement en cours...",
            "processing": "Traitement...",
            "search": "Chercher:",
            "paginate": {
                "first": "Premier",
                "last": "Dernier",
                "next": "Suivant",
                "previous": "Précédent"
            },
            "infoFiltered": "(filtré à partir de _MAX_ entrées totales)"
        },
        "responsive": true
    });

}
function getSelectedCandidatureId(id) {
    currentCandidatureId = id;
}

// Delete Request
$("#save").on("click", function () {
    $.ajax({
        "url": `/candidature/delete/${currentCandidatureId}`,
        "type": "GET",
        "success": function () {
            $('#deleteModal').modal('hide');
            $('#myTable').DataTable().ajax.reload();
        },
        "error": function (xhr, status, error) {
            // TODO : don't let the error show up on the browser console
            alert(xhr.responseText);
        }
    });
});

$(document).ready(function () {
    GetCandidatures();
});