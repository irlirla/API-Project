using Microsoft.EntityFrameworkCore;
using Services.Models;
using Services.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class MovieRepo : IAsyncRepository<Movie>
    {
        private readonly IMovieValidator _validator;
        DbTheatreContext Theatre = new();
        const string str1 = "Success!";
        const string str2 = "Something went wrong!";

        public MovieRepo(IMovieValidator validator)
        {
            _validator = validator;
        }

        public async Task<string> Delete(int id)
        {
            var movie = await Theatre.Movies.SingleAsync(x => x.ID == id);
            Theatre.Remove(movie);
            await Theatre.SaveChangesAsync();
            return str1;
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            IAsyncEnumerable<Movie> movies = Theatre.Movies.AsAsyncEnumerable();
            List<Movie> movies1 = await movies.ToListAsync();
            return movies1;
        }

        public async Task<Movie> GetById(int id)
        {
            IAsyncEnumerable<Movie> movies = Theatre.Movies.AsAsyncEnumerable().Where(x => x.ID == id);
            List<Movie> movies1 = await movies.ToListAsync();
            return movies1[0];
        }

        public async Task<string> Post(Movie movie)
        {
            if (_validator.Validate(movie).IsValid &&
                await Theatre.Movies.AnyAsync(x => x.ID == movie.ID) is false)
            {
                await Theatre.Movies.AddAsync(new Movie());
                await Theatre.SaveChangesAsync();
                return str1;
            }
            else
            {
                return str2;
            }
        }

        public async Task<string> Put(Movie movie)
        {
            if (_validator.Validate(movie).IsValid)
            {
                await Theatre.Movies.AddAsync(new Movie());
                await Theatre.SaveChangesAsync();
                return str1;
            }
            else
            {
                return str2;
            }
        }
    }
}
