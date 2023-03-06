using News.DAL.Entities;

namespace News.DAL.Repositories.Contracts
{
    public interface INoveltyRepository : IGenericRepository<Novelty>
    {
        Task<IEnumerable<Novelty>> TopFiveNoveltyAsync();
    }
}
