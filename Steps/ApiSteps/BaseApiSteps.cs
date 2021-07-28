using System;
using System.Net.Http;
using DunkeyItTest.Clients.ApiClient.Client;

namespace DunkeyItTest.Steps.ApiSteps
{
    public abstract class BaseApiSteps
    {
        protected readonly DunkeyHttpClient Client;
        private readonly string _baseAddress = "http://localhost:54092";
        protected BaseApiSteps()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };

            Client = new DunkeyHttpClient(httpClient);
        }
    }
}