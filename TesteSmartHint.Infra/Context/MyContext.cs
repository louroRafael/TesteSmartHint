using Microsoft.EntityFrameworkCore;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Infra.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(Microsoft.EntityFrameworkCore.DbContextOptions<MyContext> options) : base(options) 
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Config> Configs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
