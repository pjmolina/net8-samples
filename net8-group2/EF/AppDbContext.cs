using System;
using System.Collections.Generic;
using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public partial class AppDbContext : DbContext
    {
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Ingredient> Ingridents { get; set; }

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
                .WithOne(i => i.Pizza)
                .HasForeignKey(i => i.PizzaId);


            modelBuilder.Entity<Ingredient>();

            //modelBuilder.Entity<Pizza>().HasData(
            //    new Pizza() { Id = 1, Name = "Carbonara", Description = "Carbonara", Price = 10 },
            //    new Pizza() { Id = 2, Name = "5 Cheesee", Description = "Five cheeses", Price = 12 },
            //    new Pizza() { Id = 3, Name = "Tuna", Description = "Tuna & onion", Price = 8.5M }
            //);
        }
    }

}
