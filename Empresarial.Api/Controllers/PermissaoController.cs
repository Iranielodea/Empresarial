using Empresarial.Aplicacao.Interfaces;
using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Empresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissaoController : BaseAbstractController
    {
        private readonly IAppServicoPermissao _appServico;

        public PermissaoController(IAppServicoPermissao appServico)
        {
            _appServico = appServico;
        }

        [HttpPost("Filtrar")]
        public IActionResult Filtrar([FromBody]PermissaoFiltro filtro)
        {
            try
            {
                var listaViewModel = _appServico.Filtrar(filtro);
                return new JsonResult(listaViewModel);
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
                var viewModel = _appServico.Novo(GetEmpresaID(), GetUsuarioID());
                return new JsonResult(viewModel);
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
                var viewModel = _appServico.ObterPorId(id);
                return new JsonResult(viewModel);
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
                var viewModel = _appServico.Editar(GetEmpresaID(), GetUsuarioID(), id);
                return new JsonResult(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Incluir")]
        public IActionResult Incluir([FromBody]PermissaoModel viewModel)
        {
            return Salvar(viewModel);
        }

        [HttpPost("Alterar")]
        public IActionResult Alterar([FromBody]PermissaoModel viewModel)
        {
            return Salvar(viewModel);
        }

        private IActionResult Salvar(PermissaoModel viewModel)
        {
            try
            {
                _appServico.Salvar(viewModel);
                if (!_appServico.Notificacao().IsValid())
                    return BadRequest(_appServico.Notificacao().RetornarErros());
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
                _appServico.Excluir(GetEmpresaID(), GetUsuarioID(), id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}