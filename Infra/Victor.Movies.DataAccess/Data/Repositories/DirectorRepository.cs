using Dapper;
using Victor.Movies.DataAccess.Interfaces;
using Victor.Movies.DataAccess.Models;
using Victor.Movies.DataAccess.Utils;

namespace Victor.Movies.DataAccess.Data.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly ConnectionClass _conn;

        public DirectorRepository(ConnectionClass connection)
        {
            _conn = connection;
        }

        public async Task<IEnumerable<Diretor>> GetAllDirectors()
        {
            using (var connection = _conn.GetConnection())
            {
                var builder = new SqlBuilder();

                var query = builder.AddTemplate(@"SELECT * FROM DIRETOR D");

                return await connection.QueryAsync<Diretor>(query.RawSql);
            }
        }

        public async Task<IEnumerable<Diretor>> ListById(int? id)
        {
            using (var connection = _conn.GetConnection())
            {
                var builder = new SqlBuilder();

                var query = builder.AddTemplate(@"SELECT * FROM DIRETOR D /**where**/");

                builder.Where($"D.ID = {id}");

                return await connection.QueryAsync<Diretor>(query.RawSql);
            }
        }
    }
}
