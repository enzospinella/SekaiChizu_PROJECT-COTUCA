using System.Threading.Tasks;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Data
{
    public interface IRepositoryMM_Paises
    {
         // Métodos Get
         Task<MM_Paises[]> GetAllPaisesAsync();
         Task<MM_Paises> GetAllPaisesAsyncByCod(int codPais);
    }
}