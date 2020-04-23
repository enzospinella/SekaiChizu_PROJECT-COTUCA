using System.Threading.Tasks;
using projeto_pratica_api.Models;

namespace projeto_pratica_api.Data
{
    public interface IRepositoryPaises
    {
         Task<MM_Paises[]> GetAllPaisesAsync();
         Task<MM_Paises> GetAllPaisesAsyncByCod(int cod);
    }
}