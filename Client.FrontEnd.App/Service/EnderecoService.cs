using Client.FrontEnd.App.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client.FrontEnd.App.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly HttpClient _httpClient;

        public EnderecoService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("ClienteApi");
            // Configura o cabeçalho da requisição para enviar JSON
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IEnumerable<EstadoViewModel>> GetEstados()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/endereco/estados");
            response.EnsureSuccessStatusCode();
            var estados = JsonConvert.DeserializeObject<IEnumerable<EstadoViewModel>>
                            (await response.Content.ReadAsStringAsync());
            return estados;

        }

        public async Task<IEnumerable<CidadeViewModel>> GetCidades()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/endereco/cidades");
            response.EnsureSuccessStatusCode();
            var cidades = JsonConvert.DeserializeObject<IEnumerable<CidadeViewModel>>
                            (await response.Content.ReadAsStringAsync());
            return cidades;
        }
    }
}
