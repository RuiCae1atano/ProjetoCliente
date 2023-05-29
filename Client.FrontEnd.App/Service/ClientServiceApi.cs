using Client.FrontEnd.App.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
//using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace Client.FrontEnd.App.Service
{
    public class ClientServiceApi : IClientServiceApi
    {
        private readonly HttpClient _httpClient;

        public ClientServiceApi(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("ClienteApi");
            // Configura o cabeçalho da requisição para enviar JSON
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task CadastroCliente(ClienteViewModel cliente)
        {
            cliente.Id = new Guid();
            string jsonCliente = JsonConvert.SerializeObject(cliente);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/cliente", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ClienteViewModel>> ConsultaCliente(ClienteViewModel cliente)
        {
            string jsonCliente = JsonConvert.SerializeObject(cliente);

            // Cria o conteúdo da requisição com o JSON do objeto cliente
            var content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

            // Envia a requisição POST
            HttpResponseMessage response = await _httpClient.PostAsync("api/cliente/consultacliente",content);
            response.EnsureSuccessStatusCode();

            var resposta = JsonConvert.DeserializeObject<IEnumerable<ClienteViewModel>>
                            (await response.Content.ReadAsStringAsync());

            return resposta;
        }

        public async Task DeletaCliente(Guid idCliente)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/cliente/{idCliente}");
            response.EnsureSuccessStatusCode();
            string conteudo = await response.Content.ReadAsStringAsync();
        }

        public async Task EditaCliente(ClienteViewModel cliente)
        {
            string jsonCliente = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("api/cliente/consultacliente", content);
            response.EnsureSuccessStatusCode();
            await response.Content.ReadAsStringAsync();
        }

        public async Task<ClienteViewModel> GetClienteById(Guid id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/cliente/getclientebyid?id={id}");
            response.EnsureSuccessStatusCode();
            var cliente = JsonConvert.DeserializeObject<ClienteViewModel>
                            (await response.Content.ReadAsStringAsync());
            return cliente;
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterClientes()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/cliente/getallclientes");
            response.EnsureSuccessStatusCode();
            var cliente = JsonConvert.DeserializeObject<IEnumerable<ClienteViewModel>>
                            (await response.Content.ReadAsStringAsync());
            return cliente;
        }
    }
}
