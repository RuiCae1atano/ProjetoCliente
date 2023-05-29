$(document).ready(function () {
    $('#tabelaClientes tbody').on('click', '.btn-excluir', function () {
        var idCliente = $(this).data('id');

        $('#confirmacaoModal').modal('show');

        $('#btnConfirmarExclusao').data('idCliente', idCliente);
    });

    $('#btnConfirmarExclusao').click(function () {
        var idCliente = $(this).data('idCliente');
        enviarRequisicao(idCliente);
        $('#confirmacaoModal').modal('hide');
    });


    function enviarRequisicao(id) {

        $.ajax({
            url: '/Cliente/DeleteCliente/' + id,

            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            success: function (response, status, xhr) {
                if (xhr.status === 200) {
                    $('[data-id="' + id + '"]').closest('tr').remove();
                }
            },
            error: function (xhr, status, error) {
            }
        });
    }
});