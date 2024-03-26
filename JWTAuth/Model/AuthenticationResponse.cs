namespace JWTAuth.Model;

public class AuthenticationResponse
{
    public string Username { get; set; }
    public string JWTToken { get; set; }
    public int ExpiresIn { get; set; }
}