using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_pratica_api.Data;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Controllers
{
    [Route("/mapa/dadosH")]
    [ApiController]
    public class DadosHdoPaisController : Controller
    {
            public IRepositoryDadosH Repo { get; }
            public DadosHdoPaisController(IRepositoryDadosH repo) 
            {
                this.Repo = repo;
            }
            
            [HttpGet("{codPais}")]
            public async Task<IActionResult> Get(int codPais)
            {
                try
                {
                    var result = await this.Repo.GetDadosHAsyncByCodPais(codPais);
                    return Ok(result);
                }
                catch (System.Exception ex)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
                }
            }
    }
}