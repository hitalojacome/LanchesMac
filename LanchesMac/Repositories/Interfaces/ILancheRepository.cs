using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        // Coleção de todos os lanches
        IEnumerable<Lanche> Lanches { get; }

        // Coleção dos lanches preferidos
        IEnumerable<Lanche> LanchesPreferidos { get; }

        // Retorna um objeto do tipo lanche pelo ID
        Lanche GetLancheById(int lancgId);
    }
}
