using Newtonsoft.Json;

namespace Testes.Api
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public async void TestIntegradoValidadoComSucesso()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();
            var request = new Password(password);

            var response = await httpClient.PostAsJsonAsync($"/Password/", request);
            var stringResult = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<ValidationResponse>(stringResult);

            Assert.Contains("Senha validada com sucesso", jsonObject.Message);
            Assert.Equal(expectedResult, jsonObject.IsValid);
        }
    }
}