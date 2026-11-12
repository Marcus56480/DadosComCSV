using System.Runtime.InteropServices.Marshalling;
using System.Text;
using DadosComCSV.Models;

namespace DadosComCSV.Repositories
{
    public class JogoRepository
    {
        private readonly string _caminhoArquivo;
        public JogoRepository()
        {
            // Cria a pasta e o arquivo com o cabeçalho se ainda não existirem
            // Combina e monta caminhos usando o separador correto do sistema
            string pasta = Path.Combine(Environment.CurrentDirectory, "data");
            Directory.CreateDirectory(pasta);

            _caminhoArquivo = Path.Combine(pasta, "jogos.csv");

            if (!File.Exists(_caminhoArquivo))
            {
                File.WriteAllText(
                    _caminhoArquivo,
                    "Id;Nome;Desenvolvedora;Genero;AnoLancamento;Preco" + Environment.NewLine,
                    Encoding.UTF8
                );
            }
        }

        public List<Jogo> Listar()
        {
            var jogos = new List<Jogo>();
            var linhas = File.ReadAllLines(_caminhoArquivo, Encoding.UTF8);

            foreach (var linha in linhas.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(linha))
                {
                    continue;
                }

                var campos = linha.Split(';');

                if (campos.Length != 6)
                {
                    continue;
                }

                jogos.Add(new Jogo
                {
                    Id = int.Parse(campos[0]),
                    Nome = campos[1],
                    Desenvolvedora = campos[2],
                    Genero = campos[3],
                    AnoLancamento = int.Parse(campos[4]),
                    Preco = decimal.Parse(campos[5])

                });
            }

            return jogos;

        }
    }
}