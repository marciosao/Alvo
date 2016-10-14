$(function () {

    $("#btnAdicionarQuestao").click(function () {
        var idEtapa = $("#IdEtapa option:selected").val();
        var etapa = $("#IdEtapa option:selected").text();
        var idCategoria = $("#IdCategoriaQuestao option:selected").val();
        var categoria = $("#IdCategoriaQuestao option:selected").text();
        var descricao = $("#txtDescricao").val();

        if (etapa != "" && descricao != "") {
            var linha = $('<tr data-questao="' + idEtapa + '-' + idCategoria + '-' + descricao + '"></tr>');
            var colunas = linha.append('<td>' + etapa + '</td><td>' + categoria + '</td><td>' + descricao + '</td><td><a href="#" class = "glyphicon glyphicon-remove">&nbsp;</a></td>');
            $("#dvData").prepend(colunas);
        }
    });

    $("a.glyphicon-remove").click(function () {
        $(this).closest("tr").remove();
    });

    $("#btnConfirmar").click(function () {
        $("#dvData tbody tr[data-questao]").each(function (index) {

            var dados = $(this).data("questao").split("-");
            var idEtapa = dados[0];
            var idCategoria = dados[1];
            var descricao = dados[2];

            $('form').append("<input type='hidden' name='Questao[" + index + "].IdEtapa' value='" + idEtapa + "' />");
            $('form').append("<input type='hidden' name='Questao[" + index + "].IdCategoriaQuestao' value='" + idCategoria + "' />");
            $('form').append("<input type='hidden' name='Questao[" + index + "].Descricao' value='" + descricao + "' />");
        });

        $('form').submit();
    });
});