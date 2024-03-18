using HttpClientDelegatingHandlers.Entities;
using Microsoft.Extensions.Options;

namespace HttpClientDelegatingHandlers.DelegatingHandlers;

public class AuthenticationDelegatingHandler(IOptions<GitHubOptions> options)
    : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Add("Authorization", options.Value.AccessToken);
        request.Headers.Add("User-Agent", options.Value.UserAgent);

        return base.SendAsync(request, cancellationToken);
    }
}