using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_pratica_api.Data;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AvaliacoesController : Controller
    {
        public IRepositoryAvaliacoes Repo { get; }
        public AvaliacoesController(IRepositoryAvaliacoes repo) 
        {
            this.Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repo.GetAllAvaliacoesAsync();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

        /*
        Isso sera utilizado para quando uma procura for realizada atravez de
        */


        [HttpGet("{codUsuario}")]
        public async Task<IActionResult> Get(int codUsuario)
        {
           try
            {
                var result = await this.Repo.GetAllAvaliacoesAsyncByCodUsuario(codUsuario);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(MM_Avaliacoes model)
        {
            try
            {
                this.Repo.Add(model);

                if(await this.Repo.SaveChangesAsync()) {
                    var result = await this.Repo.GetAllAvaliacoesAsyncByCod(model.Id);
                    return Ok(result);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return BadRequest();
        }

        [HttpPut("{codAvaliacao}")]
        public async Task<IActionResult> put(int codAvaliacao, MM_Avaliacoes model)
        {
            try
            {
                var result = await this.Repo.GetAllAvaliacoesAsyncByCod(codAvaliacao);
                if(result==null) return BadRequest();

                result.qtdEstrelas = model.qtdEstrelas;
                result.mensagem = model.mensagem;
                result.dataAvaliacao = model.dataAvaliacao;

                if(await this.Repo.SaveChangesAsync())
                {
                    result = await this.Repo.GetAllAvaliacoesAsyncByCod(codAvaliacao);
                    return Ok(result);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete("{codAvaliacao}")]
        public async Task<IActionResult> delete(int codAvaliacao)
        {
            try
            {
                var aluno = await this.Repo.GetAllAvaliacoesAsyncByCod(codAvaliacao);
                if (aluno == null)
                {
                    //método do EF
                    return NotFound();
                }

                this.Repo.Delete(aluno);
                await this.Repo.SaveChangesAsync();
                return NoContent();
            }
            catch 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            //return BadRequest();
        }
    }
}