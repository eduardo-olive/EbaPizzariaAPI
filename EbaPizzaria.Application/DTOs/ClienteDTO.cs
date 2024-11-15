using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EbaPizzaria.Application.DTOs
{
	public class ClienteDTO
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[Unicode(false)]
		public string Nome { get; set; }

		[Required]
		[StringLength(50)]
		[Unicode(false)]
		public string Endereco { get; set; }

		[Required]
		[StringLength(15)]
		[Unicode(false)]
		public string Contato { get; set; }
	}
}
