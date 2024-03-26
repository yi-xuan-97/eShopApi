using JWTAuth;
using JWTAuth.Model;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly JwtTokenHandler jwtTokenHandler;

    public AccountController(JwtTokenHandler _handler)
    {
        jwtTokenHandler = _handler;
    }

    [HttpPost]
    public ActionResult<AuthenticationResponse> Login(AuthenticationRequest request)
    {
        var authResponse = jwtTokenHandler.GenerateToken(request);
        if (authResponse == null) return Unauthorized();
        return authResponse;
    }
}