using System.Threading.Tasks;
using projeto_pratica_api.models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace projeto_pratica_api.Data
{
    public class RepositoryDadosG : IRepositoryDadosG
    {
        public MapaMundiContext Context { get; }

        public RepositoryDadosG(MapaMundiContext context)
        {
            this.Context = context;
        }

        public async Task<MM_DadosGeograficos[]> GetDadosGAsyncByCodPais (int ID)
        {
            IQueryable<MM_DadosGeograficos> consultaDadosG = this.Context.MM_DadosGeograficos;

            consultaDadosG = consultaDadosG.OrderBy(p => p.Id)
                                           .Where(dadosG => dadosG.codPais == ID);
            
            return await consultaDadosG.ToArrayAsync();
        }
    }
}