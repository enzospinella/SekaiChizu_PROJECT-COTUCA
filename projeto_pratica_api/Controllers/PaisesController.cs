using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_pratica_api.Data;
using projeto_pratica_api.models;

namespace  projeto_pratica_api.Controllers
{
    [Route("/mapa")]
    [ApiController]
    public class PaisesController : Controller
    {
        public IRepositoryMM_Paises Repo { get; }
        public PaisesController(IRepositoryMM_Paises repo) 
        {
            this.Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repo.GetAllPaisesAsync();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }
        
        [HttpGet("{codPais}")]
        public async Task<IActionResult> Get(int codPais)
        {
           try
            {
                var result = await this.Repo.GetAllPaisesAsyncByCod(codPais);
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