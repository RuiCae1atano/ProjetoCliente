$(document).ready(function () {
    function selecionarOpcaoEstado() {
        var valorEstado = $('#estado').data('value-estado');
        $('#estado option[value="' + valorEstado + '"]').prop('selected', true);
    }

    function selecionarOpcaoCidade() {
        var valorCidade = $('#cidade').data('value-cidade');
        $('#cidade option[value="' + valorCidade + '"]').prop('selected', true);
    }


    function marcarRadioSexo() {
        var sexo = $('#valorSexo').val();
        if (sexo === 'Masculino') {
            $('#sexo-masculino').prop('checked', true);
        } else if (sexo === 'Feminino') {
            $('#sexo-feminino').prop('checked', true);
        }
    }

    function valorData() {

        var dataNascimento = $('#nasci').val();

        var partesData = dataNascimento.split(' ')[0].split('/');
        var dataFormatada = partesData[2] + '-' + partesData[1] + '-' + partesData[0];
        $('#data-nascimento').val(dataFormatada);
    }

    valorData();
    marcarRadioSexo();
    selecionarOpcaoEstado();
    selecionarOpcaoCidade();
    marcarRadioSexo();


    function enviarRequisicao() {

        var cpf = $("#cpf").val();
        var nome = $("#nome").val();
        var dataNascimento = $("#data-nascimento").val();
        var sexo = $("input[name='sexo']:checked").val();
        var estado = $("#estado").val();
        var cidade = $("#cidade").val();

        var dadosCliente = {
            Cpf: cpf,
            Nome: nome,
            DataNascimento: dataNascimento,
            Sexo: sexo,
            IdEstado: parseInt(estado),
            IdCidade: parseInt(cidade),
            Id : idCliente
        };

        $.ajax({
            url: '/Cliente/UpdateCliente',

            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(dadosCliente),
            contentType: 'application/json',
            success: function (response) {
                alert(response.message);
            },
            error: function (xhr, status, error) {

            }
        });
    }


    $("#update-form").submit(function (event) {
        event.preventDefault();
        enviarRequisicao();
    });

});