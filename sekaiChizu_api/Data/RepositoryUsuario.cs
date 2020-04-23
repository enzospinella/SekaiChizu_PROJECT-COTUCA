using System.Linq;
using System.Threading.Tasks;
using projeto_pratica_api.Models;
using Microsoft.EntityFrameworkCore;

namespace projeto_pratica_api.Data
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public MapaMundiContext Context { get; }
        public RepositoryUsuario(MapaMundiContext context)
        {
            this.Context = context;
        }

        public void Add<T>(T entity) where T : class
        {
           this.Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           this.Context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await this.Context.SaveChangesAsync() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
           this.Context.Update(entity);
        }

        public async Task<MM_Usuario> GetAllUsuariosAsyncByCod(int cod)
        {
           IQueryable<MM_Usuario> consultaUsuarios = this.Context.MM_Usuario;

           consultaUsuarios = consultaUsuarios.OrderBy(u => u.codUsuario)
                                          .Where(usuario => usuario.codUsuario == cod);

            return await consultaUsuarios.FirstOrDefaultAsync();
        }
    }
}