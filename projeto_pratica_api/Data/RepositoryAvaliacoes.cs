using System.Linq;
using System.Threading.Tasks;
using projeto_pratica_api.models;
using Microsoft.EntityFrameworkCore;

namespace projeto_pratica_api.Data
{
    public class RepositoryAvaliacoes : IRepositoryAvaliacoes
    {
        public MapaMundiContext Context { get; }
        public RepositoryAvaliacoes(MapaMundiContext context)
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
        
        public async Task<MM_Avaliacoes[]> GetAllAvaliacoesAsync()
        {
           IQueryable<MM_Avaliacoes> consultaAvaliacoes = this.Context.MM_Avaliacoes;

           consultaAvaliacoes = consultaAvaliacoes.OrderBy(a => a.Id);

           return await consultaAvaliacoes.ToArrayAsync();
        }

        public async Task<MM_Avaliacoes> GetAllAvaliacoesAsyncByCod(int cod)
        {
           IQueryable<MM_Avaliacoes> consultaAvaliacoes = this.Context.MM_Avaliacoes;

           consultaAvaliacoes = consultaAvaliacoes.OrderBy(a => a.Id)
                                          .Where(avaliacao => avaliacao.Id == cod);

            return await consultaAvaliacoes.FirstOrDefaultAsync();
        }

        public async Task<MM_Avaliacoes[]> GetAllAvaliacoesAsyncByCodUsuario(int codUsuario)
        {
           IQueryable<MM_Avaliacoes> consultaAvaliacoes = this.Context.MM_Avaliacoes;

           consultaAvaliacoes = consultaAvaliacoes.OrderBy(a => a.Id)
                                          .Where(avaliacao => avaliacao.IdUsuario == codUsuario);

            return await consultaAvaliacoes.ToArrayAsync();
        }
    }
}