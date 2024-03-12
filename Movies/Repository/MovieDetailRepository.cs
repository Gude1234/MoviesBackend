using Movies.contract;
using Movies.Data;
using Movies.Models;

namespace Movies.Repository
{
    public class MovieDetailRepository: GenericRepository<MovieDetail>, IMovieDetailRepository
    {
        public MovieDetailRepository(ApplicationDbContext context): base(context)
        {
            
        }
    }
}
