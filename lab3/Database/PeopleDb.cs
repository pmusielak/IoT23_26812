using lab3.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab3.Database
{
    public class PeopleDb: DbContext
    {
        public PeopleDb(DbContextOptions<PeopleDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePersonEntity(modelBuilder.Entity<Person>());
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigurePersonEntity(EntityTypeBuilder<Person> entity)
        {
            entity.ToTable("Person");
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(200);
        }

        public DbSet<Person> People {get; set;}
    }
}