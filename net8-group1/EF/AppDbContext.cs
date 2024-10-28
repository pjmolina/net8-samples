using EF.Models;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class AppDbContext: DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        public static string ConnectionString()
        {
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\cursos\\net8\\EF\\db1.mdf;Integrated Security=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder
           .UseSqlServer(ConnectionString()) 
           .EnableSensitiveDataLogging()     // for development only
           .LogTo(Console.WriteLine)
           ;


        /// <summary>
        /// * Provide predefined data
        /// * Setup conversion for WineType (enum)
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Pizza>();


            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { Id = 1, Name = "Carbonara", Description = "Carbonara", Price = 10 },
                new Pizza() { Id = 2, Name = "5 Cheesee", Description = "Five cheeses", Price = 12 },
                new Pizza() { Id = 3, Name = "Tuna", Description = "Tuna & onion", Price = 8.5M }
            );
        }
    }

}
