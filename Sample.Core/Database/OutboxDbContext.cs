using Microsoft.EntityFrameworkCore;
using Sample.Common.Models;

namespace Sample.Core.Database
{
    public class OutboxDbContext : DbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public OutboxDbContext()
        {

        }

        public OutboxDbContext(DbContextOptions<OutboxDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OutboxMessage>()
                .ToTable("OutboxMessage");

        }
    }
}
