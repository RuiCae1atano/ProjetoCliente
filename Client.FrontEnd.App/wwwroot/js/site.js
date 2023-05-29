$(document).ready(function () { 

    let selectedEstadoOption;
    let selectedCidadeOption;

    $('#estado').change(function () {
        selectedEstadoOption = $(this).val();
    })

    $('#cidade').change(function () {
        selectedCidadeOption = $(this).val();
    })

    var tabelaClientes = $('#tabelaClientes');
    var tbody = tabelaClientes.find('tbody');

    var currentPage = 1;
    var rowsPerPage = 5;

    var tabelaClientes = $('#tabelaClientes');
    var tbody = tabelaClientes.find('tbody');

    function updateTable() {
        console.log('entrei');
        tbody.empty();

        var startIndex = (currentPage - 1) * rowsPerPage;
        var endIndex = startIndex + rowsPerPage;

        for (var i = startIndex; i < endIndex && i < data.length; i++) {
            var cliente = data[i];
            var linha = $('<tr>');
            linha.append($('<td>').text(cliente.nome));
            linha.append($('<td>').text(cliente.cpf));
            linha.append($('<td>').text(cliente.dataNascimento));
            linha.append($('<td>').text(cliente.idEstado));
            linha.append($('<td>').text(cliente.idCidade));
            linha.append($('<td>').text(cliente.sexo));

            var colunaAcoes = $('<td>');
            colunaAcoes.append(
                $('<a href="cliente/update/' + cliente.id + '" class="btn btn-primary btn-editar" data-id="' + cliente.id + '">Editar</a>')
            );
            colunaAcoes.append($('<button class="btn btn-danger btn-excluir" data-id="' + cliente.id + '">Excluir</button>'));
            linha.append(colunaAcoes);

            tbody.append(linha);
        }
    }

    function updatePagination() {
        var totalPages = Math.ceil(data.length / rowsPerPage);

        var pagination = $('<nav>');
        var ul = $('<ul class="pagination">');

        // Botão "Anterior"
        var btnPrevious = $('<li class="page-item">').append(
            $('<a class="page-link" href="#">').text('Anterior').on('click', function (e) {
                e.preventDefault();
                if (currentPage > 1) {
                    currentPage--;
                    console.log("current", currentPage)
                    updateTable();
                    //updatePagination();
                }
            })
        );
        ul.append(btnPrevious);

        // Páginas
        for (var i = 1; i <= totalPages; i++) {
            var li = $('<li class="page-item">').append(
                $('<a class="page-link" href="#">').text(i).on('click', function (e) {
                    e.preventDefault();
                    var page = parseInt($(this).text());
                    if (page !== currentPage) {
                        currentPage = page;
                        console.log("current", currentPage)
                        updateTable();
                        //updatePagination();
                    }
                })
            );
            if (i === currentPage) {
                li.addClass('active');
            }
            ul.append(li);
        }

        // Botão "Próxima"
        var btnNext = $('<li class="page-item">').append(
            $('<a class="page-link" href="#">').text('Próxima').on('click', function (e) {
                e.preventDefault();
                if (currentPage < totalPages) {
                    currentPage++;
                    updateTable();
                    console.log("current", currentPage);
                    //updatePagination();
                }
            })
        );
        ul.append(btnNext);

        pagination.append(ul);
        tabelaClientes.after(pagination);
    }


    let data;

    function carregarDados() {
        $.ajax({
            url: '/Cliente/ObterClientes', // Substitua pelo endpoint correto que retorna os dados dos clientes
            type: 'GET',
            dataType: 'json',
            success: function (dados) {
                data = dados;
                updateTable();
                updatePagination();
            }


        });
    }
    carregarDados();



        var resetDataNascimento = $('#dataNascimento').val();
        var myDataNascimento = '';
        if (resetDataNascimento === '') {
            myDataNascimento = "01/01/0001 00:00:00"
        } else {
            myDataNascimento = $('#dataNascimento').val();
        }

        // Função para enviar a requisição AJAX
    function enviarRequisicao() {

        if ($('#estado').val() != '')
            selecionarOpcaoEstado();

        if ($('#cidade').val() != '')
        selecionarOpcaoCidade();

            var cpf = $("#cpf").val();
            var nome = $("#nome").val();
            var dataNascimento = myDataNascimento;
            var sexo = $("input[name='sexo']:checked").val();
            var estado = selectedEstadoOption;
            var cidade = selectedCidadeOption;

            var cliente = {
                Cpf: cpf,
                Nome: nome,
                DataNascimento: dataNascimento,
                Sexo: sexo,
                IdEstado: estado,
                IdCidade: cidade
            };


            $.ajax({
                url: '/Cliente/SearchCliente',

                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(cliente),
                contentType: 'application/json',
                success: function (data) {
                    $('#tabelaClientes tbody').empty();

                    // Preenche a tabela com os dados retornados
                    $.each(data, function (index, cliente) {
                        var linha = $('<tr>');
                        linha.append($('<td>').text(cliente.nome));
                        linha.append($('<td>').text(cliente.cpf));
                        linha.append($('<td>').text(cliente.dataNascimento));
                        linha.append($('<td>').text(cliente.idEstado));
                        linha.append($('<td>').text(cliente.idCidade));
                        linha.append($('<td>').text(cliente.sexo));

                        var colunaAcoes = $('<td>');
                        colunaAcoes.append($('<a href="cliente/update/' + cliente.id + '" class="btn btn-primary btn-editar" data-id="' + cliente.id + '">Editar</a>'));
                        colunaAcoes.append($('<button class="btn btn-danger btn-excluir" data-id="' + cliente.id + '">Excluir</button>'));
                        linha.append(colunaAcoes);

                        $('#tabelaClientes tbody').append(linha);
                    });
                },
                error: function (xhr, status, error) {
                    // Lógica de tratamento de erro da requisição
                    // ...
                }
            });
        }

        // Manipulador de evento para o envio do formulário
        $("#search-form").submit(function (event) {
            event.preventDefault();
           // Impede o envio do formulário
            enviarRequisicao(); // Chama a função para enviar a requisição AJAX
        });

        // Manipulador de evento para o botão "Limpar"
        $("#limpar").click(function () {
            $("#search-form")[0].reset(); // Limpa os campos do formulário
        });

    $('ul .pagination').val();

});
    
