using System.Threading.Tasks;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Data
{
    public interface IRepositoryDadosH
    {
        Task<MM_DadosHistoricos[]> GetDadosHAsyncByCodPais (int ID);
    }
}