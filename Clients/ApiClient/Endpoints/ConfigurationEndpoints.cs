namespace DunkeyItTest.Clients.ApiClient.Endpoints
{
    public static class ConfigurationEndpoints
    {
        public static string UpdateEndpoint => "api/configuration/update";

        public static string GetConfiguration(string configName)
            => $"api/configuration/getConfig/{configName}";
    }
}