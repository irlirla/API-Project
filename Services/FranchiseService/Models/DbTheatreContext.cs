using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace FranchiseService.Models
{
    internal class DbTheatreContext : DbContext
    {
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"server = localhost\SQLEXPRESS; Database = Theatre; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        internal class MovieContextConfig : IEntityTypeConfiguration<Franchise>
        {
            public void Configure(EntityTypeBuilder<Franchise> builder)
            {
                builder.ToTable("Franchise");
                builder.HasKey(x => x.FranchiseID);
                builder.HasMany(x => x.Movies).WithOne(x => x.FranchiseName);
            }
        }
    }
}
