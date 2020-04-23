using Microsoft.EntityFrameworkCore;
using projeto_pratica_api.models;

namespace projeto_pratica_api.Data
{
    public class MapaMundiContext: DbContext
    {
        public MapaMundiContext(DbContextOptions<MapaMundiContext> options): base (options)
        {

        }
        public DbSet<MM_Paises> MM_Paises {get; set;}
        public DbSet<MM_Usuario> MM_Usuario {get; set;}
        public DbSet<MM_DadosHistoricos> MM_DadosHistoricos {get; set;}
        public DbSet<MM_DadosGeograficos> MM_DadosGeograficos {get; set;}
        
    }
}