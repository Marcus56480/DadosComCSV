namespace DadosComCSV.Models
{
    //! Representa os dados de um jogo que serão salvos no arquivo .CSV
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Desenvolvedora { get; set; } = String.Empty;
        public string Genero { get; set; } = String.Empty;
        public int AnoLancamento { get; set; }
        public decimal Preco { get; set; }
    }
}