using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SweatitBackEnd.Models.User;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SweatitBackEnd.Utils;

public class JwtService(IConfiguration configInput) {

    private readonly IConfiguration _config = configInput;
    
    public string GenerateJwt(BaseUser userData) {
        var claims = new List<Claim>() {
            new Claim(JwtRegisteredClaimNames.Sub, userData.Id),
            new Claim(JwtRegisteredClaimNames.Email, userData.Email),
        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(this._config["Jwt:Key"] ?? throw new InvalidOperationException("Jwt Key is not set!"))
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: this._config["Jwt:Issuer"],
            audience: this._config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                double.Parse(this._config["Jwt:ExpirationMinutes"] ?? throw new InvalidOperationException("Expiration Minutes is not set!"))
                ),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}