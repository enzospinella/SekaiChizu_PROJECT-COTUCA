using System.Linq;
using System.Threading.Tasks;
using projeto_pratica_api.Models;
using Microsoft.EntityFrameworkCore;

namespace projeto_pratica_api.Data
{
    public class RepositoryPaises : IRepositoryPaises
    {
        public MapaMundiContext Context { get; }
        public RepositoryPaises(MapaMundiContext context)
        {
            this.Context = context;
        }

        public async Task<MM_Paises[]> GetAllPaisesAsync()
        {
           IQueryable<MM_Paises> consultaPaises = this.Context.MM_Paises;

           consultaPaises = consultaPaises.OrderBy(p => p.nome);

           return await consultaPaises.ToArrayAsync();
        }

        public async Task<MM_Paises> GetAllPaisesAsyncByCod(int codPais)
        {
           IQueryable<MM_Paises> consultaPaises = this.Context.MM_Paises;

           consultaPaises = consultaPaises.OrderBy(p => p.nome)
                                          .Where(pais => pais.codPais == codPais);

            return await consultaPaises.FirstOrDefaultAsync();
        }
    }
}