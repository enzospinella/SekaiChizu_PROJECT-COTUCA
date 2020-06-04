using System.Threading.Tasks;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Data
{
    public interface IRepositoryHistorico
    {
        void Add<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<MM_Historico> GetAllHistoricosAsyncByCod(int cod);
        Task<MM_Historico> GetAllHistoricosAsyncByCodUsuario(int codUsuario);
    }
}