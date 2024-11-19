using System.ComponentModel.DataAnnotations;

namespace EbaPizzaria.API.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "O E-mail é obrigatório.")]
		[DataType(DataType.EmailAddress)]
		public string email { get; set; }
		[Required(ErrorMessage = "A Senha é obrigatório.")]
		[DataType(DataType.Password)]
		public string senha { get; set; }
	}
}
