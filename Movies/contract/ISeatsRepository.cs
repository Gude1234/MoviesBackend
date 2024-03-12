using Movies.Models;

namespace Movies.contract
{
    public interface ISeatsRepository: IGenericRespository<seats>
    {
        Task<List<seats>> GetSeatsByRow(string row);
    }
}
