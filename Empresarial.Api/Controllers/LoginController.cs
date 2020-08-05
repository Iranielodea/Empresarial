using Empresarial.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Empresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller //ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario request)
        {
            if (request.Login == "irani" && request.Senha == "123")
            {
                request.Email = "iranielodea@hotmail.com";
                request.Nome = "Irani";
                request.Id = 1;

                var claims = new[]
                {
                     new Claim(ClaimTypes.Name, request.Nome),
                     new Claim(ClaimTypes.Email, request.Email),

                     new Claim("ID", "1"),
                     new Claim("EMPRESA", "1"),
                     new Claim("ORGANIZACAO", "1")
                };

                //recebe uma instancia da classe SymmetricSecurityKey 
                //armazenando a chave de criptografia usada na criação do token
                var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                //recebe um objeto do tipo SigninCredentials contendo a chave de 
                //criptografia e o algoritmo de segurança empregados na geração 
                // de assinaturas digitais para tokens
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                     issuer: "macoratti.net",
                     audience: "macoratti.net",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Credenciais inválidas...");
        }


        //[AllowAnonymous]
        //[HttpPost]
        //public object Post(
        //    [FromBody] Usuario usuario,
        //    [FromServices]ServicoUsuario usrService,
        //    [FromServices]ServicoUsuarioEmpresa servicoUsuarioEmpresa,
        //    [FromServices]SigningConfigurations signingConfigurations,
        //    [FromServices]TokenConfigurations tokenConfigurations)
        //{
        //    bool credenciaisValidas = false;
        //    if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Login))
        //    {
        //        var usuarioBase = usrService.ObterUsuarioSenha(usuario.Login, usuario.Senha);
        //        credenciaisValidas = (usuarioBase != null &&
        //            usuario.Login == usuarioBase.Login &&
        //            usuario.Senha == usuarioBase.Senha
        //            );

        //        usuario = usrService.ObterPorId(usuarioBase.Id);
        //    }

        //    if (credenciaisValidas)
        //    {
        //        var usuarioEmpresa = servicoUsuarioEmpresa.ObterPorUsuarioId(1,usuario.Id);
        //        string id = usuarioEmpresa.UsuarioId.ToString();
        //        string empresaId = usuarioEmpresa.EmpresaId.ToString();
        //        string organizacaoId = "1"; // usuarioEmpresa.Empresa.OrganizacaoId.ToString();

        //        ClaimsIdentity identity = new ClaimsIdentity(
        //            new GenericIdentity(usuario.Id.ToString(), "Login"),
        //            new[] {
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
        //                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Id.ToString()),

        //                new Claim("ID", id),
        //                new Claim("EMPRESA", empresaId),
        //                new Claim("ORGANIZACAO", organizacaoId)

        //                //new Claim("ID", "1"),
        //                ////new Claim("LOGIN", usuario.Login),
        //                //new Claim("EMPRESA", "1"),
        //                //new Claim("ORGANIZACAO", "1")
        //            }
        //        );

        //        DateTime dataCriacao = DateTime.Now;
        //        DateTime dataExpiracao = dataCriacao +
        //            TimeSpan.FromSeconds(tokenConfigurations.Seconds);

        //        var handler = new JwtSecurityTokenHandler();
        //        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        //        {
        //            Issuer = tokenConfigurations.Issuer,
        //            Audience = tokenConfigurations.Audience,
        //            SigningCredentials = signingConfigurations.SigningCredentials,
        //            Subject = identity,
        //            NotBefore = dataCriacao,
        //            Expires = dataExpiracao
        //        });
        //        var token = handler.WriteToken(securityToken);

        //        return new
        //        {
        //            authenticated = true,
        //            created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
        //            expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
        //            accessToken = token,
        //            message = "OK"
        //        };
        //    }
        //    else
        //    {
        //        return new
        //        {
        //            authenticated = false,
        //            message = "Falha ao autenticar"
        //        };
        //    }
        //}
    }
}