using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Get the base path where the API project is located (this is important for accessing the config files)
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../api");  // This assumes the command is run from the API project root

            // Set up configuration from appsettings.json in the API project
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)  // Ensure we point to the right folder for the config
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            // Retrieve the connection string from the configuration
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Set up the DbContext with the connection string
            optionsBuilder.UseSqlite(connectionString);  // Or your database provider


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

