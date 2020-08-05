using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Model;
using Empresarial.Dominio.Servicos;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Empresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ServicoUsuario _servico;
        private readonly ITransacao _transacao;

        public UsuarioController(ServicoUsuario servico, ITransacao transacao)
        {
            _servico = servico;
            _transacao = transacao;
        }

        [HttpPost("Filtrar")]
        public IActionResult Filtrar(UsuarioFiltro filtro)
        {
            try
            {
                var lista = _servico.Filtrar(filtro);
                return new JsonResult(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ObterPorId")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var usuario = _servico.ObterPorId(id);
                var model = usuario.Adapt<UsuarioModel>();
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ObterPorUsuarioSenha")]
        public IActionResult ObterPorUsuarioSenha(string login, string senha)
        {
            try
            {
                var usuario = _servico.ObterUsuarioSenha(login, senha);
                var model = usuario.Adapt<UsuarioModel>();
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Incluir")]
        public IActionResult Incluir([FromBody]UsuarioModel model)
        {
            return Salvar(model);
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar([FromBody]UsuarioModel model)
        {
            return Salvar(model);
        }

        private IActionResult Salvar(UsuarioModel model)
        {
            try
            {
                var usuario = model.Adapt<Usuario>();
                _servico.Salvar(usuario);
                _transacao.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            try
            {
                _servico.Excluir(id);
                _transacao.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}