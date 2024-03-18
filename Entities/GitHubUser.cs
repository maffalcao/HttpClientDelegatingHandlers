namespace HttpClientDelegatingHandlers.Entities;

public class GitHubUser
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public int PublicRepos { get; set; }
    public int Followers { get; set; }
    public int Following { get; set; }

}
