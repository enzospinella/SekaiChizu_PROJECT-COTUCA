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

        //isso vai retornar quando o 8080 fizer a requisicao de usuarios para o 5000 (essa API) 
        /*
        
        this.$http.get("http://localhost:5000/usuario")
                  .then(res => res.json())
                  .then (
                    dadosRetornados => (this.usuarios = dadosRetornados),
                    err => console.log(err)
                  );
        o metodo abaixo da a resposta para a requisicao
                  
        */
        //[EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
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

        /*
        Isso sera utilizado para quando uma procura for realizada atravez de
        */


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

                result.nome = model.nome;
                result.sobreNome = model.sobreNome;
                result.senha = model.senha;
                result.email = model.email;

                if(await this.Repo.SaveChangesAsync())
                {
                    result = await this.Repo.GetAllUsuariosAsyncByCod(codUsuario);
                    return Ok(result);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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