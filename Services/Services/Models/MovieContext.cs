using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Services.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opt) : base(opt)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"server = localhost\SQLEXPRESS; Database = MovieService; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        internal class MovieContextConfig : IEntityTypeConfiguration<Movie>
        {
            public void Configure(EntityTypeBuilder<Movie> builder)
            {
                builder.ToTable("Franchise");
                builder.HasKey();
                builder.HasOne(movie => movie.FranchiseName).WithMany(franchise => franchise.Movies);
            }
        }
    }
}

