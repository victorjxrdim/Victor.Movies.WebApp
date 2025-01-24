using System.Data;
using Microsoft.EntityFrameworkCore;
using Victor.Movies.DataAccess.Data.Context;

namespace Victor.Movies.DataAccess.Utils
{
    public class ConnectionClass
    {
        private readonly MoviesDbContext _db;

        public ConnectionClass(MoviesDbContext dbContext)
        {
            _db = dbContext;
        }

        public IDbConnection GetConnection()
        {
            var connection = _db.Database.GetDbConnection();
            connection.Open();
            return connection;
        }
    }
}
