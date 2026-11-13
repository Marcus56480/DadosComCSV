using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Unicode;
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

        public void Adicionar(Jogo jogo)
        {
            var jogos = Listar();

            jogo.Id = jogos.Count == 0 ? 1 : jogos.Max(j => j.Id) + 1;
            jogos.Add(jogo);
            SalvarTodos(jogos);

        }

        private void SalvarTodos(List<Jogo> jogos)
        {
            var linhas = new List<String>
            {
            "Id;Nome;Desenvolvedora;Genero;AnoLancamento;Preco"
            };

            linhas.AddRange(jogos.Select(j => string.Join(";",
            j.Id.ToString(),
            j.Nome,
            j.Desenvolvedora,
            j.Genero,
            j.AnoLancamento.ToString(),
            j.Preco.ToString()
                ))
            );

            File.WriteAllLines(_caminhoArquivo, linhas, new UTF8Encoding(false));
        }
    }
}