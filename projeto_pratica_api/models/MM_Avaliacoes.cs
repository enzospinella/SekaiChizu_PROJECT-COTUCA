namespace projeto_pratica_api.models
{
    public class MM_Avaliacoes
    {
        public int Id {get; set;}
        public double qtdEstrelas{get; set;}
        public string mensagem{get; set;}
        public string dataAvaliacao{get; set;}
        public int IdUsuario {get; set;}
    }
}