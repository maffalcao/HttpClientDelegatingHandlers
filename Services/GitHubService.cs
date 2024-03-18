using HttpClientDelegatingHandlers.Entities;

namespace HttpClientDelegatinHadlers.Services;
public class GitHubService(HttpClient client)
{
    public async Task<GitHubUser?> GetByUsernameAsync(string username)
    {
        var url = $"users/{username}";

        return await client.GetFromJsonAsync<GitHubUser>(url);
    }
}