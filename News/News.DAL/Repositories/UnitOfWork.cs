using News.DAL.Repositories.Contracts;
using System.Data;

namespace News.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public INoveltyRepository _noveltyRepository { get; }
        readonly IDbTransaction _dbTransaction;

        public UnitOfWork(
            INoveltyRepository noveltyRepository,
            IDbTransaction dbTransaction)
        {
            _noveltyRepository = noveltyRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                // By adding this we can have muliple transactions as part of a single request
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}
