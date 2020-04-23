using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_pratica_api.Data;
using projeto_pratica_api.models;

namespace  projeto_pratica_api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        public IRepositoryMM_Usuario Repo { get; }
        public UsuarioController(IRepositoryMM_Usuario repo) 
        {
            this.Repo = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repo.GetAllUsuariosAsync();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

        [HttpGet("{codUsuario}")]
        public async Task<IActionResult> Get(int codUsuario)
        {
           try
            {
                var result = await this.Repo.GetAllUsuariosAsyncByCod(codUsuario);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }
        }

        [HttpPost("cadastroUsuario")]
        public async Task<IActionResult> post(MM_Usuario model)
        {
            try
            {
                this.Repo.Add(model);

                if(await this.Repo.SaveChangesAsync()) {
                    return Created($"/usuario/{model.Id}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }

        [HttpPut("{codUsuario}")]
        public async Task<IActionResult> put(int codUsuario, MM_Usuario model)
        {
            try
            {
                var result = await this.Repo.GetAllUsuariosAsyncByCod(codUsuario);
                if(result==null) return BadRequest();

                result.Id = model.Id;
                result.nome = model.nome;
                result.sobreNome = model.sobreNome;
                result.senha = model.senha;
                result.nacionalidade = model.nacionalidade;
                result.email = model.email;

                if(await this.Repo.SaveChangesAsync())
                {
                    result = await this.Repo.GetAllUsuariosAsyncByCod(codUsuario);
                    return Ok(result);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }

        [HttpDelete("{codUsuario}")]
        public async Task<IActionResult> delete(int codUsuario)
        {
            try
            {
                //verifica se existe aluno a ser excluído
                var aluno = await this.Repo.GetAllUsuariosAsyncByCod(codUsuario);
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