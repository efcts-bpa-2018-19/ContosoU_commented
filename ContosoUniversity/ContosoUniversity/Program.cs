using ContosoUniversity.Models;                   // SchoolContext
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;   // CreateScope
using Microsoft.Extensions.Logging;
using System;

namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    context.Database.EnsureCreated();
                    //EnsureCreated ensures that the database for the context exists. If it exists, no action is taken. 
                    //If it does not exist, then the database and all its schema are created. 
                    //EnsureCreated does not use migrations to create the database. 
                    //A database that is created with EnsureCreated cannot be later updated using migrations.
                    //
                    //EnsureCreated is called on app start, which allows the following work flow:
                    //
                    //Delete the DB.
                    //Change the DB schema(for example, add an EmailAddress field).
                    //Run the app.
                    //EnsureCreated creates a DB with theEmailAddress column.
                    //
                    //EnsureCreated is convenient early in development when the schema is rapidly evolving. 
                    //Later in the tutorial the DB is deleted and migrations are used.


                    //Delete any student records and restart the app. If the DB is not initialized, set a break point in Initialize to diagnose the problem.
                    // using ContosoUniversity.Data; 
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
