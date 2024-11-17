using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EbaPizzaria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost]
    public async Task<ActionResult> Incluir(UsuarioDTO usuarioDto)
    {
        UsuarioDTO usuarioInseridoDTO = await _usuarioService.Incluir(usuarioDto);
        if (usuarioInseridoDTO == null)
        {
            return BadRequest("Falaha ao inserir o usuario");
        }
        return Ok(usuarioDto);
    }

    [HttpPut]
    public async Task<ActionResult> Alterar(UsuarioDTO usuarioDto)
    {
        UsuarioDTO usuarioAlteradoDTO = await _usuarioService.Alterar(usuarioDto);
        if (usuarioAlteradoDTO == null)
        {
            return BadRequest("Falha ao alterar o usuario");
        }
        return Ok(usuarioDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        UsuarioDTO usuarioExlcuidoDto = await _usuarioService.Excluir(id);
        if (usuarioExlcuidoDto == null)
        {
            return BadRequest("Falha ao excluir o usuario");
        }
        return Ok(usuarioExlcuidoDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDTO>> SelecionarPorId(int id)
    {
        UsuarioDTO usuarioDTOSelecionado = await _usuarioService.SelecionaById(id);
        if (usuarioDTOSelecionado == null)
        {
            return NotFound("Usuário não localiado.");
        }
        return Ok(usuarioDTOSelecionado);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> SelecionarTodos()
    {
        IEnumerable<UsuarioDTO> usuariosDTOSelecionados = await _usuarioService.SelecionarTodos();
        return Ok(usuariosDTOSelecionados);
    }
}