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
    
    [HttpPost("registrar")]
    public async Task<ActionResult<UsuarioToken>> Incluir(UsuarioDTO usuarioDto)
    {
        if (usuarioDto == null)
        {
            return BadRequest("Dados inválidos.");
        }
        
        var emailExiste = await _authenticate.UserExist(usuarioDto.Email);
        if (emailExiste)
        {
            return BadRequest("Esse e-mail possui um cadastro.");
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

    [HttpPost("login")]
    public async Task<ActionResult<UsuarioToken>> Selecionar(LoginModel loginModel)
    {
        var usuarioExiste = await _authenticate.UserExist(loginModel.email);
        if (!usuarioExiste)
        {
            return Unauthorized("Usuário não existe.");
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