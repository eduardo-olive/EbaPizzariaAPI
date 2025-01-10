using AutoMapper;
using EbaPizzaria.API.Models;
using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Domain.Account;
using EbaPizzaria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EbaPizzaria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : Controller
{
    private readonly IUsuarioService _usuarioService;
    private readonly IAuthenticate _authenticate;
    public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
    {
        _usuarioService = usuarioService;
        _authenticate = authenticate;
	}

	/// <summary>
	/// Registra um usuário
	/// </summary>
	/// <remarks>
	/// {
	///  "id": 0,
	///  "nome": "string",
	///  "email": "string",
	///  "senha": "string"
	/// }
	/// </remarks>
	/// <param name="usuarioDto"></param>
	/// <returns>Token de acesso</returns>
	/// <response code="400">Dados inválidos</response>
	/// <response code="422">E-mail informado já cadastrado.</response>
	/// <response code="201">Sucesso</response>
	[HttpPost("registrar")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<UsuarioToken>> Incluir(UsuarioDTO usuarioDto)
    {
        if (usuarioDto == null)
        {
            return BadRequest("Dados inválidos.");
        }
        
        var emailExiste = await _authenticate.UserExist(usuarioDto.Email);
        if (emailExiste)
        {
            return UnprocessableEntity("Esse e-mail possui um cadastro.");
        }
        
        UsuarioDTO usuarioInseridoDTO = await _usuarioService.Incluir(usuarioDto);
        if (usuarioInseridoDTO == null)
        {
            return BadRequest("Falha ao inserir o usuario");
        }
        var token = _authenticate.GenerateToken(usuarioInseridoDTO.Id, usuarioInseridoDTO.Email);
        return new UsuarioToken
        {
            Token = token
        };
    }

    /// <summary>
    /// Efetua login na API.
    /// </summary>
    /// <param name="loginModel"></param>
    /// <returns>Nada.</returns>
    /// <response code="404">Usuário não encontrado.</response>
    /// <response code="401">E-mail ou senha inválidos.</response>
    /// <response code="200">Sucesso</response>
    [HttpPost("login")]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<UsuarioToken>> Selecionar(LoginModel loginModel)
    {
        var usuarioExiste = await _authenticate.UserExist(loginModel.email);
        if (!usuarioExiste)
        {
            return NotFound("Usuário não existe.");
        }

        var result = await _authenticate.AuthenticateAsync(loginModel.email, loginModel.senha);
        if (!result)
        {
            return Unauthorized("E-mail ou senha inválidos.");
        }

        Usuario usuario = await _authenticate.SelecionaUsuarioEmail(loginModel.email);

        var token = _authenticate.GenerateToken(usuario.Id, usuario.Email);

        return new UsuarioToken
        {
            Token = token
        };
    }
}