using Dapper;
using Victor.Movies.DataAccess.DTOs;
using Victor.Movies.DataAccess.Interfaces;
using Victor.Movies.DataAccess.Models;
using Victor.Movies.DataAccess.Utils;

namespace Victor.Movies.DataAccess.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ConnectionClass _conn;

        public MovieRepository(ConnectionClass connection)
        {
            _conn = connection;
        }
        public IEnumerable<Filme> GetAllMovies()
        {
            using (var connection = _conn.GetConnection())
            {
                var builder = new SqlBuilder();

                var query = builder.AddTemplate(@"SELECT 
                                                    F.MOVIE_ID AS MovieId, 
                                                    F.MOVIE_NAME AS MovieName, 
                                                    F.MOVIE_YEAR AS MovieYear, 
                                                    F.MOVIE_DIRECTOR AS MovieDirector, 
                                                    F.MOVIE_IMG AS MovieImg, 
                                                    F.GENDER_ID AS GenderId  
                                                FROM FILMES F");

                return connection.Query<Filme>(query.RawSql);
            }
        }

        public IEnumerable<CompleteMovieDTO> ListMovieInformations()
        {
            using (var connection = _conn.GetConnection())
            {
                var builder = new SqlBuilder();

                var query = builder.AddTemplate(@"SELECT 
                                                  F.MOVIE_ID as MovieId, F.MOVIE_NAME as MovieName, F.MOVIE_YEAR as MovieYear, F.MOVIE_IMG as MovieImg, G.GENDER as Gender, D.NOME as Nome
                                                  FROM FILMES F /**innerjoin**/");

                builder.InnerJoin($"DIRETOR D ON D.ID = F.MOVIE_DIRECTOR");
                builder.InnerJoin($"GENEROS G ON G.GENDER_ID = F.GENDER_ID");

                return connection.Query<CompleteMovieDTO>(query.RawSql);
            }
        }

        public IEnumerable<CompleteMovieDTO> MovieFilter(string? gender = null, string? director = null, string? movie = null, int? year = null)
        {
            using (var connection = _conn.GetConnection())
            {
                var builder = new SqlBuilder();

                var query = builder.AddTemplate(@"SELECT 
                                                  F.MOVIE_ID as MovieId, F.MOVIE_NAME as MovieName, F.MOVIE_YEAR as MovieYear, F.MOVIE_IMG as MovieImg, G.GENDER as Gender, D.NOME as Nome
                                                  FROM FILMES F /**innerjoin**/");

                builder.InnerJoin($"DIRETOR D ON D.ID = F.MOVIE_DIRECTOR");
                builder.InnerJoin($"GENEROS G ON G.GENDER_ID = F.GENDER_ID");

                if (!String.IsNullOrEmpty(gender))
                {
                    builder.Where($"G.GENDER = {gender}");
                }

                if (!String.IsNullOrEmpty(director))
                {
                    builder.Where($"D.NOME = {director}");
                }

                if (!String.IsNullOrEmpty(movie))
                {
                    builder.Where($"F.MOVIE_NAME = {movie}");
                }

                if(year != null)
                {
                    builder.Where($"F.MOVIE_YEAR = {year}");
                }

                return connection.Query<CompleteMovieDTO>(query.RawSql);
            }
        }
    }
}
