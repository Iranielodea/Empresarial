using Empresarial.Aplicacao.Interfaces;
using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Empresarial.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    [ApiController]
    public class PaisController : Controller //BaseAbstractController
    {
        private readonly IAppServicoPais _appServico;
        private readonly IUsuarioIdentity _usuarioIdentity;
        public PaisController(IAppServicoPais appServico, IUsuarioIdentity usuarioIdentity)
        {
            _appServico = appServico;
            _usuarioIdentity = usuarioIdentity;
        }

        [HttpPost("Filtrar")]
        //[ProducesResponseType(typeof(PaisConsulta[]), 200)]
        //[APICustomAuthorize(ProgramasConstants.Usuario, PermissoesConstants.Acesso)]
        public IActionResult Filtrar([FromBody]PaisFiltro filtro)
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

        private int GetEmpresaID()
        {
            return 0;
        }

        private int GetUsuarioID()
        {
            return 0;
        }

        [HttpPost("Novo")]
        //[ProducesResponseType(typeof(UsuarioListaModel[]), 200)]
        //[APICustomAuthorize(ProgramasConstants.Usuario, PermissoesConstants.Acesso)]
        public IActionResult Novo()
        {
            try
            {
                var viewModel = _appServico.Novo(GetEmpresaID(), GetUsuarioID());
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObterPorId")]
        //[ProducesResponseType(typeof(UsuarioListaModel[]), 200)]
        //[APICustomAuthorize(ProgramasConstants.Usuario, PermissoesConstants.Acesso)]
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
        //[ProducesResponseType(typeof(UsuarioListaModel[]), 200)]
        //[APICustomAuthorize(ProgramasConstants.Usuario, PermissoesConstants.Acesso)]
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
        //[APICustomAuthorize(ProgramasConstants.Usuario, PermissoesConstants.Incluir)]
        public IActionResult Incluir([FromBody]PaisModel viewModel)
        {
            return Salvar(viewModel);
        }

        [HttpPost("Alterar")]
        //[APICustomAuthorize(ProgramasConstants.Usuario, PermissoesConstants.Incluir)]
        public IActionResult Alterar([FromBody]PaisModel viewModel)
        {
            return Salvar(viewModel);
        }

        //private IActionResult Salvar()
        private IActionResult Salvar(PaisModel viewModel)
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
        //[APICustomAuthorize(ProgramasConstants.Usuario, PermissoesConstants.Incluir)]
        public IActionResult Excluir(int id)
        {
            try
            {
                _appServico.Excluir(GetEmpresaID(), GetUsuarioID(), id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}