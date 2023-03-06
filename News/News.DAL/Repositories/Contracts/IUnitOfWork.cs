namespace News.DAL.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        INoveltyRepository _noveltyRepository { get; }
        void Commit();
        new void Dispose();
    }
}
