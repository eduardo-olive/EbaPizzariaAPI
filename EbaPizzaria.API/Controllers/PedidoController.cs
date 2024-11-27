using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EbaPizzaria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : Controller
{
    private readonly IPedidoService _pedidoService;

    public PedidoController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<ActionResult> Listar()
    {
        IEnumerable<PedidoDTO> pedidosDTOSelecionadoTodos = await _pedidoService.SelecionarTodos();
        return Ok(pedidosDTOSelecionadoTodos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> ListarPorId(int id)
    {
        PedidoDTO pedidoSelecionado = await _pedidoService.SelecionarById(id);
        return Ok(pedidoSelecionado);
    }


    [HttpPost]
    public async Task<ActionResult> Incluir(PedidoPostDTO pedidoPostDTO)
    {
        var pedidoDTOIncluido = await _pedidoService.Incluir(pedidoPostDTO);
        if (pedidoDTOIncluido == null)
            return BadRequest("Falha ao incluir o pedido");
        
        return Ok(pedidoDTOIncluido);
    }
}