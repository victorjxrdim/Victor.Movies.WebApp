using Microsoft.EntityFrameworkCore;
using Victor.Movies.DataAccess.Data.Context;

namespace Victor.Movies.WebApp.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplicationBuilder ConfigureDbContext(this WebApplicationBuilder builder)
        {
            var connecString = builder.Configuration.GetConnectionString("mySqlConnec");

            builder.Services.AddDbContext<MoviesDbContext>(options =>
            {
                options.UseMySql(connecString, ServerVersion.AutoDetect(connecString));
            });

            return builder;
        }
    }
}
