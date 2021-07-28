using System;
using System.Net.Http;
using DunkeyItTest.Clients.ApiClient.Endpoints;
using DunkeyItTest.Clients.ApiClient.Models;
using Newtonsoft.Json;
using System.Text;

namespace DunkeyItTest.Clients.ApiClient.Client
{
    public class DunkeyHttpClient
    {
        private readonly HttpClient _client;

        public DunkeyHttpClient(HttpClient client)
        {
            _client = client;
        }

        public void UpdateConfiguration(ConfigurationRequestModel updateModel)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateModel), Encoding.UTF8, "application/json");
            var result = _client.PostAsync(ConfigurationEndpoints.UpdateEndpoint, stringContent);

            ValidateResponseStatus(result.Result);
        }

        public ConfigurationResponseModel GetConfiguration(string configName)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, ConfigurationEndpoints.GetConfiguration(configName));
            var result = _client.Send(requestMessage);

            ValidateResponseStatus(result);
            var responseModel = Deserialize<ConfigurationResponseModel>(result);

            return responseModel;
        }

        private void ValidateResponseStatus(HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"{responseMessage.RequestMessage.RequestUri} request failed with {responseMessage.StatusCode} status");
            }
        }

        private T Deserialize<T>(HttpResponseMessage httpResponseMessage) where T : class
        {
            var stringResponseBody = httpResponseMessage.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<T>(stringResponseBody.Result);

            return responseModel;
        }
    }
}