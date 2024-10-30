using System;
using System.Collections.Generic;
using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF
{

    /*
     SQL from entities:
        dotnet ef dbcontext script -o create-db.sql

      Creatre dbcontext & entities
         dotnet ef dbcontext scaffold "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\cursos\\net8-samples\\net8-group2\\EF\\db1.mdf;Integrated Security=True" M
icrosoft.EntityFrameworkCore.SqlServer


        1. To create a MIGRATION:
                dotnet ef migrations add <NAME>
        2. wHAT MIGRATIONS DO WE HAVE?
                dotnet ef migrations list

     */
    public partial class AppDbContext : DbContext
    {
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Ingredient> Ingridents { get; set; }
        public virtual DbSet<User> Users { get; set; }

        // one line per table 


        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public static string ConnectionString() =>

            //  /d/cursos/net8-samples/net8-group2/EF
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\cursos\\net8-samples\\net8-group2\\EF\\db1.mdf;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder
               .UseSqlServer(ConnectionString())
               .EnableSensitiveDataLogging()     // for development only
                                                 // .LogTo(Console.WriteLine)
               ;


        // fluent API

        /// <summary>
        /// * Provide predefined data
        /// * Setup conversion for WineType (enum)
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasIndex(p => p.Name);

            // Relational model
            // Pizza  ----------------     Ingrednet
            //            <---        PizzaId FK

            // UML
            modelBuilder.Entity<Pizza>()                //  Pizza 1:1-------------0:* Ingredient
                .HasMany<Ingredient>()            //        Pizza       Ingredients
                .WithOne()
                .HasForeignKey(i => i.PizzaId);


            modelBuilder.Entity<Ingredient>();

            modelBuilder.Entity<User>();


            //modelBuilder.Entity<Pizza>().HasData(
            //    new Pizza() { Id = 1, Name = "Carbonara", Description = "Carbonara", Price = 10 },
            //    new Pizza() { Id = 2, Name = "5 Cheesee", Description = "Five cheeses", Price = 12 },
            //    new Pizza() { Id = 3, Name = "Tuna", Description = "Tuna & onion", Price = 8.5M }
            //);
        }
    }

}
