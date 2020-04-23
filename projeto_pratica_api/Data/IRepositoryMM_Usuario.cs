using System.Threading.Tasks;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Data
{
    public interface IRepositoryMM_Usuario
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;

        Task<bool> SaveChangesAsync();
        Task<MM_Usuario[]> GetAllUsuariosAsync();
        Task<MM_Usuario> GetAllUsuariosAsyncByCod(int cod);
    }
}