using System.Threading.Tasks;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Data
{
    public interface IRepositoryDadosG
    {
        Task<MM_DadosGeograficos[]> GetDadosGAsyncByCodPais (int ID);
    }
}