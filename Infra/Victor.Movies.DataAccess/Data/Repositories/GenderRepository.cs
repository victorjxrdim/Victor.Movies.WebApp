using Dapper;
using Victor.Movies.DataAccess.Interfaces;
using Victor.Movies.DataAccess.Models;
using Victor.Movies.DataAccess.Utils;

namespace Victor.Movies.DataAccess.Data.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly ConnectionClass _conn;

        public GenderRepository(ConnectionClass connection)
        {
            _conn = connection;
        }

        public IEnumerable<Genero> ListAllGender()
        {
            using (var connection = _conn.GetConnection())
            {
                var builder = new SqlBuilder();

                var query = builder.AddTemplate(@"SELECT *
                                                FROM GENEROS G");

                return connection.Query<Genero>(query.RawSql);
            }
        }
    }
}
