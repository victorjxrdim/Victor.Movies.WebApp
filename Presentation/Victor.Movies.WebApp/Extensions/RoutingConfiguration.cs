namespace Victor.Movies.WebApp.Extensions
{
    public static class RoutingConfiguration
    {
        public static WebApplication ConfigureRouting(this WebApplication application)
        {
            if (!application.Environment.IsDevelopment())
            {
                application.UseExceptionHandler("/Error");
                application.UseHsts();
            }

            application.UseHttpsRedirection();
            application.UseStaticFiles();
            application.UseRouting();
            application.UseAuthorization();

            application.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            application.MapControllers();

            application.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/Home/Index");
                    return;
                }
                await next();
            });

            return application;
        }
    }
}
