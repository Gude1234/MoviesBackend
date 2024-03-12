using Microsoft.EntityFrameworkCore;
using Movies.contract;
using Movies.Data;
using Movies.Models;

namespace Movies.Repository
{
    public class SeatsRepository: GenericRepository<seats>, ISeatsRepository
    {
        private readonly ApplicationDbContext _context;

        public SeatsRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<List<seats>> GetSeatsByRow(string row)
        {
            return await _context.seats.Where(s => s.Row == row).ToListAsync();
        }
    }
}
