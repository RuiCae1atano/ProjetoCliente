$(document).ready(function () {

    function enviarRequisicao() {


        var cpf = $("#cpf").val();
        var nome = $("#nome").val();
        var dataNascimento = $("#data-nascimento").val();
        var sexo = $("input[name='sexo']:checked").val();
        var estado = $("#estado").val();
        var cidade = $("#cidade").val();

        var cliente =
        {
                Cpf: cpf,
                Nome: nome,
                DataNascimento: dataNascimento,
                Sexo: sexo,
                IdEstado: parseInt(estado),
                IdCidade: parseInt(cidade)
            }
        ;


        $.ajax({
            url: '/Cliente/CriarCliente',

            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(cliente),
            contentType: 'application/json',
            success: function (response) {
                // Lógica de sucesso da requisição
                // ...
                alert(response.message);
                $("#create-form")[0].reset();
            },
            error: function (xhr, status, error) {
                // Lógica de tratamento de erro da requisição
                // ...
            }
        });
    }

    $("#create-form").submit(function (event) {
        event.preventDefault();
        enviarRequisicao();
    });

    $("#limpar").click(function () {
        $("#create-form")[0].reset();
    });
})