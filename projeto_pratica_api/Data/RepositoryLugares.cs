using System.Linq;
using System.Threading.Tasks;
using projeto_pratica_api.models;
using Microsoft.EntityFrameworkCore;

namespace projeto_pratica_api.Data
{
    public class RepositoryLugares : IRepositoryLugares
    {
        public MapaMundiContext Context { get; }
        public RepositoryLugares(MapaMundiContext context)
        {
            this.Context = context;
        }

        public async Task<MM_Lugares> GetAllLugaresAsyncByCodPais(int codPais)
        {
           IQueryable<MM_Lugares> consultaLugares = this.Context.MM_Lugares;

           consultaLugares = consultaLugares.OrderBy(l => l.Id)
                                          .Where(lugar => lugar.IdPais == codPais);

            return await consultaLugares.FirstOrDefaultAsync();
        }
    }
}