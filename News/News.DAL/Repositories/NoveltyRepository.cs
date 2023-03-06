using Dapper;
using News.DAL.Entities;
using News.DAL.Repositories.Contracts;
using System.Data.SqlClient;
using System.Data;

namespace News.DAL.Repositories
{
    public class NoveltyRepository : GenericRepository<Novelty>, INoveltyRepository
    {
        public NoveltyRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "News.Novelty")
        {
        }

        public async Task<IEnumerable<Novelty>> TopFiveNoveltyAsync()
        {
            string sql = @"SELECT TOP 5 * FROM News.Novelty";
            var results = await _sqlConnection.QueryAsync<Novelty>(sql,
                transaction: _dbTransaction);
            return results;
        }
    }
}
