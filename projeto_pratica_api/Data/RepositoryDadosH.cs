using System.Threading.Tasks;
using projeto_pratica_api.models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace projeto_pratica_api.Data
{
    public class RepositoryDadosH : IRepositoryDadosH
    {
        public MapaMundiContext Context { get; }

        public RepositoryDadosH(MapaMundiContext context)
        {
            this.Context = context;
        }

        public async Task<MM_DadosHistoricos[]> GetDadosHAsyncByCodPais (int ID)
        {
            IQueryable<MM_DadosHistoricos> consultaDadosH = this.Context.MM_DadosHistoricos;

            consultaDadosH = consultaDadosH.OrderBy(p => p.Id)
                                           .Where(dadosH => dadosH.codPais == ID);

            return await consultaDadosH.ToArrayAsync();
        }
    }
}