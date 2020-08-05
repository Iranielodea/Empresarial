using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Empresarial.Api.Controllers
{
    //[Authorize("Bearer")]
    [Authorize()]
    [Route("api/[controller]")]
    public abstract class BaseAbstractController : ControllerBase
    {
        protected int GetEmpresaID()
        {
            return int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "EMPRESA")?.Value);
        }

        protected int GetUsuarioID()
        {
            return int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ID")?.Value);
        }

        protected int GetOrganizacaoID()
        {
            return int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ORGANIZACAO")?.Value);
        }
    }
}