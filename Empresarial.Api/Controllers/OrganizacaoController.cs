using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using Empresarial.Dominio.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Empresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizacaoController : BaseAbstractController
    {
        private readonly IServicoOrganizacao _servico;
        private readonly ITransacao _transacao;

        public OrganizacaoController(IServicoOrganizacao servico, ITransacao transacao)
        {
            _servico = servico;
            _transacao = transacao;
        }

        [HttpPost("Filtrar")]
        public IActionResult Filtrar(OrganizacaoFiltro filtro)
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
                var organizacao = _servico.ObterPorId(id);
                var model = organizacao.Adapt<OrganizacaoModel>();
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost("Editar")]
        public IActionResult Editar(int id)
        {
            try
            {
                var organizacao = _servico.Editar(GetEmpresaID(), GetUsuarioID(), id);
                var model = organizacao.Adapt<OrganizacaoModel>();
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Novo")]
        public IActionResult Novo()
        {
            try
            {
                _servico.Novo(GetEmpresaID(), GetUsuarioID());
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Incluir")]
        public IActionResult Incluir([FromBody]OrganizacaoModel model)
        {
            return Salvar(model);
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar([FromBody]OrganizacaoModel model)
        {
            return Salvar(model);
        }

        private IActionResult Salvar(OrganizacaoModel model)
        {
            try
            {
                var organizacao = model.Adapt<Organizacao>();
                _servico.Salvar(organizacao);
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
                _servico.Excluir(GetEmpresaID(), GetUsuarioID(), id);
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