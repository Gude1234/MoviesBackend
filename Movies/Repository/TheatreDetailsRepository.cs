using Movies.contract;
using Movies.Data;
using Movies.Models;

namespace Movies.Repository
{
    public class TheatreDetailsRepository: GenericRepository<TheatreDetails>, ITheatreDetailsRepository
    {
        public TheatreDetailsRepository(ApplicationDbContext context): base(context)
        {
            
        }
    }
}
