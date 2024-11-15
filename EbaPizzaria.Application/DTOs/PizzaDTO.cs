using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EbaPizzaria.Application.DTOs
{
	public class PizzaDTO
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(30)]
		[Unicode(false)]
		public string Nome { get; set; }

		[Required]
		[StringLength(255)]
		[Unicode(false)]
		public string Descricao { get; set; }

		[Column(TypeName = "decimal(4, 2)")]
		public decimal Valor { get; set; }
	}
}
