namespace projeto_pratica_api.models
{
    public class MM_DadosHistoricos 
    {
        public int Id {get; set;}
        public string origem{get; set;}
        public string governo{get; set;}
        public string guerras{get; set;}
        public int codPais {get; set;}
    }
}
/*

    codDHistoricos int primary key identity,
	origem varchar(8000) not null,
	governo varchar(60) not null,
	guerras varchar(1000) not null,

*/