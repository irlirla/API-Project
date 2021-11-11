using Services.Models;

namespace Services.Mappers
{
    public class MovieToMovieDTO : IMapper<Movie, MovieDTO>
    {
        public MovieDTO Map(Movie movie)
        {
            if (movie is null)
            {
                return null;
            }
            else
            {
                return new MovieDTO { Name = movie.Name, FranchiseName = movie.FranchiseName.Name };
            }
        }
    }
}
