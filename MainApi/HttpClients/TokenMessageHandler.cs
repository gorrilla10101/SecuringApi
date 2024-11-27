
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;

namespace MainApi.HttpClients
{
    public class TokenMessageHandler(IHttpContextAccessor httpContext, IAuthenticationService authenticationService) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = httpContext.HttpContext;
            if (context is not null)
            {
                var token = await authenticationService.GetTokenAsync(context, "access_token");
                if (!string.IsNullOrWhiteSpace(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
