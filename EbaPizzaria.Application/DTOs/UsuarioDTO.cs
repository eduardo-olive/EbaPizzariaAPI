
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EbaPizzaria.Application.DTOs
{
	public class UsuarioDTO
	{
		//[Key]
		//public int Id { get; set; }

		[Required(ErrorMessage = "O Campo nome não pode ser vazio.")]
		[StringLength(255)]
		[Unicode(false)]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O Campo E-mail não pode ser vazio.")]
		[StringLength(255)]
		[Unicode(false)]
		public string Email { get; set; }

		[Required(ErrorMessage = "O Campo senha não pode ser vazio.")]
		[StringLength(255)]
		[Unicode(false)]
		public string senha { get; set; }
	}
}
