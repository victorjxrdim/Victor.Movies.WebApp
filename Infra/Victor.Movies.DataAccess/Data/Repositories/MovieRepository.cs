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
       
        public async Task<IEnumerable<CompleteMovieDTO>> ListMovieInformations(int? id = null)
        {
            using (var connection = _conn.GetConnection())
            {
                var builder = new SqlBuilder();

                var query = builder.AddTemplate(@"SELECT 
                                                  F.MOVIE_ID as MovieId, F.MOVIE_NAME as MovieName, F.MOVIE_YEAR as MovieYear, F.MOVIE_IMG as MovieImg, G.GENDER as Gender, D.NOME as Nome, 
                                                  F.DESCRIPTION as Description, F.TRAILER as Trailer
                                                  FROM FILMES F /**innerjoin**/ /**where**/");

                builder.InnerJoin($"DIRETOR D ON D.ID = F.MOVIE_DIRECTOR");
                builder.InnerJoin($"GENEROS G ON G.GENDER_ID = F.GENDER_ID");

                if(id != null)
                {
                    builder.Where($"F.MOVIE_ID = {id}");
                }

                return await connection.QueryAsync<CompleteMovieDTO>(query.RawSql);
            }
        }

        public async Task<IEnumerable<CompleteMovieDTO>> MovieFilter(string? gender = null, string? director = null, string? movie = null, int? year = null)
        {
            using (var connection = _conn.GetConnection())
            {
                var builder = new SqlBuilder();

                var query = builder.AddTemplate(@"SELECT 
                                                  F.MOVIE_ID as MovieId, F.MOVIE_NAME as MovieName, F.MOVIE_YEAR as MovieYear, F.MOVIE_IMG as MovieImg, G.GENDER as Gender, D.NOME as Nome, 
                                                  F.DESCRIPTION as Description, F.TRAILER as Trailer
                                                  FROM FILMES F /**innerjoin**/ /**where**/");

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

                return await connection.QueryAsync<CompleteMovieDTO>(query.RawSql);
            }
        }
    }
}
