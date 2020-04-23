using System.Linq;
using System.Threading.Tasks;
using projeto_pratica_api.models;
using Microsoft.EntityFrameworkCore;

namespace projeto_pratica_api.Data
{
    public class RepositoryMM_Paises : IRepositoryMM_Paises
    {
        public MapaMundiContext Context { get; }
        public RepositoryMM_Paises(MapaMundiContext context)
        {
            this.Context = context;
        } 
        
        public async Task<MM_Paises[]> GetAllPaisesAsync()
        {
           IQueryable<MM_Paises> consultaPaises = this.Context.MM_Paises;

           consultaPaises = consultaPaises.OrderBy(p => p.Id);

           return await consultaPaises.ToArrayAsync();
        }

        public async Task<MM_Paises> GetAllPaisesAsyncByCod(int codPais)
        {
           IQueryable<MM_Paises> consultaPaises = this.Context.MM_Paises;

           consultaPaises = consultaPaises.OrderBy(p => p.Id)
                                          .Where(pais => pais.Id == codPais);

            return await consultaPaises.FirstOrDefaultAsync();
        }
    }
}