using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using JWTAuth.Model;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuth;

public class JwtTokenHandler
{
    public const string JWT_SECURITY_KEY = "aqwsedrftgyhujikolpmhbnvccxesssssaaaqwwwhhg";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<User> userAccounts;
        public JwtTokenHandler()
        {
            userAccounts = new()
            {
                new User() { Username = "admin", Password = "admin@123", Role = "Admin" },
                new User() { Username = "user", Password = "user@123", Role = "User" }
            };
        }

        public AuthenticationResponse GenerateToken(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.Username) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;
            //validate the user
            var user = userAccounts.Where(x => x.Username == authenticationRequest.Username && x.Password == authenticationRequest.Password).FirstOrDefault();
            if (user == null)
                return null;
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var tokenExpireTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var claimsIdentity = new ClaimsIdentity(new List<Claim> {
            new Claim(JwtRegisteredClaimNames.Name, user.Username),
            new Claim("Role",user.Role)

            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
                );

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpireTimeStamp,
                NotBefore = DateTime.Today,
                SigningCredentials = signingCredentials

            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse {
                Username = user.Username,
                JWTToken = token,
                ExpiresIn =(int) tokenExpireTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }
}