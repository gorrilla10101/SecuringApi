using Microsoft.Extensions.Configuration;

namespace MainApi.HttpClients
{
    public static class HttpClientFactoryExtensions
    {
        public static IServiceCollection RegisterHttpClients(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHttpClient<ClientHttpClient>(client =>
            {
                var url = configuration.GetValue<string>("ClientHttpClient:BaseAddress") ?? throw new InvalidOperationException("Url for ClientService was invalid");
                client.BaseAddress = new Uri(url);
            }).AddHttpMessageHandler<TokenMessageHandler>();
            services.AddHttpClient<ReportHttpClient>(client =>
            {
                var url = configuration.GetValue<string>("ReportHttpClient:BaseAddress") ?? throw new InvalidOperationException("Url for ReportService was invalid");
                client.BaseAddress = new Uri(url);
            }).AddHttpMessageHandler<TokenMessageHandler>();
            return services;
        }
    }
}
