using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class PushUpFullStackContext : DbContext
    {
        public PushUpFullStackContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<MethodPayment> MethodPayment { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRol> UserRol { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}