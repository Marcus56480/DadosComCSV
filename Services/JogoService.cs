using DadosComCSV.Models;
using DadosComCSV.Repositories;

namespace DadosComCSV.Services
{
    public class JogoService
    {
        private readonly JogoRepository? _repository;

        public JogoService(JogoRepository repository)
        {
            _repository = repository;
        }

        public List<Jogo> Listar()
        {
            return _repository.Listar();
        }
    } 
}