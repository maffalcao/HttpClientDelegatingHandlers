using HttpClientDelegatingHandlers.DelegatingHandlers;
using HttpClientDelegatingHandlers.Entities;
using HttpClientDelegatinHadlers.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GitHubOptions>(builder.Configuration.GetSection("GitHubOptions"));

builder.Services.AddTransient<LoggingDelegatingHandler>();
builder.Services.AddTransient<RetryDelegatingHandler>();
builder.Services.AddTransient<AuthenticationDelegatingHandler>();

builder.Services.AddHttpClient<GitHubService>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com");
})
.AddHttpMessageHandler<LoggingDelegatingHandler>()
.AddHttpMessageHandler<RetryDelegatingHandler>()
.AddHttpMessageHandler<AuthenticationDelegatingHandler>();

var app = builder.Build();

app.MapGet("api/users/{username}", async (
    string username,
    GitHubService gitHubService) =>
{
    var content = await gitHubService.GetByUsernameAsync(username);

    return Results.Ok(content);
});

app.Run();