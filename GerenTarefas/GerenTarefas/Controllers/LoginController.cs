using GerenTarefas.Dtos;
using GerenTarefas.Models;
using GerenTarefas.Repository;
using GerenTarefas.Services;
using GerenTarefas.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenTarefas.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;


        public LoginController(ILogger<LoginController> logger,
            IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;

        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto requisicao)
        {
            try
            { //Autenticar usuário
                if (requisicao == null
                    || string.IsNullOrEmpty(requisicao.Login) || string.IsNullOrWhiteSpace(requisicao.Login)
                    || string.IsNullOrEmpty(requisicao.Senha) || string.IsNullOrWhiteSpace(requisicao.Senha))
                {
                    return BadRequest(new ErroRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Erro = "Parâmetros de entrada invalidos!"
                    });
                }

                var usuario = _usuarioRepository.GetUsuarioByLoginSenha(requisicao.Login, MD5Utils.GerarHashMD5(requisicao.Senha));

                if(usuario == null)
                {
                    return BadRequest(new ErroRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Erro = "Usuário ou senha inválidos"
                    });
                }

                var token = TokenService.CriarToken(usuario);

                return Ok(new LoginRespostaDto() {
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Token = token
                    });
            }
            catch (Exception excecao)
            {
                _logger.LogError($"Ocorreu erro ao efetuar login {excecao.Message}", excecao);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Erro = "Ocorreu erro ao efetuar tente novamente!"
                });
            }
        }
    }
}