using System.Threading.Tasks;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Data
{
    public interface IRepositoryLugares
    {
        Task<MM_Lugares> GetAllLugaresAsyncByCodPais(int codPais);
    }
}