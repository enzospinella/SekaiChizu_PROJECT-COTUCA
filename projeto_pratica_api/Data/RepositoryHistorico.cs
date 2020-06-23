using System.Linq;
using System.Threading.Tasks;
using projeto_pratica_api.models;
using Microsoft.EntityFrameworkCore;

namespace projeto_pratica_api.Data
{
    public class RepositoryHistorico : IRepositoryHistorico
    {
        public MapaMundiContext Context { get; }
        public RepositoryHistorico(MapaMundiContext context)
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

        public async Task<MM_Historico[]> GetAllHistoricosAsyncByCodUsuario(int codUsuario)
        {
           IQueryable<MM_Historico> consultaHistoricos = this.Context.MM_Historico;

           consultaHistoricos = consultaHistoricos.OrderBy(h => h.Id)
                                          .Where(historico => historico.IdUsuario == codUsuario);

            return await consultaHistoricos.ToArrayAsync();
        }

        public async Task<MM_Historico> GetAllHistoricosAsyncByCod(int cod)
        {
           IQueryable<MM_Historico> consultaHistoricos = this.Context.MM_Historico;

           consultaHistoricos = consultaHistoricos.OrderBy(h => h.Id)
                                          .Where(historico => historico.Id == cod);

            return await consultaHistoricos.FirstOrDefaultAsync();
        }
    }
}