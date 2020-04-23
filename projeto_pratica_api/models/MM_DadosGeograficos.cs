namespace projeto_pratica_api.models
{
    public class MM_DadosGeograficos 
    {
        public int Id {get; set;}
        public double pib {get; set;}
        public double pibPerCapita{get; set;}
        public double idh{get; set;}
        public string moeda{get; set;}
        public string fusoHorario{get; set;}
        public string idioma{get; set;}
        public int populacao { get; set; }
        public string continente { get; set; }
        public int codPais {get; set;}
    }
}