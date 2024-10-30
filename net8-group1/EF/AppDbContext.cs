using System.Text.RegularExpressions;
using EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace EF
{
    /// <summary>
    /// Sample:
    ///  dotnet ef dbcontext scaffold "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\cursos\\net8-samples\\net8-group1\\EF\\db1.mdf;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer
    ///
    /// Generate SQL from Entities:
    ///  dotnet ef dbcontext script -o create-database.sql
    /// </summary>
    public class AppDbContext: DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<User> User { get; set; }

        // More tables here....

        public static string ConnectionString()
        {
            //var cm = new ConfigurationManager();
            //var connectionString = cm["DB_Connection"] ?? "";
            //return connectionString;

            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\cursos\\net8-samples\\net8-group1\\EF\\db1.mdf;Integrated Security=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder
           .UseSqlServer(ConnectionString())
           .EnableSensitiveDataLogging()     // for development only
           // .LogTo(Console.WriteLine)
           ;


        /// <summary>
        /// * Provide predefined data
        /// * Setup conversion for WineType (enum)
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                        .HasIndex(p => p.Name);

            modelBuilder.Entity<Pizza>()
                        .HasMany<Ingredient>(p => p.Ingredients).WithOne(p => p.Pizza);
                        
            modelBuilder.Entity<Ingredient>();

            modelBuilder.Entity<User>();


            //modelBuilder.Entity<Pizza>().HasData(
            //    new Pizza() { Id = 1, Name = "Carbonara", Description = "Carbonara", Price = 10 },
            //    new Pizza() { Id = 2, Name = "5 Cheesee", Description = "Five cheeses", Price = 12 },
            //    new Pizza() { Id = 3, Name = "Tuna", Description = "Tuna & onion", Price = 8.5M }
            //);
        }
    }


    // database schema  version             Migrations   -> sql
    // v0
    // v1   1 table pizza                   add table pizza / undo delete table
    // v2   2 table  ingredients            
    // v3   3 ...
}
