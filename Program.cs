using System;
using System.Threading.Tasks;
using ClassManagementSystem.Controllers;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ClassManagementSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var environment = services.GetService<IHostingEnvironment>();
                if (environment.IsDevelopment())
                {
                    try
                    {
                        var db = services.GetRequiredService<CrmsContext>();
                        var school = await db.Schools.AddAsync(new School
                        {
                            City = "厦门",
                            Name = "厦门市人民公园",
                            Province = "福建"
                        });

                        await db.SaveChangesAsync();

                        await db.Users.AddAsync(new User(0)
                        {
                            Avatar = "/upload/avatar/Logo_Li.png",
                            Email = "t@t.test",
                            Gender = User.GenderType.Male,
                            Name = "张三",
                            Number = "123456",
                            Password = Utils.HashString("123"),
                            Phone = "1234",
                            School = await db.Schools.FindAsync(school.Entity.Id),
                            Title = "大一",
                            Type = User.UserType.Student
                        });

                        await db.Users.AddAsync(new User(0)
                        {
                            Avatar = "/upload/avatar/Logo_Li.png",
                            Email = "t2@t.test",
                            Gender = User.GenderType.Male,
                            Name = "李四",
                            Number = "134254",
                            Password = Utils.HashString("456"),
                            Phone = "123",
                            School = await db.Schools.FindAsync(school.Entity.Id),
                            Title = "教授",
                            Type = User.UserType.Teacher
                        });

                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while seeding the database.");
                    }
                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}