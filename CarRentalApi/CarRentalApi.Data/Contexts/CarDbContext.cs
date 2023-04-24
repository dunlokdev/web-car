using CarRentalApi.Core.Entities;
using CarRentalApi.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CarRentalApi.Data.Contexts
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Galery> Galeries { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public CarDbContext ()
        {
        }


        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModelMap).Assembly);
        }
    }
}
