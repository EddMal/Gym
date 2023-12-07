
namespace Gym.Web.Data.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope()) 
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();

                try 
                {
                    await Gym.Web.Data.SeedData.SeedData.Init(context, services);
                }
                catch (Exception) 
                {
                    throw new ApplicationException("Seeding init caused error.");
                }
            }

            return app;
            
        }
    }
}
