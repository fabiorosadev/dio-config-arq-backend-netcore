using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Curso.Api.Business.Entities;
using Curso.Api.Business.Repositories;
using Curso.Api.Configurations;
using Curso.Api.Filters;
using Curso.Api.Infraestruture.Data;
using Curso.Api.Models;
using Curso.Api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace Curso.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;        
        private readonly IAuthenticationService _authenticationService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IConfiguration configuration, IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;            
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Método para Login
        /// </summary>
        /// <param name="loginViewModelinput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode:200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelinput))]
        [SwaggerResponse(statusCode:400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode:500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelinput loginViewModelinput)
        {

            var usuario = _usuarioRepository.ObterUsuario(loginViewModelinput.Login);

            if (usuario == null)
            {
                return BadRequest("Houve um erro ao tentar acessar.");
            }

            //if(usuario.Senha != loginViewModelinput)

            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "fabiorosa.net",
                Email = "fabiorosa.net@gmail.com"
            };
            
            
            var token = _authenticationService.GerarToken(usuarioViewModelOutput);

            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutput
            });
        }

        /// <summary>
        /// Método para Registrar Login
        /// </summary>
        /// <param name="registroViewModelinput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelinput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelinput)
        {
            
            // var migracoesPendentes = contexto.Database.GetPendingMigrations();
            // if(migracoesPendentes.Count() > 0)
            // {
            //     contexto.Database.Migrate();
            // }

            var usuario = new Usuario()
            {
                Login = registroViewModelinput.Login,
                Senha = registroViewModelinput.Senha,
                Email = registroViewModelinput.Email
            };

            _usuarioRepository.Adicionar(usuario);  
            _usuarioRepository.Comnit();          

            return Created("", registroViewModelinput);
        }
    }
}
