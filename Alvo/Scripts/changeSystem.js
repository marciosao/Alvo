
$(document).ready(function () {
    $('body.alvo #dvData').DataTable({
        "destroy":true,
        "paging": true,
        "pageLength": 10,
        "ordering": true,
        "info": true,
        "searching": true,
        "lengthChange": false,
        language: {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }

        }
    });
   
    if (typeof $('input[type="datetime"].datemask').inputmask === "function") {
        $('input[type="datetime"].datemask').inputmask("99/99/9999");
    }
    //Validação de todos os campos Data do sistema;
    $("input[data-val-date]").on('keydown', function (e) {
        var keyCode = e.which || e.keyCode;
        if (keyCode > 57) {
            keyCode -= 48;
        }

        var newchar = String.fromCharCode(keyCode);

        var date = $(this).val().toString();

        if ($.isNumeric(newchar)) {
            date = date.replace(/\//g, "").replace(/_/g, "") + "";

            switch (date.length) {
                case 0:
                    date = newchar + "_/__/____";
                    break;
                case 1:
                    date = date[0] + newchar + "/__/____";
                    break;
                case 2:
                    date = date[0] + "" + date[1] + "/" + newchar + "_/____";
                    break;
                case 3:
                    date = date[0] + "" + date[1] + "/" + date[2] + "" + newchar + "/____";
                    break;
                case 4:
                    date = date[0] + "" + date[1] + "/" + date[2] + "" + date[3] + "/" + newchar + "___";
                    break;
                case 5:
                    date = date[0] + "" + date[1] + "/" + date[2] + "" + date[3] + "/" + date[4] + "" + newchar + "__";
                    break;
                case 6:
                    date = date[0] + "" + date[1] + "/" + date[2] + "" + date[3] + "/" + date[4] + "" + date[5] + "" + newchar + "_";
                    break;
                case 7:
                    date = date[0] + "" + date[1] + "/" + date[2] + "" + date[3] + "/" + date[4] + "" + date[5] + "" + date[6] + "" + newchar;

            }

        }

        if (date.match(/^([0]([1-9]|_)|([12](\d|_)|[3]([01]|_))|__)\/(([0]([1-9]|_))|([1]([0-2]|_))|__)\/(([1-2](\d(\d(\d|_)|__)|___))|____)$/) == null) {
            e.preventDefault();
        }


    });

});

function loadDataTable() {
    
    $('#dvDataSearch').DataTable({
        "lengthChange": false,
        language: {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }

        }
    });
}