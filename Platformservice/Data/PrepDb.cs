using Platformservice.Models;

namespace Platformservice.Data;
public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using(var serviceScope=app.ApplicationServices.CreateScope())
        {
            
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }
    private static void SeedData(AppDbContext context)
    {
        if(!context.Platforms.Any())
        {
            Console.WriteLine("seeding data");
            context.Platforms.AddRange(
                new Platform
                {
                    Id = 1,
                    Name = "Dot net",
                    Publisher = "MS",
                    Cost = "free"
                },
                new Platform
                {
                    Id = 2,
                    Name = "SQL",
                    Publisher = "MS",
                    Cost = "free"
                },
                new Platform
                {
                    Id = 3,
                    Name = "K8s",
                    Publisher = "Cloud Native",
                    Cost = "free"
                }
            );
            context.SaveChanges();
        }
        else {
            Console.WriteLine("we already have data");
        }
    }
}