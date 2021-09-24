using CarDealership.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<BodyStyle> BodyStyles { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<InteriorColor> InteriorColors { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseType> PurchaseTypes { get; set; }
        public DbSet<Special> Specials { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        //public DbSet<IdentityUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Make>().Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Model>().Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Purchase>().Property(x => x.PurchaseDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Vehicle>().Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Purchase>().HasOne(p => p.User);

            modelBuilder.Entity<State>().HasKey(c => c.Id);
            modelBuilder.Entity<State>().Property(s => s.Name).HasMaxLength(30);

            //seed Makes
            modelBuilder.Entity<Make>().HasData(new Make { Id = 1, Name = "Acura" });
            modelBuilder.Entity<Make>().HasData(new Make { Id = 2, Name = "Jaguar" });
            modelBuilder.Entity<Make>().HasData(new Make { Id = 3, Name = "GMC" });
            modelBuilder.Entity<Make>().HasData(new Make { Id = 4, Name = "Chrysler" });
            modelBuilder.Entity<Make>().HasData(new Make { Id = 5, Name = "Hyundai" });

            //seed Models
            modelBuilder.Entity<Model>().HasData(new Model { Id = 1, Name = "NSX", MakeId = 1 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 2, Name = "Vandura 3500", MakeId = 2 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 3, Name = "Acadia", MakeId = 3 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 4, Name = "RDX", MakeId = 1 });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 5, Name = "NSX", MakeId = 1 });

            //seed BodyStyles
            modelBuilder.Entity<BodyStyle>().HasData(new BodyStyle { Id = 1, Name = "Car" });
            modelBuilder.Entity<BodyStyle>().HasData(new BodyStyle { Id = 2, Name = "Truck" });
            modelBuilder.Entity<BodyStyle>().HasData(new BodyStyle { Id = 3, Name = "SUV" });

            //seed Colors
            modelBuilder.Entity<Color>().HasData(new Color { Id = 1, Name = "Blue" });
            modelBuilder.Entity<Color>().HasData(new Color { Id = 2, Name = "Yellow" });
            modelBuilder.Entity<Color>().HasData(new Color { Id = 3, Name = "Black" });
            modelBuilder.Entity<Color>().HasData(new Color { Id = 4, Name = "Red" });
            modelBuilder.Entity<Color>().HasData(new Color { Id = 5, Name = "Silver" });

            //seed Interior Colors
            modelBuilder.Entity<InteriorColor>().HasData(new InteriorColor { Id = 1, Name = "Blue" });
            modelBuilder.Entity<InteriorColor>().HasData(new InteriorColor { Id = 2, Name = "Grey" });
            modelBuilder.Entity<InteriorColor>().HasData(new InteriorColor { Id = 3, Name = "Black" });
            modelBuilder.Entity<InteriorColor>().HasData(new InteriorColor { Id = 4, Name = "Red" });
            modelBuilder.Entity<InteriorColor>().HasData(new InteriorColor { Id = 5, Name = "Silver" });

            //seed Purchase Types
            modelBuilder.Entity<PurchaseType>().HasData(new PurchaseType { Id = 1, Name = "Bank Finance" });
            modelBuilder.Entity<PurchaseType>().HasData(new PurchaseType { Id = 2, Name = "Cash" });
            modelBuilder.Entity<PurchaseType>().HasData(new PurchaseType { Id = 3, Name = "Dealer Finance" });

            //seed Specials
            modelBuilder.Entity<Special>().HasData(new Special { Id = 1, Title = "New Year'savings", Description = "Decentralized global open system" });
            modelBuilder.Entity<Special>().HasData(new Special { Id = 2, Title = "Presidents Day Special", Description = "Presidents Day Special" });

            //insert Condition
            modelBuilder.Entity<Condition>().HasData(new Condition { Id = 1, Name = "New" });
            modelBuilder.Entity<Condition>().HasData(new Condition { Id = 2, Name = "Used" });
            modelBuilder.Entity<Condition>().HasData(new Condition { Id = 3, Name = "Certified Used" });

            //insert Transmission
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = 1, Name = "Automatic" });
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = 2, Name = "Manual" });

            //insert states
            modelBuilder.Entity<State>().HasData(new State { Id = "NM", Name = "New Mexico" });
            modelBuilder.Entity<State>().HasData(new State { Id = "TX", Name = "Texas" });
            modelBuilder.Entity<State>().HasData(new State { Id = "CA", Name = "California" });
            modelBuilder.Entity<State>().HasData(new State { Id = "DC", Name = "District of Columbia" });
            modelBuilder.Entity<State>().HasData(new State { Id = "FL", Name = "Florida" });
            modelBuilder.Entity<State>().HasData(new State { Id = "GA", Name = "Georgia" });

        }
    }
}
