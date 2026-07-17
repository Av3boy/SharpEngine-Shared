namespace SharpEngine.Identity;

public class Auth0TokenResponseDto
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public string expires_in { get; set; }
}