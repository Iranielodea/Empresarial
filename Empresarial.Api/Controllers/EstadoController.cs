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
    public class EstadoController : BaseAbstractController
    {
        private readonly IServicoEstado _servico;
        private readonly ITransacao _transacao;
        private int _usuarioId;
        private int _empresaId;

        public EstadoController(IServicoEstado servico, ITransacao transacao)
        {
            _servico = servico;
            _transacao = transacao;
        }

        [HttpPost("Filtrar")]
        public IActionResult Filtrar([FromBody]EstadoFiltro filtro)
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

        [HttpPost("Novo")]
        public IActionResult Novo()
        {
            try
            {
                PegarUsuarioEmpresa();
                _servico.Novo(_empresaId, _usuarioId);
                return Ok();
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
                var estado = _servico.ObterPorId(id);
                var model = estado.Adapt<EstadoModel>();
                model.NomePais = estado.Pais.Nome;
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ObterPorSigla")]
        public IActionResult ObterPorSigla(string sigla)
        {
            try
            {
                var estado = _servico.ObterPorSigla(sigla);
                var model = estado.Adapt<EstadoModel>();
                model.NomePais = estado.Pais.Nome;
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
                var estado = _servico.Editar(_empresaId, _usuarioId, id);
                var model = estado.Adapt<EstadoModel>();
                model.NomePais = estado.Pais.Nome;
                return new JsonResult(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Incluir")]
        public IActionResult Incluir([FromBody]EstadoModel model)
        {
            return Salvar(model);
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar([FromBody]EstadoModel model)
        {
            return Salvar(model);
        }

        private IActionResult Salvar(EstadoModel model)
        {
            try
            {
                var estado = model.Adapt<Estado>();
                _servico.Salvar(estado);
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
                PegarUsuarioEmpresa();
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