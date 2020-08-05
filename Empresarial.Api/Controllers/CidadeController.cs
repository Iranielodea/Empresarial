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
    public class CidadeController : BaseAbstractController
    {
        private readonly IServicoCidade _servico;
        private readonly ITransacao _transacao;
        private int _usuarioId;
        private int _empresaId;

        public CidadeController(IServicoCidade servico, ITransacao transacao)
        {
            _servico = servico;
            _transacao = transacao;
        }

        [HttpPost("Filtrar")]
        public IActionResult Filtrar(CidadeFiltro filtro)
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
                var cidade = _servico.ObterPorId(id);
                var model = cidade.Adapt<CidadeModel>();
                model.NomeEstado = cidade.Estado.Nome;
                model.Sigla = cidade.Estado.Sigla;
                return new JsonResult(model);
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
                PegarUsuarioEmpresa();
                var cidade = _servico.Editar(_empresaId, _usuarioId, id);
                var model = cidade.Adapt<CidadeModel>();
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Incluir")]
        public IActionResult Incluir([FromBody]CidadeModel model)
        {
            return Salvar(model);
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar([FromBody]CidadeModel model)
        {
            return Salvar(model);
        }

        private IActionResult Salvar(CidadeModel model)
        {
            try
            {
                var cidade = model.Adapt<Cidade>();
                _servico.Salvar(cidade);
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
                _servico.Excluir(1,1, id);
                _transacao.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void PegarUsuarioEmpresa()
        {
            _empresaId = GetEmpresaID();
            _usuarioId = GetEmpresaID();
        }
    }
}