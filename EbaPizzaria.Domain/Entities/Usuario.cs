using EbaPizzaria.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaPizzaria.Domain.Entities
{
	public class Usuario
	{
		public int Id { get; private set; }
		public string Nome { get; private set; }
		public string Email { get; private set; }
		public bool IsAdmin { get; private set; }
		public byte[] SenhaHash { get; private set; }
		public byte[] SenhaSalt { get; private set; }

		public Usuario(int id, string nome, string email)
		{
			DomainExceptionValidation.When(id < 0, "O Id não pode ser negativo.");
			Id = id;
			validateDomain(nome, email);
		}

		public Usuario(string nome, string email)
		{
			validateDomain(nome, email);
		}

		public void SetAdmin(bool isAdmin)
		{
			IsAdmin = isAdmin;
		}

		public void AlterarSenha(byte[] senhaHash, byte[] senhaSalt)
		{
			SenhaHash = senhaHash;
			SenhaSalt = senhaSalt;
		}

		private void validateDomain(string nome, string email)
		{
			DomainExceptionValidation.When(nome == null, "O Nome é obrigatório.");
			DomainExceptionValidation.When(email == null, "O Email é obrigatório.");
			DomainExceptionValidation.When(nome.Length > 250, "O Nome não pode passar de 250 caracteres.");
			DomainExceptionValidation.When(email.Length > 250, "O Email não pode passar de 250 caracteres");

			Nome = nome;
			Email = email;
			IsAdmin = false;
		}
	}
}
