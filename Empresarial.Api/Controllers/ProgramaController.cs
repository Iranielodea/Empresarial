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
    public class ProgramaController : BaseAbstractController // ControllerBase
    {
        private readonly IServicoPrograma _servico;
        private readonly ITransacao _transacao;
        private int _usuarioId;
        private int _empresaId;

        public ProgramaController(IServicoPrograma servico, ITransacao transacao)
        {
            _servico = servico;
            _transacao = transacao;
        }

        [HttpPost("Filtrar")]
        public IActionResult Filtrar(ProgramaFiltro filtro)
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
                var programa = _servico.ObterPorId(id);
                var model = programa.Adapt<ProgramaModel>();
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Incluir")]
        public IActionResult Incluir([FromBody]ProgramaModel model)
        {
            return Salvar(model);
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar([FromBody]ProgramaModel model)
        {
            return Salvar(model);
        }

        private IActionResult Salvar(ProgramaModel model)
        {
            try
            {
                var programa = model.Adapt<Programa>();
                _servico.Salvar(programa);
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
                _servico.Excluir(_empresaId, _usuarioId, id);
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