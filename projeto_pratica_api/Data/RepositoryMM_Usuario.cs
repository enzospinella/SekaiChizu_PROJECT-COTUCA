using System.Linq;
using System.Threading.Tasks;
using projeto_pratica_api.models;
using Microsoft.EntityFrameworkCore;

namespace projeto_pratica_api.Data
{
    public class RepositoryMM_Usuario : IRepositoryMM_Usuario
    {
        public MapaMundiContext Context { get; }
        public RepositoryMM_Usuario(MapaMundiContext context)
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
        
        public async Task<MM_Usuario[]> GetAllUsuariosAsync()
        {
           IQueryable<MM_Usuario> consultaUsuarios = this.Context.MM_Usuario;

           consultaUsuarios = consultaUsuarios.OrderBy(u => u.Id);

           return await consultaUsuarios.ToArrayAsync();
        }

        public async Task<MM_Usuario> GetAllUsuariosAsyncByCod(int cod)
        {
           IQueryable<MM_Usuario> consultaUsuarios = this.Context.MM_Usuario;

           consultaUsuarios = consultaUsuarios.OrderBy(u => u.Id)
                                          .Where(usuario => usuario.Id == cod);

            return await consultaUsuarios.FirstOrDefaultAsync();
        }
    }
}