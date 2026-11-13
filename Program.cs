// Program => Service => Repository => Modelo + DB

using DadosComCSV.Models;
using DadosComCSV.Repositories;
using DadosComCSV.Services;

var repository = new JogoRepository();
var service = new JogoService(repository);

bool executando = true;

while (executando)
{
    Console.Clear();
    Console.WriteLine("\n======= GESTÃO DE JOGOS =======");
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
                Cadastrar();
            break;

            case "2":
                Listar();
            break;

            case "3":
                //TODO: Editar();
            break;

            case "4":
                //TODO: Apagar();
            break;

            case "0":
                executando = false;
            break; 

            default:
                Console.WriteLine("Opção inválida!");
                Pausar();
            break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
        throw;
    }
}

void Listar()
{
    Console.Clear();
    Console.WriteLine("============= Jogos Cadastrados =============");

    var jogos = service.Listar();

    if (jogos.Count == 0)
    {
        Console.WriteLine("Nenhum jogo cadastrado.");
    }

    else
    {
        foreach (var jogo in jogos)
        {
            ExibirJogo(jogo);
        }
    }

    Pausar();
}

void ExibirJogo(Jogo jogo)
{
    Console.WriteLine($"""
    --------------------------------------------------------------
    ID: {jogo.Id}
    Nome: {jogo.Nome}
    Desenvolvedora: {jogo.Desenvolvedora}
    Gênero: {jogo.Genero}
    Ano de Lançamento: {jogo.AnoLancamento}
    Preço: {jogo.Preco:C}
    """);
}

void Pausar()
{
    Console.WriteLine("\nPressione Enter para continuar...");
    Console.ReadLine();
}

void Cadastrar()
{
    Console.Clear();
    Console.WriteLine("============= Cadastrar Jogo =============");

    var jogo = LerDadosJogo();

    service.Cadastrar(jogo);

    Console.WriteLine("\nJogo Cadastrado com sucesso");
    Pausar();
}

Jogo LerDadosJogo()
{
    Console.Write("Nome: ");
    string nome = Console.ReadLine() ?? "Não Informado";

    Console.Write("Desenvolvedora: ");
    string desenvolvedora = Console.ReadLine() ?? "Não Informado";
    
    Console.Write("Gênero: ");
    string genero = Console.ReadLine() ?? "Não Informado";
    
    Console.Write("Ano de Lançamento: ");
    int ano = int.Parse(Console.ReadLine() ?? "Não Informado");
    
    Console.Write("Preço: ");
    decimal preco = decimal.Parse(Console.ReadLine() ?? "Não Informado");

    return new Jogo
    {
        Nome = nome,
        Desenvolvedora = desenvolvedora,
        Genero = genero,
        AnoLancamento = ano,
        Preco = preco
    };
}