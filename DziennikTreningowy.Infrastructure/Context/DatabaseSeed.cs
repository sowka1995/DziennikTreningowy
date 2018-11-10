using DziennikTreningowy.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DziennikTreningowy.Infrastructure.Context
{
    public class DatabaseSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<WorkoutDiaryDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            dbContext.Database.EnsureCreated();

            if (!dbContext.Users.Any()) 
            {
                User user = new User()
                {
                    // Required minimum
                    Email = "arnold@workout.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "arnold@workout.com",

                    // Additional
                    FirstName = "Arnold",
                    LastName = "Schwarzenegger"
                };

                var result = userManager.CreateAsync(user, "Arnold1234!");
                result.Wait();
                Console.WriteLine(result.Result.Succeeded);
            }

        }
    }
}
