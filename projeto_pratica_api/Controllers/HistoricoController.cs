using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_pratica_api.Data;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class HistoricoController : Controller
    {
        public IRepositoryHistorico Repo { get; }
        public HistoricoController(IRepositoryHistorico repo) 
        {
            this.Repo = repo;
        }

        [HttpDelete("{codHistorico}")]
        public async Task<IActionResult> delete(int codHistorico)
        {
            try
            {
                var usuario = await this.Repo.GetAllHistoricosAsyncByCod(codHistorico);
                if (usuario == null)
                {
                    //método do EF
                    return NotFound();
                }

                this.Repo.Delete(usuario);
                await this.Repo.SaveChangesAsync();
                return NoContent();
            }
            catch 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            //return BadRequest();
        }

        [HttpGet("{codUsuario}")]
        public async Task<IActionResult> Get(int codUsuario)
        {
           try
            {
                var result = await this.Repo.GetAllHistoricosAsyncByCodUsuario(codUsuario);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(MM_Historico model)
        {
            try
            {
                this.Repo.Add(model);

                if(await this.Repo.SaveChangesAsync()) {
                    var result = await this.Repo.GetAllHistoricosAsyncByCod(model.Id);
                    return Ok(result);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }
    }
}