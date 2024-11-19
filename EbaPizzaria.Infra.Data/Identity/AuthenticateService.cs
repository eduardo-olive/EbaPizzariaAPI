using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EbaPizzaria.Domain.Account;
using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EbaPizzaria.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    private readonly ApplicationDbContext _ebaPizzariaContext;
    private readonly IConfiguration _configuration;

    public AuthenticateService(ApplicationDbContext ebaPizzariaContext, IConfiguration configuration)
    {
        _ebaPizzariaContext = ebaPizzariaContext;
        _configuration = configuration;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        Usuario usuario = await _ebaPizzariaContext.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        if (usuario == null)
        {
            return false;
        }

        using var hmac = new HMACSHA256(usuario.SenhaSalt);
		var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computerHash.Length; i++)
        {
            if (computerHash[i] != usuario.SenhaHash[i]) return false;
        }
        
        return true;
    }

    public async Task<bool> UserExist(string email)
    {
        Usuario usuario = await _ebaPizzariaContext.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        if (usuario == null)
        {
            return false;
        }
        
        return true;
    }

    public string GenerateToken(int id, string email)
    {
        var claims = new[]
        {
            new Claim("id", id.ToString()),
            new Claim("email", email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration["jwt:secretKey"]));
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddMinutes(10);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["jwt:issuer"],
            audience: _configuration["jwt:audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

	public async Task<Usuario> SelecionaUsuarioEmail(string email)
	{
		return await _ebaPizzariaContext.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
	}
}