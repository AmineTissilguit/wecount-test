function GetCandidatures() {
    $('#myTable').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/condidatures",
            "type": "POST",
            "datatype": "json",
        },
        "columns": [
            { "data": "id" },
            { "data": "nomComplet" },
            { "data": "tele" },
            { "data": "dateEnvoi" },
            {
                "render": function(data, type, row) {
                    return `<a href="#">Delete</a>`;
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
$(document).ready(function () {
    GetCandidatures();

});