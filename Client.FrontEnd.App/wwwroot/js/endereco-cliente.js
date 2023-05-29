$(document).ready(function () {
    // Mapeia os estados e suas cidades associadas
    let estados;
    let cidades;
    $.ajax({
        url: '/endereco/getestados',
        type: 'get',
        dataType: 'json',
        contentType: 'application/json',
        success: function (response, status, xhr) {
            console.log(response);
            estados = response;

            if (response) {
                // Popula o dropdown de cidades com as cidades associadas ao estado selecionado
                $.each(response, function (index, estado) {
                    $('#estado').append($('<option>', {
                        value: estado.id,
                        text: estado.nome
                    }));
                });
            } else {
                // Caso não haja cidades associadas, exibe a opção padrão "Todos"
                $('#estado').append($('<option>', {
                    value: '',
                    text: 'Todos'
                }));
            }
            
        },
        error: function (xhr, status, error) {
            // Ocorreu um erro na requisição
            // Faça algo apropriado aqui
        }
    });

    $.ajax({
        url: '/endereco/getcidades',
        type: 'get',
        dataType: 'json',
        contentType: 'application/json',
        success: function (response, status, xhr) {
            console.log(response);
            cidades = response;

        },
        error: function (xhr, status, error) {
            // Ocorreu um erro na requisição
            // Faça algo apropriado aqui
        }
    });




    // Quando o estado for alterado
    $('#estado').on('change', function () {
        var estadoSelecionado = $(this).val();
        var cidadesAssociadas = cidades.find(x=> x.idEstado == estadoSelecionado);
        console.log('CidadesAssociadas', cidadesAssociadas);
        

        // Remove todas as opções de cidade
        $('#cidade').empty();

        if (cidadesAssociadas) {
            // Popula o dropdown de cidades com as cidades associadas ao estado selecionado
                $('#cidade').append($('<option>', {
                    value: cidadesAssociadas.id,
                    text: cidadesAssociadas.nomeCidade
                }));
            
        } else {
            // Caso não haja cidades associadas, exibe a opção padrão "Todos"
            $('#cidade').append($('<option>', {
                value: '',
                text: 'Todos'
            }));
        }
    });
});