using System.Threading.Tasks;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Data
{
    public interface IRepositoryAvaliacoes
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;

        Task<bool> SaveChangesAsync();
        Task<MM_Avaliacoes[]> GetAllAvaliacoesAsync();
        Task<MM_Avaliacoes> GetAllAvaliacoesAsyncByCod(int cod);
        Task<MM_Avaliacoes> GetAllAvaliacoesAsyncByCodUsuario(int codUsuario);
    }
}