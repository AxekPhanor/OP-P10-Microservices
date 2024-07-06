using Gestion_Notes.api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Gestion_Notes.api.Data
{
    public class MongoDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public MongoDbContext(DbContextOptions options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>().ToCollection("notes");
        }
    }
}
