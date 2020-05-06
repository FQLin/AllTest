using Demo1.Framework.Core;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Framework.Repository
{
    public class Demo1Context:DbContext
    {
        public Demo1Context(DbContextOptions<Demo1Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Demo1Context).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<tbl_Demo1> Demo1 { get; set; }
    }
}
