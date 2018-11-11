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

                var exercise = new Exercise() { Name = "Arnoldki", Description = "Ćwiczenie na barki" };

                var userExercise = new UserExercise();

                userExercise.Exercise = exercise;
                userExercise.User = user;

                user.UserExercises.Add(userExercise);

                dbContext.Exercises.Add(exercise);
                dbContext.SaveChanges();

                Console.WriteLine(result.Result.Succeeded);
            }

        }
    }
}
