using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_pratica_api.Data;
using projeto_pratica_api.Models;

namespace projeto_pratica_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : Controller
    {
        public IRepositoryPaises Repo { get; }
        public PaisesController(IRepositoryPaises repo)
        {
            this.Repo = repo;
        }

        /*
        Realiza a conexao com o banco de dados
        */
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repo.GetAllPaisesAsync();
                return Ok(result);
            }
            catch 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao Banco de Dados");
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
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao Banco de Dados");
            }
        }
    }
}