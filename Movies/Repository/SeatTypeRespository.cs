using Movies.contract;
using Movies.Data;
using Movies.Models;

namespace Movies.Repository
{
    public class SeatTypeRespository: GenericRepository<SeatType>, ISeatTypeRespository
    {
        public SeatTypeRespository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
