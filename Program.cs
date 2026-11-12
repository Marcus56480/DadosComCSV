using DadosComCSV.Repositories;
using DadosComCSV.Services;

var repository = new JogoRepository();
var service = new JogoService(repository);

bool executando = true;

while (executando)
{
    // Console.Clear();
    Console.WriteLine("======= GESTÃO DE JOGOS =======");
    Console.WriteLine("1 - CADASTRAR JOGO");
    Console.WriteLine("2 - LISTAR JOGOS");
    Console.WriteLine("0 - SAIR");
    Console.Write("\nEscolha uma opção: ");

    string? opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1": 
                //TODO: Cadastrar();
            break;

            case "2":
                var listaJogos = service.Listar();
                foreach (var item in listaJogos)
                {
                    Console.WriteLine($"Nome: {item.Nome} - Preço: {item.Preco:C}");
                }
            break;

            case "0":
                executando = false;
            break; 

            default:
                Console.WriteLine("Opção inválida!");
            break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
        throw;
    }
}