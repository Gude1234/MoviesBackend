using Movies.contract;
using Movies.Data;
using Movies.Models;

namespace Movies.Repository
{
    public class CouponRepository: GenericRepository<coupons>, ICouponRepository
    {
        public CouponRepository(ApplicationDbContext context): base(context)
        {
            
        }
    }
}
