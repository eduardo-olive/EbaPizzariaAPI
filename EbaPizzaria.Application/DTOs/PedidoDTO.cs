using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EbaPizzaria.Application.DTOs;

public class PedidoDTO
{
    [Key]
    public int Id { get; private set; }
    
    [Required(ErrorMessage = "O Id do cliente não pode ser vazio.")]
    public int IdCliente { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorPedido { get; set; }
	public ClienteDTO ClienteDTO { get; set; }
	
}