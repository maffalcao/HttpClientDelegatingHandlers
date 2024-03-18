using HttpClientDelegatinHadlers.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<GitHubService>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com");
});

var app = builder.Build();

app.MapGet("api/users/{username}", async (
    string username,
    GitHubService gitHubService) =>
{
    var content = await gitHubService.GetByUsernameAsync(username);

    return Results.Ok(content);
});

app.Run();