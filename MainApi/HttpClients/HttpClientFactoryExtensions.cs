using Microsoft.Extensions.Configuration;
using Polly.Extensions.Http;
using Polly;

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
            }).AddHttpMessageHandler<TokenMessageHandler>()
            .AddPolicyHandler(GetRetryPolicy());
            services.AddHttpClient<ReportHttpClient>(client =>
            {
                var url = configuration.GetValue<string>("ReportHttpClient:BaseAddress") ?? throw new InvalidOperationException("Url for ReportService was invalid");
                client.BaseAddress = new Uri(url);
            }).AddHttpMessageHandler<TokenMessageHandler>()
            .AddPolicyHandler(GetRetryPolicy());
            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                            retryAttempt)));
        }

    }
}
