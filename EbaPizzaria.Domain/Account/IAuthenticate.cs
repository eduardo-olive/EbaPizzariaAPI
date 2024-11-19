using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Domain.Account;

public interface IAuthenticate
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<bool> UserExist(string email);
    public string GenerateToken(int id, string email);

    public Task<Usuario> SelecionaUsuarioEmail(string email);
}