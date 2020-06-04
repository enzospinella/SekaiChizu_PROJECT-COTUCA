using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_pratica_api.Data;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LugaresController : Controller
    {
        public IRepositoryLugares Repo { get; }
        public LugaresController(IRepositoryLugares repo)
        {
            this.Repo = repo;
        }
            
        [HttpGet("{codPais}")]
        public async Task<IActionResult> Get(int codPais)
        {
            try
            {
                var result = await this.Repo.GetAllLugaresAsyncByCodPais(codPais);
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