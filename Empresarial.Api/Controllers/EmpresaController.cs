using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using Empresarial.Dominio.Model;
using Empresarial.Dominio.Servicos;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Empresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : BaseAbstractController
    {
        private readonly IServicoEmpresa _servico;
        private readonly ITransacao _transacao;

        public EmpresaController(IServicoEmpresa servico, ITransacao transacao)
        {
            _servico = servico;
            _transacao = transacao;
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

        [HttpPost("Editar")]
        public IActionResult Editar(int id)
        {
            try
            {
                var empresa = _servico.Editar(GetEmpresaID(), GetUsuarioID(), id);
                var model = empresa.Adapt<EmpresaModel>();
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Filtrar")]
        public IActionResult Filtrar(EmpresaFiltro filtro)
        {
            try
            {
                filtro.OrganizacaoId = GetOrganizacaoID();
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
                var empresa = _servico.ObterPorId(id);
                var model = empresa.Adapt<EmpresaModel>();
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Incluir")]
        public IActionResult Incluir([FromBody]EmpresaModel model)
        {
            return Salvar(model);
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar([FromBody]EmpresaModel model)
        {
            return Salvar(model);
        }

        private IActionResult Salvar(EmpresaModel model)
        {
            try
            {
                var empresa = model.Adapt<Empresa>();
                empresa.OrganizacaoId = GetOrganizacaoID();
                _servico.Salvar(empresa);
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