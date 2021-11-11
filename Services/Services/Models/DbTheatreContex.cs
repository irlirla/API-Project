using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Services.Models
{
    internal class DbTheatreContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        //public DbSet<Franchise> Franchises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"server = localhost\SQLEXPRESS; Database = Theatre; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        internal class MovieContextConfig : IEntityTypeConfiguration<Movie>
        {
            public void Configure(EntityTypeBuilder<Movie> builder)
            {
                builder.ToTable("Movie");
                builder.HasKey(x => x.ID);
                builder.HasOne(x => x.FranchiseName).WithMany(x => x.Movies);
            }
        }
    }
}
